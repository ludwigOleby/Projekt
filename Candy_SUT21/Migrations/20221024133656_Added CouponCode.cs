using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class AddedCouponCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CouponCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    DiscountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponCodes_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3305b89-d9ca-4de7-bd6a-c592ef285980", "AQAAAAEAACcQAAAAEH84MGF0JYbeMEtWrLgy/dIPbPJjnKn+UT1zrElKe/R7PU4mRdvAYdzxkAhhGYB5Bg==", "8c700a08-be2a-4ff9-9961-f96072c91c4e" });

            migrationBuilder.CreateIndex(
                name: "IX_CouponCodes_DiscountId",
                table: "CouponCodes",
                column: "DiscountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponCodes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a26308b9-5bef-4a26-abb1-719129482b59", "AQAAAAEAACcQAAAAEHt4smutjKxuaRxpXAYfYwZmqsHdSvEVoEktjB1fgSf1GfvAsnKx7ZpMMjVDaAvLfA==", "2277224f-b35a-46b3-818a-e5b09f4957fa" });
        }
    }
}
