using HotelAppKyh.Data;

namespace HotelAppKyh.Controllers;

public class Delete
{
    public Delete(AppDbContext context)
    {
        myContext = context;
    }

    public Read read { get; set; }
    public AppDbContext myContext { get; set; }


    public void DeleteGuest()
    {
        while (true)
            try
            {
                var read = new Read(myContext);


                read.ListGuest();
                Console.Write("\nAnge id för gäst du vill radera: ");
                var guestId = int.Parse(Console.ReadLine());
                var delete = myContext.Guests.First(x => x.GuestId == guestId);
                var checkFor = myContext.Reservations.Any(x => x.Guest == delete);
                if (checkFor)
                {
                    Console.Clear();
                    Console.WriteLine("Gäst kan ej tas bort pga att den har en aktiv boking !");
                    Console.WriteLine();
                    Console.WriteLine("Tryck enter för att fortsätta ");
                    Console.ReadLine();
                    break;
                }

                if (!checkFor)
                {
                    myContext.Guests.Remove(delete);
                    myContext.SaveChanges();
                    ContinueMessage();
                    break;
                }
            }
            catch
            {

                ErrorMessage();
            }
    }

    public void CancelReservation()
    {
        while (true)
        {
            try
            {
                var read = new Read(myContext);
                read.ListReservations();
                Console.Write("\nAnge (Id) för att avboka rum : ");
                var resId = int.Parse(Console.ReadLine());
                var delete = myContext.Reservations.First(x => x.Id == resId);

                myContext.Reservations.Remove(delete);
                myContext.SaveChanges();
                ContinueMessage();
                break;
            }
            catch
            {

                Console.Clear();

                Console.WriteLine("\nDu kan endast ange ett befintligt Id");
                Console.WriteLine("\nTryck enter för att fortsätta");

                Console.ReadLine();
            }
        }
        
    }

    public void DeleteRoom()
    {
        while (true)
        {
            try
            {
                var read = new Read(myContext);
                read.ListRoom();
                Console.Write("\nAnge (Id) för rum du vill radera: ");
                var roomId = int.Parse(Console.ReadLine());
                var delete = myContext.Rooms.First(x => x.RoomId == roomId);


                myContext.Rooms.Remove(delete);
                myContext.SaveChanges();
                ContinueMessage();
                break;
            }
            catch 
            {
                ErrorMessage();
            }
        }
       
    }

    private static void ContinueMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Lyckades !");
        Console.WriteLine();
        Console.WriteLine("Tryck enter för att fortsätta");
        Console.ReadLine();
        Console.ResetColor();
    }

    private static void ErrorMessage()
    {

        Console.Clear();

        Console.WriteLine("\nDu kan endast ange ett befintligt (Id)");
        Console.WriteLine("\nTryck enter för att fortsätta");

        Console.ReadLine();
    }
}