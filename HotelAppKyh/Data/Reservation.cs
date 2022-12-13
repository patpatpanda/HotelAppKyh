using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelAppKyh.Data
{
    public class Reservation
    {
        
            public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Guest Guest { get; set; }
        public Room Room { get; set; } 



        public void MakeReservation(AppDbContext myContext)
        {
            Console.Write("Hur många nätter vill du stanna?: ");
            int numerOfDays = int.Parse(Console.ReadLine());

            DateStart = new DateTime(2000, 01, 01, 23, 59, 59);
            while (DateStart < DateTime.Now.Date)
            {
                Console.Write("Vilken dag vill du checka in?: ");
                DateStart = Convert.ToDateTime(Console.ReadLine());
            }

            DateEnd = DateStart.AddDays(numerOfDays);
            List<DateTime> reservationsAllDates = new List<DateTime>();
            for (var dt = DateStart; dt <= DateEnd; dt = dt.AddDays(1))
            {
                reservationsAllDates.Add(dt);
            }
            List<Room> availableRooms = new List<Room>();
            foreach (var room in myContext.Rooms.ToList())
            {

                bool roomIsFree = true;
                foreach (var res in myContext.Reservations.Include(r => r.Room).Where(r => r.Room == room) )
                {
                    for (var dt = res.DateStart; dt <= res.DateEnd; dt = dt.AddDays(1))
                    {
                        if (reservationsAllDates.Contains(dt))
                        {
                            roomIsFree = false;
                        }
                    }

                    if (!roomIsFree)
                        break;
                }
                if(roomIsFree)
                    availableRooms.Add(room);

            }

            
            
        }
    }
}
