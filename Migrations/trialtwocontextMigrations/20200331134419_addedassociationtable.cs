using Microsoft.EntityFrameworkCore.Migrations;

namespace generics.Migrations.trialtwocontextMigrations
{
    public partial class addedassociationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    studentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.studentid);
                });

            migrationBuilder.CreateTable(
                name: "employeestudentassociation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeid = table.Column<int>(nullable: false),
                    studentid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeestudentassociation", x => x.id);
                    table.ForeignKey(
                        name: "FK_employeestudentassociation_employee_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeestudentassociation_student_studentid",
                        column: x => x.studentid,
                        principalTable: "student",
                        principalColumn: "studentid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employeestudentassociation_employeeid",
                table: "employeestudentassociation",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_employeestudentassociation_studentid",
                table: "employeestudentassociation",
                column: "studentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeestudentassociation");

            migrationBuilder.DropTable(
                name: "student");
        }
    }
}
