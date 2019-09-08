using Microsoft.EntityFrameworkCore.Migrations;

namespace BdMarketWebApp.Migrations
{
    public partial class UpdateOrderInfoAndOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsClientState",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsClientState",
                table: "OrderInfo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClientState",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsClientState",
                table: "OrderInfo");
        }
    }
}
