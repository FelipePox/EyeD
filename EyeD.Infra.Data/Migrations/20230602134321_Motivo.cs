using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeD.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Motivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Motivo",
                table: "Peoples",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Motivo",
                table: "Peoples");
        }
    }
}
