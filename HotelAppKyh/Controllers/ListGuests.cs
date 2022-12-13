using HotelAppKyh.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppKyh.Controllers
{
    internal class ListGuests
    {
        public AppDbContext myContext { get; set; }
        public ListGuests(AppDbContext context)
        {
            myContext = context;
        }

        public void run()
        {
            Console.Clear();
            Console.WriteLine(" Bookings information");
            Console.WriteLine("Id\tFname\t\tLname\t\tPhone");
            Console.WriteLine("================================================");
            foreach (var guest in myContext.Guests.OrderBy(x => x.GuestId))
            {

                Console.WriteLine($"{guest.GuestId}\t{guest.FirstName}\t\t{guest.LastName}\t{guest.PhoneNumber}");

            }

            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }
    }
}
