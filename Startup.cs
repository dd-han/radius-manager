using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RadiusManager.Models;
using RadiusManager.Services;

namespace RadiusManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region Set up Database

        private bool IsMySQL()
        {
            return "MySQL".Equals(Configuration.GetValue("DatabaseEngine", ""));
        }

        private bool IsSqlServer()
        {
            return "SqlServer".Equals(Configuration.GetValue("DatabaseEngine", ""));
        }

        private bool IsSqlite()
        {
            return "Sqlite".Equals(Configuration.GetValue("DatabaseEngine", ""));
        }

        private string ConnectionString()
        {
            return Configuration.GetConnectionString("DefaultConnection");
        }

        private void SetupDbContextOptions(DbContextOptionsBuilder options)
        {
            if (IsSqlite())
            {
                options.UseSqlite(ConnectionString());
            }
            else if (IsSqlServer())
            {
                options.UseSqlServer(ConnectionString());
            }
            else if (IsMySQL())
            {
                options.UseMySql(ConnectionString());
            }
            else
            {
                options.UseInMemoryDatabase(databaseName: "CargoCMS_DB");
            }
        }

        #endregion

        private T GetIdentityConfig<T>(string key)
        {
            return Configuration.GetValue<T>($"Identity.{key}");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<DatabaseContext>(options => SetupDbContextOptions(options));

            services.AddDefaultIdentity<IdentityUser>(options => {
                options.Password.RequireDigit = GetIdentityConfig<bool>("RequireDigit");
                options.Password.RequireLowercase = GetIdentityConfig<bool>("RequireLowercase");
                options.Password.RequireNonAlphanumeric = GetIdentityConfig<bool>("RequireNonAlphanumeric");
                options.Password.RequireUppercase = GetIdentityConfig<bool>("RequireUppercase");
                options.Password.RequiredLength = GetIdentityConfig<int>("RequiredLength");
                options.Password.RequiredUniqueChars = GetIdentityConfig<int>("RequiredUniqueChars");;
            })
            .AddEntityFrameworkStores<DatabaseContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
