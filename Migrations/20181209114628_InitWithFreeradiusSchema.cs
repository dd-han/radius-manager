using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RadiusManager.Migrations
{
    public partial class InitWithFreeradiusSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nas",
                columns: table => new
                {
                    id = table.Column<int>(maxLength: 10, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nasname = table.Column<string>(maxLength: 128, nullable: false),
                    shortname = table.Column<string>(maxLength: 32, nullable: true),
                    type = table.Column<string>(maxLength: 30, nullable: true, defaultValueSql: "'other'"),
                    ports = table.Column<int>(maxLength: 5, nullable: true),
                    secret = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "'secret'"),
                    server = table.Column<string>(maxLength: 64, nullable: true),
                    community = table.Column<string>(maxLength: 50, nullable: true),
                    description = table.Column<string>(maxLength: 200, nullable: true, defaultValueSql: "'RADIUS Client'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "radacct",
                columns: table => new
                {
                    radacctid = table.Column<long>(maxLength: 21, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    acctsessionid = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    acctuniqueid = table.Column<string>(maxLength: 32, nullable: false, defaultValueSql: "''"),
                    username = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    groupname = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    realm = table.Column<string>(maxLength: 64, nullable: true, defaultValueSql: "''"),
                    nasipaddress = table.Column<string>(maxLength: 15, nullable: false, defaultValueSql: "''"),
                    nasportid = table.Column<string>(maxLength: 15, nullable: true),
                    nasporttype = table.Column<string>(maxLength: 32, nullable: true),
                    acctstarttime = table.Column<DateTime>(type: "datetime", nullable: true),
                    acctupdatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    acctstoptime = table.Column<DateTime>(type: "datetime", nullable: true),
                    acctinterval = table.Column<int>(maxLength: 12, nullable: true),
                    acctsessiontime = table.Column<uint>(nullable: true),
                    acctauthentic = table.Column<string>(maxLength: 32, nullable: true),
                    connectinfo_start = table.Column<string>(maxLength: 50, nullable: true),
                    connectinfo_stop = table.Column<string>(maxLength: 50, nullable: true),
                    acctinputoctets = table.Column<long>(maxLength: 20, nullable: true),
                    acctoutputoctets = table.Column<long>(maxLength: 20, nullable: true),
                    calledstationid = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "''"),
                    callingstationid = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "''"),
                    acctterminatecause = table.Column<string>(maxLength: 32, nullable: false, defaultValueSql: "''"),
                    servicetype = table.Column<string>(maxLength: 32, nullable: true),
                    framedprotocol = table.Column<string>(maxLength: 32, nullable: true),
                    framedipaddress = table.Column<string>(maxLength: 15, nullable: false, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radacct", x => x.radacctid);
                });

            migrationBuilder.CreateTable(
                name: "radcheck",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    attribute = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    op = table.Column<string>(type: "char(2)", nullable: false, defaultValueSql: "'=='"),
                    value = table.Column<string>(maxLength: 253, nullable: false, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radcheck", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "radgroupcheck",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    groupname = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    attribute = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    op = table.Column<string>(type: "char(2)", nullable: false, defaultValueSql: "'=='"),
                    value = table.Column<string>(maxLength: 253, nullable: false, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radgroupcheck", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "radgroupreply",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    groupname = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    attribute = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    op = table.Column<string>(type: "char(2)", nullable: false, defaultValueSql: "'='"),
                    value = table.Column<string>(maxLength: 253, nullable: false, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radgroupreply", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "radpostauth",
                columns: table => new
                {
                    id = table.Column<int>(maxLength: 11, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    pass = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    reply = table.Column<string>(maxLength: 32, nullable: false, defaultValueSql: "''"),
                    authdate = table.Column<DateTime>(type: "timestamp", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radpostauth", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "radreply",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    attribute = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    op = table.Column<string>(type: "char(2)", nullable: false, defaultValueSql: "'='"),
                    value = table.Column<string>(maxLength: 253, nullable: false, defaultValueSql: "''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadReply", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "radusergroup",
                columns: table => new
                {
                    username = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    groupname = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "''"),
                    priority = table.Column<int>(type: "int(11)", nullable: false, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radusergroup", x => new { x.username, x.groupname, x.priority });
                });

            migrationBuilder.CreateIndex(
                name: "nasname",
                table: "nas",
                column: "nasname");

            migrationBuilder.CreateIndex(
                name: "acctinterval",
                table: "radacct",
                column: "acctinterval");

            migrationBuilder.CreateIndex(
                name: "acctsessionid",
                table: "radacct",
                column: "acctsessionid");

            migrationBuilder.CreateIndex(
                name: "acctsessiontime",
                table: "radacct",
                column: "acctsessiontime");

            migrationBuilder.CreateIndex(
                name: "acctstarttime",
                table: "radacct",
                column: "acctstarttime");

            migrationBuilder.CreateIndex(
                name: "acctstoptime",
                table: "radacct",
                column: "acctstoptime");

            migrationBuilder.CreateIndex(
                name: "acctuniqueid",
                table: "radacct",
                column: "acctuniqueid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "framedipaddress",
                table: "radacct",
                column: "framedipaddress");

            migrationBuilder.CreateIndex(
                name: "nasipaddress",
                table: "radacct",
                column: "nasipaddress");

            migrationBuilder.CreateIndex(
                name: "username",
                table: "radacct",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "username",
                table: "radcheck",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "groupname",
                table: "radgroupcheck",
                column: "groupname");

            migrationBuilder.CreateIndex(
                name: "groupname",
                table: "radgroupreply",
                column: "groupname");

            migrationBuilder.CreateIndex(
                name: "username",
                table: "radreply",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "username",
                table: "radusergroup",
                column: "username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nas");

            migrationBuilder.DropTable(
                name: "radacct");

            migrationBuilder.DropTable(
                name: "radcheck");

            migrationBuilder.DropTable(
                name: "radgroupcheck");

            migrationBuilder.DropTable(
                name: "radgroupreply");

            migrationBuilder.DropTable(
                name: "radpostauth");

            migrationBuilder.DropTable(
                name: "radreply");

            migrationBuilder.DropTable(
                name: "radusergroup");
        }
    }
}
