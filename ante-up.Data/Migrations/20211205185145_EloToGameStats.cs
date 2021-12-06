using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ante_up.Data.Migrations
{
    public partial class EloToGameStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Skill",
                table: "GameStats");

            migrationBuilder.DropColumn(
                name: "Elo",
                table: "Account");

            migrationBuilder.AddColumn<int>(
                name: "Elo",
                table: "GameStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("d0e99a19-0040-43c9-bb84-53fd1221411b"), "fortnite.jpg", "Fortnite" },
                    { new Guid("3205bd33-5928-4684-bddd-792b614bb617"), "chess.jpg", "Chess" },
                    { new Guid("0d315544-d46d-446b-9cfd-22cfa91022ac"), "codmw.jpg", "Call of Duty MW" },
                    { new Guid("3a908d63-7744-4a06-a9a3-f618d02dc0c1"), "csgo.jpg", "CS:GO" },
                    { new Guid("07d5aa64-1a9f-47b5-8fda-41a7cd7bab0c"), "fifa22.jpg", "Fifa 22" },
                    { new Guid("aa55236f-5a54-44d8-afb6-c76e3e66c76d"), "madden.jpg", "Madden NFL 22" },
                    { new Guid("98ad5e4b-ea26-43a3-9534-47c3e71e750a"), "nba2k.jpg", "NBA 2K22" },
                    { new Guid("f1252346-bd75-4948-a853-4a8e4479241d"), "apex.jpg", "Apex Legends" },
                    { new Guid("32784a46-c8fc-4d7a-bf53-801ff10abed4"), "leagueoflegends.jpg", "League of Legends" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("07d5aa64-1a9f-47b5-8fda-41a7cd7bab0c"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("0d315544-d46d-446b-9cfd-22cfa91022ac"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("3205bd33-5928-4684-bddd-792b614bb617"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("32784a46-c8fc-4d7a-bf53-801ff10abed4"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("3a908d63-7744-4a06-a9a3-f618d02dc0c1"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("98ad5e4b-ea26-43a3-9534-47c3e71e750a"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("aa55236f-5a54-44d8-afb6-c76e3e66c76d"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("d0e99a19-0040-43c9-bb84-53fd1221411b"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("f1252346-bd75-4948-a853-4a8e4479241d"));

            migrationBuilder.DropColumn(
                name: "Elo",
                table: "GameStats");

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "GameStats",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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
    }
}
