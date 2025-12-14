using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace groupby.Console.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "computer",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    videocard = table.Column<int>(type: "INTEGER", nullable: false),
                    power = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computer", x => x.ComputerId);
                });

            migrationBuilder.CreateTable(
                name: "cyberclubs",
                columns: table => new
                {
                    cyberclub_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name_cyberclub = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cyberclubs", x => x.cyberclub_id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CyberClubId = table.Column<int>(type: "INTEGER", nullable: false),
                    name_employee = table.Column<string>(type: "TEXT", nullable: true),
                    salary = table.Column<int>(type: "INTEGER", nullable: false),
                    position = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_employees_cyberclubs_CyberClubId",
                        column: x => x.CyberClubId,
                        principalTable: "cyberclubs",
                        principalColumn: "cyberclub_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gaming_places",
                columns: table => new
                {
                    GamingPlaceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CyberClubId = table.Column<int>(type: "INTEGER", nullable: false),
                    ComputerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    is_ordered = table.Column<bool>(type: "INTEGER", nullable: false),
                    Seat = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gaming_places", x => x.GamingPlaceId);
                    table.ForeignKey(
                        name: "FK_gaming_places_computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gaming_places_cyberclubs_CyberClubId",
                        column: x => x.CyberClubId,
                        principalTable: "cyberclubs",
                        principalColumn: "cyberclub_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_CyberClubId",
                table: "employees",
                column: "CyberClubId");

            migrationBuilder.CreateIndex(
                name: "IX_gaming_places_ComputerId",
                table: "gaming_places",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_gaming_places_CyberClubId",
                table: "gaming_places",
                column: "CyberClubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "gaming_places");

            migrationBuilder.DropTable(
                name: "computer");

            migrationBuilder.DropTable(
                name: "cyberclubs");
        }
    }
}
