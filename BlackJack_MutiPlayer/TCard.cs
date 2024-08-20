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

    public enum emCardSuit
    {
        None,
        Clubs,    // 梅花
        Diamonds, // 方塊
        Hearts,   // 紅心
        Spades    // 黑桃
    }

    public static class Constants
    {
        public const int CARD_LEN = 13;
        public const int CARD_XLEN = 15;
        public const int CARD_YLEN = 13;
    }



    public class TCard
    {
        public int Number;
        public emCardSuit Suit;

        


        public string[] cardshape = new string[Constants.CARD_LEN];

        public TCard()
        {
            Number = -1;
            Suit = emCardSuit.None;
        }

        public TCard(int num, emCardSuit suit)
        {
            Number = num;
            Suit = suit;

            build();
        }

        public void build() 
        {
            string Numstr = "";
            switch (Number)
            {
                case 1:
                    Numstr = " A";
                    break;
                case 10:
                    Numstr = "10";
                    break;
                case 11:
                    Numstr = " J";
                    break;
                case 12:
                    Numstr = " Q";
                    break;
                case 13:
                    Numstr = " K";
                    break;
                default:
                    Numstr = " " + Number.ToString();
                    break;
            }

            switch (Suit)
            {
                case emCardSuit.Clubs:
                    cardshape[0] = " ------------- ";
                    cardshape[1] = "|" + Numstr + "           |";
                    cardshape[2] = "|             |";
                    cardshape[3] = "|      *      |";
                    cardshape[4] = "|     ***     |";
                    cardshape[5] = "|   *  *  *   |";
                    cardshape[6] = "|  *********  |";
                    cardshape[7] = "|   *  *  *   |";
                    cardshape[8] = "|      *      |";
                    cardshape[9] = "|   *******   |";
                    cardshape[10] = "|             |";
                    cardshape[11] = "|           " + Numstr + "|";
                    cardshape[12] = " ------------- ";
                    break;
                case emCardSuit.Diamonds:
                    cardshape[0] = " ------------- ";
                    cardshape[1] = "|" + Numstr + "           |";
                    cardshape[2] = "|             |";
                    cardshape[3] = "|      *      |";
                    cardshape[4] = "|    *****    |";
                    cardshape[5] = "|   *******   |";
                    cardshape[6] = "|  *********  |";
                    cardshape[7] = "|   *******   |";
                    cardshape[8] = "|    *****    |";
                    cardshape[9] = "|      *      |";
                    cardshape[10] = "|             |";
                    cardshape[11] = "|           " + Numstr + "|";
                    cardshape[12] = " ------------- ";
                    break;
                case emCardSuit.Hearts:
                    cardshape[0] = " ------------- ";
                    cardshape[1] = "|" + Numstr + "           |";
                    cardshape[2] = "|             |";
                    cardshape[3] = "|    ** **    |";
                    cardshape[4] = "|  *********  |";
                    cardshape[5] = "|  *********  |";
                    cardshape[6] = "|   *******   |";
                    cardshape[7] = "|    *****    |";
                    cardshape[8] = "|     ***     |";
                    cardshape[9] = "|      *      |";
                    cardshape[10] = "|             |";
                    cardshape[11] = "|           " + Numstr + "|";
                    cardshape[12] = " ------------- ";
                    break;
                case emCardSuit.Spades:
                    cardshape[0] = " ------------- ";
                    cardshape[1] = "|" + Numstr + "           |";
                    cardshape[2] = "|      *      |";
                    cardshape[3] = "|     ***     |";
                    cardshape[4] = "|   *******   |";
                    cardshape[5] = "|  *********  |";
                    cardshape[6] = "| *********** |";
                    cardshape[7] = "|  **  *  **  |";
                    cardshape[8] = "|      *      |";
                    cardshape[9] = "|   *******   |";
                    cardshape[10] = "|             |";
                    cardshape[11] = "|           " + Numstr + "|";
                    cardshape[12] = " ------------- ";
                    break;

                
            }


        }

        private void SetColor_bySuit()
        {
            if (Suit == emCardSuit.Spades || Suit == emCardSuit.Clubs)
            {
                Print_Tool.SetColor(ConsoleColor.Blue);  // 黑桃、梅花
            }
            else if (Suit == emCardSuit.Hearts || Suit == emCardSuit.Diamonds)
            {
                Print_Tool.SetColor(ConsoleColor.Red); // 紅心、方塊
            }
        }

        private void ResetColor()
        {
            Print_Tool.SetColor(ConsoleColor.White);//reset

        }


        public void print()
        {
            Position cursorPos = Print_Tool.getpos();

            SetColor_bySuit();

            for (int i = 0; i < Constants.CARD_LEN; i++)
            {
                Print_Tool.gotoxy(cursorPos.X, cursorPos.Y + i);
                Print_Tool.Write(cardshape[i]);
            }

            Print_Tool.gotoxy(cursorPos.X + Constants.CARD_XLEN, cursorPos.Y); //position RESET
            Print_Tool.SetColor(ConsoleColor.White);//reset
        }

        public void printline(int line)
        {
            SetColor_bySuit();

            Print_Tool.Write(cardshape[line]);
            ResetColor();
        }

    }


    public class TDeck
    {
        List<TCard> Cards = new List<TCard>();


        private static Random rng = new Random(); // 將 Random 物件設為類的成員




        public TDeck()
        {

        }
        public TCard getCard(int index)
        {
            TCard card = Cards[index];

            return card;
        }
        public TCard getBack()
        {
            int index = Cards.Count - 1;
            TCard card = Cards[index];

            return card;
        }
        public void printall()
        {
            printAmount(5);
        }
        public void printAmount(int cardsPerRow)
        {
            int total = Cards.Count;

            for (int i = 0; i < total; i += cardsPerRow)
            {
                for (int line = 0; line < Constants.CARD_LEN; line++)
                {
                    for (int j = i; j < i + cardsPerRow && j < total; j++)
                    {
                        Cards[j].printline(line);
                    }
                    Print_Tool.Print_Enter();
                }
            }
        }


        public void printallPos(Position pos)
        {
            Print_Tool.gotoxy(pos.X, pos.Y); //position RESET
            for (int i = 0; i < Cards.Count; i++)
            {
                Cards[i].print();
                if (i != 0 && i % 5 == 0)
                {
                    Print_Tool.gotoxy(pos.X, pos.Y + Constants.CARD_YLEN * (i / 5)); //position RESET
                }
            }
        }



        public void createDeck()
        {
            for (int num = 1; num <= 13; num++)
            {
                Cards.Add(new TCard(num, emCardSuit.Clubs));
                Cards.Add(new TCard(num, emCardSuit.Diamonds));
                Cards.Add(new TCard(num, emCardSuit.Hearts));
                Cards.Add(new TCard(num, emCardSuit.Spades));
            }
        }

        public void shuffle()
        {
            Random rng = new Random();
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                TCard value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }
        public void add_card(int num, emCardSuit suit)
        {
            TCard card = new TCard(num, suit);
            Cards.Add(card);
        }
        public void add_card(TCard card)
        {
            Cards.Add(card);
        }
        public void popBack()
        {
            Cards.RemoveAt(Count - 1);
        }
        public int Count
        {
            get
            {
                return Cards.Count;
            }
        }
        public int getdeckpoint()
        {
            int sum = 0;
            for(int i = 0; i < Cards.Count; i++)
            {
                sum += Cards[i].Number;
            }
            return sum;
        }

    }
}
