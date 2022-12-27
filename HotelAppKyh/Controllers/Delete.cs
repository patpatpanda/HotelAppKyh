using HotelAppKyh.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelAppKyh.Controllers
{
    public class Delete
    {
        public  Read read { get; set; }
        public AppDbContext myContext { get; set; }
        public Delete(AppDbContext context)
        {
            myContext = context;
        }

        
        public void DeleteGuest()
        {

            var read = new Read(myContext);
            
            
            read.ListGuest();
            Console.Write("\nAnge id för gäst du vill radera: ");
            int guestId = int.Parse(Console.ReadLine());
            var delete = myContext.Guests.First(x => x.GuestId == guestId);
            var checkFor = myContext.Reservations.Any(x => x.Guest == delete);
            if (checkFor)
            {
                Console.Clear();
                Console.WriteLine("Gäst kan ej tas bort !");
                Console.WriteLine();
                Console.WriteLine("Tryck enter för att fortsätta ");
                Console.ReadLine();
            }
            else if (!checkFor)
            {
                myContext.Guests.Remove(delete);
                myContext.SaveChanges();
                ContinueMessage();
            }
            
            
           
        }

        public void CanselReservation()
        {
            var read = new Read(myContext);
            read.ListReservations();
            Console.Write("\nAnge id för att avboka rum : ");
            int resId = int.Parse(Console.ReadLine());
            var delete = myContext.Reservations.First(x => x.Id == resId);

            myContext.Reservations.Remove(delete);
            myContext.SaveChanges();
            ContinueMessage();

        }

        public void DeleteRoom()
        {
            var read = new Read(myContext);
            read.ListRoom();
            Console.Write("\nAnge id för rum du vill radera: ");
            int roomId = int.Parse(Console.ReadLine());
            var delete = myContext.Rooms.First(x => x.RoomId == roomId);
            
            myContext.Rooms.Remove(delete);
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
