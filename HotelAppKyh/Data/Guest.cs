using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppKyh.Data
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber  { get; set; }


        public void NewGuestProps(string newFirstName, string newLastName, string newPhoneNumber)
        {

            FirstName = newFirstName;
            LastName = newLastName;
            PhoneNumber = newPhoneNumber;


        }


        public void AddGuest(AppDbContext myContext)
        {
            Console.Clear();
            var guest = new Guest();
            Console.Write("Ange förstanamn : ");
            guest.FirstName = Console.ReadLine();

            Console.Write("Ange efternamn : ");
            guest.LastName = Console.ReadLine();
            Console.Write("Ange telefonnummer : ");
            guest.PhoneNumber = Console.ReadLine();

           

            myContext.Guests.Add(guest);
            myContext.SaveChanges();

            Console.WriteLine("Gäst skapad!");
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();

        }

        public void ListAllGuests(AppDbContext myContext)
        {
            Console.Clear();

            foreach (var guest in myContext.Guests.OrderBy(x => x.GuestId))
                Console.WriteLine(
                    $" gästId {guest.GuestId}. {guest.FirstName} {guest.LastName}. Telefon : {guest.PhoneNumber}");

            Console.WriteLine();
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();
        }
        public void EditGuest(AppDbContext myContext)
        {
            Console.Clear();
            Console.Write("Ange gästId för att ändra gästens uppgiter :");
            var guestId = int.Parse(Console.ReadLine());


            var editGuest = myContext.Guests.First(x => x.GuestId == guestId);
            Console.Clear();
            Console.WriteLine("Vill du radera gästen tryck 1, vill du ändra uppgifter tryck 2");
            string input = Console.ReadLine();
            string inputToLower = input.ToLower();
            if (inputToLower == "1")
            {
                myContext.Remove(editGuest);
            }
            else if (inputToLower == "2")
            {
                Console.Clear();
                Console.Write("Förnamn : ");
                var firstName = Console.ReadLine();
                Console.Write("Efternamn : ");
                var lastName = Console.ReadLine();
                Console.Write("Telefonummer : ");
                var nummer = Console.ReadLine();
                editGuest.NewGuestProps(firstName, lastName, nummer);
                Console.WriteLine("Uppgifter uppdaterade!");
            }
           

            Console.WriteLine();
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadLine();


            myContext.SaveChanges();
        }

    }
}
