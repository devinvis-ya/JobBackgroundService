using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Migrations
{
    public partial class add_placeid_to_fact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Facts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Facts");
        }
    }
}
