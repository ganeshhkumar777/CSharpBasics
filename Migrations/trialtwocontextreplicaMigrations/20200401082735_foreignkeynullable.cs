using Microsoft.EntityFrameworkCore.Migrations;

namespace generics.Migrations.trialtwocontextreplicaMigrations
{
    public partial class foreignkeynullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeedetailsid_employeedetails",
                table: "employee");

            migrationBuilder.AddForeignKey(
                name: "FK_employeedetailsid_employeedetails",
                table: "employee",
                column: "EmployeeDetailsId",
                principalTable: "employeeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeedetailsid_employeedetails",
                table: "employee");

            migrationBuilder.AddForeignKey(
                name: "FK_employeedetailsid_employeedetails",
                table: "employee",
                column: "EmployeeDetailsId",
                principalTable: "employeeDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
