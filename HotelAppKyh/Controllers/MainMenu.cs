using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppKyh.Controllers
{
    public static class MainMenu
    {

        public static int ShowMenu()
        {

            Console.Clear();
            Console.WriteLine("1:  Skapa ny gäst");
            Console.WriteLine("2:  Skapa nytt rum");
            Console.WriteLine("3:  Lista alla gäster");
            Console.WriteLine("4:  Lista alla rum");
            Console.WriteLine("5:  Editera gäst ");
            Console.WriteLine("6:  Editera rum ");
            Console.WriteLine("7:  Avsluta ");

            Console.Write("Val : ");

            int inuput = int.Parse(Console.ReadLine());
            return inuput;
        }
    }
}
