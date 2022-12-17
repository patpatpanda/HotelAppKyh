using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using HotelAppKyh.Controllers;
using HotelAppKyh.Migrations;
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

        public Reservation(AppDbContext context)
        {
            myContext = context;
        }

        public Reservation()
        {
        }

        public AppDbContext myContext { get; set; }

        public void CreateReservation()
        {
            var res = new Reservation(myContext);
            var guest = new Guest();
            guest.FirstName = "fdfdf";
            guest.LastName = "334";
            guest.PhoneNumber = "3232";
            res.Guest = guest;


            var room = new Room();
            room.RoomType = "dsd";
            room.NumberOfBeds = 2;
            room.RoomSize = 30;
            room.RoomPrice = 500;


            res.Room = room;
            
            res.DateStart = Convert.ToDateTime(Console.ReadLine());
            res.DateEnd = Convert.ToDateTime(Console.ReadLine());
            myContext.Add(res);
            myContext.SaveChanges();
        }

        
    }



}