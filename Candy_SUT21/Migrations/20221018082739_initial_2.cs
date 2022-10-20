using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class initial_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5a09599-7fb3-41bd-8a5f-935c920e9229", "AQAAAAEAACcQAAAAEOhOw8BMylY7Q0FVRSOyPoumvLueU3ZVZbPTqxJOwCMBNro8GLjDuyQBELZWmdmJlw==", "44317d58-261f-49ee-88ef-6992b969e1d1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e0e5964-8454-4320-a376-388e699a9d1e", "AQAAAAEAACcQAAAAECuFSbIArXBkHAb0Y+/luA4jEBUrhWkJ9Yx9s1Een3zqRFS/5ERXalicJ0arTOQ/xA==", "59622f9a-ff2a-4702-b8a2-64a88659e9b4" });
        }
    }
}
