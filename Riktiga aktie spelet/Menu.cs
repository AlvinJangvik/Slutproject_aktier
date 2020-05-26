using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class Menu
    {
        private static int svåroghetsGrad;
        /// <summary>
        /// Startmenyn, Låter spelaren välja mellan lätt och svårt samt säger hur man vinner och förlorar
        /// </summary>
        /// <param name="d">Sparar svårighetsgraden och skickar den till spel loopen</param>  
        public static void Start(ref int d)//Gör inget än
        {
            Console.WriteLine("     ____________Alvins Aktie Simulator________ ");
            Console.WriteLine("     __________________________________________ ");
            Console.WriteLine("    |                   Aktier                 |");
            Console.WriteLine("    |             1)    Lätt                   |");
            Console.WriteLine("    |             2)    Svårt                  |");
            Console.WriteLine("    | Svårt lägger till Corona som ett event!  |");
            Console.WriteLine("    |__________________________________________| ");
            Console.WriteLine("           Få 500K i pengar för att vinna!");
            Console.WriteLine("har du mindre än 0 i pengar och portfolier så förlorar du!");
            int.TryParse(Console.ReadLine(), out svåroghetsGrad);
            d = svåroghetsGrad;
        }
    }
}
