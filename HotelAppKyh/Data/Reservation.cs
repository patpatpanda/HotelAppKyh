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

        

        
    }



}