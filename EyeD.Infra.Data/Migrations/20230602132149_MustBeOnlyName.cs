using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeD.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class MustBeOnlyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "ThirdName",
                table: "Peoples");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Peoples",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ThirdName",
                table: "Peoples",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
