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

            int temp = 0; //Fick error när den inte hade et värde från början
            int val;

            Menu.Start();

            while (true) //Spel-loop
            {
                olja.NewStatus = stocks.Change(olja.Change, olja.Potential, olja.NewStatus, olja.SpecialChange);
                bröd.NewStatus = stocks.Change(bröd.Change, bröd.Potential, bröd.NewStatus, bröd.SpecialChange);
                vapen.NewStatus = stocks.Change(vapen.Change, vapen.Potential, vapen.NewStatus, vapen.SpecialChange);
                olja.TempChange = olja.NewStatus - olja.OldStatus;
                bröd.TempChange = bröd.NewStatus - bröd.OldStatus;
                vapen.TempChange = vapen.NewStatus - vapen.OldStatus;

                //Portfolie förändring
                olja.Portfolio += olja.Money * olja.TempChange;
                bröd.Portfolio += bröd.Money * bröd.TempChange;
                vapen.Portfolio += vapen.Money * vapen.TempChange;

                while (true)
                {
                    for(int i = 25; i>0; i--)
                    {
                        Console.WriteLine();
                    }
                    Console.WriteLine("|Aktievärde| Olja: " + olja.NewStatus + "| Bröd: " + bröd.NewStatus + "| Vapen: " + vapen.NewStatus + "|", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.WriteLine("");
                    Console.WriteLine("|Förändring| Olja: " + olja.TempChange + "| Bröd: " + bröd.TempChange + "| Vapen: " + vapen.TempChange + "|", Console.ForegroundColor = ConsoleColor.Magenta);
                    Console.WriteLine("");
                    Console.WriteLine("|Portfolion| Olja: " + olja.Portfolio + "| Bröd: " + bröd.Portfolio + "| Vapen: " + vapen.Portfolio + "|", Console.ForegroundColor = ConsoleColor.Green);
                    Console.WriteLine("");
                    Console.WriteLine("Vill du invester i(1), (2), (3) eller (4) för att sälja?", Console.ForegroundColor = ConsoleColor.Red);
                    
                    int.TryParse(Console.ReadLine(), out val); 
                    if( val == 4) { break; }

                    Console.WriteLine("Hur mycket? Du har: " + variable.Money);
                    int.TryParse(Console.ReadLine(), out temp);
                    if (temp <= variable.Money && temp >= 0 && val > 0 && val < 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("FEL VÄRDE!", Console.ForegroundColor = ConsoleColor.Red); //Kollar att båda readlines är rätt
                    }
                }
                //Vilken aktie som köps
                if(val == 1)
                {
                    olja.Money += temp;
                    variable.Money -= temp;
                }
                if (val == 2)
                {
                    bröd.Money += temp;
                    variable.Money -= temp;
                }
                if (val == 3)
                {
                    vapen.Money += temp;
                    variable.Money -= temp;
                }
                if (val == 4)
                {
                    while (true) //sälja
                    {
                        Console.WriteLine("Vilken aktie vill du sälja? (1) (2) eller (3)");
                        int.TryParse(Console.ReadLine(), out val);
                        Console.WriteLine("Hur mycket? Olja:" + olja.Portfolio + "$ Bröd:" + bröd.Portfolio + "$ Vapen:" + vapen.Portfolio);
                        int.TryParse(Console.ReadLine(), out temp);
                        
                        if(val < 4 && val > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("FEL VÄRDE!", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    if (val == 1) //Säjlningen
                    {
                        variable.Money += temp;
                        olja.Portfolio -= temp;
                    }
                    if (val == 2) //Säjlningen
                    {
                        variable.Money += temp;
                        bröd.Portfolio -= temp;
                    }
                    if (val == 3) //Säjlningen
                    {
                        variable.Money += temp;
                        vapen.Portfolio -= temp;
                    }
                }

                //Status uppdateringar
                olja.OldStatus = olja.NewStatus;
                bröd.OldStatus = bröd.NewStatus;
                vapen.OldStatus = vapen.NewStatus;

                
            }
        }
    }
}
