using Microsoft.EntityFrameworkCore.Migrations;

namespace generics.Migrations.trialtwocontextMigrations
{
    public partial class movingtonewdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeestudentassociation_employee_employeeid",
                table: "employeestudentassociation");

            migrationBuilder.DropForeignKey(
                name: "FK_employeestudentassociation_student_studentid",
                table: "employeestudentassociation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_student",
                table: "student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employeestudentassociation",
                table: "employeestudentassociation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employee",
                table: "employee");

            migrationBuilder.RenameTable(
                name: "student",
                newName: "students");

            migrationBuilder.RenameTable(
                name: "employeestudentassociation",
                newName: "employeestudentassociations");

            migrationBuilder.RenameTable(
                name: "employee",
                newName: "employees");

            migrationBuilder.RenameIndex(
                name: "IX_employeestudentassociation_studentid",
                table: "employeestudentassociations",
                newName: "IX_employeestudentassociations_studentid");

            migrationBuilder.RenameIndex(
                name: "IX_employeestudentassociation_employeeid",
                table: "employeestudentassociations",
                newName: "IX_employeestudentassociations_employeeid");

            migrationBuilder.RenameIndex(
                name: "IX_employee_EmployeeDetailsId",
                table: "employees",
                newName: "IX_employees_EmployeeDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                table: "students",
                column: "studentid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeestudentassociations",
                table: "employeestudentassociations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employeestudentassociations_employees_employeeid",
                table: "employeestudentassociations",
                column: "employeeid",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employeestudentassociations_students_studentid",
                table: "employeestudentassociations",
                column: "studentid",
                principalTable: "students",
                principalColumn: "studentid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeestudentassociations_employees_employeeid",
                table: "employeestudentassociations");

            migrationBuilder.DropForeignKey(
                name: "FK_employeestudentassociations_students_studentid",
                table: "employeestudentassociations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employeestudentassociations",
                table: "employeestudentassociations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "student");

            migrationBuilder.RenameTable(
                name: "employeestudentassociations",
                newName: "employeestudentassociation");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "employee");

            migrationBuilder.RenameIndex(
                name: "IX_employeestudentassociations_studentid",
                table: "employeestudentassociation",
                newName: "IX_employeestudentassociation_studentid");

            migrationBuilder.RenameIndex(
                name: "IX_employeestudentassociations_employeeid",
                table: "employeestudentassociation",
                newName: "IX_employeestudentassociation_employeeid");

            migrationBuilder.RenameIndex(
                name: "IX_employees_EmployeeDetailsId",
                table: "employee",
                newName: "IX_employee_EmployeeDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_student",
                table: "student",
                column: "studentid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeestudentassociation",
                table: "employeestudentassociation",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employee",
                table: "employee",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employeestudentassociation_employee_employeeid",
                table: "employeestudentassociation",
                column: "employeeid",
                principalTable: "employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employeestudentassociation_student_studentid",
                table: "employeestudentassociation",
                column: "studentid",
                principalTable: "student",
                principalColumn: "studentid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
