using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class Addedidentitywithseededadminuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24315075-2f02-4e7d-98ee-28edd3bb66c7", "AQAAAAEAACcQAAAAEDGt/4RHepZSpDNXq0PKC23eFu+iy8/K/Op3esCmC8URmGoSGsK/xpav1R14oDUOgA==", "74ff51bd-df64-48bb-9327-8c4dc40e47af" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2850a13f-f41c-4eef-af83-9924c9893fc1", "AQAAAAEAACcQAAAAEO8bY1TH2VRJtSdMeTSQFSQEBSLaC2U78DVWyzqPj0ktQLpYkQNY/J/vMSQsGYTi/Q==", "1534a469-4e82-4af8-b54b-c889919a0d75" });
        }
    }
}
