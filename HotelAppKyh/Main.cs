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
            var Read = new Read(myContext);
            var uppdate = new Uppdate(myContext);
            var delete = new Delete(myContext);
            var res = new Reservation();

            while (true)
            {
                var inuput = MainMenu.ShowMenu();

                if (inuput == 1) create.AddGuest();

               else if (inuput == 2) create.AddRoom();

              else  if (inuput == 3) Read.ListGuest();

               else if (inuput == 4) Read.ListRoom();

              else  if (inuput == 5) uppdate.UppdateGuest();
                
              else  if(inuput == 6) uppdate.UppdateRoom();

              else  if(inuput == 7) uppdate.AddBed();
                
             else   if(inuput == 8 ) delete.DeleteGuest();
               
               else if(inuput == 9 ) delete.DeleteRoom();
                
                else if(inuput == 10) res.MakeReservation(myContext);


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

