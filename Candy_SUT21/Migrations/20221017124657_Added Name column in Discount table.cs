using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class AddedNamecolumninDiscounttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Discounts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fe7e0f9-c022-4769-b2c7-0e74cf91dd5b", "AQAAAAEAACcQAAAAEBNyAY9P9aT4VtXLKG3GIunYpA5X7LwWo+u7KsY5xAalojzptVi1eZKldyFkbf6h/w==", "90604948-8fe3-4105-a66c-4c5c83693433" });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "MyDiscount");

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "YourDiscount");

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "AnotherDiscount");

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "HellooDiscoconut");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Discounts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ad57ceb-f697-4e7e-8064-4f9b79e94be4", "AQAAAAEAACcQAAAAELnjNKaeHZHbIxQzWK/Vjg/4gx+sjJeBxAIAUHyYOQO0KJn9gWpT8WspVNeRPV8/Fg==", "fda8ecf7-878b-40ef-af70-d6c856270ed8" });
        }
    }
}
