﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RadiusManager.Models;

namespace RadiusManager.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(127);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(127);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(127);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(127);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(127);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(127);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(127);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(127);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(127);

                    b.Property<string>("Name")
                        .HasMaxLength(127);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RadiusManager.Models.Nas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasMaxLength(10);

                    b.Property<string>("Community")
                        .HasColumnName("community")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("description")
                        .HasDefaultValueSql("'RADIUS Client'")
                        .HasMaxLength(200);

                    b.Property<string>("NasName")
                        .IsRequired()
                        .HasColumnName("nasname")
                        .HasMaxLength(128);

                    b.Property<int?>("Ports")
                        .HasColumnName("ports")
                        .HasMaxLength(5);

                    b.Property<string>("Secret")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("secret")
                        .HasDefaultValueSql("'secret'")
                        .HasMaxLength(50);

                    b.Property<string>("Server")
                        .HasColumnName("server")
                        .HasMaxLength(64);

                    b.Property<string>("ShortName")
                        .HasColumnName("shortname")
                        .HasMaxLength(32);

                    b.Property<string>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("type")
                        .HasDefaultValueSql("'other'")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("NasName")
                        .HasName("nasname");

                    b.ToTable("nas");
                });

            modelBuilder.Entity("RadiusManager.Models.RadAcct", b =>
                {
                    b.Property<long>("RadAcctId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("radacctid")
                        .HasMaxLength(21);

                    b.Property<string>("AcctAuthentic")
                        .HasColumnName("acctauthentic")
                        .HasMaxLength(32);

                    b.Property<long?>("AcctInputOctets")
                        .HasColumnName("acctinputoctets")
                        .HasMaxLength(20);

                    b.Property<int?>("AcctInterval")
                        .HasColumnName("acctinterval")
                        .HasMaxLength(12);

                    b.Property<long?>("AcctOutputOctets")
                        .HasColumnName("acctoutputoctets")
                        .HasMaxLength(20);

                    b.Property<string>("AcctSessionId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("acctsessionid")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<uint?>("AcctSessionTime")
                        .HasColumnName("acctsessiontime");

                    b.Property<DateTime?>("AcctStartTime")
                        .HasColumnName("acctstarttime")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("AcctStopTime")
                        .HasColumnName("acctstoptime")
                        .HasColumnType("datetime");

                    b.Property<string>("AcctTerminateCause")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("acctterminatecause")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(32);

                    b.Property<string>("AcctUniqueId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("acctuniqueid")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(32);

                    b.Property<DateTime?>("AcctUpdateTime")
                        .HasColumnName("acctupdatetime")
                        .HasColumnType("datetime");

                    b.Property<string>("CalledStationId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("calledstationid")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(50);

                    b.Property<string>("CallingStationId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("callingstationid")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(50);

                    b.Property<string>("ConnectInfoStart")
                        .HasColumnName("connectinfo_start")
                        .HasMaxLength(50);

                    b.Property<string>("ConnectInfoStop")
                        .HasColumnName("connectinfo_stop")
                        .HasMaxLength(50);

                    b.Property<string>("FramedIpAddress")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("framedipaddress")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(15);

                    b.Property<string>("FramedProtocol")
                        .HasColumnName("framedprotocol")
                        .HasMaxLength(32);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("groupname")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<string>("NasIpAddress")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("nasipaddress")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(15);

                    b.Property<string>("NasPortId")
                        .HasColumnName("nasportid")
                        .HasMaxLength(15);

                    b.Property<string>("NasPortType")
                        .HasColumnName("nasporttype")
                        .HasMaxLength(32);

                    b.Property<string>("Realm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("realm")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<string>("ServiceType")
                        .HasColumnName("servicetype")
                        .HasMaxLength(32);

                    b.Property<string>("Username")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("username")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.HasKey("RadAcctId");

                    b.HasIndex("AcctInterval")
                        .HasName("acctinterval");

                    b.HasIndex("AcctSessionId")
                        .HasName("acctsessionid");

                    b.HasIndex("AcctSessionTime")
                        .HasName("acctsessiontime");

                    b.HasIndex("AcctStartTime")
                        .HasName("acctstarttime");

                    b.HasIndex("AcctStopTime")
                        .HasName("acctstoptime");

                    b.HasIndex("AcctUniqueId")
                        .IsUnique()
                        .HasName("acctuniqueid");

                    b.HasIndex("FramedIpAddress")
                        .HasName("framedipaddress");

                    b.HasIndex("NasIpAddress")
                        .HasName("nasipaddress");

                    b.HasIndex("Username")
                        .HasName("username");

                    b.ToTable("radacct");
                });

            modelBuilder.Entity("RadiusManager.Models.RadCheck", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Attribute")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("attribute")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<string>("Op")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("op")
                        .HasColumnType("char(2)")
                        .HasDefaultValueSql("'=='");

                    b.Property<string>("Username")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("username")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<string>("Value")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("value")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(253);

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .HasName("username");

                    b.ToTable("radcheck");
                });

            modelBuilder.Entity("RadiusManager.Models.RadGroupCheck", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Attribute")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("attribute")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("groupname")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<string>("Op")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("op")
                        .HasColumnType("char(2)")
                        .HasDefaultValueSql("'=='");

                    b.Property<string>("Value")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("value")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(253);

                    b.HasKey("Id");

                    b.HasIndex("GroupName")
                        .HasName("groupname");

                    b.ToTable("radgroupcheck");
                });

            modelBuilder.Entity("RadiusManager.Models.RadGroupReply", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Attribute")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("attribute")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("groupname")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<string>("Op")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("op")
                        .HasColumnType("char(2)")
                        .HasDefaultValueSql("'='");

                    b.Property<string>("Value")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("value")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(253);

                    b.HasKey("Id");

                    b.HasIndex("GroupName")
                        .HasName("groupname");

                    b.ToTable("radgroupreply");
                });

            modelBuilder.Entity("RadiusManager.Models.RadPostAuth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasMaxLength(11);

                    b.Property<DateTime>("AuthDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("authdate")
                        .HasColumnType("timestamp");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pass")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<string>("Reply")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("reply")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(32);

                    b.Property<string>("Username")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("username")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("radpostauth");
                });

            modelBuilder.Entity("RadiusManager.Models.RadReply", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Attribute")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("attribute")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<string>("Op")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("op")
                        .HasColumnType("char(2)")
                        .HasDefaultValueSql("'='");

                    b.Property<string>("Username")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("username")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<string>("Value")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("value")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(253);

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .HasName("username");

                    b.ToTable("radreply");
                });

            modelBuilder.Entity("RadiusManager.Models.RadUserGroup", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("username")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<string>("GroupName")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("groupname")
                        .HasDefaultValueSql("''")
                        .HasMaxLength(64);

                    b.Property<int>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("priority")
                        .HasColumnType("int(11)")
                        .HasDefaultValueSql("'1'");

                    b.HasKey("Username", "GroupName", "Priority");

                    b.HasIndex("Username")
                        .HasName("username");

                    b.ToTable("radusergroup");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
