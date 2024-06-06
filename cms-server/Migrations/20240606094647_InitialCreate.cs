using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cms_server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floors_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Niches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Niches_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tháp A" },
                    { 2, "Tháp B" }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "BuildingId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Floor 1" },
                    { 2, 1, "Floor 2" },
                    { 3, 1, "Floor 3" },
                    { 4, 2, "Floor 1" },
                    { 5, 2, "Floor 2" },
                    { 6, 2, "Floor 3" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "FloorId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Section A1" },
                    { 2, 2, "Section A2" },
                    { 3, 3, "Section A3" },
                    { 4, 4, "Section B1" },
                    { 5, 5, "Section B2" },
                    { 6, 6, "Section B3" }
                });

            migrationBuilder.InsertData(
                table: "Niches",
                columns: new[] { "Id", "SectionId", "Status" },
                values: new object[,]
                {
                    { 1, 3, "available" },
                    { 2, 4, "available" },
                    { 3, 5, "booked" },
                    { 4, 5, "unavailable" },
                    { 5, 6, "available" },
                    { 6, 5, "available" },
                    { 7, 3, "available" },
                    { 8, 4, "available" },
                    { 9, 3, "available" },
                    { 10, 3, "unavailable" },
                    { 11, 1, "unavailable" },
                    { 12, 5, "available" },
                    { 13, 5, "available" },
                    { 14, 1, "available" },
                    { 15, 4, "unavailable" },
                    { 16, 6, "available" },
                    { 17, 3, "available" },
                    { 18, 4, "booked" },
                    { 19, 3, "available" },
                    { 20, 5, "available" },
                    { 21, 1, "unavailable" },
                    { 22, 3, "booked" },
                    { 23, 5, "unavailable" },
                    { 24, 1, "available" },
                    { 25, 3, "unavailable" },
                    { 26, 6, "booked" },
                    { 27, 3, "available" },
                    { 28, 2, "available" },
                    { 29, 4, "booked" },
                    { 30, 5, "available" },
                    { 31, 2, "available" },
                    { 32, 4, "unavailable" },
                    { 33, 4, "booked" },
                    { 34, 5, "available" },
                    { 35, 5, "booked" },
                    { 36, 5, "booked" },
                    { 37, 4, "available" },
                    { 38, 6, "unavailable" },
                    { 39, 4, "booked" },
                    { 40, 5, "available" },
                    { 41, 6, "available" },
                    { 42, 6, "available" },
                    { 43, 4, "booked" },
                    { 44, 5, "available" },
                    { 45, 3, "available" },
                    { 46, 5, "available" },
                    { 47, 4, "available" },
                    { 48, 4, "booked" },
                    { 49, 1, "available" },
                    { 50, 6, "booked" },
                    { 51, 5, "booked" },
                    { 52, 5, "available" },
                    { 53, 2, "booked" },
                    { 54, 6, "available" },
                    { 55, 2, "available" },
                    { 56, 4, "available" },
                    { 57, 5, "booked" },
                    { 58, 3, "available" },
                    { 59, 3, "available" },
                    { 60, 6, "available" },
                    { 61, 5, "available" },
                    { 62, 3, "available" },
                    { 63, 4, "available" },
                    { 64, 3, "unavailable" },
                    { 65, 2, "booked" },
                    { 66, 4, "available" },
                    { 67, 6, "available" },
                    { 68, 4, "available" },
                    { 69, 2, "available" },
                    { 70, 3, "available" },
                    { 71, 2, "booked" },
                    { 72, 5, "available" },
                    { 73, 6, "available" },
                    { 74, 3, "booked" },
                    { 75, 2, "booked" },
                    { 76, 4, "available" },
                    { 77, 4, "available" },
                    { 78, 1, "available" },
                    { 79, 3, "available" },
                    { 80, 3, "available" },
                    { 81, 3, "unavailable" },
                    { 82, 1, "available" },
                    { 83, 1, "booked" },
                    { 84, 3, "available" },
                    { 85, 4, "available" },
                    { 86, 2, "booked" },
                    { 87, 5, "available" },
                    { 88, 4, "available" },
                    { 89, 5, "available" },
                    { 90, 3, "available" },
                    { 91, 3, "available" },
                    { 92, 3, "available" },
                    { 93, 5, "available" },
                    { 94, 2, "booked" },
                    { 95, 2, "booked" },
                    { 96, 5, "available" },
                    { 97, 5, "available" },
                    { 98, 5, "available" },
                    { 99, 3, "booked" },
                    { 100, 4, "available" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Floors_BuildingId",
                table: "Floors",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Niches_SectionId",
                table: "Niches",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_FloorId",
                table: "Sections",
                column: "FloorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Niches");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
