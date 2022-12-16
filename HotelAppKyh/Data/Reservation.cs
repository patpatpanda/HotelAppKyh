using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using HotelAppKyh.Controllers;
using Microsoft.EntityFrameworkCore;

namespace HotelAppKyh.Data
{
    public class Reservation 
    {
        
            public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Guest? Guest { get; set; }
        public Room? Room { get; set; }

       



        public void MakeReservation(AppDbContext myContext)
        {
            var reservation = new Reservation();
            var numberOfDays = NumberOfDays();
           reservation.DateStart  = CheckInDate();
            reservation.DateEnd = DateStart.AddDays(numberOfDays);
            var reservationsAllDates = ReservationsAllDates();

            List<Room> availableRooms = new List<Room>();
            foreach (var room in myContext.Rooms.ToList())
            {
                bool roomIsFree = true;
                foreach (var res in myContext.Reservations.Include(r => r.Room).Where(r => r.Room == room))
                {
                    for (var dt = res.DateStart; dt <= res.DateEnd; dt = dt.AddDays(1))
                    {
                        if (reservationsAllDates.Contains(dt))
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
                    availableRooms.Add(room);
                }
                    
               
            }

            ReservationInfoText(reservation,numberOfDays);
            NoAvailbleRoomsMessage(new List<Room>( availableRooms));
            AvailbleRoomsMessage(new List<Room>( availableRooms));

            ChooseRoom(myContext, reservation);



            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine(" Bokningen lyckades !");
            Console.WriteLine(" ==============================================================================");
            Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
            Console.WriteLine($" {reservation.DateStart.ToShortDateString()}\t{reservation.DateEnd.ToShortDateString()}\t{numberOfDays}");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n Tryck enter för att fortsätta");
            Console.ReadLine();
        }

       
        private static void ChooseRoom(AppDbContext myContext, Reservation reservation)
        {
            Console.WriteLine("\n Välj rum genom att ange rumid");
            int roomId = int.Parse(Console.ReadLine());
            reservation.Room = myContext.Rooms
                .Where(r => r.RoomId == roomId)
                .FirstOrDefault();
            Console.WriteLine("\n Välj rum genom att ange rumid");
            int guestId = int.Parse(Console.ReadLine());
            reservation.Guest = myContext.Guests
                .Where(r => r.GuestId == guestId)
                .FirstOrDefault();

            myContext.Add(reservation);
            myContext.SaveChanges();
        }

        private void AvailbleRoomsMessage(List<Room> availableRooms)
        {
            Console.Clear();
            Console.WriteLine("\n\n\n Lediga rum redo för att bokas");
            Console.WriteLine("\n Id\tTyp\t\tStorlek\t\tSängar\t\tPris");
            Console.WriteLine(" ==================================================================");

            foreach (var room in availableRooms.OrderBy(r => r.RoomId))
            {
                Console.WriteLine(
                    $" {room.RoomId}\t{room.RoomType}\t\t{room.RoomSize}\t\t{room.NumberOfBeds}\t\t{room.RoomPrice}");
                Console.WriteLine(" ------------------------------------------------------------------");
                
            }

            Console.ReadLine();
        }

        private static void NoAvailbleRoomsMessage(List<Room> availableRooms)
        {
            Console.Clear();
            if (availableRooms.Count() < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n There are no cars available for these dates. Please try another date");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine(" Press any key to continue");
                Console.ReadLine();
                return;
            }
        }

        private static void ReservationInfoText(Reservation reservation, int numberOfDays)
        {
            Console.Clear();
            Console.WriteLine("Boknings infortmation");
            Console.WriteLine(" ==================================================================");
            Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
            Console.WriteLine(
                $" {reservation.DateStart.ToShortDateString()}\t{reservation.DateEnd.ToShortDateString()}\t{numberOfDays}");
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }


        private List<DateTime> ReservationsAllDates()
        {
            List<DateTime> reservationsAllDates = new List<DateTime>();
            for (var dt = DateStart; dt <= DateEnd; dt = dt.AddDays(1))
            {
                reservationsAllDates.Add(dt);
            }

            return reservationsAllDates;
        }

        private DateTime CheckInDate()
        {
            Console.Clear();
            DateStart = new DateTime(2000, 01, 01, 23, 59, 59);
            while (DateStart < DateTime.Now.Date)
            {
                Console.Write("Vilken dag vill du checka in?: ");
                DateStart = Convert.ToDateTime(Console.ReadLine());
                


            }

            return DateStart;
        }

        private int NumberOfDays()
        {
            Console.Clear();
            Console.Write("Hur många nätter vill du stanna?: ");
            int numberOfDays = int.Parse(Console.ReadLine());
            return numberOfDays;
        }

       
    }
}
