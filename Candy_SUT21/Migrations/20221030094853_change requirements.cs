using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class changerequirements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d95807b-cb3a-4032-8059-35f9c4959960", "AQAAAAEAACcQAAAAEFsi/Jn2TCGxfx+0wlfrAq+RvbLT8uYs/KTP+vgUOluCwgdoBw/GuSV0THcJY4hanQ==", "203d1f11-df01-4953-b819-8421b001abf5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "394e4f3f-ba26-45f3-b7ac-2ced7689e4f4", "AQAAAAEAACcQAAAAEHDyapYst76oS+GD1cFk24ZSdbyWUqR91lTJW39vSqIZ6LEozFwkT9UHbLGNUj0QfQ==", "66278cae-8c95-49d7-89c0-720ee7c3ab6e" });
        }
    }
}
