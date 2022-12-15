using System.ComponentModel.DataAnnotations;

namespace HotelAppKyh.Data;

public class Room
{
    
    public int RoomId { get; set; }

    [Required]
    [MaxLength(50)]
    public string? RoomType { get; set; }
    
    public int? RoomSize { get; set; }

    public int? NumberOfBeds { get; set; }
    public int? RoomPrice { get; set; }


   

    

    
    public void NewRoomProps(string roomType, int roomSize, int roomPrice)
    {
        RoomType = roomType;
        RoomSize = roomSize;
        RoomPrice = roomPrice;
    }
}