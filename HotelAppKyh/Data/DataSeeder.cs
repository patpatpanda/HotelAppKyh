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

        private void SeedCountys(AppDbContext dbContext)
        {


            if (!dbContext.Guests.Any() || !dbContext.Rooms.Any())
            {
                dbContext.Guests.Add(new Guest()
                {
                    FirstName = "Gus",
                    LastName = "Griswald",
                    PhoneNumber = "07334567"

                });
                dbContext.Guests.Add(new Guest()
                {
                    FirstName = "Spinelli",
                    LastName = "Adams",
                    PhoneNumber = "07014567"
                });
                dbContext.Guests.Add(new Guest()
                {
                    FirstName = "Tobbe",
                    LastName = "Dethweiler",
                    PhoneNumber = "07034537"
                });
                dbContext.Guests.Add(new Guest()
                {
                    FirstName = "Mike",
                    LastName = "Bloomberg",
                    PhoneNumber = "07039567"
                });
                dbContext.Rooms.Add(new Room()
                {
                    RoomType = "Enkel",
                    RoomSize = 30,
                    NumberOfBeds = 1,
                    RoomPrice = 1000

                });
                dbContext.Rooms.Add(new Room()
                {
                    RoomType = "Dubbel",
                    RoomSize = 40,
                    NumberOfBeds = 2,
                    RoomPrice = 1200

                });
                dbContext.Rooms.Add(new Room()
                {
                    RoomType = "Dubbel",
                    RoomSize = 50,
                    NumberOfBeds = 2,
                    RoomPrice = 1500

                });
                dbContext.Rooms.Add(new Room()
                {
                    RoomType = "Dubbel",
                    RoomSize = 70,
                    NumberOfBeds = 2,
                    RoomPrice = 2000

                });

            }
        }

        }
    }

