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
            Ints variable = new Ints(1000);
            StockChange stocks = new StockChange();

            int temp;
            int val;

            while (true) //Spel-loop
            {
                olja.NewStatus = stocks.Change(olja.Change, olja.Potential, olja.NewStatus, olja.SpecialChange);
                bröd.NewStatus = stocks.Change(bröd.Change, bröd.Potential, bröd.NewStatus, bröd.SpecialChange);
                vapen.NewStatus = stocks.Change(vapen.Change, vapen.Potential, vapen.NewStatus, vapen.SpecialChange);
                olja.TempChange = olja.NewStatus - olja.OldStatus;
                bröd.TempChange = bröd.NewStatus - bröd.OldStatus;
                vapen.TempChange = vapen.NewStatus - vapen.OldStatus;

                while (true)
                {
                    Console.WriteLine("|Olja: " + olja.NewStatus + "| Bröd: " + bröd.NewStatus + "| Vapen: " + vapen.NewStatus + "|", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.WriteLine("");
                    Console.WriteLine("|Olja förändring: " + olja.TempChange + "| Bröd förändring: " + bröd.TempChange + "| Vapen förändring: " + vapen.TempChange + "|", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.WriteLine("Vill du invester i( 1) (2) eller (3)?");
                    int.TryParse(Console.ReadLine(), out val);
                    int.TryParse(Console.ReadLine(), out temp);
                    if (temp <= variable.Money && temp >= 0 && val > 0 && val < 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("FEL VÄRDE!", Console.ForegroundColor = ConsoleColor.Red);
                    }
                }
                if(val == 1)
                {
                    bröd.Portfolio=Buy.Stocks(bröd.Portfolio, temp);
                    bröd.Money = temp;
                }
                if (val == 2)
                {
                    bröd.Portfolio = Buy.Stocks(bröd.Portfolio, temp);
                    bröd.Money = temp;
                }
                if (val == 3)
                {
                    vapen.Portfolio = Buy.Stocks(vapen.Portfolio, temp);
                    vapen.Money = temp;
                }

                olja.OldStatus = olja.NewStatus;
                bröd.OldStatus = bröd.NewStatus;
                vapen.OldStatus = vapen.NewStatus;
            }
        }
    }
}
