using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkModel.Migrations
{
    public partial class newseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 1,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 2,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 3,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 4,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 5,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 6,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 7,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 8,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 9,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 11,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 12,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 13,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 14,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 15,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 16,
                column: "SpaceParkID",
                value: 1);

            migrationBuilder.InsertData(
                table: "SpaceParks",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 3, "Sorca Retreat" },
                    { 2, "Death Star Parking" },
                    { 4, "Space Yoda" },
                    { 1, "Citadel of Rur" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpaceParks",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SpaceParks",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SpaceParks",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SpaceParks",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 1,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 2,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 3,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 4,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 5,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 6,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 7,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 8,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 9,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 11,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 12,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 13,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 14,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 15,
                column: "SpaceParkID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Occupancies",
                keyColumn: "ID",
                keyValue: 16,
                column: "SpaceParkID",
                value: 0);
        }
    }
}
