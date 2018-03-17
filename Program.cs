/*
Tic Tac Toe
Started: 2/2/18
*/

using System;
using System.Collections.Generic;
using ConsoleApp1;

/*
 *Show menu. Options:(play, help, exit)
 *Get player data. Data:(names, tic tac toe mark)
 *Start a game. Data:(turns, winners) 
 *Say the winner. Print stats of each player.
 *Prompt if another game is desired.
 *Goto the first step if yes.
*/

namespace TicTacToe
{
    class Board
    {
        public Board()
        {
            markdata = new Dictionary<int, char>();//Chars: x, o, - The char "-" represents an empty tile.
            for (int i = 0; i < 9; i++)
            {
                markdata.Add(i, '-');
            }
        }

        public void showBoard() {
            for (int i = 0; i <= 6; i+=3)
            {
                Console.Write(markdata[i] + " " + markdata[i + 1] + " " + markdata[i + 2]);
                Console.WriteLine("\n");
            }
        }

        public void editBoard(int id, char pc)
        {
            if (markdata[id] == '-')
            {
                markdata[id] = pc;
            }
            else
            {
                Console.WriteLine("Spot already filled. Try again...");
                int redoid = Convert.ToInt16(Console.ReadLine());
                editBoard(redoid, pc);
                redoid = 0;
            }
        }

        public bool checkIfFilled()
        {
            for (int i = 0; i <= 8; i++)
            {
                if (markdata[i] == '-')
                {
                    return false;
                }
            }
            return true;//goes to game loop, which ends if the board is full or a player wins.
        }

        public int getWinner(int cp)
        {
            /*
             * Board indexes:
             * 0 1 2
             * 3 4 5
             * 6 7 8
            */

            //check horizontals
            for (int b = 0; b <= 6; b+=3)
            {
                if (markdata[b] != '-' && markdata[b] == markdata[b + 1] && markdata[b + 1] == markdata[b + 2])
                {
                    if (markdata[b] == 'x') return 1; else return -1;
                }
            }

            //check verticals
            for (int d = 0; d <= 2; d++)
            {
                if (markdata[d] != '-' && markdata[d] == markdata[d+3] && markdata[d+3] == markdata[d+6])
                {
                    if (markdata[d] == 'x') return 1; else return -1;
                }
            }

            //check 2 diagonal cases
            if ((markdata[0] != '-' && markdata[0] == markdata[4] && markdata[4] == markdata[8]) || (markdata[2] != '-' && markdata[2] == markdata[4] && markdata[4] == markdata[6]))
            {
                if (markdata[0] == 'x' || markdata[2] == 'x') return 1; else return -1;
            }

            return 0;
        }

        //board data
        private Dictionary<int, char> markdata;
    };

    class Program
    {
        private static bool validateInput(int input)
        {
            if (input >= 0 && input < 9)
            {
                return true;
            }
            return false;
        }

        private static void sayWinner(int winner, int turn, Board b)
        {
            Console.WriteLine("Game over");
            winner = b.getWinner(turn);
            switch (winner)
            {
                case (1):
                    Console.WriteLine("Winner: Player X");
                    break;
                case (-1):
                    Console.WriteLine("Winner: Player O");
                    break;
                default:
                    Console.WriteLine("Tie Game");
                    break;
            }
            System.Threading.Thread.Sleep(10000);
        }

        public static void Main(string[] args)
        {
            //inst game objects
            Board board = new Board();
            Player x = new Player('x');
            Player o = new Player('o');

            //init game vars
            int input = 0;
            int turn = 1;//1: x. -1: o.
            int winner = 0;//0: no winner yet.
            while (true)
            {
                board.showBoard();
                winner = board.getWinner(turn);
                if (winner == 0 && board.checkIfFilled() == false)
                {
                    switch (turn)
                    {
                        case (1):
                            Console.WriteLine("Player X's turn.");
                            input = Convert.ToInt16(Console.ReadLine());
                            board.editBoard(input, x.getChar());
                            break;
                        case (-1):
                            Console.WriteLine("Player O's turn.");
                            input = Convert.ToInt16(Console.ReadLine());
                            board.editBoard(input, o.getChar());
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    sayWinner(winner, turn, board);
                    break;
                }
                turn *= -1;
            }
        }
    }
}
