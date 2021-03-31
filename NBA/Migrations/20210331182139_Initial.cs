using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBA.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(type: "varchar(60) CHARACTER SET utf8mb4", maxLength: 60, nullable: false),
                    Location = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    NbaTeamsChampionships = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlayerName = table.Column<string>(type: "varchar(60) CHARACTER SET utf8mb4", maxLength: 60, nullable: false),
                    Position = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    JerseyNumber = table.Column<int>(type: "int", nullable: false),
                    NbaPlayersChampionships = table.Column<int>(type: "int", nullable: false),
                    PlayOffs = table.Column<int>(type: "int", nullable: false),
                    AllStars = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Location", "NbaTeamsChampionships", "TeamName" },
                values: new object[,]
                {
                    { 1, "Atlanta", 7, "Hawks" },
                    { 29, "Utah", 7, "Jazz" },
                    { 28, "Toronto", 7, "Raptors" },
                    { 27, "Sacramento", 7, "Kings" },
                    { 26, "Portland", 7, "Trail Blazers" },
                    { 25, "Phoenix", 7, "Suns" },
                    { 24, "Philadelphia", 7, "76ers" },
                    { 23, "Orlando", 7, "Magic" },
                    { 22, "San Antonio", 7, "Spurs" },
                    { 21, "Oklakhoma", 7, "Thunder" },
                    { 20, "New York", 7, "Knicks" },
                    { 19, "Charlotte", 7, "Hornets" },
                    { 18, "Minnesota", 7, "Timberwolves" },
                    { 17, "Milwaukee", 7, "Bucks" },
                    { 30, "Washington", 7, "Wizards" },
                    { 16, "Miami", 7, "Heat" },
                    { 14, "Los Angeles", 7, "Lakers" },
                    { 13, "Los Angeles", 7, "Clippers" },
                    { 12, "Indiana", 7, "Pacers" },
                    { 11, "Houston", 7, "Rockets" },
                    { 10, "Golden State", 7, "Warriors" },
                    { 9, "Detroit", 7, "Pistons" },
                    { 8, "Denver", 7, "Nuggets" },
                    { 7, "Dallas", 7, "Mavericks" },
                    { 6, "Cleveland", 7, "Cavaliers" },
                    { 5, "Chicago", 7, "Bulls" },
                    { 4, "Hornets", 7, "Hornets" },
                    { 3, "Brooklyn", 7, "Nets" },
                    { 2, "Boston", 7, "Celtics" },
                    { 15, "Memphis", 7, "Grizzlies" },
                    { 31, "NBA", 7, "Free Agents" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
