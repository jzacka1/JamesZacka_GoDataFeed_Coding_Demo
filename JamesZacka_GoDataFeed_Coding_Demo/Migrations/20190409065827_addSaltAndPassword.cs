using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JamesZacka_GoDataFeed_Coding_Demo.Migrations
{
    public partial class addSaltAndPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "Customers",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Customers",
                maxLength: 36,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Customers");
        }
    }
}
