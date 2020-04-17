using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class Ints
    {
        //Lättare att hålla koll på dessa viktiga ints
        private int money;
        private bool life;

        public Ints(int m)
        {
            money = m;
            life = true;
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
