using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class Ints
    {
        private int money;
        private bool life;

        public Ints(int m)
        {
            money = m;
        }

        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        public bool Life
        {
            get { return life; }
            set { life = value; }
        }
    }
}
