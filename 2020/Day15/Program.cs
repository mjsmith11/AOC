using System;
using System.Collections.Generic;

namespace Day15
{
    class Program
    {
        static void Main(string[] args)
        {
            string inp = "6,19,0,5,7,13,1";
            Console.WriteLine("Part 1: " + run(2020,inp));
            Console.WriteLine("Part 2: " + run(30000000,inp));
        }

        static int run(int numTurns, string inp) {
            string[] splitInp = inp.Split(',');
            int lastNum = 0;
            int turn = 1;
            Dictionary<int,int> lastSpoken = new Dictionary<int,int>();
            Dictionary<int,int> diff = new Dictionary<int,int>();
            for(int i=0;i<splitInp.Length;i++) {
                lastNum = int.Parse(splitInp[i]);
                lastSpoken[lastNum] = turn;
                turn++;
            }

            while(turn<=numTurns) {
                //figure out the number to say
                int myNum = 0;
                if(diff.ContainsKey(lastNum)) {
                    myNum = diff[lastNum];
                }

                // say it and update vars
                lastNum = myNum;
                if(lastSpoken.ContainsKey(lastNum)) {
                    diff[lastNum] = turn - lastSpoken[lastNum];
                }
                lastSpoken[lastNum] = turn;
                turn++;
            }
            return lastNum;
        }
    }
}
