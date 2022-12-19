using HotelAppKyh.Data;
using Microsoft.EntityFrameworkCore;
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
            Console.WriteLine("****************** All guests **********************");
            Console.WriteLine();
            Console.WriteLine("Id\tFname\t\tLname\t\tPhone");
            Console.WriteLine("================================================");
            foreach (var guest in myContext.Guests.OrderBy(x => x.GuestId))
            {

                Console.WriteLine($"{guest.GuestId}\t{guest.FirstName}\t\t{guest.LastName}\t\t{guest.PhoneNumber}");

            }

            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("Tryck Enter för fortsätta !");
            Console.ReadLine();
        }

        public void ListRoom()
        {
            Console.Clear();
            Console.WriteLine("****************** All rooms **********************");
            Console.WriteLine();
            Console.WriteLine("Id\tType\t\tSize\t\tBeds\t\tPrice");
            Console.WriteLine("==============================================================");
            foreach (var room in myContext.Rooms.OrderBy(x => x.RoomId))
            {

                Console.WriteLine(
                    $"{room.RoomId}\t{room.RoomType}\t\t{room.RoomSize}kvm\t\t{room.NumberOfBeds}\t\t{room.RoomPrice}");

            }

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Tryck Enter för fortsätta !");
            Console.ReadLine();
        }

        public void ListReservations()
        {
           

            Console.Clear();
            Console.WriteLine("********* All reservations ************");
            Console.WriteLine();
            Console.WriteLine("Id\tDateStart\t\tDateEnd\t\tRoomId\t\tGuestId");
            Console.WriteLine("=====================================================================================================================");

            foreach (var guest in myContext.Guests.ToList())
            
                
            
            foreach (var room in myContext.Rooms.ToList())

            foreach (var booking in myContext.Reservations.Include(b => b.Room).Include(b => b.Guest)
                         .Where(b => b.Room == room).Where(b => b.Guest  == guest))
                
            {
                Console.WriteLine($"{booking.Id}\t{booking.DateStart.ToShortDateString()}\t\t{booking.DateEnd.ToShortDateString()}\t\t{booking.Room.RoomId}\t\t{booking.Guest.GuestId}");
                
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Tryck Enter för fortsätta !");
            
            Console.ReadLine();



        }

          
        
    }
}
