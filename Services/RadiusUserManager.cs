using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RadiusManager.Models;

namespace RadiusManager.Services {
    public class RadiusUserManager : UserManager<IdentityUser>
    {
        private static DatabaseContext _context;
        public RadiusUserManager(
            DatabaseContext context,
            IUserStore<IdentityUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<IdentityUser> passwordHasher,
            IEnumerable<IUserValidator<IdentityUser>> userValidators,
            IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<IdentityUser>> logger): 
            base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _context = context;
        }

        public override async Task<IdentityResult> CreateAsync(IdentityUser user, String password) {
            var identityCreate = await base.CreateAsync(user, password);

            if (identityCreate.Succeeded) {
                _context.Add(new RadCheck{
                    Username = user.UserName,
                    Attribute = "Cleartext-Password",
                    Op = ":=",
                    Value = password
                });
                var radCreate = await _context.SaveChangesAsync();
            }

            return identityCreate;
        }

        public override async Task<IdentityResult> ChangePasswordAsync(IdentityUser user, String currentPassword, String newPassword) {
            var identityUpdate = await base.ChangePasswordAsync(user, currentPassword, newPassword);

            if (identityUpdate.Succeeded) {
                var radUser = _context.RadCheck.First(r => r.Username == user.UserName);
                radUser.Value = newPassword;
                _context.Update(radUser);
                await _context.SaveChangesAsync();
            }

            return identityUpdate;
        }

        public override async Task<IdentityResult> ResetPasswordAsync(IdentityUser user, String token, String newPassword) {
            var identityReset = await base.ResetPasswordAsync(user, token, newPassword);

            if (identityReset.Succeeded) {
                var radUser = _context.RadCheck.First(r => r.Username == user.UserName);
                radUser.Value = newPassword;
                _context.Update(radUser);
                await _context.SaveChangesAsync();
            }

            return identityReset;
        }

    }

}