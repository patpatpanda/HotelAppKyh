using HotelAppKyh.Controllers;

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
            while (true)
            {
                var inuput = MainMenu.ShowMenu();

                if (inuput == 1) create.AddGuest();

                if (inuput == 2) create.AddRoom();

                if (inuput == 3) Read.ListGuest();

                if (inuput == 4) Read.ListRoom();

                if (inuput == 5) uppdate.UppdateGuest();
                
                if(inuput == 6) uppdate.UppdateRoom();

                if(inuput == 7) uppdate.AddBed();
                
                if(inuput == 8 ) delete.DeleteGuest();
               
                if(inuput == 9 ) delete.DeleteRoom();


                if (inuput == 0)
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

