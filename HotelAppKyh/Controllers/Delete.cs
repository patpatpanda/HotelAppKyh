using HotelAppKyh.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppKyh.Controllers
{
    public class Delete
    {
        public AppDbContext myContext { get; set; }
        public Delete(AppDbContext context)
        {
            myContext = context;
        }

        public void DeleteGuest()
        {
            var read = new Read(myContext);
            read.ListGuest();
            Console.Write("Ange id för gäst du vill radera: ");
            int guestId = int.Parse(Console.ReadLine());
            var delete = myContext.Guests.First(x => x.GuestId == guestId);
            

            myContext.Guests.Remove(delete);
            myContext.SaveChanges();

            Console.WriteLine("Gästen har raderats!");
            Console.Write("Tryck Enter för att fortsätta");
            Console.ReadLine();
        }

        public void DeleteRoom()
        {
            var read = new Read(myContext);
            read.ListRoom();
            Console.Write("Ange id för rum du vill radera: ");
            int roomId = int.Parse(Console.ReadLine());
            var delete = myContext.Rooms.First(x => x.RoomId == roomId);
            
            myContext.Rooms.Remove(delete);
            myContext.SaveChanges();
            Console.WriteLine("Rummet har raderats!");
            Console.Write("Tryck Enter för att fortsätta");
            Console.ReadLine();

        }
    }
}
