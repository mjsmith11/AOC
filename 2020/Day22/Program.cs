using System;
using System.Collections;
using System.Collections.Generic;

namespace Day22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1: " + part1());
            Console.WriteLine("Part 2: " + part2());
        }

        static int part1() {
            Queue<int> deck1 = new Queue<int>();
            Queue<int> deck2 = new Queue<int>();
            string[] p1Cards = getPlayer1();
            string[] p2Cards = getPlayer2();

            foreach(string card in p1Cards) {
                deck1.Enqueue(int.Parse(card));
            }

            foreach(string card in p2Cards) {
                deck2.Enqueue(int.Parse(card));
            }


            while (deck1.Count > 0 && deck2.Count > 0) {
                int card1 = deck1.Dequeue();
                int card2 = deck2.Dequeue();

                if (card1>card2) {
                    deck1.Enqueue(card1);
                    deck1.Enqueue(card2);
                } else {
                    deck2.Enqueue(card2);
                    deck2.Enqueue(card1);
                }
            }

            int score = 0;
            int currentMultiplier = deck1.Count>0 ? deck1.Count : deck2.Count;

            while (deck1.Count > 0) {
                score += currentMultiplier * deck1.Dequeue();
                currentMultiplier--;
            }

            while (deck2.Count > 0) {
                score += currentMultiplier * deck2.Dequeue();
                currentMultiplier--;
            }

            return score;
        }

        static int part2() {
            Queue<int> deck1 = new Queue<int>();
            Queue<int> deck2 = new Queue<int>();
            string[] p1Cards = getPlayer1();
            string[] p2Cards = getPlayer2();

            foreach(string card in p1Cards) {
                deck1.Enqueue(int.Parse(card));
            }

            foreach(string card in p2Cards) {
                deck2.Enqueue(int.Parse(card));
            }

            recursiveGame(deck1,deck2,0);

            int score = 0;
            int currentMultiplier = deck1.Count>0 ? deck1.Count : deck2.Count;

            while (deck1.Count > 0) {
                score += currentMultiplier * deck1.Dequeue();
                currentMultiplier--;
            }

            while (deck2.Count > 0) {
                score += currentMultiplier * deck2.Dequeue();
                currentMultiplier--;
            }

            return score;
        }

        static int recursiveGame(Queue<int> deck1, Queue<int> deck2, int j) {
            Console.WriteLine("Recursion Level " + j);
            List<Queue<int>> deck1History = new List<Queue<int>>();
            List<Queue<int>> deck2History = new List<Queue<int>>();
            
            while (deck1.Count > 0 && deck2.Count > 0) {
                for(int i=0; i<deck1History.Count; i++) {
                    if (queuesEqual(deck1,deck1History[i]) && queuesEqual(deck2,deck2History[i])) { return 1; }
                }
                deck1History.Add(new Queue<int>(deck1));
                deck2History.Add(new Queue<int>(deck2));

                int card1 = deck1.Dequeue();
                int card2 = deck2.Dequeue();

                int roundWinner = 0;
                if (deck1.Count >= card1 && deck2.Count>=card2) {
                    // recursive combat!
                    roundWinner = recursiveGame(new Queue<int>(deck1), new Queue<int>(deck2),j+1);
                } else {
                    if (card1>card2) {
                        roundWinner = 1;
                    } else {
                        roundWinner = 2;
                    }
                }

                if (roundWinner == 1) {
                    deck1.Enqueue(card1);
                    deck1.Enqueue(card2);
                } else {
                    deck2.Enqueue(card2);
                    deck2.Enqueue(card1);
                }
            }
            if (deck1.Count > 0) {return 1; }
            else { return 2; }
        }

        static bool queuesEqual(Queue<int> q1, Queue<int> q2) {
            if (q1.Count != q2.Count) {return false;}
            Queue<int> myQ1 = new Queue<int>(q1);
            Queue<int> myQ2 = new Queue<int>(q2);
            while(myQ1.Count > 0){
                if (myQ1.Dequeue() != myQ2.Dequeue()) { return false;}
            }
            return true;
        }

        static string[] getPlayer1() {
            string input = System.IO.File.ReadAllText(@"player1.txt");
            return input.Split('\n');
        }

        static string[] getPlayer2() {
            string input = System.IO.File.ReadAllText(@"player2.txt");
            return input.Split('\n');
        }
    }
}
