using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class Event
    {
        private int time; //Hur länge eventet håller på
        private int change; // hur mycket eventet ändrar

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
