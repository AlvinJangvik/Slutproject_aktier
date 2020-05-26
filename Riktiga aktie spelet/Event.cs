using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class Event
    {
        private int time; //Hur länge eventet håller på
        private int change; // hur mycket eventet ändrar
        
        /// <summary>
        /// Fixar variablerna som ändras när ett event händer
        /// </summary>
        /// <param name="t">Tiden som eventet håller på</param>
        /// <param name="c">Förändringen i aktierna som kommer hända</param> 
        public Event(int t, int c)
        {
            time = t;
            change = c;
        }

        public int Time
        {
            get { return time; }
            set { time = value; }
        }

        public int Change
        {
            get { return change; }
            set { change = value; }
        }
    }
}
