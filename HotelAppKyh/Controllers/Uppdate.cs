using HotelAppKyh.Data;

namespace HotelAppKyh.Controllers;

public class Uppdate
{
    public Uppdate(AppDbContext context)
    {
        myContext = context;
    }

    public AppDbContext myContext { get; set; }


    public void UpdateReservation()
    {
        var reservationId = getReservationId();
        Console.WriteLine();
        Console.Write("Hur många nätter ? ");
        int numberOfNightsStaying = int.Parse(Console.ReadLine());
        Console.Write("Check in datum (yyyy-mm-dd) : " );
        var checkInDate = Convert.ToDateTime(Console.ReadLine());
        var checkOutDate = checkInDate.AddDays(numberOfNightsStaying);
      

        myContext.SaveChanges();
        ContinueMessage();

    }

    private Reservation getReservationId()
    {
        var read = new Read(myContext);
        read.ListReservations();
        Console.Write("Ange id för den bokning du vill uppdtera : ");
        var reservationId = int.Parse(Console.ReadLine());
        var editReservation = myContext.Reservations.First(x => x.Id == reservationId);
        return editReservation;

    }
    
    public void UpdateGuest()
    {
        var guestId = GetGuestId();
        
        Console.Write("Förnamn : ");
        var firstName = Console.ReadLine();
        Console.Write("Efternamn : ");
        var lastName = Console.ReadLine();
        Console.Write("Telefonummer : ");
        var nummer = Console.ReadLine();
        guestId.NewGuestProps(firstName, lastName, nummer);
        
        
        myContext.SaveChanges();
        ContinueMessage();
    }

    private Guest GetGuestId()
    {
        var read = new Read(myContext);
        read.ListGuest();
        Console.Write("Ange id för gäst du vill uppdatera : ");
        
    
        var guestId = int.Parse(Console.ReadLine());
        var editGuest = myContext.Guests.First(x => x.GuestId == guestId);
        return editGuest;
    }


    public void UpdateRoom()
    {
        var roomId = GetRoomId();
        
        Console.Write("Ange typ av rum : ");
        
        var newTypeOfRoom = Console.ReadLine().ToLower();
        Console.Write("Ange storlek :");
        var newSizeOfRoom = int.Parse(Console.ReadLine());
        Console.Write("Pris : ");
        var newPrice = int.Parse(Console.ReadLine());
        roomId.NewRoomProps(newTypeOfRoom, newSizeOfRoom, newPrice);
        Console.WriteLine("Rummet har uppdaterats!");
       ContinueMessage();
    }

    public void AddBed()
    {
        var roomId = GetRoomId();

        if (roomId.RoomType == "enkel")
        {
            Console.WriteLine("enkelrum kan inte lägga till säng");
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }
        if (roomId.RoomType == "dubbel" && roomId.RoomSize >= 40 && roomId.RoomSize <= 50 &&
            roomId.NumberOfBeds == 2)
        {
            Console.WriteLine("Det finns möjlighet att lägga till 1 säng!");
            Console.Write("Vill du göra det yes/no: ");
            var inuput = Console.ReadLine();
            if (inuput == "yes") roomId.NumberOfBeds = 3;


           else if (inuput == "no") Console.WriteLine("Ingen säng har lagts till");
        }

        else if (roomId.RoomType == "dubbel" && roomId.RoomSize > 50 && roomId.NumberOfBeds == 2)
        {
            Console.WriteLine("Det finns möjlighet att lägga till 1 eller 2 sängar");
            Console.Write("Hur många vill du lägga till: ");
            var innput3 = Console.ReadLine();
            if (innput3 == "1")
            {
                roomId.NumberOfBeds = 3;
                Console.WriteLine("1 säng har lagts till");
            }


            else if (innput3 == "2")
            {
                roomId.NumberOfBeds = 4;
                Console.WriteLine("2 sängar har lagts till");
            }
        }
        else if (roomId.RoomType == "dubbel" && roomId.RoomSize > 50 && roomId.NumberOfBeds == 3)
        {
            Console.WriteLine("Det finns möjlighet att lägga till 1 säng");
            Console.Write("Vill du göra det yes/no: ");
            var inuput = Console.ReadLine();
            if (inuput == "yes") roomId.NumberOfBeds = 4;


            if (inuput == "no") Console.WriteLine("Ingen säng har lagts till");
        }
        else
        {
            Console.WriteLine("Rummet har redan max antal sängar!");
        }

        

        myContext.SaveChanges();
    }

    private Room GetRoomId()
    {
        var read = new Read(myContext);
        read.ListRoom();

        Console.Write("Ange id för rum du vill uppdatera : ");
        var roomId = int.Parse(Console.ReadLine());

        var editRoom = myContext.Rooms.First(x => x.RoomId == roomId);
        Console.Clear();
        return editRoom;
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
}

   
