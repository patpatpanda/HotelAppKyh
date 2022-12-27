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
        
        Console.Write("\n Hur många nätter ? ");
        int numberOfNightsStaying = int.Parse(Console.ReadLine());
        Console.Write("Check in datum (yyyy-mm-dd) : " );
        var checkInDate = Convert.ToDateTime(Console.ReadLine());
        var checkOutDate = checkInDate.AddDays(numberOfNightsStaying);
      reservationId.NewReservationProps(checkInDate,checkOutDate);

        myContext.SaveChanges();
        ContinueMessage();

    }

    private Reservation getReservationId()
    {
        var read = new Read(myContext);
        read.ListReservations();
        Console.WriteLine();
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
        Console.Write("\nAnge (Id) för gäst du vill uppdatera : ");
        
    
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
        myContext.SaveChanges();
       ContinueMessage();
    }

    public void AddBed()
    {
        var roomId = GetRoomId();

        if (roomId.RoomType == "enkel")
        {
            AddBedNotPossibleMessage();
        }
      else  if (roomId.RoomType == "dubbel" && roomId.RoomSize >= 40 && roomId.RoomSize <= 50 &&
            roomId.NumberOfBeds == 2)
        {
            AddOneBedPossibleMessage(roomId);
        }

        else if (roomId.RoomType == "dubbel" && roomId.RoomSize > 50 && roomId.NumberOfBeds == 2)
        {
            AddTwoBedsPossibleMessage(roomId);
        }
        else if (roomId.RoomType == "dubbel" && roomId.RoomSize > 50 && roomId.NumberOfBeds == 3)
        {
            AddTotalFourBedsPossibleMessage(roomId);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Rummet har redan max antal sängar!");
            Console.WriteLine();
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }

        

        myContext.SaveChanges();
    }

    private static void AddTotalFourBedsPossibleMessage(Room roomId)
    {
        Console.WriteLine("Det finns möjlighet att lägga till 1 säng");
        Console.Write("Vill du göra det yes/no: ");
        var inuput = Console.ReadLine();
        if (inuput == "yes")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            roomId.NumberOfBeds = 4;
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }


        else if (inuput == "no") Console.WriteLine("Ingen säng har lagts till");
    }

    private static void AddTwoBedsPossibleMessage(Room roomId)
    {
        Console.WriteLine("Det finns möjlighet att lägga till 1 eller 2 sängar");
        Console.Write("Hur många vill du lägga till: ");
        var innput3 = Console.ReadLine();
        if (innput3 == "1")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            roomId.NumberOfBeds = 3;
            Console.WriteLine("1 säng har lagts till");
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }


        else if (innput3 == "2")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            roomId.NumberOfBeds = 4;
            Console.WriteLine("2 sängar har lagts till");
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }
    }

    private static void AddOneBedPossibleMessage(Room roomId)
    {
        Console.WriteLine("Det finns möjlighet att lägga till 1 säng!");
        Console.Write("Vill du göra det yes/no: ");
        var inuput = Console.ReadLine();
        if (inuput == "yes")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            roomId.NumberOfBeds = 3;
            Console.WriteLine("1 säng har lagts till");
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }


        else if (inuput == "no")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingen säng har lagts till");
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }
    }

    private static void AddBedNotPossibleMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("enkelrum kan inte lägga till säng");
        
        Console.WriteLine("\n Tryck enter för att fortsätta");
        Console.ReadLine();
    }

    public  void RemoveBed()
    {
        var roomId = GetRoomId();
        if (roomId.NumberOfBeds == 3 || roomId.NumberOfBeds == 4)
        {
            Console.WriteLine("1 säng har tagits bort från rummet ! ");
            Console.WriteLine("\nTryck enter för att fortsätta");
            Console.ReadLine();

            roomId.NumberOfBeds += -1;
            myContext.SaveChanges();
            
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Detta rum får ej ha färre sängar");
            Console.WriteLine("\nTryck enter för att fortsätta");
            Console.ReadLine();

        }
       
       
    }

    private Room GetRoomId()
    {
        var read = new Read(myContext);
        read.ListRoom();

        Console.Write("\nAnge id för rum du vill uppdatera : ");
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

   
