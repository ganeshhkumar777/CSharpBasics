using Microsoft.EntityFrameworkCore.Migrations;

namespace generics.Migrations.trialtwocontextMigrations
{
    public partial class addedforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "employee",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeDetailsId",
                table: "employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "employee",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "employeeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_EmployeeDetailsId",
                table: "employee",
                column: "EmployeeDetailsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_employeedetailsid_employeedetails",
                table: "employee",
                column: "EmployeeDetailsId",
                principalTable: "employeeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeedetailsid_employeedetails",
                table: "employee");

            migrationBuilder.DropTable(
                name: "employeeDetails");

            migrationBuilder.DropIndex(
                name: "IX_employee_EmployeeDetailsId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "EmployeeDetailsId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "employee");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
