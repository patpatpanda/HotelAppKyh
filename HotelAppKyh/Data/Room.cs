using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppKyh.Data
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public int RoomSize { get; set; }

        public int NumberOfBeds { get; set; }
        public int RoomPrice { get; set; }

        public void CreateRoom(AppDbContext myContext)
        {


            Console.Clear();
            var room = new Room();
            Console.Write("Ange typ av rum : ");

            room.RoomType = Console.ReadLine();
            var typeToLower = room.RoomType.ToLower();

            if (typeToLower == "enkel")
            {
                room.NumberOfBeds = 1;
                Console.Write("Ange antal kv/m för rummet : ");
                room.RoomSize = int.Parse(Console.ReadLine());

                Console.WriteLine("Rummet har skapats!");
                Console.WriteLine("Tryck enter för att fortsätta");
                Console.ReadLine();

            }

            else if (typeToLower == "dubbel")
            {
                room.NumberOfBeds = 2;

                Console.Write("Ange antal kv/m för rummet : ");
                room.RoomSize = int.Parse(Console.ReadLine());


                Console.WriteLine("Rummet har skapats!");
                Console.WriteLine("Tryck enter för att fortsätta");
                Console.ReadLine();


            }
            else if (typeToLower != "enkel" || typeToLower != "dubbel")
            {
                Console.WriteLine("Typ av rum kan endast anges som dubbel eller enkel");
                Console.WriteLine("Tryck enter för att fortsätta");
                Console.ReadLine();

            }


            myContext.Add(room);
            myContext.SaveChanges();
        }

        public void ListAllRooms(AppDbContext myContext)
        {
            Console.Clear();
            foreach (var room in myContext.Rooms)
                Console.WriteLine($"Rumsnummer = {room.RoomId} *** " +
                                  $"Typ av rum = {room.RoomType} *** Storlek = {room.RoomSize}kvm *** Antal sängar = " +
                                  $"{room.NumberOfBeds} *** Pris = {room.RoomPrice} kronor");
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }
        public void EditRoom(AppDbContext myContext)


        {
            Console.Clear();

            var editRoom = new Room();

            Console.Write("Ange rummets id : ");
            int roomId = int.Parse(Console.ReadLine());

            editRoom = myContext.Rooms.First(x => x.RoomId == roomId);

            Console.Write("Ange typ av rum : ");
            string newTypeOfRoom = Console.ReadLine();
            Console.Write("Ange storlek :");
            int newSizeOfRoom = int.Parse(Console.ReadLine());
            Console.WriteLine("Pris : ");
            int newPrice = int.Parse(Console.ReadLine());
            editRoom.NewRoomProps(newTypeOfRoom, newSizeOfRoom,newPrice);

            Console.WriteLine();
            Console.WriteLine("Tryck enter for att fortsätta");
            Console.ReadLine();
            myContext.SaveChanges();
        }
        public void NewRoomProps(string roomType, int roomSize,int roomPrice)
        {
            RoomType = roomType;
            RoomSize = roomSize;
            RoomPrice = roomPrice;
        }
    }
}
