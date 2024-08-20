using Luffy_Tool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_MutiPlayer
{
    internal class TPlayer
    {
	    string name = "Default";
        TDeck player_deck = new TDeck();
        Tmoney player_money = new Tmoney();  // 玩家擁有的錢
        Tmoney gain = new Tmoney();          // 贏的錢
        bool Bool_bankerorNot;
        bool Bool_died = false;
        bool Bool_outofmoney = false;


	    public TPlayer(string name, int money)
        {
            player_money.set_money(money);
        }
        public TPlayer()
        {

        }
        public static bool pay(TPlayer fromplayer, TPlayer toplayer, int pay_money)
        {
            if (fromplayer.getmoney() <= pay_money)
            {
                Print_Tool.WriteLine("已破產");
                return false;
            }
            else
            {
                fromplayer.loseMoney(pay_money);
                toplayer.earnMoney(pay_money);
                return true;
            }
        }
        public int getmoney()
        {
            return player_money.get_money();

        }
        //取得玩家目前金額
        public void add_todeck(TCard card)
        {
            player_deck.add_card(card);
        }
        public void displayDeck(Position pos) 
        {
            TDeck deck = player_deck;
            deck.printallPos(pos);
            Print_Tool.gotoxy(pos.X, pos.Y + Constants.CARD_YLEN);
        }// 在pos 處顯示
        public void earnMoney(int money)
        {
            player_money.add_money(money);
            gain.add_money(money);

        } // 玩家賺錢
        public void loseMoney(int money)
        {
            player_money.minus_money(money);
            gain.minus_money(money);
        }
        public void SetMoney(int money)
        {
            player_money.set_money(money);

        }

        public void drawPlayerUI(Position pos)
        {
            //Position pos = Card::getpos();

            int point = getdeckpoint();
            //cout << name << ", Money: " << player_money.get_money() << "¥Ø«eÂI¼Æ: " << point;
            Print_Tool.Write(name + ", Money: " + player_money.get_money() + "目前點數: " + point);
            pos.Y++;

            displayDeck(pos);
        }
        public void drawPlayerUI()
        {
            Position pos = Print_Tool.getpos();

            int point = getdeckpoint();


            if (isBankerorNot())
            {
                Print_Tool.Write("[玩家]: Player : ", ConsoleColorType.Notice);
            }
            else
            {
                Print_Tool.Write("[莊家]: Player : ", ConsoleColorType.Default);
            }

            if (isdead())
            {
                Print_Tool.Write(name + "     ", ConsoleColor.Red);
            }
            else
            {
                Print_Tool.Write(name + "     ", ConsoleColorType.Default);

            }


            if (isoutofmoney())
            {
                Print_Tool.Write("   , Money: " + player_money.get_money(), ConsoleColor.Red);
            }
            else
            {
                Print_Tool.Write("   , Money: " + player_money.get_money(), ConsoleColorType.Default);
            }


            if (point > 21)
            {
                Print_Tool.Write("   , 爆點: " + point, ConsoleColor.Red);
            }
            else
            {
                Print_Tool.Write("   , 點數: " + point, ConsoleColorType.Default);
            }

            pos.Y++;

            displayDeck(pos);

            Print_Tool.Print_Enter(2);

        }
        public void drawPlayerUI(int playerindex)
        {
            Position getpos = Print_Tool.getpos(); //player 1 = (0,5)
            Position pos = new Position(0, 2 + (16 * playerindex));
            Print_Tool.gotoxy(pos.X, pos.Y);
            int point = getdeckpoint();


            if (isBankerorNot())
            {

                Print_Tool.Write("[玩家]: Player : ", ConsoleColorType.Notice);

            }
            else
            {
                Print_Tool.Write("[莊家]: Player : ", ConsoleColorType.Default);

            }

            if (isdead())
            {
                Print_Tool.Write(name + "淘汰", ConsoleColor.Red);
            }
            else
            {
                Print_Tool.Write(name + "     ", ConsoleColorType.Default);
            }


            if (isoutofmoney())
            {
                Print_Tool.Write("   , Money: " + player_money.get_money(), ConsoleColor.Red);


            }
            else
            {
                Print_Tool.Write("   , Money: " + player_money.get_money(), ConsoleColorType.Default);
            }


            if (point > 21)
            {

                Print_Tool.Write("   , 爆點: " + point, ConsoleColor.Red);

            }
            else
            {
                Print_Tool.Write("   , 點數: " + point, ConsoleColorType.Default);

            }

            pos.Y++;

            displayDeck(pos);
            Print_Tool.Print_Enter(2);

        }

        public bool isdead()
        {
            return Bool_died;

        }
        public bool isoutofmoney()
        {
            if (player_money.get_money() <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isBankerorNot()
        {
            return Bool_bankerorNot;

        }
        public void calculate()
        {
            int point = getdeckpoint();


            if (point > 21)
            {
                Bool_died = true;
            }
        }

        public int getdeckpoint()
        {
            return player_deck.getdeckpoint();

        }




    }
}
