using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class Sälja
    {
        public static void start(ref int money, ref int aMoney, ref int portfolie, int temp)
        {
            aMoney = 0;
            money = portfolie;
            portfolie -= temp;
        }
    }
}
