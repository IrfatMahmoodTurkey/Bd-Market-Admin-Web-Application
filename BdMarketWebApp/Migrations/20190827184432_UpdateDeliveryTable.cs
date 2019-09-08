using Microsoft.EntityFrameworkCore.Migrations;

namespace BdMarketWebApp.Migrations
{
    public partial class UpdateDeliveryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Delivaries",
                table: "Delivaries");

            migrationBuilder.RenameTable(
                name: "Delivaries",
                newName: "Deliveries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deliveries",
                table: "Deliveries",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Deliveries",
                table: "Deliveries");

            migrationBuilder.RenameTable(
                name: "Deliveries",
                newName: "Delivaries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delivaries",
                table: "Delivaries",
                column: "Id");
        }
    }
}
