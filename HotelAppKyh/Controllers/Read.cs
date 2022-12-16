using HotelAppKyh.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppKyh.Controllers
{
    public class Read
    {

        public AppDbContext myContext { get; set; }

        public Read(AppDbContext context)
        {
            myContext = context;
        }

        public void ListGuest()
        {
            Console.Clear();
            
            Console.WriteLine("Id\tFname\t\tLname\t\tPhone");
            Console.WriteLine("================================================");
            foreach (var guest in myContext.Guests.OrderBy(x => x.GuestId))
            {

                Console.WriteLine($"{guest.GuestId}\t{guest.FirstName}\t\t{guest.LastName}\t\t{guest.PhoneNumber}");

            }

            Console.WriteLine("--------------------------------------------------");

        }

        public void ListRoom()
        {
            Console.Clear();
            Console.WriteLine("Id\tType\t\tSize\t\tBeds\t\tPrice");
            Console.WriteLine("==============================================================");
            foreach (var room in myContext.Rooms.OrderBy(x => x.RoomId))
            {

                Console.WriteLine(
                    $"{room.RoomId}\t{room.RoomType}\t\t{room.RoomSize}kvm\t\t{room.NumberOfBeds}\t\t{room.RoomPrice}");

            }

            Console.WriteLine("---------------------------------------------------------------");

            
        }
    }
}
