using HotelAppKyh.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppKyh
{
    public class Main
    {
        public void run()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            var myContext = new AppDbContext(options.Options);

            var dataSeeder  = new DataSeeder();
            dataSeeder.MigrateAndSeed(myContext);
            var guest = new Guest();
            var room = new Room();

            
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("1 **************** Skapa ny gäst ******************");
                    Console.WriteLine("2 **************** Skapa nytt rum ******************");
                    Console.WriteLine("3 **************** Lista alla gäster ***************");
                    Console.WriteLine("4 **************** Lista alla rum ******************");
                    Console.WriteLine("5 **************** Editera gäst ********************");
                    Console.WriteLine("6 **************** Editera rum *********************" );
                    Console.WriteLine("7 **************** Avsluta *************************");

                    Console.Write("Val : ");

                    string inuput = Console.ReadLine();

                    if (inuput == "1")

                        guest.AddGuest(myContext);

                    if (inuput == "2")
                        room.CreateRoom(myContext);

                    if (inuput == "3")
                        guest.ListAllGuests(myContext);

                    if (inuput == "4")
                        room.ListAllRooms(myContext);

                    if(inuput == "5")
                        guest.EditGuest(myContext);

                    if(inuput == "6")
                        room.EditRoom(myContext);

                    if (inuput == "7")
                    
                        
                        break;
                    
                        
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Tryck enter för att fortsätta");
                    Console.ReadLine();
                }

               

            }
















        }
    }
}
