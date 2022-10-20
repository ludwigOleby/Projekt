using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class ChanegdNamesofCandy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0892750-28da-47c8-837b-323f5584b1f1", "AQAAAAEAACcQAAAAEAGnE1chaRpReyadlN4/pGQ3YPaUGCOVxLkJudxlEiZV4EHyLPcWTI7biITgkllw9Q==", "a28028f5-17b1-4687-8ccd-975dd36de837" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 1,
                column: "Name",
                value: "Mixed Chocolate Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 2,
                column: "Name",
                value: "M&M's");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 3,
                column: "Name",
                value: "Another Mixed Chocolate Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 4,
                column: "Name",
                value: "Mixed Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 5,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 5, "Mixed Hard Candy" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 6,
                column: "Name",
                value: "Sour Fruit Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 7,
                column: "Name",
                value: "Gummy Bears");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 8,
                column: "Name",
                value: "Another Gummy Bears");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 9,
                column: "Name",
                value: "Sour Gummy Bears");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 11,
                column: "Name",
                value: "Another Halloween Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 12,
                column: "Name",
                value: "Mixed Halloween Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 14,
                column: "Name",
                value: "Mixed Sweet/Sour & Hard Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 15,
                column: "Name",
                value: "Another Hard Candy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e0e5964-8454-4320-a376-388e699a9d1e", "AQAAAAEAACcQAAAAECuFSbIArXBkHAb0Y+/luA4jEBUrhWkJ9Yx9s1Een3zqRFS/5ERXalicJ0arTOQ/xA==", "59622f9a-ff2a-4702-b8a2-64a88659e9b4" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 1,
                column: "Name",
                value: "Assorted Chocolate Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 2,
                column: "Name",
                value: "Another Assorted Chocolate Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 3,
                column: "Name",
                value: "Another Chocolate Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 4,
                column: "Name",
                value: "Assorted Fruit Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 5,
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 2, "Fruit Candy" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 6,
                column: "Name",
                value: "Another Assorted Fruit Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 7,
                column: "Name",
                value: "Assorted Gummy Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 8,
                column: "Name",
                value: "Another Assorted Gummy Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 9,
                column: "Name",
                value: "Gummy Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 11,
                column: "Name",
                value: "Assorted Halloween Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 12,
                column: "Name",
                value: "Another Halloween Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 14,
                column: "Name",
                value: "Another Hard Candy");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 15,
                column: "Name",
                value: "Best Hard Candy");
        }
    }
}
