using Microsoft.EntityFrameworkCore.Migrations;

namespace DoFest.Persistence.Migrations
{
    public partial class AddDescriptionActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Activity",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Activity");
        }
    }
}
