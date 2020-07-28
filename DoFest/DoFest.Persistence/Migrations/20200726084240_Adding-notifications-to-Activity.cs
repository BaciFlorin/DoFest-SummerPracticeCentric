using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoFest.Persistence.Migrations
{
    public partial class AddingnotificationstoActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActivityId",
                table: "Notification",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ActivityId",
                table: "Notification",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Activity_ActivityId",
                table: "Notification",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Activity_ActivityId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_ActivityId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Notification");
        }
    }
}
