using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cms_server.Migrations
{
    /// <inheritdoc />
    public partial class AddFloorNameToFloor_Fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FloorName",
                table: "Floor",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FloorName",
                table: "Floor");
        }
    }
}
