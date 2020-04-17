using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class Menu
    {
        private static int svåroghetsGrad;
        public static void Start()//Gör inget än
        {
            Console.WriteLine(" __________________________________________ ");
            Console.WriteLine("|                   Aktier                 |");
            Console.WriteLine("|             1)    Lätt                   |");
            Console.WriteLine("|             2)    Svårt                  |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("|__________________________________________| ");
            Console.WriteLine("Skillnade är hur många olika saker som kan hända");
            int.TryParse(Console.ReadLine(), out svåroghetsGrad);
        }
    }
}
