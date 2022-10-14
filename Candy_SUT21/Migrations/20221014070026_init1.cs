using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e0e5964-8454-4320-a376-388e699a9d1e", "AQAAAAEAACcQAAAAECuFSbIArXBkHAb0Y+/luA4jEBUrhWkJ9Yx9s1Een3zqRFS/5ERXalicJ0arTOQ/xA==", "59622f9a-ff2a-4702-b8a2-64a88659e9b4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44c3e368-de98-4499-8a6e-2b44229e3376", "AQAAAAEAACcQAAAAEDTCNeg7i9Vc2QXDBkDMWtZ9ZRcuYLe2IJnla97BU0WWtUGlZyWTlbAMy1yEsZM20w==", "f9f7b1ae-70b2-4990-b02c-a8dd52d604d5" });
        }
    }
}
