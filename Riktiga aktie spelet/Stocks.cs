using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class Stocks
    {
        private string name;
        private int status; //Om aktien är plus eller minus
        private int portfolio; //Hur mycket man äger av aktien
        private int change; //Hur mycket aktien kan förändras
        private bool active; //Om man har investerat
        private int money; //Hur mycket man investerade från början
        private int potential; //Sannolikheten att det går bra för en aktie
        private int specialChange; //För att event ska kunna påvärka hur aktien ändras
        public Stocks(string n, int c, int s)
        {
            name = n;
            status = 0;
            portfolio = 0;
            change = c;
            active = false;
            money = 0;
            potential = s;
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public int Portfolio
        {
            get { return portfolio; }
            set { portfolio = value; }
        }

        public int Change
        {
            get { return change; }
            set { change = value; }
        }

        public bool Active
        {
            get { return active; }
            set
            {
                if(value==true || value == false)
                {
                    active = value;
                }
                else
                {
                    Console.WriteLine("Nu är en active fel!!", Console.ForegroundColor = ConsoleColor.Red);
                }
            }
        }

        public int Potential
        {
            get { return potential; }
            set { potential = value; }
        }

        public int Money
        {
            get { return money; }
            set { money = value;  }
        }
    }
}
