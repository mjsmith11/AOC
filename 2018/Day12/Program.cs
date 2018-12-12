using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            string input = @".#.#. => .
...#. => #
..##. => .
....# => .
##.#. => #
.##.# => #
.#### => #
#.#.# => #
#..#. => #
##..# => .
##### => .
...## => .
.#... => .
###.. => #
#..## => .
#...# => .
.#..# => #
.#.## => .
#.#.. => #
..... => .
####. => .
##.## => #
..### => #
#.... => .
###.# => .
.##.. => #
#.### => #
..#.# => .
.###. => #
##... => #
#.##. => #
..#.. => #";
            string initial = "#.##.###.#.##...##..#..##....#.#.#.#.##....##..#..####..###.####.##.#..#...#..######.#.....#..##...#";


            // Indices -150 to 150.  Add 150 to index
            bool[] state = new bool[2001];
            for(int i = 0; i<state.Length; i++)
            {
                state[i] = false;
            }
            for(int i=0; i<initial.Length; i++)
            {
                if (initial[i] == '#')
                {
                    state[i + 1000] = true;
                }
            }
            string[] splits = input.Split('\n');
            Dictionary<string, string> rules = new Dictionary<string, string>();
            foreach(string s in splits)
            {
                string trimmed = s.Trim();
                string left = trimmed.Substring(0, 5);
                string right = trimmed.Substring(9, 1);

                if (right == "#")
                {
                    rules[trimmed.Substring(0, 5)] = trimmed.Substring(9, 1);
                }
            }

            bool[] newState = new bool[2001];
            newState[0] = false;
            newState[1] = false;
            newState[1999] = false;
            newState[2000] = false;
            for(int i=0; i<200; i++)
            {
                for(int j = 2; j < 1999; j++)
                {
                    string test = "";
                    if (state[j - 2])
                    {
                        test += "#";
                    }
                    else
                    {
                        test += ".";
                    }

                    if (state[j - 1])
                    {
                        test += "#";
                    }
                    else
                    {
                        test += ".";
                    }

                    if (state[j])
                    {
                        test += "#";
                    }
                    else
                    {
                        test += ".";
                    }

                    if (state[j + 1])
                    {
                        test += "#";
                    }
                    else
                    {
                        test += ".";
                    }

                    if (state[j + 2])
                    {
                        test += "#";
                    }
                    else
                    {
                        test += ".";
                    }
                    newState[j] = (rules.ContainsKey(test));
                }
                for(int q=0; q < 2001; q++)
                {
                    state[q] = newState[q];
                }
                int total = 0;
                for (int r = -1000; r <= 1000; r++)
                {
                    if (state[r + 1000])
                    {
                        total += r;
                    }
                }
                Console.WriteLine((i+1) + " " + total);
            }
           
            Console.ReadLine();
        }

    }
}

// Part 2
// By iteration 200, it can be observed that the result increases by 62 with each iteration and the result after 200 iterations is 13055.
// To calculate the result for 50,000,000,000:
// 13055 + (50,000,000,000 - 200) * 62
