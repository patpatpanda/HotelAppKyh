using HotelAppKyh.Controllers;
using HotelAppKyh.Data;

namespace HotelAppKyh;

public class Main
{
    public void run()
    {
        try
        {
            var buildApp = new Builder();
            var myContext = buildApp.AppBuilder();
            var create = new Create(myContext);
            var read = new Read(myContext);
            var uppdate = new Uppdate(myContext);
            var delete = new Delete(myContext);
            var res = new Reservation(myContext);
            
            ////
          
           

            while (true)
            {
                var inuput = MainMenu.ShowMenu();

                if (inuput == 1) create.AddGuest();

               else if (inuput == 2) create.AddRoom();

              else  if (inuput == 3) read.ListGuest();

               else if (inuput == 4) read.ListRoom();

              else  if (inuput == 5) uppdate.UpdateGuest();
                
              else  if(inuput == 6) uppdate.UpdateRoom();
                else  if(inuput == 7) uppdate.AddBed();
                
             else   if(inuput == 8 ) delete.DeleteGuest();
               
               else if(inuput == 9 ) delete.DeleteRoom();

                else if(inuput == 10) create.CreateReservation();
                else if (inuput == 11) delete.CanselReservation();
                else if(inuput == 12) uppdate.UpdateReservation();
                
                    
                


             else   if (inuput == 0)
                {
                    break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
}

