using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class FinalBookingImplementation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingEnd",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingStart",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Bookings",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "Bookings",
                newName: "EndTime");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Bookings",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Bookings",
                newName: "RoomNumber");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BookingEnd",
                table: "Bookings",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BookingStart",
                table: "Bookings",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "Bookings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
