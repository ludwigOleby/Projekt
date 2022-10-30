using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class AddedApplicationUserinfotoOrdertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderWeathers",
                columns: table => new
                {
                    OrderWeatherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RainMean = table.Column<float>(nullable: false),
                    WeatherSymbol = table.Column<float>(nullable: false),
                    Temperature = table.Column<float>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderWeathers", x => x.OrderWeatherId);
                    table.ForeignKey(
                        name: "FK_OrderWeathers_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79d1f8b3-8d29-4066-a9c3-fe67579bf984", "AQAAAAEAACcQAAAAEBojCzS3+7L+GqDW+fogRHYrbPcWaAYu9H9zirr4tAHttmZaKJtaWgJoQc5UTxLnYQ==", "507a8c9a-f6d5-4739-9bb1-4b02d6be1caa" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderWeathers_OrderId",
                table: "OrderWeathers",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderWeathers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4eb720b8-88ae-4f92-8a5f-ae258b55b271", "AQAAAAEAACcQAAAAEHoto0EuUPHNjHxtgMdeDaq30gVG6asPeWKRm73i/0U0cwJS7nkCRfMs0G7N/b05wA==", "42f798fc-0dde-4af9-8726-42f3ed6c0158" });
        }
    }
}
