using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ante_up.Data.Migrations
{
    public partial class Elo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("0416721d-d86e-4167-882b-554b796966cd"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("167ad54f-c441-426d-a975-67a00dbe3ada"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("5ecb869f-230d-45f6-a93f-c36d18b74b3d"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("b6d1a1f0-f63e-4eb5-997e-e887559167c5"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("baf06966-6cc4-4ae7-88f5-5692fef2614e"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("dd286a78-71c2-4627-b21d-5426117b8162"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("e2108490-c403-4f1f-8dc0-914d095998ca"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("ebaf0686-60a1-4cc1-a1e2-84053d3b93a7"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("f8b2bde1-66e9-40a4-98fe-262bc413dae1"));

            migrationBuilder.AddColumn<int>(
                name: "Elo",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("105b8cec-6f33-4e62-8d01-61c94b67128f"), "fortnite.jpg", "Fortnite" },
                    { new Guid("ffd1530f-c520-47dd-8609-f5fb9a39d3cb"), "chess.jpg", "Chess" },
                    { new Guid("b5957cee-01fa-4b16-a123-b5fdbedb4d91"), "codmw.jpg", "Call of Duty MW" },
                    { new Guid("c3dafe5b-7c32-4f8a-9941-6fe6fe7c6d82"), "csgo.jpg", "CS:GO" },
                    { new Guid("67a22445-41c8-46a1-80d0-408d371d36e3"), "fifa22.jpg", "Fifa 22" },
                    { new Guid("11d8d908-8bb2-4bca-a061-d20b3746e4ad"), "madden.jpg", "Madden NFL 22" },
                    { new Guid("093976e0-56e9-42c0-96df-e0433372d306"), "nba2k.jpg", "NBA 2K22" },
                    { new Guid("8aa0558f-e6c0-42d7-8b07-7ad85ffb41da"), "apex.jpg", "Apex Legends" },
                    { new Guid("488d8a1d-6dae-4786-b9b0-54ac22a273f5"), "leagueoflegends.jpg", "League of Legends" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("093976e0-56e9-42c0-96df-e0433372d306"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("105b8cec-6f33-4e62-8d01-61c94b67128f"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("11d8d908-8bb2-4bca-a061-d20b3746e4ad"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("488d8a1d-6dae-4786-b9b0-54ac22a273f5"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("67a22445-41c8-46a1-80d0-408d371d36e3"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("8aa0558f-e6c0-42d7-8b07-7ad85ffb41da"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("b5957cee-01fa-4b16-a123-b5fdbedb4d91"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("c3dafe5b-7c32-4f8a-9941-6fe6fe7c6d82"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("ffd1530f-c520-47dd-8609-f5fb9a39d3cb"));

            migrationBuilder.DropColumn(
                name: "Elo",
                table: "Account");

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("e2108490-c403-4f1f-8dc0-914d095998ca"), "fortnite.jpg", "Fortnite" },
                    { new Guid("b6d1a1f0-f63e-4eb5-997e-e887559167c5"), "chess.jpg", "Chess" },
                    { new Guid("167ad54f-c441-426d-a975-67a00dbe3ada"), "codmw.jpg", "Call of Duty MW" },
                    { new Guid("baf06966-6cc4-4ae7-88f5-5692fef2614e"), "csgo.jpg", "CS:GO" },
                    { new Guid("dd286a78-71c2-4627-b21d-5426117b8162"), "fifa22.jpg", "Fifa 22" },
                    { new Guid("0416721d-d86e-4167-882b-554b796966cd"), "madden.jpg", "Madden NFL 22" },
                    { new Guid("f8b2bde1-66e9-40a4-98fe-262bc413dae1"), "nba2k.jpg", "NBA 2K22" },
                    { new Guid("5ecb869f-230d-45f6-a93f-c36d18b74b3d"), "apex.jpg", "Apex Legends" },
                    { new Guid("ebaf0686-60a1-4cc1-a1e2-84053d3b93a7"), "leagueoflegends.jpg", "League of Legends" }
                });
        }
    }
}
