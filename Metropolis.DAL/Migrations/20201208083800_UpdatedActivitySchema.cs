using Microsoft.EntityFrameworkCore.Migrations;

namespace Metropolis.DAL.Migrations
{
    public partial class UpdatedActivitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Streets_StreetFk",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_Activities_StreetFk",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StreetFk",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "ActivityType",
                table: "Activities",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlternativeStreet",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Activities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "Activities",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternativeStreet",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "ActivityType",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "StreetFk",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    StreetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlternativeStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.StreetId);
                });

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
    }
}
