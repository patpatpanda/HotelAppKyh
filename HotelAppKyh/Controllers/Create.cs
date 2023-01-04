using HotelAppKyh.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelAppKyh.Controllers;

public class Create
{
    public Create(AppDbContext context)
    {
        myContext = context;
    }

    public AppDbContext myContext { get; set; }

    public void AddGuest()
    {
        Console.Clear();
        var guest = new Guest();
        Console.Write("Ange förnamn : ");
        guest.FirstName = Console.ReadLine();
        Console.Write("Ange efternamn : ");
        guest.LastName = Console.ReadLine();
        Console.Write("Ange telefonnummer : ");
        guest.PhoneNumber = Console.ReadLine();


        myContext.Guests.Add(guest);
        myContext.SaveChanges();
        ContinueMessage();
    }

    public void AddRoom()
    {
        Console.Clear();
        var room = new Room();
        Console.WriteLine("Ange typ av rum  ");
        Console.Write("enkel eller dubbel: ");

        room.RoomType = Console.ReadLine().ToLower();
        while (true)
        {
            if (room.RoomType == "enkel")
            {
                room.NumberOfBeds = 1;
                break;
            }

            if (room.RoomType == "dubbel")
            {
                room.NumberOfBeds = 2;
                break;
            }
            
            if (room.RoomType != "dubbel" || room.RoomType != "enkel")
            {
                Console.Clear();
                Console.WriteLine("Du kan endast ange (enkel) eller (dubbel)");
                Console.Write("Ange typ av rum : ");

                room.RoomType = Console.ReadLine().ToLower();
            }
        }

        Console.Write("Ange antal kv/m för rummet : ");
        room.RoomSize = int.Parse(Console.ReadLine());
        Console.Write("Ange pris för rummet : ");
        room.RoomPrice = int.Parse(Console.ReadLine());


        myContext.Add(room);
        myContext.SaveChanges();
        ContinueMessage();
    }

   

    public void CreateReservation()
    {
        var reservation = new Reservation();
       

        
        var guestId = GetGuest();
        reservation.Guest = guestId;

        Console.Clear();
        Console.Write("Hur många nätter? : ");
        var numberOfNightsStaying = int.Parse(Console.ReadLine());
        GetCheckInDate(reservation);

        GetCheckOutDate(numberOfNightsStaying, reservation);


        var newBookingAllDates = GetAllBookingDates(reservation);


        var availableRoms = GetAvailableRooms(newBookingAllDates);

        while (true)
        {
            if (ShowAvailableRooms(availableRoms)) return;


            try
            {
                ChooseRoom(reservation);
                break;
            }
            catch (Exception e)
            {
                ErrorMessage();
            }
        }
        
        
        
        

        BookingSuccesMessage(reservation, numberOfNightsStaying);
    }

    private static void BookingSuccesMessage(Reservation reservation, int numberOfNightsStaying)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine(" Bookningen lyckades!");
        Console.WriteLine(" ==============================================================================");
        Console.WriteLine(" Start\t\tSlut\t\tAntal dagar");
        Console.WriteLine(
            $" {reservation.DateStart.ToShortDateString()}\t{reservation.DateEnd.ToShortDateString()}\t{numberOfNightsStaying}");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine("\n Tryck enter för att fortsätta");
        Console.ReadLine();
    }

    private void ChooseRoom(Reservation reservation)
    {
        
               Console.WriteLine("\n Välja mellan dessa rum (ange Id)");
                var roomId = int.Parse(Console.ReadLine());
                reservation.Room = myContext.Rooms
                    .Where(c => c.RoomId == roomId)
                    .FirstOrDefault();

                myContext.Add(reservation);
                myContext.SaveChanges();
                
    }

    private static bool ShowAvailableRooms(List<Room> availableRoms)
    {
        if (availableRoms.Count() < 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n Det finns inga lediga rum för valt datum");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
            return true;
        }

        Console.WriteLine("\n\n\n Lediga rum redo att bokas");
        Console.WriteLine("\n Id\tTyp\t\tStorlek\t\tSängar\t\tPris");
        Console.WriteLine(" ==================================================================");

        foreach (var room in availableRoms.OrderBy(r => r.RoomId))
        {
            Console.WriteLine(
                $" {room.RoomId}\t{room.RoomType}\t\t{room.RoomSize}\t\t{room.NumberOfBeds}\t\t{room.RoomPrice}");
            Console.WriteLine(" ------------------------------------------------------------------");
        }

        return false;
    }

    private List<Room> GetAvailableRooms(List<DateTime> newBookingAllDates)
    {
        var availableRooms = new List<Room>();

        foreach (var room in myContext.Rooms.ToList())
        {
            var roomIsFree = true;
            foreach (var booking in myContext.Reservations.Include(b => b.Room).Where(b => b.Room == room))
            {
                for (var dt = booking.DateStart; dt <= booking.DateEnd; dt = dt.AddDays(1))
                    if (newBookingAllDates.Contains(dt))
                        roomIsFree = false;

                if (!roomIsFree) break;
            }


            if (roomIsFree) availableRooms.Add(room);
        }

        return availableRooms;
    }

    private static List<DateTime> GetAllBookingDates(Reservation reservation)
    {
        var newBookingAllDates = new List<DateTime>();
        for (var dt = reservation.DateStart; dt <= reservation.DateEnd; dt = dt.AddDays(1)) newBookingAllDates.Add(dt);

        return newBookingAllDates;
    }

    private static void GetCheckOutDate(int numberOfNightsStaying, Reservation reservation)
    {
        if (numberOfNightsStaying == 1) reservation.DateEnd = reservation.DateStart;
        else if (numberOfNightsStaying > 1)
            reservation.DateEnd = reservation.DateStart.AddDays(numberOfNightsStaying);
    }

    private static void GetCheckInDate(Reservation reservation)
    {
        reservation.DateStart = new DateTime(2022, 12, 01, 23, 59, 59);
        while (reservation.DateStart < DateTime.Now.Date)
        {
            Console.WriteLine("CheckIn datum (yyyy-mm-dd) ");
            reservation.DateStart = Convert.ToDateTime(Console.ReadLine());
        }
    }
    public Guest GetGuest()
    {
        while (true)
        {
            try
            {
                Console.Clear();
                var read = new Read(myContext);
                read.ListGuest();
                Console.Write("\nAnge (Id) För gäst som ska stå på bokningen : ");


                var guestId = int.Parse(Console.ReadLine());
                var editGuest = myContext.Guests.First(x => x.GuestId == guestId);
                return editGuest;

            }
            catch
            {
                ErrorMessage();
            }
        }
      
    }
    private static void ErrorMessage()
    {

        Console.Clear();

        Console.WriteLine("\nDu kan endast ange ett befintligt (Id)");
        Console.WriteLine("\nTryck enter för att fortsätta");

        Console.ReadLine();
        Console.Clear();
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