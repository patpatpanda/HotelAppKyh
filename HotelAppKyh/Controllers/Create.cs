using HotelAppKyh.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppKyh.Controllers
{
   public class Create : Reservation
    {
        public AppDbContext myContext { get; set; }
        public Create(AppDbContext context)
        {
            myContext = context;
        }

        public void AddGuest()
        {
            Console.Clear();
            var guest = new Guest();
            Console.Write("Ange förstanamn : ");
            guest.FirstName = Console.ReadLine();
            Console.Write("Ange efternamn : ");
            guest.LastName = Console.ReadLine();
            Console.Write("Ange telefonnummer : ");
            guest.PhoneNumber = Console.ReadLine();



            myContext.Guests.Add(guest);
            myContext.SaveChanges();
            ContinueMessage();
        }

        public void AddRoom()
        {
            Console.Clear();
            var room = new Room();
            Console.WriteLine("Ange typ av rum  ");
            Console.Write("enkel eller dubbel: ");

            room.RoomType = Console.ReadLine().ToLower();
            while (true)
            {
                if (room.RoomType == "enkel")
                {
                    room.NumberOfBeds = 1;
                    break;
                }

                if (room.RoomType == "dubbel")
                {
                    room.NumberOfBeds = 2;
                    break;
                }

                if (room.RoomType != "dubbel" || room.RoomType != "enkel")
                {
                    Console.Clear();
                    Console.WriteLine("Felaktigt val");
                    Console.Write("Ange typ av rum : ");

                    room.RoomType = Console.ReadLine().ToLower();
                }
            }

            Console.Write("Ange antal kv/m för rummet : ");
            room.RoomSize = int.Parse(Console.ReadLine());
            Console.Write("Ange pris för rummet : ");
            room.RoomPrice = int.Parse(Console.ReadLine());
            
           
            myContext.Add(room);
            myContext.SaveChanges();
            ContinueMessage();
        }

        private static void ContinueMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lyckades !");
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
            Console.ResetColor();
        }
    }
}
