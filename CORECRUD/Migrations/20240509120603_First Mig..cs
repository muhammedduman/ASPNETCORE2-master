using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CORECRUD.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department_",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Description1 = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Description2 = table.Column<string>(type: "VARCHAR(5000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "People_",
                columns: table => new
                {
                    PeopleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Surname = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    City = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People_", x => x.PeopleID);
                    table.ForeignKey(
                        name: "FK_People__Department__DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department_",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People__DepartmentID",
                table: "People_",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People_");

            migrationBuilder.DropTable(
                name: "Department_");
        }
    }
}
