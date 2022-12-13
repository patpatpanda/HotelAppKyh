using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAppKyh.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_BookedGuestGuestId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_BookedRoomRoomId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "BookedRoomRoomId",
                table: "Reservations",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "BookedGuestGuestId",
                table: "Reservations",
                newName: "GuestId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_BookedRoomRoomId",
                table: "Reservations",
                newName: "IX_Reservations_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_BookedGuestGuestId",
                table: "Reservations",
                newName: "IX_Reservations_GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_GuestId",
                table: "Reservations",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guests_GuestId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Reservations",
                newName: "BookedRoomRoomId");

            migrationBuilder.RenameColumn(
                name: "GuestId",
                table: "Reservations",
                newName: "BookedGuestGuestId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                newName: "IX_Reservations_BookedRoomRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_GuestId",
                table: "Reservations",
                newName: "IX_Reservations_BookedGuestGuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guests_BookedGuestGuestId",
                table: "Reservations",
                column: "BookedGuestGuestId",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_BookedRoomRoomId",
                table: "Reservations",
                column: "BookedRoomRoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
