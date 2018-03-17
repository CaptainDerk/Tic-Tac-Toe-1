/*Player class*/
namespace ConsoleApp1
{
    class Player
    {
        public Player(char mk)
        {
            mark = mk;
            wins = 0;
            losses = 0;
        }
        
        public char getChar()
        {
            return mark;
        }
        public void updateStats(bool win)
        {
            if (win)
            {
                wins++;
            }
            else
            {
                losses++;
            }
        }

        ~Player()
        {
            mark = ' ';
            wins = 0;
            losses = 0;
        }

        private char mark;
        private int wins, losses;
    }
}
