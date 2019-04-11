using Microsoft.EntityFrameworkCore.Migrations;

namespace JamesZacka_GoDataFeed_Coding_Demo.Migrations
{
    public partial class ModifyShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Customers_CustomerID",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "ShoppingCarts",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_CustomerID",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Customers_CustomerId",
                table: "ShoppingCarts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Customers_CustomerId",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "ShoppingCarts",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_CustomerId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Customers_CustomerID",
                table: "ShoppingCarts",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
