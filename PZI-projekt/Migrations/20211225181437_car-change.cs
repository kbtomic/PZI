using Microsoft.EntityFrameworkCore.Migrations;

namespace PZI_projekt.Migrations
{
    public partial class carchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBonnetOpened",
                table: "Car",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrunkOpened",
                table: "Car",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OilOK",
                table: "Car",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBonnetOpened",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "IsTrunkOpened",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "OilOK",
                table: "Car");
        }
    }
}
