using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeD.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class right : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferenceDocument",
                table: "Vehicles",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceDocument",
                table: "Vehicles");
        }
    }
}
