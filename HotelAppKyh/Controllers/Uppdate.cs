using HotelAppKyh.Data;

namespace HotelAppKyh.Controllers;

public class Uppdate
{
    public Uppdate(AppDbContext context)
    {
        myContext = context;
    }

    public AppDbContext myContext { get; set; }

    public void UppdateGuest()
    {
        var read = new Read(myContext);
        read.ListGuest();

        Console.WriteLine("--------------------------------------------------");
        Console.Write("Ange id för gäst du vill editera : ");
        var guestId = int.Parse(Console.ReadLine());
        var editGuest = myContext.Guests.First(x => x.GuestId == guestId);

        Console.Clear();
        Console.Write("Förnamn : ");
        var firstName = Console.ReadLine();
        Console.Write("Efternamn : ");
        var lastName = Console.ReadLine();
        Console.Write("Telefonummer : ");
        var nummer = Console.ReadLine();
        editGuest.NewGuestProps(firstName, lastName, nummer);
        Console.WriteLine("Uppgifter uppdaterade!");


        Console.WriteLine();
        Console.WriteLine("Tryck enter för att fortsätta");
        Console.ReadLine();


        myContext.SaveChanges();
    }

    public void UppdateRoom()
    {
        var read = new Read(myContext);
        read.ListRoom();
        Console.Write("Ange id för rum du vill editera : ");
        var roomId = int.Parse(Console.ReadLine());

        var editRoom = myContext.Rooms.First(x => x.RoomId == roomId);
        Console.Clear();
        Console.Write("Ange typ av rum : ");
        

        var newTypeOfRoom = Console.ReadLine().ToLower();
        Console.Write("Ange storlek :");
        var newSizeOfRoom = int.Parse(Console.ReadLine());
        Console.Write("Pris : ");
        var newPrice = int.Parse(Console.ReadLine());
        editRoom.NewRoomProps(newTypeOfRoom, newSizeOfRoom, newPrice);
        Console.WriteLine("Rummet har uppdaterats!");
    }

    public void AddBed()
    {
        var read = new Read(myContext);
        read.ListRoom();
        Console.Write("Ange id för rum du vill lägga till säng : ");
        var roomId = int.Parse(Console.ReadLine());

        var editRoom = myContext.Rooms.First(x => x.RoomId == roomId);
        Console.Clear();

        if (editRoom.RoomType == "dubbel" && editRoom.RoomSize >= 40 && editRoom.RoomSize <= 50 &&
            editRoom.NumberOfBeds == 2)
        {
            Console.WriteLine("Det finns möjlighet att lägga till 1 säng!");
            Console.Write("Vill du göra det yes/no: ");
            var inuput = Console.ReadLine();
            if (inuput == "yes") editRoom.NumberOfBeds = 3;


            if (inuput == "no") Console.WriteLine("Ingen säng har lagts till");
        }

        else if (editRoom.RoomType == "dubbel" && editRoom.RoomSize > 50 && editRoom.NumberOfBeds == 2)
        {
            Console.WriteLine("Det finns möjlighet att lägga till 1 eller 2 sängar");
            Console.Write("Hur många vill du lägga till: ");
            var innput3 = Console.ReadLine();
            if (innput3 == "1")
            {
                editRoom.NumberOfBeds = 3;
                Console.WriteLine("1 säng har lagts till");
            }


            else if (innput3 == "2")
            {
                editRoom.NumberOfBeds = 4;
                Console.WriteLine("2 sängar har lagts till");
            }
        }
        else if (editRoom.RoomType == "dubbel" && editRoom.RoomSize > 50 && editRoom.NumberOfBeds == 3)
        {
            Console.WriteLine("Det finns möjlighet att lägga till 1 säng");
            Console.Write("Vill du göra det yes/no: ");
            var inuput = Console.ReadLine();
            if (inuput == "yes") editRoom.NumberOfBeds = 4;


            if (inuput == "no") Console.WriteLine("Ingen säng har lagts till");
        }
        else
        {
            Console.WriteLine("Rummet har redan max antal sängar!");
        }


        Console.WriteLine();
        Console.WriteLine("Tryck enter for att fortsätta");
        Console.ReadLine();
        myContext.SaveChanges();
    }
}