using Luffy_Tool;



namespace BlackJack_MutiPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TBlackJack blackJack = new TBlackJack(3,50000,3,100);

            blackJack.start();

        }
    }
}