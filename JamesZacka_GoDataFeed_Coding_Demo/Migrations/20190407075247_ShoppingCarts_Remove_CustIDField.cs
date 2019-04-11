using Microsoft.EntityFrameworkCore.Migrations;

namespace JamesZacka_GoDataFeed_Coding_Demo.Migrations
{
    public partial class ShoppingCarts_Remove_CustIDField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Customers_CustomerId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_CustomerId",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "ShoppingCarts",
                newName: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CustomerID",
                table: "ShoppingCarts",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Customers_CustomerID",
                table: "ShoppingCarts",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Customers_CustomerID",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_CustomerID",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "ShoppingCarts",
                newName: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CustomerId",
                table: "ShoppingCarts",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Customers_CustomerId",
                table: "ShoppingCarts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
