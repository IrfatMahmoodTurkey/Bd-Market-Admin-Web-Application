using Microsoft.EntityFrameworkCore.Migrations;

namespace BdMarketWebApp.Migrations
{
    public partial class UpdateOrderTableProductPriceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Orders",
                newName: "ProductPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "Orders",
                newName: "Total");
        }
    }
}
