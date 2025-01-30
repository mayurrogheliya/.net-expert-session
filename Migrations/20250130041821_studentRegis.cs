using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace expertsession.Migrations
{
    /// <inheritdoc />
    public partial class studentRegis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentRegister",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    student_branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    student_roll = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRegister", x => x.student_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentRegister");
        }
    }
}
