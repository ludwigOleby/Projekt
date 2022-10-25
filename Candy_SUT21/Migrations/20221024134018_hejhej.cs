using Microsoft.EntityFrameworkCore.Migrations;

namespace Candy_SUT21.Migrations
{
    public partial class hejhej : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "023a7ed5-292d-4952-b292-df7a924eeec6", "AQAAAAEAACcQAAAAEJi+638MB+PjcYHftDZKEdtK+ajGpFSl/h/S2CZ7gcRBa2DbAbfQi8TGC4azIMe5cQ==", "bf5bc138-3756-4229-ab6d-c322f01871d7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "076ad35f-8f67-46e5-9584-4d3ffefbcc36", "AQAAAAEAACcQAAAAELSQ7QdF1kGYvNbykP5wCpokwUrNazbMUkC0CG4Z4dFgaRJ7O6y3mr0vvngPWMvm6w==", "68d36f29-0e7e-4823-b748-94a62eba23c1" });
        }
    }
}
