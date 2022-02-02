using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ante_up.Data.Migrations
{
    public partial class GameEdits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("3edb06a4-40bc-4312-b0c9-89a99d4ceeb9"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("40f6c971-a12e-427b-81f9-6cf930c624dd"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("410f7a38-d677-4590-96ac-4fc4f7516670"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("6df86239-16bc-493e-aec8-5addee1c57d6"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("6f3816b9-9364-4745-94ee-dd063621bb99"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("a1fd929a-d1ea-4c20-ba96-e7a1fb81cf0e"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("de47636f-961f-4489-ad8e-44aa3d66c526"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("e1622627-b098-4291-8da0-403b33b53702"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("eceda76c-95c7-4e8f-af8f-dbf710c5be0d"));

            migrationBuilder.AddColumn<string>(
                name: "BannerImage",
                table: "Game",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "WaitingTime",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LobbySize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalPlayers = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LobbySize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LobbySize_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "BannerImage", "Image", "Name", "WaitingTime" },
                values: new object[,]
                {
                    { new Guid("04d2ca60-af9b-4ef9-8dad-3cc186a2f8ea"), "", "fortnite.jpg", "Fortnite", 60 },
                    { new Guid("0b7111cf-a5ca-474d-a193-a82d4c574354"), "", "chess.jpg", "Chess", 60 },
                    { new Guid("525811c0-0678-4831-89f2-740717b3778e"), "", "codmw.jpg", "Call of Duty MW", 60 },
                    { new Guid("e9c47219-0a33-427f-8f6c-522ad211dd0d"), "", "csgo.jpg", "CS:GO", 60 },
                    { new Guid("2999967b-8765-4dc3-a97b-e885e42cbb38"), "", "fifa22.jpg", "Fifa 22", 60 },
                    { new Guid("b8ec4a38-9703-4bdd-8827-ae15d95e470a"), "", "madden.jpg", "Madden NFL 22", 60 },
                    { new Guid("431a62a6-9120-4316-979c-1baee4856970"), "", "nba2k.jpg", "NBA 2K22", 60 },
                    { new Guid("3fd24b23-3d05-40e5-afca-23a271c5a297"), "", "apex.jpg", "Apex Legends", 60 },
                    { new Guid("18146b6d-21a5-4e83-83d7-19de51b5f9bb"), "", "leagueoflegends.jpg", "League of Legends", 60 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LobbySize_GameId",
                table: "LobbySize",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LobbySize");

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("04d2ca60-af9b-4ef9-8dad-3cc186a2f8ea"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("0b7111cf-a5ca-474d-a193-a82d4c574354"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("18146b6d-21a5-4e83-83d7-19de51b5f9bb"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("2999967b-8765-4dc3-a97b-e885e42cbb38"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("3fd24b23-3d05-40e5-afca-23a271c5a297"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("431a62a6-9120-4316-979c-1baee4856970"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("525811c0-0678-4831-89f2-740717b3778e"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("b8ec4a38-9703-4bdd-8827-ae15d95e470a"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("e9c47219-0a33-427f-8f6c-522ad211dd0d"));

            migrationBuilder.DropColumn(
                name: "BannerImage",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "WaitingTime",
                table: "Game");

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("6df86239-16bc-493e-aec8-5addee1c57d6"), "fortnite.jpg", "Fortnite" },
                    { new Guid("de47636f-961f-4489-ad8e-44aa3d66c526"), "chess.jpg", "Chess" },
                    { new Guid("410f7a38-d677-4590-96ac-4fc4f7516670"), "codmw.jpg", "Call of Duty MW" },
                    { new Guid("6f3816b9-9364-4745-94ee-dd063621bb99"), "csgo.jpg", "CS:GO" },
                    { new Guid("3edb06a4-40bc-4312-b0c9-89a99d4ceeb9"), "fifa22.jpg", "Fifa 22" },
                    { new Guid("eceda76c-95c7-4e8f-af8f-dbf710c5be0d"), "madden.jpg", "Madden NFL 22" },
                    { new Guid("40f6c971-a12e-427b-81f9-6cf930c624dd"), "nba2k.jpg", "NBA 2K22" },
                    { new Guid("a1fd929a-d1ea-4c20-ba96-e7a1fb81cf0e"), "apex.jpg", "Apex Legends" },
                    { new Guid("e1622627-b098-4291-8da0-403b33b53702"), "leagueoflegends.jpg", "League of Legends" }
                });
        }
    }
}
