using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAppKyh.Migrations
{
    public partial class newClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookedGuestGuestId = table.Column<int>(type: "int", nullable: false),
                    BookedRoomRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Guests_BookedGuestGuestId",
                        column: x => x.BookedGuestGuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_BookedRoomRoomId",
                        column: x => x.BookedRoomRoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookedGuestGuestId",
                table: "Reservations",
                column: "BookedGuestGuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookedRoomRoomId",
                table: "Reservations",
                column: "BookedRoomRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
