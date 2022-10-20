using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class Addeddiscountentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnSale",
                table: "Candies");

            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "Candies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percentage = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ad57ceb-f697-4e7e-8064-4f9b79e94be4", "AQAAAAEAACcQAAAAELnjNKaeHZHbIxQzWK/Vjg/4gx+sjJeBxAIAUHyYOQO0KJn9gWpT8WspVNeRPV8/Fg==", "fda8ecf7-878b-40ef-af70-d6c856270ed8" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "EndDate", "Percentage", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 1,
                column: "DiscountId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 2,
                column: "DiscountId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 3,
                column: "DiscountId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 4,
                column: "DiscountId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Candies_DiscountId",
                table: "Candies",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candies_Discounts_DiscountId",
                table: "Candies",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candies_Discounts_DiscountId",
                table: "Candies");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Candies_DiscountId",
                table: "Candies");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Candies");

            migrationBuilder.AddColumn<bool>(
                name: "IsOnSale",
                table: "Candies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e0e5964-8454-4320-a376-388e699a9d1e", "AQAAAAEAACcQAAAAECuFSbIArXBkHAb0Y+/luA4jEBUrhWkJ9Yx9s1Een3zqRFS/5ERXalicJ0arTOQ/xA==", "59622f9a-ff2a-4702-b8a2-64a88659e9b4" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 2,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 5,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 6,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 7,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 10,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 11,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 12,
                column: "IsOnSale",
                value: true);

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 14,
                column: "IsOnSale",
                value: true);
        }
    }
}
