using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class StockChange
    {
         /// <summary>
        /// Ändrar den aktien som skickas in genom att använda Change, Potential och State.
        /// </summary>
        /// <param name="c">Hur mycket aktien kan förändras, kastas in i random</param>
        /// <param name="po">Hur stor chans det är att aktien går plus eller minus</param>
        /// <param name="s">Vilket värde aktien har just nu</param>
        /// <returns></returns> 
        public int Change(int c, int po, int s)
        {
            Random rand = new Random();
            int r = rand.Next(-c, c + 1); //Göra att den kan bara ändra som det vart bestämt i huvud koden
            s += r + po;  //status += en random baserad på change + special change + potential
            return s;
        }

    }
}
