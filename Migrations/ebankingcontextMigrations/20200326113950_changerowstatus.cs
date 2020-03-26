using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace generics.Migrations.ebankingcontextMigrations
{
    public partial class changerowstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RowStatus",
                columns: table => new
                {
                    RowstatusUid = table.Column<Guid>(nullable: false),
                    RowStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowStatus_RowStatusUid", x => x.RowstatusUid);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    CustomerDetailsUid = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    CustomerDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerUid = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(type: "nvarchar(2000)", maxLength: 1000, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(28)", maxLength: 14, nullable: true),
                    RowStatusUid = table.Column<Guid>(nullable: false, defaultValue: new Guid("01000000-0000-0000-0000-000000000000"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails_CustomerDetailsUid", x => x.CustomerDetailsUid);
                    table.ForeignKey(
                        name: "FK_CustomerDetails_RowStatus_RowStatusUid",
                        column: x => x.RowStatusUid,
                        principalTable: "RowStatus",
                        principalColumn: "RowstatusUid");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerUid = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    RowStatusUid = table.Column<Guid>(nullable: false, defaultValue: new Guid("01000000-0000-0000-0000-000000000000"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_CustomerUid", x => x.CustomerUid);
                    table.ForeignKey(
                        name: "FK_Customer_CustomerDetails_CustomerUid",
                        column: x => x.CustomerUid,
                        principalTable: "CustomerDetails",
                        principalColumn: "CustomerDetailsUid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_RowStatus_RowStatusUid",
                        column: x => x.RowStatusUid,
                        principalTable: "RowStatus",
                        principalColumn: "RowstatusUid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_RowStatusUid",
                table: "Customer",
                column: "RowStatusUid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_RowStatusUid",
                table: "CustomerDetails",
                column: "RowStatusUid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "CustomerDetails");

            migrationBuilder.DropTable(
                name: "RowStatus");
        }
    }
}
