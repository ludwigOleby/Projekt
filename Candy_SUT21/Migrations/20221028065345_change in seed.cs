using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class changeinseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d599bdef-0752-4e8d-ae8e-4a7ac9a95b80", "AQAAAAEAACcQAAAAEDmy16lziy4u5woRjlBFUHmvVO7O6E1kDSjlLeLVyvIG1iIloVaj7W5rf4KukOxTjw==", "b331e46b-0336-4fd8-b1d9-af8e5d9a060c" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 1,
                column: "DiscountId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Name", "Percentage", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "MyDiscount", 5, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Percentage", "StartDate" },
                values: new object[] { "YourDiscount", 15, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "Name", "Percentage" },
                values: new object[] { new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AnotherDiscount", 50 });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "Name", "Percentage", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "HellooDiscoconut", 25, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a4001d1-c1e2-4152-a666-5ee3454fcc04", "AQAAAAEAACcQAAAAEJROx7VxiVyDT8FFzLzbtt0/b5+LaaBARnPbuiTf7a2adTEUnZXKLbLbinIDYjoWDA==", "2de60d8f-d09c-4706-ba34-853ae51bc56c" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 1,
                column: "DiscountId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Name", "Percentage", "StartDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NoDiscount", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Percentage", "StartDate" },
                values: new object[] { "MyDiscount", 5, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "Name", "Percentage" },
                values: new object[] { new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "YourDiscount", 15 });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "Name", "Percentage", "StartDate" },
                values: new object[] { new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AnotherDiscount", 50, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "EndDate", "Name", "Percentage", "StartDate" },
                values: new object[] { 5, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "HellooDiscoconut", 25, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
