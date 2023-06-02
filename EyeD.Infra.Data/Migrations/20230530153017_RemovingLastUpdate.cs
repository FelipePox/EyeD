using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeD.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovingLastUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecoverPasswordExpirationDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RecoverPasswordRequest",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RecoverPasswordExpirationDate",
                table: "Users",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RecoverPasswordRequest",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
