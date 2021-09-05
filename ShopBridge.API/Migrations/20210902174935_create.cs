using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBridge.API.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sb_product");

            migrationBuilder.CreateTable(
                name: "product",
                schema: "sb_product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    tax = table.Column<double>(type: "double precision", nullable: false),
                    is_refundable = table.Column<bool>(type: "boolean", nullable: false),
                    category = table.Column<string>(type: "text", nullable: true),
                    is_available = table.Column<string>(type: "text", nullable: true),
                    available_quantity = table.Column<int>(type: "integer", nullable: false),
                    is_gift = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product",
                schema: "sb_product");
        }
    }
}
