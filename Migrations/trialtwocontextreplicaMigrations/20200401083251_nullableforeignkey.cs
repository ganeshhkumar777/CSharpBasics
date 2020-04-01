using Microsoft.EntityFrameworkCore.Migrations;

namespace generics.Migrations.trialtwocontextreplicaMigrations
{
    public partial class nullableforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_employee_EmployeeDetailsId",
                table: "employee");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeDetailsId",
                table: "employee",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_employee_EmployeeDetailsId",
                table: "employee",
                column: "EmployeeDetailsId",
                unique: true,
                filter: "[EmployeeDetailsId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_employee_EmployeeDetailsId",
                table: "employee");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeDetailsId",
                table: "employee",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_EmployeeDetailsId",
                table: "employee",
                column: "EmployeeDetailsId",
                unique: true);
        }
    }
}
