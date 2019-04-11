using Microsoft.EntityFrameworkCore.Migrations;

namespace JamesZacka_GoDataFeed_Coding_Demo.Migrations
{
    public partial class addOrderItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrdersID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrdersID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrdersID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersID",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrdersID",
                table: "Products",
                column: "OrdersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrdersID",
                table: "Products",
                column: "OrdersID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
