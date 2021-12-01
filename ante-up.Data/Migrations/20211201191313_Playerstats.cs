using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ante_up.Data.Migrations
{
    public partial class Playerstats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_PlayerStats_StatsId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_StatsId",
                table: "Account");

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("0a12c1ce-aedf-404b-b3d1-07d83216d961"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("136903f2-3000-4629-aab6-93ceb585844a"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("1beacc45-76ad-4a28-b945-591f7e33fcf2"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("22ca7058-60ad-4534-8d25-4b6094265517"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("62bb9825-744a-4aba-b0e1-c9d14306413b"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("7c111d25-95f9-4e67-824b-ceb101660315"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("b7816780-a87a-4d8a-898d-e953a60cb40b"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("c51d6676-4cef-4438-b960-247493ff500d"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("d9b84f28-61b3-40e0-be1d-8b3626a41867"));

            migrationBuilder.DropColumn(
                name: "StatsId",
                table: "Account");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "PlayerStats",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "Earnings",
                table: "PlayerStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GameName",
                table: "PlayerStats",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Record",
                table: "PlayerStats",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "PlayerStats",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("9520b9b0-fd19-4701-a340-be142fb62d99"), "fortnite.jpg", "Fortnite" },
                    { new Guid("241058d1-8f2b-4de2-ac6f-e7889f1b1c67"), "chess.jpg", "Chess" },
                    { new Guid("92ebeed9-4f46-4715-837e-6728787ce89e"), "codmw.jpg", "Call of Duty MW" },
                    { new Guid("6fb862bd-674c-445a-98e6-1e37eff25c5a"), "csgo.jpg", "CS:GO" },
                    { new Guid("ad3cdc7a-f7dd-47c5-a98f-686589eaf7ef"), "fifa22.jpg", "Fifa 22" },
                    { new Guid("f6aa70d9-b8f4-411b-a1b3-77b779481c41"), "madden.jpg", "Madden NFL 22" },
                    { new Guid("9c8802b9-5e90-46c8-992e-dae0d2a326e4"), "nba2k.jpg", "NBA 2K22" },
                    { new Guid("4c08a133-06c3-4597-a87c-1a77f79f83d9"), "apex.jpg", "Apex Legends" },
                    { new Guid("84402a43-52cf-4e69-9968-a9338c063479"), "leagueoflegends.jpg", "League of Legends" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_AccountId",
                table: "PlayerStats",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStats_Account_AccountId",
                table: "PlayerStats",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStats_Account_AccountId",
                table: "PlayerStats");

            migrationBuilder.DropIndex(
                name: "IX_PlayerStats_AccountId",
                table: "PlayerStats");

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("241058d1-8f2b-4de2-ac6f-e7889f1b1c67"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("4c08a133-06c3-4597-a87c-1a77f79f83d9"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("6fb862bd-674c-445a-98e6-1e37eff25c5a"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("84402a43-52cf-4e69-9968-a9338c063479"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("92ebeed9-4f46-4715-837e-6728787ce89e"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("9520b9b0-fd19-4701-a340-be142fb62d99"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("9c8802b9-5e90-46c8-992e-dae0d2a326e4"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("ad3cdc7a-f7dd-47c5-a98f-686589eaf7ef"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("f6aa70d9-b8f4-411b-a1b3-77b779481c41"));

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Earnings",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "GameName",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Record",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "PlayerStats");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Account");

            migrationBuilder.AddColumn<Guid>(
                name: "StatsId",
                table: "Account",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("136903f2-3000-4629-aab6-93ceb585844a"), "fortnite.jpg", "Fortnite" },
                    { new Guid("0a12c1ce-aedf-404b-b3d1-07d83216d961"), "chess.jpg", "Chess" },
                    { new Guid("7c111d25-95f9-4e67-824b-ceb101660315"), "codmw.jpg", "Call of Duty MW" },
                    { new Guid("c51d6676-4cef-4438-b960-247493ff500d"), "csgo.jpg", "CS:GO" },
                    { new Guid("d9b84f28-61b3-40e0-be1d-8b3626a41867"), "fifa22.jpg", "Fifa 22" },
                    { new Guid("1beacc45-76ad-4a28-b945-591f7e33fcf2"), "madden.jpg", "Madden NFL 22" },
                    { new Guid("b7816780-a87a-4d8a-898d-e953a60cb40b"), "nba2k.jpg", "NBA 2K22" },
                    { new Guid("22ca7058-60ad-4534-8d25-4b6094265517"), "apex.jpg", "Apex Legends" },
                    { new Guid("62bb9825-744a-4aba-b0e1-c9d14306413b"), "leagueoflegends.jpg", "League of Legends" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_StatsId",
                table: "Account",
                column: "StatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_PlayerStats_StatsId",
                table: "Account",
                column: "StatsId",
                principalTable: "PlayerStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
