using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ante_up.Data.Migrations
{
    public partial class GamertagToGameStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamerTag");

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

            migrationBuilder.AddColumn<string>(
                name: "GamerTag",
                table: "GameStats",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "GamerTag",
                table: "GameStats");

            migrationBuilder.CreateTable(
                name: "GamerTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Service = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tag = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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

            migrationBuilder.CreateIndex(
                name: "IX_GamerTag_AccountId",
                table: "GamerTag",
                column: "AccountId");
        }
    }
}
