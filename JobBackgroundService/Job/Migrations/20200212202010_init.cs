using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Temp = table.Column<int>(nullable: false),
                    FeelsLike = table.Column<int>(nullable: false),
                    Condition = table.Column<string>(nullable: true),
                    WindSpeed = table.Column<int>(nullable: false),
                    WindDirection = table.Column<string>(nullable: true),
                    PressureMM = table.Column<int>(nullable: false),
                    Humidity = table.Column<int>(nullable: false),
                    Season = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Latitude", "Longitude", "Name", "Url" },
                values: new object[] { 1, 55.751379, 37.618853000000001, "Moscow", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facts");

            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
