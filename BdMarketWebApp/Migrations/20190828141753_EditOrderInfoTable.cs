using Microsoft.EntityFrameworkCore.Migrations;

namespace BdMarketWebApp.Migrations
{
    public partial class EditOrderInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryCharge",
                table: "OrderInfo",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "OrderInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsHomeDelivery",
                table: "OrderInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfo_DeliveryId",
                table: "OrderInfo",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfo_Deliveries_DeliveryId",
                table: "OrderInfo",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfo_Deliveries_DeliveryId",
                table: "OrderInfo");

            migrationBuilder.DropIndex(
                name: "IX_OrderInfo_DeliveryId",
                table: "OrderInfo");

            migrationBuilder.DropColumn(
                name: "DeliveryCharge",
                table: "OrderInfo");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "OrderInfo");

            migrationBuilder.DropColumn(
                name: "IsHomeDelivery",
                table: "OrderInfo");
        }
    }
}
