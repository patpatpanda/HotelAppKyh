namespace HotelAppKyh.Controllers;

public static class MainMenu
{
    public static int ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("                             -----------------------------------------------------");
        Console.WriteLine("                             |    ****         1:  Skapa ny gäst      ****       |");   
        Console.WriteLine("                             |    ****         2:  Skapa nytt rum     ****       |"); 
        Console.WriteLine("                             |    ****         3:  Lista alla gäster  ****       |");
        Console.WriteLine("                             |    ****         4:  Lista alla rum     ****       |");
        Console.WriteLine("                             |    ****         5:  Uppdatera gäst     ****       |");
        Console.WriteLine("                             |    ****         6:  Uppdatera rum      ****       |");
        Console.WriteLine("                             |    ****         7:  Lägg till säng     ****       |");
        Console.WriteLine("                             |    ****         8:  Radera gäst        ****       |");
        Console.WriteLine("                             |    ****         9:  Radera rum         ****       |"); 
        Console.WriteLine("                             |    ****         10: Bokning            ****       |");
        Console.WriteLine("                             |    ****         11: Avboka           ****         |");

        Console.WriteLine("                             |    ****         0:  Avsluta            ****       |");
        Console.WriteLine("                             ------------------------------------------------------");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("                                                    Val : ");
        Console.ResetColor();
        var inuput = int.Parse(Console.ReadLine());
        
        return inuput;
    }
}