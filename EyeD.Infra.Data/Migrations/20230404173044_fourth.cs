using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeD.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThirdNome",
                table: "Peoples",
                newName: "ThirdName");

            migrationBuilder.RenameColumn(
                name: "SecondNome",
                table: "Peoples",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "FirstNome",
                table: "Peoples",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThirdName",
                table: "Peoples",
                newName: "ThirdNome");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Peoples",
                newName: "SecondNome");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Peoples",
                newName: "FirstNome");
        }
    }
}
