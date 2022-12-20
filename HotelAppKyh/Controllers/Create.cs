using HotelAppKyh.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppKyh.Controllers
{
    public class Create
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

        public void CreateReservation()
        {
            var reservation = new Reservation();
            var guestReservation = new Guest();


            var read = new Read(myContext);
            read.ListGuest();
            Console.Write("Ange id för gästen som ska stå på bokningen : ");
            var guestId = int.Parse(Console.ReadLine());
            var guest = myContext.Guests.First(x => x.GuestId == guestId);
            reservation.Guest = guest;





            Console.Clear();
            Console.Write("Hur många nätter ? : ");
            int numberOfNightsStaying = int.Parse(Console.ReadLine());

            reservation.DateStart = new DateTime(2022, 12, 01, 23, 59, 59);
            while (reservation.DateStart < DateTime.Now.Date)
            {
                Console.WriteLine("\n From which date would you like your booking to start from? (yyyy-mm-dd)");
                reservation.DateStart = Convert.ToDateTime(Console.ReadLine());
            }

            // set dateEnd
            if (numberOfNightsStaying == 1) reservation.DateEnd = reservation.DateStart;
            else if (numberOfNightsStaying > 1)
                reservation.DateEnd = reservation.DateStart.AddDays(numberOfNightsStaying);

            List<DateTime> newBookingAllDates = new List<DateTime>();
            for (var dt = reservation.DateStart; dt <= reservation.DateEnd; dt = dt.AddDays(1))
            {
                newBookingAllDates.Add(dt);
            }


            List<Room> availableCars = new List<Room>();

            foreach (var room in myContext.Rooms.ToList())
            {
                bool roomIsFree = true;
                foreach (var booking in myContext.Reservations.Include(b => b.Room).Where(b => b.Room == room))
                {
                    for (var dt = booking.DateStart; dt <= booking.DateEnd; dt = dt.AddDays(1))
                    {
                        if (newBookingAllDates.Contains(dt))
                        {
                            roomIsFree = false;

                        }

                    }

                    if (!roomIsFree)
                    {
                        break;
                    }
                }


                if (roomIsFree)
                {
                    availableCars.Add(room);
                }


            }


            if (availableCars.Count() < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n Det finns inga lediga rum för valt datum");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("Tryck enter för att fortsätta");
                Console.ReadLine();
                return;
            }
            else
            {

                Console.WriteLine("\n\n\n Lediga rum redo att bokas");
                Console.WriteLine("\n Id\tTyp\t\tStorlek\t\tSängar\t\tPris");
                Console.WriteLine(" ==================================================================");

                foreach (var car in availableCars.OrderBy(r => r.RoomId))
                {
                    Console.WriteLine(
                        $" {car.RoomId}\t{car.RoomType}\t\t{car.RoomSize}\t\t{car.NumberOfBeds}\t\t{car.RoomPrice}");
                    Console.WriteLine(" ------------------------------------------------------------------");
                }
            }



            Console.WriteLine("\n Välja mellan dessa rum (ange id)");
            int roomId = int.Parse(Console.ReadLine());
            reservation.Room = myContext.Rooms
                .Where(c => c.RoomId == roomId)
                .FirstOrDefault();

            myContext.Add(reservation);
            myContext.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine(" Bookningen lyckades!");
            Console.WriteLine(" ==============================================================================");
            Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
            Console.WriteLine(
                $" {reservation.DateStart.ToShortDateString()}\t{reservation.DateEnd.ToShortDateString()}\t{numberOfNightsStaying}");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n Tryck enter för att fortsätta");
            Console.ReadLine();

        }
    }
}