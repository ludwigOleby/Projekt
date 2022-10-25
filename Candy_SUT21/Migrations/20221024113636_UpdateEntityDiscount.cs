using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class UpdateEntityDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79c4541a-e5b8-4fa6-8db4-94727bebaef0", "AQAAAAEAACcQAAAAEDu9YqtHCQ1hz6R1mZDKbGWW8VGPW27OIfXv9H81GWIT+TQO16eB+xpKJBc2WY/vcw==", "fe039b39-1176-4c3f-8aa0-57447c1b6ad4" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "796ba0fb-3164-44a7-92cd-0a9b5f5b4aeb", "AQAAAAEAACcQAAAAEGhrcCvma7QvSWXDGzrCmrp3Fv73KIT2JwXBhhdKiy15BYSk2TCha9P07SUlkctMiA==", "116c49a2-159b-4fce-8d48-95c3b131a84d" });

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
    }
}
