using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class Stocks
    {
        private string name;
        private int newStatus; //Visar det nuvarande värdet på aktien 
        private int oldStatus; //Visar värdet på aktien förra rundan
        private int portfolio; //Hur mycket man äger av aktien
        private int change; //Hur mycket aktien kan förändras
        private bool active; //Om man har investerat
        private int money; //Hur mycket man investerade från början
        private int potential; //Sannolikheten att det går bra för en aktie
        private int specialChange; //För att event ska kunna påvärka hur aktien ändras
        private int tempChange; //Visar hur mycket en aktie har gått ner eller upp sen förra rundan

        public Stocks(string n, int c, int s)
        {
            name = n;
            newStatus = 1;
            oldStatus = 1;
            portfolio = 0;
            change = c;
            active = false;
            money = 0;
            potential = s;
            specialChange = 0;
        }

        public int NewStatus
        {
            get { return newStatus; }
            set { newStatus = value; }
        }

        public int OldStatus
        {
            get { return oldStatus; }
            set { oldStatus = value; }
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
                    Console.WriteLine("Nu är en active fel!!", Console.ForegroundColor = ConsoleColor.Red); //Error medelande om jag har råkat sätta active till något annat än en bool.
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
        public int SpecialChange
        {
            get { return specialChange; }
            set { specialChange = value; }
        }
        public int TempChange
        {
            get { return tempChange; }
            set { tempChange = value; }
        }
    }
}
