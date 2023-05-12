using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class adddiscountandproducttables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    discount_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discount_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discount_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discount_persentage = table.Column<int>(type: "int", nullable: false),
                    discount_enabled = table.Column<bool>(type: "bit", nullable: false),
                    maxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.discount_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    discount_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Products_Discounts_discount_id",
                        column: x => x.discount_id,
                        principalTable: "Discounts",
                        principalColumn: "discount_id",
                        onDelete: ReferentialAction.SetDefault);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_discount_id",
                table: "Products",
                column: "discount_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Discounts");
        }
    }
}
