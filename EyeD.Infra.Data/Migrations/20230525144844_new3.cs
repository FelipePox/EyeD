using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeD.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class new3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FaceId",
                table: "Peoples",
                type: "varchar(56)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(55)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FaceId",
                table: "Peoples",
                type: "varchar(55)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(56)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
