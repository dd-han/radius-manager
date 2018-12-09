using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RadiusManager.Models
{
    public partial class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DatabaseContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public virtual DbSet<Nas> Nas { get; set; }
        public virtual DbSet<RadAcct> Radacct { get; set; }
        public virtual DbSet<RadCheck> Radcheck { get; set; }
        public virtual DbSet<RadGroupCheck> Radgroupcheck { get; set; }
        public virtual DbSet<RadGroupReply> Radgroupreply { get; set; }
        public virtual DbSet<RadPostAuth> Radpostauth { get; set; }
        public virtual DbSet<RadReply> RadReply { get; set; }
        public virtual DbSet<RadUserGroup> Radusergroup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(36);
                entity.Property(m => m.Email)
                      .HasMaxLength(127);
                entity.Property(m => m.NormalizedEmail)
                      .HasMaxLength(127);
                entity.Property(m => m.UserName)
                      .HasMaxLength(127);
                entity.Property(m => m.NormalizedUserName)
                      .HasMaxLength(127);
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(36);
                entity.Property(e => e.Name)
                    .HasMaxLength(127);
                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(127);
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(127);
                entity.Property(e => e.ProviderKey)
                    .HasMaxLength(127);
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(127);
                entity.Property(e => e.Name)
                    .HasMaxLength(127);
            });

            modelBuilder.Entity<Nas>(entity =>
            {
                entity.ToTable("nas");

                entity.HasIndex(e => e.NasName)
                    .HasName("nasname");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(10);

                entity.Property(e => e.Community)
                    .HasColumnName("community")
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .HasDefaultValueSql("'RADIUS Client'");

                entity.Property(e => e.NasName)
                    .IsRequired()
                    .HasColumnName("nasname")
                    .HasMaxLength(128);

                entity.Property(e => e.Ports)
                    .HasColumnName("ports")
                    .HasMaxLength(5);

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnName("secret")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'secret'");

                entity.Property(e => e.Server)
                    .HasColumnName("server")
                    .HasMaxLength(64);

                entity.Property(e => e.ShortName)
                    .HasColumnName("shortname")
                    .HasMaxLength(32);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'other'");
            });

            modelBuilder.Entity<RadAcct>(entity =>
            {
                entity.ToTable("radacct");

                entity.HasIndex(e => e.AcctInterval)
                    .HasName("acctinterval");

                entity.HasIndex(e => e.AcctSessionId)
                    .HasName("acctsessionid");

                entity.HasIndex(e => e.AcctSessionTime)
                    .HasName("acctsessiontime");

                entity.HasIndex(e => e.AcctStartTime)
                    .HasName("acctstarttime");

                entity.HasIndex(e => e.AcctStopTime)
                    .HasName("acctstoptime");

                entity.HasIndex(e => e.AcctUniqueId)
                    .HasName("acctuniqueid")
                    .IsUnique();

                entity.HasIndex(e => e.FramedIpAddress)
                    .HasName("framedipaddress");

                entity.HasIndex(e => e.NasIpAddress)
                    .HasName("nasipaddress");

                entity.HasIndex(e => e.Username)
                    .HasName("username");

                entity.Property(e => e.RadAcctId)
                    .HasColumnName("radacctid")
                    .HasMaxLength(21);

                entity.Property(e => e.AcctAuthentic)
                    .HasColumnName("acctauthentic")
                    .HasMaxLength(32);

                entity.Property(e => e.AcctInputOctets)
                    .HasColumnName("acctinputoctets")
                    .HasMaxLength(20);

                entity.Property(e => e.AcctInterval)
                    .HasColumnName("acctinterval")
                    .HasMaxLength(12);

                entity.Property(e => e.AcctOutputOctets)
                    .HasColumnName("acctoutputoctets")
                    .HasMaxLength(20);

                entity.Property(e => e.AcctSessionId)
                    .IsRequired()
                    .HasColumnName("acctsessionid")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AcctSessionTime).HasColumnName("acctsessiontime");

                entity.Property(e => e.AcctStartTime)
                    .HasColumnName("acctstarttime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AcctStopTime)
                    .HasColumnName("acctstoptime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AcctTerminateCause)
                    .IsRequired()
                    .HasColumnName("acctterminatecause")
                    .HasMaxLength(32)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AcctUniqueId)
                    .IsRequired()
                    .HasColumnName("acctuniqueid")
                    .HasMaxLength(32)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AcctUpdateTime)
                    .HasColumnName("acctupdatetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CalledStationId)
                    .IsRequired()
                    .HasColumnName("calledstationid")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CallingStationId)
                    .IsRequired()
                    .HasColumnName("callingstationid")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ConnectInfoStart)
                    .HasColumnName("connectinfo_start")
                    .HasMaxLength(50);

                entity.Property(e => e.ConnectInfoStop)
                    .HasColumnName("connectinfo_stop")
                    .HasMaxLength(50);

                entity.Property(e => e.FramedIpAddress)
                    .IsRequired()
                    .HasColumnName("framedipaddress")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.FramedProtocol)
                    .HasColumnName("framedprotocol")
                    .HasMaxLength(32);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("groupname")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NasIpAddress)
                    .IsRequired()
                    .HasColumnName("nasipaddress")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NasPortId)
                    .HasColumnName("nasportid")
                    .HasMaxLength(15);

                entity.Property(e => e.NasPortType)
                    .HasColumnName("nasporttype")
                    .HasMaxLength(32);

                entity.Property(e => e.Realm)
                    .HasColumnName("realm")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ServiceType)
                    .HasColumnName("servicetype")
                    .HasMaxLength(32);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<RadCheck>(entity =>
            {
                entity.ToTable("radcheck");

                entity.HasIndex(e => e.Username)
                    .HasName("username");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasColumnName("attribute")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Op)
                    .IsRequired()
                    .HasColumnName("op")
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("'=='");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(253)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<RadGroupCheck>(entity =>
            {
                entity.ToTable("radgroupcheck");

                entity.HasIndex(e => e.GroupName)
                    .HasName("groupname");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasColumnName("attribute")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("groupname")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Op)
                    .IsRequired()
                    .HasColumnName("op")
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("'=='");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(253)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<RadGroupReply>(entity =>
            {
                entity.ToTable("radgroupreply");

                entity.HasIndex(e => e.GroupName)
                    .HasName("groupname");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasColumnName("attribute")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("groupname")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Op)
                    .IsRequired()
                    .HasColumnName("op")
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("'='");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(253)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<RadPostAuth>(entity =>
            {
                entity.ToTable("radpostauth");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(11);

                entity.Property(e => e.AuthDate)
                    .HasColumnName("authdate")
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Reply)
                    .IsRequired()
                    .HasColumnName("reply")
                    .HasMaxLength(32)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<RadReply>(entity =>
            {
                entity.ToTable("radreply");

                entity.HasIndex(e => e.Username)
                    .HasName("username");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasColumnName("attribute")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Op)
                    .IsRequired()
                    .HasColumnName("op")
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("'='");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(253)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<RadUserGroup>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.GroupName, e.Priority });

                entity.ToTable("radusergroup");

                entity.HasIndex(e => e.Username)
                    .HasName("username");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GroupName)
                    .HasColumnName("groupname")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");
            });
        }
    }
}
