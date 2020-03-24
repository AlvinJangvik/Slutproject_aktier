using System;

namespace Riktiga_aktie_spelet
{
    class Program
    {
        static void Main(string[] args)
        {
            //aktier
            Stocks olja = new Stocks("Olja", 5);
            Stocks bröd = new Stocks("Bröd", 3);
            Stocks vapen = new Stocks("Vapen", 10);
        }
    }
}
