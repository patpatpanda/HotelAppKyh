using HotelAppKyh.Data;

namespace HotelAppKyh.Controllers;

internal class CreateRoom
{
    public CreateRoom(AppDbContext context)
    {
        myContext = context;
    }

    public AppDbContext myContext { get; set; }

    public void run()
    {
        Console.Clear();
        var room = new Room();
        Console.Write("Ange typ av rum : ");

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
                Console.WriteLine("enkel eller dubbel är enda valid typ av rum");
                Console.Write("Ange typ av rum : ");

                room.RoomType = Console.ReadLine().ToLower();
            }
        }

        Console.Write("Ange antal kv/m för rummet : ");
        room.RoomSize = int.Parse(Console.ReadLine());
        Console.Write("Ange pris för rummet : ");
        room.RoomPrice = int.Parse(Console.ReadLine());

        Console.WriteLine("Rummet har skapats!");
        Console.WriteLine("Tryck enter för att fortsätta");
        Console.ReadLine();
        myContext.Add(room);
        myContext.SaveChanges();
    }
}