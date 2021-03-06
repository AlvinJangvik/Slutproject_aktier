﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class Goal
    {   
         /// <summary>
        /// Ser till att man kan vinna och förlora genom att kolla värdet på variabeln Money samt värdet på alla 3 portfolier.
        /// </summary>
        /// <param name="m">Spelarens pengar</param>
        /// <param name="op">Olja portfoliet</param>
        /// <param name="bp">Bröd portfoliet</param>
        /// <param name="vp">Vapen portfoliet</param> 
         public static void Check(int m, int op, int bp, int vp)
         {
            if (m >= 500000)//Kollar om spelaren har mer eller like med 500k
            {
                for (int i = 25; i > 0; i--)//Flyttar ner texten
                {
                    Console.WriteLine();
                }
                Console.WriteLine("DU VANN!!!",Console.ForegroundColor = ConsoleColor.Green);
                Console.ReadLine();
                Environment.Exit(0); //Stänger programmet
            }
            else if(m < 0 || op < 0 || bp < 0 || vp < 0)//kollar om pengarna eller nån av portfolierna är under 0
            {
                for (int i = 25; i > 0; i--)//Flyttar ner texten
                {
                    Console.WriteLine();
                }
                Console.WriteLine("DU GICK BANKRUPT!!", Console.ForegroundColor = ConsoleColor.Green);
                Console.ReadLine();
                Environment.Exit(0); //Stänger programmet
            }
         }
    }
}
