using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Candies",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "394e4f3f-ba26-45f3-b7ac-2ced7689e4f4", "AQAAAAEAACcQAAAAEHDyapYst76oS+GD1cFk24ZSdbyWUqR91lTJW39vSqIZ6LEozFwkT9UHbLGNUj0QfQ==", "66278cae-8c95-49d7-89c0-720ee7c3ab6e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Candies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46987f8d-0a78-48bb-8c24-6660302bc59d", "AQAAAAEAACcQAAAAEAYgTZZxFpo6nhusCHMvjCEcbSgsl0LW7TZ0g6FT6yxYAEfBofuTcJgCMP2r3BRK5A==", "5449aeef-37a3-42c1-8930-d3047f48b2ec" });
        }
    }
}
