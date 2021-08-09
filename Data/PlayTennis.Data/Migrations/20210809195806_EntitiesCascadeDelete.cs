using Microsoft.EntityFrameworkCore.Migrations;

namespace PlayTennis.Data.Migrations
{
    public partial class EntitiesCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clubs_ClubId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clubs_ClubId",
                table: "Reservations",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clubs_ClubId",
                table: "Reservations");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clubs_ClubId",
                table: "Reservations",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
