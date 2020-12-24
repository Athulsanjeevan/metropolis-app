using Microsoft.EntityFrameworkCore.Migrations;

namespace Metropolis.DAL.Migrations
{
    public partial class AddForeignKeyToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "streetStatus",
                table: "Streets",
                newName: "StreetStatus");

            migrationBuilder.RenameColumn(
                name: "streetName",
                table: "Streets",
                newName: "StreetName");

            migrationBuilder.RenameColumn(
                name: "alternativeStreet",
                table: "Streets",
                newName: "AlternativeStreet");

            migrationBuilder.RenameColumn(
                name: "streetId",
                table: "Streets",
                newName: "StreetId");

            migrationBuilder.RenameColumn(
                name: "streetFK",
                table: "Activities",
                newName: "StreetFk");

            migrationBuilder.RenameColumn(
                name: "scheduledDate",
                table: "Activities",
                newName: "ScheduledDate");

            migrationBuilder.RenameColumn(
                name: "activityType",
                table: "Activities",
                newName: "ActivityType");

            migrationBuilder.RenameColumn(
                name: "activityName",
                table: "Activities",
                newName: "ActivityName");

            migrationBuilder.RenameColumn(
                name: "activityId",
                table: "Activities",
                newName: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_StreetFk",
                table: "Activities",
                column: "StreetFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Streets_StreetFk",
                table: "Activities",
                column: "StreetFk",
                principalTable: "Streets",
                principalColumn: "StreetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Streets_StreetFk",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_StreetFk",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "StreetStatus",
                table: "Streets",
                newName: "streetStatus");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Streets",
                newName: "streetName");

            migrationBuilder.RenameColumn(
                name: "AlternativeStreet",
                table: "Streets",
                newName: "alternativeStreet");

            migrationBuilder.RenameColumn(
                name: "StreetId",
                table: "Streets",
                newName: "streetId");

            migrationBuilder.RenameColumn(
                name: "StreetFk",
                table: "Activities",
                newName: "streetFK");

            migrationBuilder.RenameColumn(
                name: "ScheduledDate",
                table: "Activities",
                newName: "scheduledDate");

            migrationBuilder.RenameColumn(
                name: "ActivityType",
                table: "Activities",
                newName: "activityType");

            migrationBuilder.RenameColumn(
                name: "ActivityName",
                table: "Activities",
                newName: "activityName");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "Activities",
                newName: "activityId");
        }
    }
}
