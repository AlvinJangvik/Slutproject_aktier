using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class StockChange
    {
        public int Change(int c, int s, int sp, int po)
        {
            Random rand = new Random();
            int r = rand.Next(-c, c + 1);
            s += r + sp + po;  //status += en random baserad på change + special change + potential
            return s;
        }

    }
}
