namespace HotelAppKyh.Data;

public class Room
{
    public int RoomId { get; set; }
    public string RoomType { get; set; }
    public int RoomSize { get; set; }

    public int NumberOfBeds { get; set; }
    public int RoomPrice { get; set; }


    public void CreateRoom(AppDbContext myContext)
    {
        Console.Clear();
        var room = new Room();
        Console.Write("Ange typ av rum : ");

        room.RoomType = Console.ReadLine().ToLower();


        if (room.RoomType == "enkel")
        {
            room.NumberOfBeds = 1;
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

        else if (room.RoomType == "dubbel")
        {
            room.NumberOfBeds = 2;

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
        else if (room.RoomType != "enkel" || room.RoomType != "dubbel")
        {
            Console.WriteLine("Typ av rum kan endast anges som dubbel eller enkel");
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }
    }

    public void ListAllRooms(AppDbContext myContext)
    {
        Console.Clear();
        foreach (var room in myContext.Rooms)
            Console.WriteLine($"RumId = {room.RoomId} *** " +
                              $"Typ av rum = {room.RoomType} *** Storlek = {room.RoomSize}kvm *** Antal sängar = " +
                              $"{room.NumberOfBeds} *** Pris = {room.RoomPrice} kronor");
        Console.WriteLine();
        Console.WriteLine("Tryck enter för att fortsätta");
        Console.ReadLine();
    }

    public void EditRoom(AppDbContext myContext)


    {
        Console.Clear();

        var editRoom = new Room();

        Console.Write("Ange rummets id : ");
        var roomId = int.Parse(Console.ReadLine());

        editRoom = myContext.Rooms.First(x => x.RoomId == roomId);

        Console.WriteLine("1 *** Radera rum ***");
        Console.WriteLine("2 *** Uppdatera rum ***");
        Console.WriteLine("3 *** Lägg till säng ***");


        var input = Console.ReadLine().ToLower();

        if (input == "1")
        {
            Console.Clear();
            myContext.Remove(editRoom);
            Console.WriteLine("Rummet har raderats!");
        }

        if (input == "2")
        {
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

        if (input == "3")
        {
            if (editRoom.RoomType == "dubbel" && editRoom.RoomSize >= 40 && editRoom.RoomSize <= 50 &&
                editRoom.NumberOfBeds == 2)
            {
                Console.WriteLine("1 säng har lagts till");
                editRoom.NumberOfBeds = 3;
            }

            if (editRoom.RoomType == "dubbel" && editRoom.RoomSize > 50 && editRoom.NumberOfBeds == 2)
            {
                Console.WriteLine("Det finns möjlighet att lägga till 1 eller 2 sängar");
                Console.Write("Skriv 1 för en säng, 2 för två sängar: ");
                var innput3 = Console.ReadLine();
                if (innput3 == "1")
                {
                    editRoom.NumberOfBeds = 3;
                    Console.WriteLine("1 säng har lagts till");
                }


                if (innput3 == "2")
                {
                    editRoom.NumberOfBeds = 4;
                    Console.WriteLine("2 sängar har lagts till");
                }
            }
            else
            {
                Console.WriteLine("Det finns ingen möjlighet att lägga till säng till detta rum");
            }
        }


        Console.WriteLine();
        Console.WriteLine("Tryck enter for att fortsätta");
        Console.ReadLine();
        myContext.SaveChanges();
    }

    public void NewRoomProps(string roomType, int roomSize, int roomPrice)
    {
        RoomType = roomType;
        RoomSize = roomSize;
        RoomPrice = roomPrice;
    }
}