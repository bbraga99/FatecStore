using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fatec.Store.Carts.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPayment",
                table: "Carts",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPayment",
                table: "Carts");
        }
    }
}
