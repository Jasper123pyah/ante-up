using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ante_up.Data.Migrations
{
    public partial class GameStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "WagerResult",
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
                    table.PrimaryKey("PK_WagerResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WagerResult_Account_AccountId",
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

            migrationBuilder.CreateIndex(
                name: "IX_WagerResult_AccountId",
                table: "WagerResult",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WagerResult");

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

            migrationBuilder.CreateTable(
                name: "WagerResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Earnings = table.Column<int>(type: "int", nullable: false),
                    GameName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WagerDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                name: "IX_WagerResults_AccountId",
                table: "WagerResults",
                column: "AccountId");
        }
    }
}
