using System;

namespace Riktiga_aktie_spelet
{
    class Program
    {
        /// <summary>
        /// Spel-loopen. Skulle vart indelad i flera metoder men fokuserade förmycket på att 
        /// använda klasser till så mycket som möjligt att jag glömde bort det. 
        /// Fixar igentligen allt. Sätter aktiern, spel menyn, aktie säljning och köpning m.m.
        /// </summary> 
        static void Main(string[] args)
        {
            //aktier
            Stocks olja = new Stocks("Olja", 5, 0); //5:an är aktiens change värde och 1:an aktiens potential
            Stocks bröd = new Stocks("Bröd", 3, 2);
            Stocks vapen = new Stocks("Vapen", 10, -3);
            Ints variable = new Ints(1000);
            StockChange stocks = new StockChange();

            //Event
            Event OljeStrejk = new Event(4, 5);
            Event Corona = new Event(2, 20);

            int temp = 0; //Fick error när den inte hade et värde från början
            int val;
            int eventActive = 0; //Vilket event som är aktivt
            int eventCountdown = 0; //Räknar ner rundorna
            int Diff = 0; //Svårighetsgrad

            Menu.Start(ref Diff); //Start Menyn

            while (true) //Spel-loop
            {
                //Kollar om spelaren har vunnit eller förlorat
                Goal.Check(variable.Money, olja.Portfolio, bröd.Portfolio, vapen.Portfolio);

                for (int i = 25; i > 0; i--)//Flyttar ner texten
                {
                    Console.WriteLine();
                }

                if (eventActive > 0)
                {
                    if(eventActive == 1)
                    {
                        Console.WriteLine("OLJESTREJK", Console.ForegroundColor = ConsoleColor.Magenta);
                        Console.ForegroundColor = ConsoleColor.Black;
                        olja.Potential += OljeStrejk.Change;
                        eventCountdown--;
                        if(eventCountdown == 0) { eventActive = 0; }
                    }
                    else
                    {
                        Console.WriteLine("CORONA UTBROTT", Console.ForegroundColor = ConsoleColor.Magenta);
                        Console.ForegroundColor = ConsoleColor.Black;
                        olja.Potential -= Corona.Change;
                        bröd.Potential += Corona.Change;
                        eventCountdown--;
                        if (eventCountdown == 0) { eventActive = 0; }
                    }
                }
                else //Fixar så att ifal aktien är hög så blir det större chans att den går neråt och vise versa
                {
                    if (olja.NewStatus > 15) { olja.Potential--; } //för olja
                    else if (olja.NewStatus < -15) { olja.Potential++; }
                    if (bröd.NewStatus > 10) { bröd.Potential--; } //för bröd
                    else if (bröd.NewStatus < -10) { bröd.Potential++; }
                    if (vapen.NewStatus > 35) { vapen.Potential--; } //för vapen
                    else if (vapen.NewStatus < -35) { vapen.Potential++; }
                }

                //Ändrar på aktierna.
                olja.NewStatus = stocks.Change(olja.Change, olja.Potential, olja.NewStatus);
                bröd.NewStatus = stocks.Change(bröd.Change, bröd.Potential, bröd.NewStatus);
                vapen.NewStatus = stocks.Change(vapen.Change, vapen.Potential, vapen.NewStatus);
                olja.TempChange = olja.NewStatus - olja.OldStatus; //Räknar ut aktiernas förändring
                bröd.TempChange = bröd.NewStatus - bröd.OldStatus;
                vapen.TempChange = vapen.NewStatus - vapen.OldStatus;

                //Portfolie förändring
                if (olja.Active == true) { olja.Portfolio += olja.Money * olja.TempChange; }
                if (bröd.Active == true) bröd.Portfolio += bröd.Money * bröd.TempChange;
                if (vapen.Active == true) vapen.Portfolio += vapen.Money * vapen.TempChange;

                while (true)
                {
                    Console.WriteLine("|Aktievärde| Olja: " + olja.NewStatus + "| Bröd: " + bröd.NewStatus + "| Vapen: " + vapen.NewStatus + "|", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.WriteLine("");
                    Console.WriteLine("|Förändring| Olja: " + olja.TempChange + "| Bröd: " + bröd.TempChange + "| Vapen: " + vapen.TempChange + "|", Console.ForegroundColor = ConsoleColor.Magenta);
                    Console.WriteLine("");
                    Console.WriteLine("|Portfolion| Olja: " + olja.Portfolio + "| Bröd: " + bröd.Portfolio + "| Vapen: " + vapen.Portfolio + "|", Console.ForegroundColor = ConsoleColor.Green);
                    Console.WriteLine("");
                    Console.WriteLine("Du har: " + variable.Money + "$");
                    Console.WriteLine("");
                    Console.WriteLine("Vill du invester i(1), (2), (3),(4) för att sälja eller (5) för att inte göra något?", Console.ForegroundColor = ConsoleColor.Red);
                    
                    int.TryParse(Console.ReadLine(), out val); 
                    if( val == 4) { break; }

                    Console.WriteLine("Hur mycket?");
                    int.TryParse(Console.ReadLine(), out temp);
                    if (temp <= variable.Money && temp >= 0 && val > 0 && val < 6)
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
                    olja.Active = true;
                }
                if (val == 2)
                {
                    bröd.Money += temp;
                    variable.Money -= temp;
                    bröd.Active = true;
                }
                if (val == 3)
                {
                    vapen.Money += temp;
                    variable.Money -= temp;
                    vapen.Active = true;
                }
                if (val == 4)
                {
                    while (true) //sälja
                    {
                        Console.WriteLine("Hur mycket? Olja:" + olja.Portfolio + "$ Bröd:" + bröd.Portfolio + "$ Vapen:" + vapen.Portfolio);
                        Console.WriteLine("Aktien måste ligga i pluss");
                        Console.WriteLine("Vilken aktie vill du sälja? (1), (2), (3) eller (4) för att avbryta");
                        int.TryParse(Console.ReadLine(), out val);
                        
                        if(val == 1 && olja.Portfolio > 0) { break; } //Kollar att spelaren vallt ett alternativ
                        else if (val == 2 && bröd.Portfolio > 0) { break; }
                        else if(val == 3 && vapen.Portfolio > 0) { break; }
                        else if (val == 4) { break; }
                        else
                        {
                            Console.WriteLine("FEL VÄRDE!", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    if (val == 1) //Säjlningen för olja
                    {
                        variable.Money += olja.Portfolio;
                        olja.Portfolio = 0;
                        olja.Active = false;
                    }
                    if (val == 2) //Säjlningen för bröd
                    {
                        variable.Money += bröd.Portfolio;
                        bröd.Portfolio = 0;
                        bröd.Active = false;
                    }
                    if (val == 3) //Säjlningen för vapen
                    {
                        variable.Money += vapen.Portfolio;
                        vapen.Portfolio = 0;
                        vapen.Active = false;
                    }
                }

                //Ifall ett event händer
                if (eventActive < 1) //kollar så det inte redan är ett event som är ingång
                {
                    Random r = new Random();
                    temp = r.Next(1, 51);//hur stor chans det är att ett event händer
                    if (temp == 1)
                    {
                        if (Diff == 2) { eventActive = r.Next(1, 3); }
                        else { eventActive = 1; }

                        if (eventActive == 1) { eventCountdown = OljeStrejk.Time; } //sätter antalet rundor som eventer är igång
                        else { eventCountdown = Corona.Time; }
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
