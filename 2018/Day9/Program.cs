using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static int players = 435;
        public static int lastMarble = 71184 * 100;
        static void Main(string[] args)
        {
            List<long> scores = new List<long>();
            for (int i = 0; i <= players; i++)
            {
                scores.Add(0);
            }
            List<int> marbles = new List<int>();
            marbles.Add(0);
            int nextMarble = 1;
            int turn = 1;
            int current = 0;
            while (nextMarble <= lastMarble)
            {
                if (nextMarble % 23 == 0)
                {
                    scores[turn] += nextMarble;
                    int take = current;
                    for (int i = 0; i < 7; i++)
                    {
                        take = moveCounterClockwise(marbles, take);
                    }
                    scores[turn] += marbles[take];
                    marbles.RemoveAt(take);
                    current = take;
                    if (current == marbles.Count())
                    {
                        current = 0;
                    }
                }
                else
                {
                    int ind = moveClockwise(marbles, current);
                    marbles.Insert(ind + 1, nextMarble);
                    current = ind + 1;
                }

                nextMarble++;
                turn = nextTurn(turn);

            }
            Console.WriteLine(scores.Max());
            Console.ReadLine();
        }

        public static int moveClockwise(List<int> list, int current)
        {
            current++;
            if (current >= list.Count())
            {
                current = 0;
            }
            return current;
        }

        public static int moveCounterClockwise(List<int> list, int current)
        {
            current--;
            if (current < 0)
            {
                current = list.Count() - 1;
            }
            return current;
        }
        public static int nextTurn(int turn)
        {
            turn++;
            if (turn > players)
            {
                turn = 1;
            }
            return turn;
        }
    }
}
