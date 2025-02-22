using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class FinalSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomSlots_AvailableDays_AvailableDayId",
                table: "RoomSlots");

            migrationBuilder.DropIndex(
                name: "IX_RoomSlots_AvailableDayId",
                table: "RoomSlots");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RoomSlots_AvailableDayId",
                table: "RoomSlots",
                column: "AvailableDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSlots_AvailableDays_AvailableDayId",
                table: "RoomSlots",
                column: "AvailableDayId",
                principalTable: "AvailableDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
