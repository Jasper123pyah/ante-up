using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ante_up.Data.Migrations
{
    public partial class Blacklist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("289833a2-9614-4ab3-8a50-a18ff21a099a"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("2c0ac839-edb0-4dc0-ab29-069b71bbeccb"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("3a4421ed-77ae-4743-8300-6d9e70b8aec8"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("3a7a7f40-43f3-4bc2-a638-84331664ecbd"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("879c1a50-ea99-4d20-bbac-a34d230ea98f"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("a3436386-f23f-46f6-8759-27459dfe9b7f"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("ac2a81d9-e219-4f48-9577-0b3abd729392"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("ad32db4b-7e53-4857-a98a-774063f94420"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("d667e826-f83b-4f6f-9ccc-38f7a04dac5c"));

            migrationBuilder.CreateTable(
                name: "Blacklisted",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AccountId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WagerId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blacklisted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blacklisted_Wager_WagerId",
                        column: x => x.WagerId,
                        principalTable: "Wager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_Blacklisted_WagerId",
                table: "Blacklisted",
                column: "WagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blacklisted");

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

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("289833a2-9614-4ab3-8a50-a18ff21a099a"), "fortnite.jpg", "Fortnite" },
                    { new Guid("ac2a81d9-e219-4f48-9577-0b3abd729392"), "chess.jpg", "Chess" },
                    { new Guid("2c0ac839-edb0-4dc0-ab29-069b71bbeccb"), "codmw.jpg", "Call of Duty MW" },
                    { new Guid("d667e826-f83b-4f6f-9ccc-38f7a04dac5c"), "csgo.jpg", "CS:GO" },
                    { new Guid("3a7a7f40-43f3-4bc2-a638-84331664ecbd"), "fifa22.jpg", "Fifa 22" },
                    { new Guid("879c1a50-ea99-4d20-bbac-a34d230ea98f"), "madden.jpg", "Madden NFL 22" },
                    { new Guid("a3436386-f23f-46f6-8759-27459dfe9b7f"), "nba2k.jpg", "NBA 2K22" },
                    { new Guid("3a4421ed-77ae-4743-8300-6d9e70b8aec8"), "apex.jpg", "Apex Legends" },
                    { new Guid("ad32db4b-7e53-4857-a98a-774063f94420"), "leagueoflegends.jpg", "League of Legends" }
                });
        }
    }
}
