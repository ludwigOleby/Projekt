using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class blbla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouponCodes_Discounts_DiscountId",
                table: "CouponCodes");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountId",
                table: "CouponCodes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "076ad35f-8f67-46e5-9584-4d3ffefbcc36", "AQAAAAEAACcQAAAAELSQ7QdF1kGYvNbykP5wCpokwUrNazbMUkC0CG4Z4dFgaRJ7O6y3mr0vvngPWMvm6w==", "68d36f29-0e7e-4823-b748-94a62eba23c1" });

            migrationBuilder.AddForeignKey(
                name: "FK_CouponCodes_Discounts_DiscountId",
                table: "CouponCodes",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouponCodes_Discounts_DiscountId",
                table: "CouponCodes");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountId",
                table: "CouponCodes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3305b89-d9ca-4de7-bd6a-c592ef285980", "AQAAAAEAACcQAAAAEH84MGF0JYbeMEtWrLgy/dIPbPJjnKn+UT1zrElKe/R7PU4mRdvAYdzxkAhhGYB5Bg==", "8c700a08-be2a-4ff9-9961-f96072c91c4e" });

            migrationBuilder.AddForeignKey(
                name: "FK_CouponCodes_Discounts_DiscountId",
                table: "CouponCodes",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
