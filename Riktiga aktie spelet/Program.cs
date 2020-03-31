using System;

namespace Riktiga_aktie_spelet
{
    class Program
    {
        static void Main(string[] args)
        {
            //aktier
            Stocks olja = new Stocks("Olja", 5, 0); //5:an är aktiens change värde och 1:an aktiens potential
            Stocks bröd = new Stocks("Bröd", 3, 2);
            Stocks vapen = new Stocks("Vapen", 10, -1);
            StockChange changes = new StockChange();
            while (true) //Spel-loop
            {
                olja.NewStatus = changes.Change(olja.Change, olja.Potential, olja.NewStatus, olja.SpecialChange);
                bröd.NewStatus = changes.Change(bröd.Change, bröd.Potential, bröd.NewStatus, bröd.SpecialChange);
                vapen.NewStatus = changes.Change(vapen.Change, vapen.Potential, vapen.NewStatus, vapen.SpecialChange);
                olja.TempChange = olja.NewStatus - olja.OldStatus;
                bröd.TempChange = bröd.NewStatus - bröd.OldStatus;
                vapen.TempChange = vapen.NewStatus - vapen.OldStatus;

                Console.WriteLine("|Olja: "+ olja.NewStatus+"| Bröd: "+bröd.NewStatus+"| Vapen: "+vapen.NewStatus+"|", Console.ForegroundColor = ConsoleColor.Blue);
                Console.WriteLine("");
                Console.WriteLine("|Olja förändring: " + olja.TempChange + "| Bröd förändring: " + bröd.TempChange + "| Vapen förändring: " + vapen.TempChange + "|", Console.ForegroundColor = ConsoleColor.Blue);
                Console.ReadLine();
                olja.OldStatus = olja.NewStatus;
                bröd.OldStatus = bröd.NewStatus;
                vapen.OldStatus = vapen.NewStatus;
            }
        }
    }
}
