using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unclewood.Modules.Ingredients.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ingredients");

            migrationBuilder.CreateTable(
                name: "ingredients",
                schema: "ingredients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price_value = table.Column<decimal>(type: "numeric", nullable: false),
                    price_currency = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ingredients", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredients",
                schema: "ingredients");
        }
    }
}
