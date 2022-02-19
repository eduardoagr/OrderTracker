using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderTracker.Data.Migrations
{
    public partial class ItemManuAddtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Manufacturers_ManufacturerId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Manufacturers_ManufacturerId",
                table: "Items",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Manufacturers_ManufacturerId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Items",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Manufacturers_ManufacturerId",
                table: "Items",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
