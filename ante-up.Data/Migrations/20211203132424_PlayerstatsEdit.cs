using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ante_up.Data.Migrations
{
    public partial class PlayerstatsEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerStats");

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

            migrationBuilder.CreateTable(
                name: "GamerTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Tag = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Service = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamerTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamerTag_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GameStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GameName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Skill = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameStats_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WagerResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GameName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Earnings = table.Column<int>(type: "int", nullable: false),
                    WagerDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WagerResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WagerResults_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("0ca0de45-91db-4202-bba7-efd76fb014a0"), "fortnite.jpg", "Fortnite" },
                    { new Guid("8e5492f2-c218-4edd-860b-f6312bef9348"), "chess.jpg", "Chess" },
                    { new Guid("526ce6b2-3b1e-435a-9b16-cd00d511e81d"), "codmw.jpg", "Call of Duty MW" },
                    { new Guid("dc6a69c0-74de-4b60-b54a-a164bd12849e"), "csgo.jpg", "CS:GO" },
                    { new Guid("4b46a6a5-b631-42f5-89b4-893639026f68"), "fifa22.jpg", "Fifa 22" },
                    { new Guid("a606d10e-e775-48a7-991a-fd49e3ab73a7"), "madden.jpg", "Madden NFL 22" },
                    { new Guid("9296c4b6-cf5b-4630-8164-4ee2a86fb410"), "nba2k.jpg", "NBA 2K22" },
                    { new Guid("e038e051-3341-4151-b49c-f878a8ec7b93"), "apex.jpg", "Apex Legends" },
                    { new Guid("3472ada7-e718-4ca2-8201-d3ae28c0d91d"), "leagueoflegends.jpg", "League of Legends" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamerTag_AccountId",
                table: "GamerTag",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GameStats_AccountId",
                table: "GameStats",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_WagerResults_AccountId",
                table: "WagerResults",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamerTag");

            migrationBuilder.DropTable(
                name: "GameStats");

            migrationBuilder.DropTable(
                name: "WagerResults");

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("0ca0de45-91db-4202-bba7-efd76fb014a0"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("3472ada7-e718-4ca2-8201-d3ae28c0d91d"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("4b46a6a5-b631-42f5-89b4-893639026f68"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("526ce6b2-3b1e-435a-9b16-cd00d511e81d"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("8e5492f2-c218-4edd-860b-f6312bef9348"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("9296c4b6-cf5b-4630-8164-4ee2a86fb410"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("a606d10e-e775-48a7-991a-fd49e3ab73a7"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("dc6a69c0-74de-4b60-b54a-a164bd12849e"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("e038e051-3341-4151-b49c-f878a8ec7b93"));

            migrationBuilder.CreateTable(
                name: "PlayerStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Earnings = table.Column<int>(type: "int", nullable: false),
                    GameName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Record = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Skill = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStats_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
        }
    }
}
