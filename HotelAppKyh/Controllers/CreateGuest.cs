using HotelAppKyh.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppKyh.Controllers
{
    internal class CreateGuest
    {
        public AppDbContext myContext { get; set; }
        public CreateGuest(AppDbContext context)
        {
            myContext = context;
        }

        public void run()
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

            Console.WriteLine("Gäst skapad!");
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();

        }

    }
}
