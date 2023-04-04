using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeD.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TerceiroNome",
                table: "Peoples",
                newName: "ThirdNome");

            migrationBuilder.RenameColumn(
                name: "PrimeiroNome",
                table: "Peoples",
                newName: "FirstNome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThirdNome",
                table: "Peoples",
                newName: "TerceiroNome");

            migrationBuilder.RenameColumn(
                name: "FirstNome",
                table: "Peoples",
                newName: "PrimeiroNome");
        }
    }
}
