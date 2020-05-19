using System;
using System.Collections.Generic;
using System.Text;

namespace Riktiga_aktie_spelet
{
    class Ints
    {
        //Denna klassen blev bara mindre och mindre viktigare men har använt money lite överallt så kan inte ta bort den
        private int money;

        public Ints(int m)
        {
            money = m;
        }

        public int Money
        {
            get { return money; }
            set { money = value; }
        }
    }
}
