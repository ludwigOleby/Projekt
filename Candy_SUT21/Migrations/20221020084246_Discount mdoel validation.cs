using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class Discountmdoelvalidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Discounts",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8873754e-8b12-4c83-b503-138c4cb6aa0b", "AQAAAAEAACcQAAAAEFwmiBSg+wEd46X+ehSiKRvf+DYqtLUHO4hC3xTKpzZYa5GyQpSsBLoJ5msl8JDqkg==", "db2f6437-ef92-46a9-a748-ed4044f43601" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fe7e0f9-c022-4769-b2c7-0e74cf91dd5b", "AQAAAAEAACcQAAAAEBNyAY9P9aT4VtXLKG3GIunYpA5X7LwWo+u7KsY5xAalojzptVi1eZKldyFkbf6h/w==", "90604948-8fe3-4105-a66c-4c5c83693433" });
        }
    }
}
