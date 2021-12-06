using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ante_up.Data.Migrations
{
    public partial class GameStatsTweak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Earnings",
                table: "GameStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Losses",
                table: "GameStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wins",
                table: "GameStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("e627732a-2a8c-489d-9f37-913a975e77bc"), "fortnite.jpg", "Fortnite" },
                    { new Guid("0d1bb319-4447-4c00-9fd9-dd47fd4d1e70"), "chess.jpg", "Chess" },
                    { new Guid("c512aaff-7a84-4671-b7a8-634e63c24dca"), "codmw.jpg", "Call of Duty MW" },
                    { new Guid("e195bca3-072c-49f5-932b-eade0c127444"), "csgo.jpg", "CS:GO" },
                    { new Guid("81f84fbf-8c4c-47b8-bed8-689d0987c5f2"), "fifa22.jpg", "Fifa 22" },
                    { new Guid("61a649c1-4730-42c6-a55e-0ba386de2cf2"), "madden.jpg", "Madden NFL 22" },
                    { new Guid("750ed041-c547-450d-95fc-f724b6d520a1"), "nba2k.jpg", "NBA 2K22" },
                    { new Guid("e349773e-c6d8-4cf9-bf21-9eed8652ea19"), "apex.jpg", "Apex Legends" },
                    { new Guid("ede1df29-350b-4d8b-acdc-2b6db965a71d"), "leagueoflegends.jpg", "League of Legends" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("0d1bb319-4447-4c00-9fd9-dd47fd4d1e70"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("61a649c1-4730-42c6-a55e-0ba386de2cf2"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("750ed041-c547-450d-95fc-f724b6d520a1"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("81f84fbf-8c4c-47b8-bed8-689d0987c5f2"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("c512aaff-7a84-4671-b7a8-634e63c24dca"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("e195bca3-072c-49f5-932b-eade0c127444"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("e349773e-c6d8-4cf9-bf21-9eed8652ea19"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("e627732a-2a8c-489d-9f37-913a975e77bc"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("ede1df29-350b-4d8b-acdc-2b6db965a71d"));

            migrationBuilder.DropColumn(
                name: "Earnings",
                table: "GameStats");

            migrationBuilder.DropColumn(
                name: "Losses",
                table: "GameStats");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "GameStats");

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
    }
}
