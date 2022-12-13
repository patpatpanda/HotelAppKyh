using HotelAppKyh.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using HotelAppKyh.Controllers;

namespace HotelAppKyh
{
    public class Main
    {
        public void run()
        {
            var buildApp = new Builder();
            var myContext = buildApp.AppBuilder();
            
            
            var guest = new Guest();
            var room = new Room();
            var reservation = new Reservation();
            
            while (true)
            {
                var inuput = MainMenu.ShowMenu();

                if (inuput == 1)
                {
                    var action = new CreateGuest(myContext);
                    action.run();   

                }
                
                if (inuput == 2)

                {
                    var action = new CreateRoom(myContext);
                    action.run();

                }

                    if (inuput == 3)
                        guest.ListAllGuests(myContext);

                    if (inuput == 4)
                        room.ListAllRooms(myContext);

                    if(inuput == 5)
                        guest.EditGuest(myContext);

                    if(inuput == 6)
                        room.EditRoom(myContext);

                    if (inuput == 7)
                    
                        
                        break;
                    

                

               

            }
















        }
    }
}
