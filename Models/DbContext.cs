using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RadiusManager.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DbContext> options)
            : base(options)
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
            modelBuilder.Entity<Nas>(entity =>
            {
                entity.ToTable("nas");

                entity.HasIndex(e => e.NasName)
                    .HasName("nasname");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Community)
                    .HasColumnName("community")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(200)")
                    .HasDefaultValueSql("'RADIUS Client'");

                entity.Property(e => e.NasName)
                    .IsRequired()
                    .HasColumnName("nasname")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Ports)
                    .HasColumnName("ports")
                    .HasColumnType("int(5)");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnName("secret")
                    .HasColumnType("varchar(60)")
                    .HasDefaultValueSql("'secret'");

                entity.Property(e => e.Server)
                    .HasColumnName("server")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.ShortName)
                    .HasColumnName("shortname")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(30)")
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
                    .HasColumnType("bigint(21)");

                entity.Property(e => e.AcctAuthentic)
                    .HasColumnName("acctauthentic")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.AcctInputOctets)
                    .HasColumnName("acctinputoctets")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AcctInterval)
                    .HasColumnName("acctinterval")
                    .HasColumnType("int(12)");

                entity.Property(e => e.AcctOutputOctets)
                    .HasColumnName("acctoutputoctets")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AcctSessionId)
                    .IsRequired()
                    .HasColumnName("acctsessionid")
                    .HasColumnType("varchar(64)")
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
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AcctUniqueId)
                    .IsRequired()
                    .HasColumnName("acctuniqueid")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AcctUpdateTime)
                    .HasColumnName("acctupdatetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CalledStationId)
                    .IsRequired()
                    .HasColumnName("calledstationid")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CallingStationId)
                    .IsRequired()
                    .HasColumnName("callingstationid")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ConnectInfoStart)
                    .HasColumnName("connectinfo_start")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ConnectInfoStop)
                    .HasColumnName("connectinfo_stop")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FramedIpAddress)
                    .IsRequired()
                    .HasColumnName("framedipaddress")
                    .HasColumnType("varchar(15)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.FramedProtocol)
                    .HasColumnName("framedprotocol")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("groupname")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NasIpAddress)
                    .IsRequired()
                    .HasColumnName("nasipaddress")
                    .HasColumnType("varchar(15)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NasPortId)
                    .HasColumnName("nasportid")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.NasPortType)
                    .HasColumnName("nasporttype")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Realm)
                    .HasColumnName("realm")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ServiceType)
                    .HasColumnName("servicetype")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(64)")
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
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Op)
                    .IsRequired()
                    .HasColumnName("op")
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("'=='");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("varchar(253)")
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
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("groupname")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Op)
                    .IsRequired()
                    .HasColumnName("op")
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("'=='");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("varchar(253)")
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
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("groupname")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Op)
                    .IsRequired()
                    .HasColumnName("op")
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("'='");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("varchar(253)")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<RadPostAuth>(entity =>
            {
                entity.ToTable("radpostauth");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AuthDate)
                    .HasColumnName("authdate")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Reply)
                    .IsRequired()
                    .HasColumnName("reply")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<RadReply>(entity =>
            {
                entity.ToTable("RadReply");

                entity.HasIndex(e => e.Username)
                    .HasName("username");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasColumnName("attribute")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Op)
                    .IsRequired()
                    .HasColumnName("op")
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("'='");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("varchar(253)")
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
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GroupName)
                    .HasColumnName("groupname")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");
            });
        }
    }
}
