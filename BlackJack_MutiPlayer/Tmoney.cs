using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_MutiPlayer
{
    internal class Tmoney
    {
        int money;

	    public Tmoney()
        {
            money = 0;
        }
        public Tmoney(int amount)
        {
            money = amount;

        }
        public int get_money()
        {
            return money;
        }
        public void set_money(int amount)
        {
            money = amount;

        }

        public void add_money(int amount)
        {
            money += amount;

        }
        public void minus_money(int amount)
        {
            money -= amount;

        }



    }
}
