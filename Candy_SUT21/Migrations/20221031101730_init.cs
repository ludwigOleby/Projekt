using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34f28780-f534-462e-93db-bb9d34c3e1b6", "AQAAAAEAACcQAAAAENTFODd5fd4wHe4nlNznFFg4zee455AMyQZWQ2wu+4N2RPYtjHuyxelT5kpBCorWMw==", "3b0024ef-349c-457d-aa4b-a67a4f66a801" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79d1f8b3-8d29-4066-a9c3-fe67579bf984", "AQAAAAEAACcQAAAAEBojCzS3+7L+GqDW+fogRHYrbPcWaAYu9H9zirr4tAHttmZaKJtaWgJoQc5UTxLnYQ==", "507a8c9a-f6d5-4739-9bb1-4b02d6be1caa" });
        }
    }
}
