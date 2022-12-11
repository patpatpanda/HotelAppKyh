using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelAppKyh.Data
{
    public class DataSeeder
    {
        public void MigrateAndSeed(AppDbContext myContext)
        {
            myContext.Database.Migrate();
            SeedCountys(myContext);
            myContext.SaveChanges();
        }

        private void SeedCountys(AppDbContext myContext)
        {


            if (!myContext.Guests.Any() || !myContext.Rooms.Any())
            {
                myContext.Guests.Add(new Guest()
                {
                    FirstName = "Gus",
                    LastName = "Griswald",
                    PhoneNumber = "07334567"

                });
                myContext.Guests.Add(new Guest()
                {
                    FirstName = "Spinelli",
                    LastName = "Adams",
                    PhoneNumber = "07014567"
                });
                myContext.Guests.Add(new Guest()
                {
                    FirstName = "Tobbe",
                    LastName = "Dethweiler",
                    PhoneNumber = "07034537"
                });
                myContext.Guests.Add(new Guest()
                {
                    FirstName = "Mike",
                    LastName = "Bloomberg",
                    PhoneNumber = "07039567"
                });
                myContext.Rooms.Add(new Room()
                {
                    RoomType = "enkel",
                    RoomSize = 30,
                    NumberOfBeds = 1,
                    RoomPrice = 1000

                });
                myContext.Rooms.Add(new Room()
                {
                    RoomType = "dubbel",
                    RoomSize = 40,
                    NumberOfBeds = 2,
                    RoomPrice = 1200

                });
                myContext.Rooms.Add(new Room()
                {
                    RoomType = "dubbel",
                    RoomSize = 50,
                    NumberOfBeds = 2,
                    RoomPrice = 1500

                });
                myContext.Rooms.Add(new Room()
                {
                    RoomType = "dubbel",
                    RoomSize = 70,
                    NumberOfBeds = 2,
                    RoomPrice = 2000

                });

            }
        }

        }
    }

