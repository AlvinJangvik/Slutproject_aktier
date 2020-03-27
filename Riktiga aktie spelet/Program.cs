using System;

namespace Riktiga_aktie_spelet
{
    class Program
    {
        static void Main(string[] args)
        {
            //aktier
            Stocks olja = new Stocks("Olja", 5, 1); //5:an är aktiens change värde och 1:an aktiens potential
            Stocks bröd = new Stocks("Bröd", 3, 2);
            Stocks vapen = new Stocks("Vapen", 10, 1);
            StockChange changes = new StockChange();
            while (true) //Spel-loop
            {
                olja.Status = changes.Change(olja.Change, olja.Potential, olja.Status);
            }
        }
    }
}
