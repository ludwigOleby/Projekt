using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class AddedshoppingcartCouponCodetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCartCoupons",
                columns: table => new
                {
                    ShoppingCartCouponId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<string>(nullable: true),
                    CouponCodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartCoupons", x => x.ShoppingCartCouponId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartCoupons_CouponCodes_CouponCodeId",
                        column: x => x.CouponCodeId,
                        principalTable: "CouponCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcb8a9bf-8fef-47b9-8795-71871eaaf4fc", "AQAAAAEAACcQAAAAEKn9hvs4yaVGBuBAIZW1cwxpCIz6sUAdNkDJ1D11ocDuaZq0Qq2i4Y2B/7BXYfe1Jw==", "4870920d-8cdb-401f-b815-aeab0e8960c1" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartCoupons_CouponCodeId",
                table: "ShoppingCartCoupons",
                column: "CouponCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartCoupons");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85f7a7c0-4db2-4703-8a98-633f146e21f3", "AQAAAAEAACcQAAAAEO7Ppu4E0ZeIR5nkzy8CLtCSiQYKTUHQjYTUskUBzLDKTt61SrQ4xgMad9gjyFxq/A==", "02bb1921-22dc-4b08-a3b0-c813b740296c" });
        }
    }
}
