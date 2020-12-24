using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metropolis.DAL.Migrations
{
    public partial class AddStreetAndEditActivityToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "activityType",
                table: "Activities",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "scheduledDate",
                table: "Activities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "streetFK",
                table: "Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    streetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    streetName = table.Column<string>(nullable: false),
                    alternativeStreet = table.Column<string>(nullable: true),
                    streetStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.streetId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropColumn(
                name: "scheduledDate",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "streetFK",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "activityType",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
