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
    internal class TBlackJack
    {
        List<TPlayer> playerlist = new List<TPlayer>();
        List<int> playerOUTlist = new List<int>();

        TDeck main_deck = new TDeck();

        int Player_amount = 0;
        int Default_money = 0 ;
        int Rounds = 0;
        int Mustpay = 0;



        public TBlackJack(int plays_amount, int start_money, int rds, int must_pay)
        {
            Rounds = rds;
            Player_amount = plays_amount;
            Default_money = start_money;
            Mustpay = must_pay;


            for (int i = 0; i < Player_amount; i++)
            {
                TPlayer temp = new TPlayer();
                string name = "Default_" + (i + 1).ToString();
                //temp.SetMoney(start_money);
                playerlist.Add(temp);
            }

            for (int i = 0; i < Player_amount; i++)
            {
                int status = 0;
                playerOUTlist.Add(status);
            }

            // 牌庫生成
            main_deck.createDeck();
            main_deck.shuffle(); // 洗牌
        }
        public void start()
        {
            Print_Tool.Clear();
            Print_Tool.WriteLine("遊戲設定 : " + "玩家數量 :" + Player_amount + "  起始金額 :" + Default_money + "  底注為 :"+ Mustpay, ConsoleColorType.Notice);





            int player_amount = playerlist.Count();

            bool finish = false;
            int cur_round = 1;
            //cout << endl;
            Position start_pos = Print_Tool.getpos();
            while (finish != true && cur_round <= Rounds)
            {
                Print_Tool.gotoxy(start_pos.X, start_pos.Y);

                Print_Tool.Write("[ Round : ");

                if (cur_round == Rounds)
                {
                    Print_Tool.Write(cur_round.ToString(), ConsoleColorType.Default);

                }
                else
                {
                    Print_Tool.Write(cur_round.ToString());

                }

                //cout << " / " << Rounds << " ]" << endl;
                Print_Tool.WriteLine(" / " + Rounds + " ]" , ConsoleColorType.Default);
                //cout << endl;

                //system("pause");

                for (int i = 0; i < playerlist.Count(); i++)
                {
                    TPlayer player = playerlist[i];   // 被發牌玩家
                    player.drawPlayerUI(i);

                    if (!player.isdead())
                    {

                        askfordeal(player, i);

                        //Card card = main_deck.getBack(); //抽牌
                        //player->add_todeck(card);
                        //main_deck.popBack();

                        player.calculate();  //判斷玩家狀態
                    }

                    player.drawPlayerUI(i);



                }












                cur_round++;
            }



        }
        public void shuffle()
        {
            Print_Tool.WriteLine("開始洗牌");
            main_deck.shuffle();
            Print_Tool.WriteLine("洗牌完畢");

        }
        public void giveout(TPlayer player)
        {

        }



        //UI
        public void drawUI()
        {

        }
        public void drawMenu()
        {

        }
        public void drawPlayer()
        {

        }
        public void showStatus()
        {

        }

        public void dealCard()
        {

        }
        public void askfordeal(TPlayer player, int playerindex)
        {
            Position pos = Print_Tool.getpos();
            pos.Y = pos.Y - 2;
            Print_Tool.gotoxy(pos.X, pos.Y);

            string choice;
            //cout << "請問是否抽牌 [Y/N] : ";
            Print_Tool.Write("請問是否抽牌 [Y/N] : ");
            //cin >> choice;
            choice = Console.ReadLine(); 

            if (choice == "Y" || choice == "y") {
                TCard card = main_deck.getBack(); //抽牌
                player.add_todeck(card);
                main_deck.popBack();
            }

            else
            {
                playerOUTlist[playerindex] = -1;
            }
            Print_Tool.gotoxy(pos.X, pos.Y);

            Print_Tool.Write("                                ");
        }


        public Position getMenuPos()
        {
            int x = 0; 
            int y = 0;
            Position pos = new Position(x,y);


            return pos; 
        }
        public Position getMenu_Status_Pos()
        {
            int x = 0;
            int y = 0;
            Position pos = new Position(x,y);

            return pos;
        }






    }



}
