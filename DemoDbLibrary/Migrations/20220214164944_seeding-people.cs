using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoDbLibrary.Migrations
{
    public partial class seedingpeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Ben", "Kenobi" },
                    { 2, "Luke", "Skywalker" },
                    { 3, "Anakin", "Skywalker" },
                    { 4, "Han", "Solo" },
                    { 5, "Chewbacca", "" },
                    { 6, "Yoda", "" },
                    { 7, "Leia", "Organa Skywalker-Solo" },
                    { 8, "Rei", "WhoKnows" },
                    { 9, "Boba", "Fett" },
                    { 10, "Jabba", "TheHut" },
                    { 11, "Sheev", "Palpatine" },
                    { 12, "Padme", "Amidalla" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
