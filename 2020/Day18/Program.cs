using System;
// the idea is to write a translator to take the input and create executable code for the part2() method to calculate 
// the answer.  First we swap + and * signs in the input.  Since C# does * before +, swapping them makes the 
// operations that are actually + happen first.  Then to do the math correctly, I use the Num struct which overrides
// + and * to make them do the opposite operation.
namespace Day18
{
    class Program
    {
        static void Main(string[] args)
        {
            //part2trans();
            Console.WriteLine("Part 2: " + part2());
        }

        public static void part2trans() {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"/work/Day18/code.txt")) {
                foreach(string s in getInput()) {
                    file.WriteLine("sum += (" + translate(s.Trim()) + ").ToInt();");
                }
            }
        }

        public static long part2() {
            long sum=0;

            sum += (new Num(3) + new Num(4) + new Num(2) + new Num(5) + (new Num(3) * new Num(4) + (new Num(6) * new Num(3) * new Num(2) * new Num(8) * new Num(4)) * new Num(5) + new Num(7))).ToInt();
sum += (new Num(2) * new Num(6) + new Num(2) + new Num(4) + (new Num(9) * new Num(6) + new Num(7) * new Num(2) + new Num(7)) * new Num(3)).ToInt();
sum += ((new Num(9) * new Num(4) + new Num(4) * new Num(5) + new Num(2)) + new Num(2) + new Num(7)).ToInt();
sum += (new Num(5) + new Num(9) + (new Num(6) * new Num(6) * new Num(8) + (new Num(5) * new Num(2) * new Num(2) + new Num(6) + new Num(8)) + new Num(8) * new Num(9)) + new Num(3) * ((new Num(8) + new Num(9) * new Num(6) + new Num(5)) * new Num(2) + new Num(5) * new Num(4) + new Num(6) + new Num(4)) * new Num(4)).ToInt();
sum += (new Num(3) * (new Num(4) * new Num(9) * new Num(6) * new Num(6) + new Num(4)) * new Num(9)).ToInt();
sum += (new Num(7) + new Num(2) + new Num(7) + ((new Num(7) + new Num(6) * new Num(8) + new Num(9)) * new Num(2))).ToInt();
sum += (new Num(2) + (new Num(7) + new Num(5)) * (new Num(7) + new Num(9) + new Num(7)) * new Num(9)).ToInt();
sum += ((new Num(6) + (new Num(6) * new Num(8)) * (new Num(4) * new Num(7) * new Num(4) * new Num(8) * new Num(2) * new Num(8)) + new Num(8) * (new Num(4) * new Num(9) + new Num(9) + new Num(5) * new Num(7))) * new Num(6) * new Num(6) + new Num(6)).ToInt();
sum += (new Num(4) * (new Num(4) + new Num(3) + new Num(9)) * (new Num(8) * new Num(4) * new Num(4) * (new Num(3) * new Num(8) * new Num(8))) * new Num(8) + new Num(6) + (new Num(8) + new Num(5) * new Num(4) + new Num(5) + (new Num(9) * new Num(8) + new Num(4) * new Num(2)))).ToInt();
sum += (new Num(9) * (new Num(8) + (new Num(3) * new Num(2) * new Num(9) * new Num(8) + new Num(8)) * (new Num(3) + new Num(7) + new Num(7) * new Num(8)) + new Num(2)) + new Num(6) + new Num(9)).ToInt();
sum += (new Num(2) * (new Num(4) * new Num(3) + new Num(7) + new Num(8)) + ((new Num(6) + new Num(3) * new Num(4) * new Num(6)) * new Num(8) * new Num(2) * new Num(4) + new Num(5))).ToInt();
sum += (new Num(2) * (new Num(5) + new Num(9) * (new Num(6) * new Num(7) * new Num(4) * new Num(3)) + new Num(4)) * new Num(3) * new Num(4) + (new Num(9) + new Num(2) * (new Num(5) + new Num(7) + new Num(5) + new Num(6) * new Num(9))) + new Num(9)).ToInt();
sum += (new Num(6) + new Num(7) * new Num(8)).ToInt();
sum += (new Num(7) + new Num(5) * (new Num(4) + new Num(6) * new Num(7) + (new Num(3) * new Num(9) * new Num(4) * new Num(7) + new Num(7)) * new Num(6) + new Num(2))).ToInt();
sum += (new Num(7) * new Num(9) + new Num(6) + (new Num(6) * (new Num(2) + new Num(7) * new Num(5) * new Num(4))) * new Num(5) * (new Num(2) * new Num(9) * (new Num(4) * new Num(5) * new Num(6)))).ToInt();
sum += (new Num(5) + (new Num(5) * new Num(8) + new Num(3)) * (new Num(6) + (new Num(5) + new Num(8)) + new Num(4))).ToInt();
sum += (new Num(5) + (new Num(3) * new Num(8) * new Num(6) * new Num(9) + new Num(7)) + (new Num(3) + new Num(6) + new Num(3)) + (new Num(8) * (new Num(5) + new Num(9) * new Num(7) + new Num(5)) * new Num(4) * new Num(5) * new Num(5) * new Num(9)) * new Num(5)).ToInt();
sum += (new Num(4) * (new Num(6) * new Num(2) + new Num(8) * new Num(7)) + new Num(6) + new Num(5) * (new Num(2) + new Num(9))).ToInt();
sum += (((new Num(5) * new Num(7) + new Num(6) * new Num(4) + new Num(3)) * new Num(7) * new Num(2) + new Num(2)) * new Num(7) + new Num(7) * new Num(2)).ToInt();
sum += (new Num(9) * new Num(8) + ((new Num(2) * new Num(4) + new Num(7)) * new Num(7) + new Num(9) * (new Num(2) + new Num(5) * new Num(7) + new Num(9) * new Num(4) + new Num(4)))).ToInt();
sum += ((new Num(7) * new Num(5)) * new Num(5) + (new Num(5) * new Num(2) + new Num(5) * new Num(3) + new Num(7) + new Num(6)) * new Num(7)).ToInt();
sum += (new Num(4) * (new Num(4) * (new Num(6) + new Num(2) + new Num(8) * new Num(6) * new Num(3)) + (new Num(6) + new Num(6) + new Num(4) + new Num(7) + new Num(2))) + new Num(5) + new Num(2) * new Num(2) * new Num(6)).ToInt();
sum += ((new Num(2) + (new Num(6) + new Num(2) * new Num(4))) * new Num(5) * new Num(7) + new Num(2) + new Num(8) * new Num(8)).ToInt();
sum += (new Num(5) + new Num(4) * new Num(8) * new Num(9) * new Num(6)).ToInt();
sum += ((new Num(3) + new Num(4) * new Num(3) * new Num(5)) * new Num(7) * (new Num(7) * new Num(9))).ToInt();
sum += ((new Num(2) + new Num(8) * new Num(2) * new Num(2) * new Num(2) * (new Num(4) * new Num(2) + new Num(8) + new Num(6) + new Num(5) * new Num(6))) * (new Num(8) * new Num(7) * new Num(8) + (new Num(4) + new Num(5) + new Num(5) + new Num(4))) + new Num(7) + new Num(6) + (new Num(7) * new Num(3) * new Num(3) + new Num(8) * new Num(5)) * new Num(8)).ToInt();
sum += (new Num(8) + ((new Num(6) * new Num(5) + new Num(3)) + new Num(3) * new Num(5)) * new Num(3) + (new Num(4) * (new Num(9) * new Num(4) + new Num(4) * new Num(8) * new Num(9)) + new Num(6) + (new Num(9) + new Num(4) + new Num(2))) + new Num(6)).ToInt();
sum += (new Num(4) + new Num(6) * (new Num(3) + new Num(8) + new Num(8)) + new Num(2)).ToInt();
sum += (new Num(8) + new Num(2) + new Num(8) + new Num(4) + (new Num(7) * new Num(8) * new Num(2) * (new Num(7) * new Num(2) * new Num(5) + new Num(6) + new Num(8) * new Num(2)) + new Num(3) * new Num(4))).ToInt();
sum += (new Num(3) * new Num(8) + new Num(5) * new Num(4) + (new Num(7) + (new Num(7) * new Num(6)) * new Num(9) * (new Num(9) * new Num(8) * new Num(6)))).ToInt();
sum += (new Num(9) * (new Num(2) + new Num(2) * (new Num(7) * new Num(9) * new Num(7) * new Num(7) + new Num(2)) * new Num(5) + new Num(6) * new Num(4))).ToInt();
sum += (new Num(7) * (new Num(6) * new Num(2) * (new Num(5) + new Num(7) + new Num(5) + new Num(3)) + new Num(8))).ToInt();
sum += (new Num(2) + (new Num(8) + new Num(6)) * new Num(7) + new Num(6) + new Num(8) + new Num(8)).ToInt();
sum += (new Num(7) * (new Num(2) * new Num(8) + new Num(6)) + new Num(9)).ToInt();
sum += (((new Num(7) * new Num(4) * new Num(9)) + (new Num(7) + new Num(6) + new Num(7) + new Num(3) * new Num(2) + new Num(6))) + (new Num(4) + new Num(8) * new Num(6)) * new Num(4)).ToInt();
sum += (new Num(5) * new Num(6) * (new Num(2) * new Num(2) + (new Num(6) + new Num(9) * new Num(8) + new Num(4)) * new Num(4))).ToInt();
sum += (new Num(8) * (new Num(5) * new Num(8) + new Num(9) * new Num(3) + new Num(3)) + new Num(8) * new Num(5) + new Num(5) + new Num(3)).ToInt();
sum += (new Num(4) * ((new Num(2) + new Num(7) + new Num(3) + new Num(2) + new Num(5) * new Num(3)) * (new Num(8) * new Num(6) * new Num(5) + new Num(3) * new Num(2) * new Num(4)) * new Num(7) + new Num(8) * new Num(2) * new Num(6)) + new Num(2)).ToInt();
sum += (((new Num(9) * new Num(4)) * new Num(4) * new Num(9) + (new Num(6) * new Num(7))) * new Num(3) + new Num(2)).ToInt();
sum += (new Num(9) + new Num(6)).ToInt();
sum += ((new Num(3) * (new Num(2) * new Num(5) + new Num(2) + new Num(7) + new Num(9) + new Num(6)) + new Num(5) * new Num(7) * new Num(4) + new Num(8)) + new Num(3) * (new Num(2) * new Num(8) + new Num(5) * new Num(6) + new Num(8)) + new Num(7)).ToInt();
sum += ((new Num(9) * new Num(5) * (new Num(9) + new Num(8) * new Num(2) * new Num(6)) * new Num(5)) * (new Num(4) + new Num(5) + new Num(4)) * new Num(6) * new Num(4)).ToInt();
sum += ((new Num(4) * (new Num(7) * new Num(3) * new Num(3) + new Num(5) + new Num(5))) * new Num(6) * ((new Num(4) + new Num(4) + new Num(8) * new Num(3) + new Num(9)) * (new Num(6) * new Num(2) * new Num(3)) * new Num(2)) + new Num(7) * new Num(2)).ToInt();
sum += ((new Num(8) * new Num(9) + (new Num(5) + new Num(7))) + new Num(8) + new Num(9) + (new Num(3) + new Num(6) + (new Num(4) * new Num(4) * new Num(6)) + new Num(9) * (new Num(2) * new Num(7) + new Num(6) + new Num(2) + new Num(2))) * new Num(8)).ToInt();
sum += (new Num(4) * new Num(7) * (new Num(8) * (new Num(5) + new Num(9) + new Num(5) * new Num(4) + new Num(5) + new Num(3)) * new Num(7) + (new Num(8) + new Num(4) * new Num(5) * new Num(9) * new Num(4) + new Num(5)) * new Num(2) + new Num(7)) + new Num(5) + new Num(8)).ToInt();
sum += (new Num(4) + new Num(9) + (new Num(7) + new Num(2) + new Num(8) * (new Num(8) + new Num(2) + new Num(9) * new Num(2) * new Num(3)) + new Num(7))).ToInt();
sum += ((new Num(5) + new Num(2)) + new Num(9) * new Num(7) + (new Num(9) * new Num(9) + new Num(2)) * ((new Num(2) * new Num(5) * new Num(8) * new Num(6) + new Num(2)) + new Num(6) * new Num(4))).ToInt();
sum += (new Num(5) + new Num(4) + ((new Num(2) * new Num(8) * new Num(9)) * new Num(3) * new Num(4) + (new Num(8) + new Num(9) * new Num(2)) + new Num(8)) * new Num(2) + new Num(5)).ToInt();
sum += ((new Num(3) * (new Num(5) + new Num(4) + new Num(6) * new Num(2)) + new Num(3) * new Num(8) * (new Num(2) + new Num(6) * new Num(2) + new Num(5) * new Num(9) + new Num(8))) + new Num(4) * new Num(4) * (new Num(4) * new Num(7) * (new Num(3) * new Num(8) + new Num(3)) * new Num(5) * new Num(6) * new Num(5))).ToInt();
sum += (new Num(6) * new Num(3) + new Num(7)).ToInt();
sum += (new Num(6) * (new Num(6) * (new Num(5) + new Num(9) * new Num(5) + new Num(2) + new Num(2) * new Num(6)) + new Num(8)) * new Num(5) * (new Num(3) * new Num(6) * new Num(5)) * new Num(3) + new Num(4)).ToInt();
sum += (new Num(4) * new Num(9) * ((new Num(7) * new Num(7)) * new Num(2) * (new Num(2) + new Num(3) * new Num(4) + new Num(2)) * new Num(3) * new Num(6)) + new Num(9) * new Num(7) + new Num(9)).ToInt();
sum += ((new Num(5) * new Num(8) + new Num(5)) * new Num(8)).ToInt();
sum += (new Num(4) + new Num(5) + new Num(5) + (new Num(9) * new Num(2) + (new Num(7) + new Num(5) + new Num(8) * new Num(6) * new Num(4)) + (new Num(5) * new Num(8) * new Num(7)) * new Num(5) * (new Num(7) * new Num(9) + new Num(8) + new Num(9)))).ToInt();
sum += (new Num(7) * ((new Num(9) + new Num(6) * new Num(6) + new Num(5) + new Num(2) + new Num(6)) * new Num(7) * new Num(2) + new Num(4) + new Num(7) * new Num(7)) + (new Num(7) + new Num(4) + new Num(3))).ToInt();
sum += (new Num(2) * new Num(5) * (new Num(7) * (new Num(6) * new Num(5) + new Num(5)) * new Num(9) * new Num(7) * new Num(9) + new Num(8)) * new Num(7) * new Num(7) + new Num(2)).ToInt();
sum += (new Num(7) * new Num(9) + (new Num(9) * new Num(6) * new Num(3) * new Num(7) + new Num(4) * (new Num(6) + new Num(6))) + new Num(9) + new Num(2) * (new Num(4) * new Num(8) + (new Num(6) + new Num(6)) + new Num(2) * new Num(3))).ToInt();
sum += (((new Num(4) + new Num(3)) + new Num(6) + new Num(7) * new Num(7)) + new Num(3) + new Num(8) * (new Num(7) + (new Num(5) * new Num(6) * new Num(8) + new Num(2))) * (new Num(8) + (new Num(5) * new Num(4) + new Num(5) * new Num(9) + new Num(3) * new Num(4)) + new Num(3) * new Num(9) + new Num(4))).ToInt();
sum += (new Num(9) + ((new Num(8) * new Num(9) * new Num(7)) * new Num(2)) * new Num(8) + new Num(3)).ToInt();
sum += (new Num(4) * new Num(3) * new Num(9) * new Num(4) * (new Num(2) * new Num(8)) * (new Num(2) * new Num(4) + new Num(8) * new Num(6) + new Num(5))).ToInt();
sum += (new Num(7) + ((new Num(7) + new Num(2)) + (new Num(3) + new Num(4)) * new Num(8) * (new Num(8) + new Num(6) * new Num(5) * new Num(2)) + new Num(8) + (new Num(6) + new Num(9) + new Num(3))) + new Num(3) * (new Num(8) + (new Num(4) + new Num(3) * new Num(8) + new Num(9) + new Num(6) * new Num(3)) + new Num(7) + new Num(6) + new Num(3))).ToInt();
sum += (new Num(5) * new Num(3) + new Num(4) * new Num(9) * new Num(5) * ((new Num(5) * new Num(6) + new Num(3) * new Num(7) + new Num(9)) * new Num(5))).ToInt();
sum += (new Num(9) * new Num(9) + new Num(8) + new Num(8) + new Num(5) + (new Num(6) + new Num(7) + new Num(8) * new Num(5) + (new Num(6) + new Num(7)) * new Num(9))).ToInt();
sum += (new Num(7) + (new Num(6) + (new Num(4) * new Num(2) + new Num(7) + new Num(5) * new Num(8) + new Num(5)) * new Num(5) + new Num(3) + new Num(9) + new Num(4)) * new Num(9) * new Num(7)).ToInt();
sum += (new Num(4) + new Num(7)).ToInt();
sum += (new Num(2) * new Num(9) * new Num(3) * ((new Num(9) + new Num(5) * new Num(5)) + new Num(6) + new Num(9) * (new Num(9) + new Num(9)) + new Num(2) * (new Num(6) * new Num(5) * new Num(2))) + new Num(6) * (new Num(5) + new Num(8))).ToInt();
sum += ((new Num(6) * new Num(6)) * new Num(3) + new Num(3) * new Num(2) * (new Num(6) + (new Num(2) + new Num(3) * new Num(3)) * new Num(3) * new Num(6)) * new Num(6)).ToInt();
sum += ((new Num(5) * new Num(3) * new Num(5) + new Num(8) * new Num(6)) + new Num(9) * (new Num(9) + new Num(3) + new Num(3) + new Num(9) + new Num(5))).ToInt();
sum += (new Num(9) * (new Num(3) * (new Num(5) + new Num(4)) + new Num(7) * new Num(4)) * new Num(3)).ToInt();
sum += ((new Num(4) + new Num(5) + new Num(5) * new Num(2) + (new Num(5) * new Num(2) * new Num(3))) + new Num(7) + (new Num(4) * new Num(7)) + new Num(9) * new Num(4) * new Num(8)).ToInt();
sum += ((new Num(8) + (new Num(2) * new Num(9) + new Num(7)) * new Num(8) * (new Num(7) * new Num(9) * new Num(6) * new Num(4) * new Num(3) + new Num(9))) * new Num(4) * (new Num(3) * new Num(3) * new Num(7)) + new Num(4) * new Num(7) * new Num(3)).ToInt();
sum += (new Num(7) * new Num(2) + new Num(4) * (new Num(7) * new Num(7) + new Num(5) + new Num(3))).ToInt();
sum += (new Num(7) * new Num(9) * (new Num(6) * (new Num(9) * new Num(6) * new Num(6) * new Num(8) + new Num(4)) + (new Num(5) + new Num(2) + new Num(9))) + (new Num(9) + new Num(2) + new Num(8) + new Num(5) + new Num(8)) * new Num(3)).ToInt();
sum += (new Num(8) * (new Num(8) * new Num(9) * (new Num(9) * new Num(9) + new Num(9) * new Num(9)) * new Num(4) + (new Num(6) + new Num(6) * new Num(2) + new Num(9) + new Num(8) + new Num(3)))).ToInt();
sum += ((new Num(5) + new Num(4) * new Num(4)) * new Num(3) + ((new Num(9) + new Num(5) * new Num(8) + new Num(8) * new Num(9) + new Num(8)) * new Num(3) + new Num(2) * new Num(3) + new Num(5) * (new Num(3) + new Num(9) + new Num(8) * new Num(3))) + (new Num(5) + new Num(4) + new Num(6) + new Num(7))).ToInt();
sum += (new Num(5) * new Num(2) * (new Num(9) + (new Num(7) + new Num(7) + new Num(6) * new Num(8) + new Num(6)) + new Num(9) * new Num(6) * (new Num(6) * new Num(9) + new Num(9) * new Num(2)) * (new Num(4) * new Num(5) + new Num(4) + new Num(2) * new Num(5) * new Num(4))) * new Num(9)).ToInt();
sum += ((new Num(6) * new Num(2) + (new Num(6) + new Num(3) + new Num(9))) * new Num(4) + new Num(5) + new Num(2)).ToInt();
sum += ((new Num(3) * (new Num(8) * new Num(4) * new Num(7)) * new Num(9) * new Num(6) + new Num(3)) + new Num(9) * new Num(3) + new Num(7) + (new Num(9) + (new Num(6) + new Num(8) * new Num(4) + new Num(9)) * new Num(2))).ToInt();
sum += (((new Num(9) * new Num(5) + new Num(7)) + (new Num(2) * new Num(4)) + new Num(3)) + new Num(4) + new Num(5) * new Num(2) + new Num(3)).ToInt();
sum += (new Num(4) + ((new Num(7) + new Num(7) * new Num(5) * new Num(6)) * new Num(8) * new Num(7) + new Num(6)) * (new Num(8) * new Num(9) * new Num(6)) * new Num(8) * (new Num(8) + new Num(6) * new Num(4) * new Num(8) * new Num(6)) * new Num(3)).ToInt();
sum += ((new Num(9) * new Num(9) * new Num(8)) * new Num(3) + (new Num(6) * new Num(6)) * new Num(6) * new Num(2)).ToInt();
sum += (((new Num(6) * new Num(8)) * (new Num(9) * new Num(5) + new Num(8)) + new Num(4) * new Num(4)) + new Num(2) * new Num(6) + new Num(7)).ToInt();
sum += (new Num(9) + new Num(2) * (new Num(6) * new Num(9) * (new Num(6) * new Num(8) + new Num(2) * new Num(4)) + (new Num(5) * new Num(5) + new Num(9) * new Num(9) * new Num(9) * new Num(6)) + (new Num(8) + new Num(4) * new Num(6) * new Num(8) * new Num(3) + new Num(7))) * new Num(8)).ToInt();
sum += (new Num(4) + (new Num(7) + new Num(9) + new Num(5) + new Num(2)) + (new Num(5) * new Num(6) + (new Num(5) * new Num(4) * new Num(5) * new Num(5)) * new Num(4) * new Num(5) * new Num(7)) + (new Num(3) + new Num(8) * new Num(3) + new Num(4) + new Num(6) + new Num(7))).ToInt();
sum += (new Num(6) * (new Num(8) + new Num(9) * new Num(2)) * new Num(7) * new Num(5) + new Num(8) + new Num(4)).ToInt();
sum += (((new Num(5) + new Num(4) + new Num(6) + new Num(5)) * new Num(5) * new Num(5) + new Num(5) * new Num(9) * new Num(8)) + new Num(3)).ToInt();
sum += ((new Num(2) * (new Num(4) * new Num(3) * new Num(8) * new Num(2) * new Num(5) + new Num(2)) + new Num(3)) + new Num(3) * new Num(5) + (new Num(4) * new Num(6) + new Num(9) + new Num(7) + new Num(2)) + (new Num(2) + new Num(2) * new Num(8) * new Num(7) * new Num(9)) + new Num(9)).ToInt();
sum += ((new Num(7) * new Num(4) * new Num(3) * new Num(5) * new Num(4) * new Num(7)) * new Num(6)).ToInt();
sum += (new Num(8) * new Num(5) + new Num(2) + new Num(6)).ToInt();
sum += (new Num(5) + new Num(6) * new Num(6) * new Num(5) * new Num(4) * new Num(5)).ToInt();
sum += (new Num(3) * (new Num(6) + new Num(5) * new Num(7) + new Num(5) * new Num(8) + new Num(6)) + new Num(6)).ToInt();
sum += (((new Num(6) + new Num(2) + new Num(3) * new Num(6)) + (new Num(2) + new Num(6) + new Num(4) + new Num(4) + new Num(6)) * new Num(5)) + new Num(8) * new Num(5) * new Num(8)).ToInt();
sum += ((new Num(4) * new Num(4) * new Num(9) * new Num(7)) * new Num(3)).ToInt();
sum += (new Num(7) + (new Num(2) * new Num(5) + (new Num(5) + new Num(8) + new Num(9) + new Num(3) + new Num(4)) * new Num(7) * new Num(8)) * new Num(6) * new Num(8) + new Num(6) * new Num(3)).ToInt();
sum += (new Num(3) + new Num(4) + (new Num(7) + new Num(2)) + new Num(2) * new Num(8)).ToInt();
sum += (new Num(2) * new Num(5) * new Num(8) + new Num(4) + (new Num(4) * new Num(3) * new Num(6) + new Num(6) + new Num(3) + new Num(9)) * new Num(2)).ToInt();
sum += (new Num(9) + (new Num(6) * new Num(4) * (new Num(7) * new Num(3) * new Num(3) + new Num(3)) * (new Num(2) * new Num(4) + new Num(2) * new Num(8) * new Num(7))) + (new Num(9) * new Num(2)) + new Num(2)).ToInt();
sum += (new Num(8) + new Num(9) + new Num(3) * new Num(8) + new Num(4)).ToInt();
sum += (new Num(3) * new Num(6) * new Num(9) + (new Num(5) + new Num(2) * new Num(8)) * new Num(3) * (new Num(9) * new Num(4) * new Num(8) * new Num(5) * new Num(6))).ToInt();
sum += ((new Num(4) + new Num(3)) * new Num(7) * new Num(7) * new Num(3)).ToInt();
sum += (new Num(3) + new Num(5) + (new Num(2) + new Num(9) + new Num(5) + new Num(7) + new Num(9) + new Num(5))).ToInt();
sum += (new Num(2) + (new Num(7) + new Num(9) + new Num(6)) + new Num(8) * new Num(4) * (new Num(8) * new Num(5) + new Num(2)) + new Num(4)).ToInt();
sum += ((new Num(6) * new Num(4) + new Num(3) + new Num(3)) + (new Num(5) + new Num(7)) + new Num(2)).ToInt();
sum += (new Num(6) + new Num(7) + (new Num(2) + (new Num(2) + new Num(4) + new Num(9) * new Num(4) * new Num(2) + new Num(3)) * new Num(6) * (new Num(9) * new Num(8) * new Num(8) * new Num(7) * new Num(6)) + new Num(3)) * new Num(7) + (new Num(3) + (new Num(7) + new Num(2) * new Num(5) + new Num(8) * new Num(2)) * new Num(4) * new Num(7) + new Num(8)) * new Num(2)).ToInt();
sum += (((new Num(9) * new Num(4)) * (new Num(2) + new Num(8) * new Num(4) + new Num(9) * new Num(3)) * new Num(9) + new Num(5) * new Num(7)) + new Num(6)).ToInt();
sum += (new Num(4) * new Num(4) + (new Num(2) * new Num(4)) * ((new Num(9) + new Num(6) * new Num(2) * new Num(6) + new Num(2) * new Num(4)) + new Num(9) * new Num(6)) + new Num(3) + new Num(7)).ToInt();
sum += (new Num(9) * ((new Num(4) * new Num(6) * new Num(9) * new Num(6) * new Num(5) * new Num(9)) * new Num(8) + new Num(3) * new Num(2) * new Num(5))).ToInt();
sum += (new Num(4) + new Num(6) + new Num(3) * new Num(7)).ToInt();
sum += (new Num(7) * ((new Num(8) + new Num(2) + new Num(8) + new Num(6)) * new Num(6) + new Num(9))).ToInt();
sum += ((new Num(7) + new Num(3) + new Num(4) + (new Num(5) + new Num(2) * new Num(3) + new Num(6) + new Num(4) * new Num(5)) + new Num(5)) * new Num(3)).ToInt();
sum += (new Num(3) * new Num(4) * (new Num(3) * new Num(5) * new Num(8) * new Num(5) + new Num(8) + (new Num(3) + new Num(4))) * new Num(2) + (new Num(9) + new Num(4) * new Num(5)) * new Num(7)).ToInt();
sum += (((new Num(8) + new Num(5) * new Num(3)) * new Num(7) + new Num(8)) + (new Num(3) + new Num(8) + new Num(6) + new Num(8) * new Num(3))).ToInt();
sum += (new Num(8) + new Num(8) * ((new Num(4) + new Num(5) * new Num(5)) + new Num(7) * new Num(4) + new Num(7) + new Num(4) + new Num(5)) * new Num(3) * (new Num(4) * new Num(5) * new Num(8))).ToInt();
sum += ((new Num(4) * new Num(6)) * (new Num(2) + new Num(7) * new Num(2) + new Num(2) * new Num(7)) + new Num(6)).ToInt();
sum += (((new Num(9) + new Num(6) + new Num(7) * new Num(5) * new Num(4)) * new Num(2) * (new Num(7) * new Num(6) * new Num(5) * new Num(6) * new Num(3)) + new Num(4)) * new Num(5) * new Num(4) + new Num(9)).ToInt();
sum += (new Num(4) * new Num(6) * (new Num(7) + (new Num(3) * new Num(6) + new Num(6)) * new Num(5))).ToInt();
sum += (new Num(9) + (new Num(4) + (new Num(4) * new Num(5) + new Num(4)) + new Num(6) + (new Num(2) + new Num(9) + new Num(8)) * new Num(8))).ToInt();
sum += ((new Num(8) * new Num(6) + new Num(4) + (new Num(7) * new Num(4) + new Num(8) * new Num(9) + new Num(5) + new Num(5)) * new Num(7)) * (new Num(6) + new Num(7) * new Num(7) + new Num(2) + new Num(8) * (new Num(9) + new Num(2) + new Num(6)))).ToInt();
sum += ((new Num(5) * new Num(2) + (new Num(7) * new Num(6) + new Num(5) + new Num(8) * new Num(8) * new Num(2)) * new Num(6) + new Num(5)) + new Num(7) + new Num(9) + new Num(6) * new Num(3) + new Num(5)).ToInt();
sum += (new Num(6) * new Num(6) + ((new Num(7) * new Num(4) * new Num(7) + new Num(5) + new Num(8)) * new Num(7) + new Num(6) * new Num(2) + new Num(9)) * new Num(3) * new Num(8) + new Num(4)).ToInt();
sum += (new Num(4) * new Num(3) + (new Num(3) * new Num(5) * new Num(3) * new Num(4) + new Num(5) * new Num(2)) + (new Num(3) + new Num(9)) + new Num(2) * new Num(6)).ToInt();
sum += (((new Num(8) * new Num(6) * new Num(3) * new Num(5) + new Num(9) * new Num(8)) + new Num(3) * new Num(6) + new Num(8)) * new Num(9) + new Num(7)).ToInt();
sum += ((new Num(7) + new Num(3) + new Num(6) + new Num(3) * new Num(5) + (new Num(3) + new Num(3) + new Num(7) + new Num(9))) * new Num(8)).ToInt();
sum += (new Num(5) + (new Num(4) + new Num(8) + new Num(4) + new Num(7))).ToInt();
sum += ((new Num(5) * new Num(8) * (new Num(5) * new Num(3) * new Num(6) + new Num(8)) + new Num(3)) + new Num(9)).ToInt();
sum += (new Num(4) + new Num(6) + new Num(9)).ToInt();
sum += ((new Num(4) + new Num(5) + (new Num(2) * new Num(7) * new Num(5))) + new Num(7) * (new Num(6) * new Num(5) * (new Num(7) + new Num(6) + new Num(8)) + new Num(4) * new Num(5) + (new Num(2) + new Num(9) * new Num(6) + new Num(4) + new Num(4) + new Num(2))) * ((new Num(5) * new Num(3) * new Num(7) + new Num(2) + new Num(7) + new Num(8)) * new Num(7) + new Num(3) * new Num(5) * (new Num(5) + new Num(2))) + new Num(3) * new Num(7)).ToInt();
sum += (((new Num(7) + new Num(5) * new Num(9) + new Num(9)) * new Num(9) * (new Num(3) + new Num(5) * new Num(9) + new Num(5) * new Num(3))) * (new Num(9) * new Num(5) + (new Num(5) * new Num(4) + new Num(7) * new Num(6) * new Num(7)) * new Num(4)) + new Num(2)).ToInt();
sum += (new Num(4) + new Num(2)).ToInt();
sum += (new Num(9) * new Num(6) + new Num(6) * (new Num(8) + (new Num(8) + new Num(8) * new Num(5)))).ToInt();
sum += (new Num(7) * new Num(9) * (new Num(4) + new Num(6) + new Num(4)) + new Num(2) * (new Num(7) * (new Num(7) * new Num(3) + new Num(4) + new Num(6) + new Num(2)) * (new Num(6) * new Num(8) * new Num(8) + new Num(7))) + new Num(3)).ToInt();
sum += (new Num(7) * new Num(8) + new Num(2) + new Num(7) + (new Num(2) * new Num(6) + (new Num(7) + new Num(2) * new Num(6)) * new Num(6) * new Num(2)) + new Num(4)).ToInt();
sum += ((new Num(4) * new Num(3) + (new Num(2) * new Num(3) * new Num(8) * new Num(7) * new Num(6)) + (new Num(6) + new Num(7)) + (new Num(2) + new Num(6) * new Num(2) + new Num(4)) * new Num(5)) + new Num(2) * new Num(8) * new Num(8) + new Num(4)).ToInt();
sum += (new Num(6) + new Num(8) * ((new Num(7) + new Num(9) * new Num(9) + new Num(3)) + new Num(2) * new Num(7) * (new Num(8) + new Num(5) * new Num(4) + new Num(8)) * new Num(6)) * ((new Num(4) * new Num(2) * new Num(3) + new Num(5)) + new Num(5) * new Num(5) + new Num(8) + new Num(8)) + (new Num(3) * new Num(4))).ToInt();
sum += (new Num(6) + new Num(2)).ToInt();
sum += (new Num(6) * (new Num(7) * new Num(4)) + (new Num(6) * new Num(3) * new Num(8) + new Num(8) * new Num(8)) + new Num(9) * (new Num(2) * (new Num(9) * new Num(8) + new Num(8)) + new Num(6) * new Num(9))).ToInt();
sum += (new Num(8) + new Num(7) * (new Num(7) + new Num(3) * (new Num(2) + new Num(5)) * new Num(3)) * new Num(5)).ToInt();
sum += (new Num(6) + new Num(4) * new Num(3) * new Num(3) * new Num(2) + new Num(3)).ToInt();
sum += ((new Num(2) * (new Num(3) * new Num(4) * new Num(5) + new Num(7) * new Num(2)) + new Num(8) * new Num(4)) + new Num(3) * new Num(5) + new Num(7) + (new Num(5) + new Num(8) + new Num(4) + new Num(8) + new Num(9) * new Num(2))).ToInt();
sum += ((new Num(9) * new Num(9) + new Num(7) * new Num(9) + new Num(4) + new Num(2)) * ((new Num(4) * new Num(5) + new Num(6) * new Num(2) + new Num(5) + new Num(2)) + new Num(3) + new Num(3) * new Num(2) + new Num(7)) + new Num(4) * new Num(6) + new Num(4)).ToInt();
sum += ((new Num(4) + new Num(4) * new Num(6) * (new Num(4) + new Num(5) + new Num(8) + new Num(7) + new Num(9))) * new Num(3) + new Num(7) + (new Num(3) + new Num(8) + new Num(5) + new Num(8) + new Num(9) * new Num(2))).ToInt();
sum += ((new Num(3) * (new Num(9) + new Num(4) + new Num(6) + new Num(2) * new Num(4)) * (new Num(4) * new Num(6) * new Num(2) * new Num(6) + new Num(3) + new Num(3))) * (new Num(4) * new Num(7) * new Num(8) + new Num(4)) + ((new Num(7) + new Num(9)) * new Num(9) * new Num(3) + new Num(4)) * new Num(4) + new Num(8)).ToInt();
sum += ((new Num(9) + (new Num(2) + new Num(3) + new Num(4) + new Num(2) * new Num(4)) + (new Num(8) + new Num(7) * new Num(5) + new Num(7) * new Num(9))) + new Num(9) * new Num(6) * new Num(5) + (new Num(8) * new Num(4) * new Num(5) + (new Num(7) * new Num(9) * new Num(5)))).ToInt();
sum += (new Num(5) * ((new Num(9) + new Num(5) * new Num(6) * new Num(6) + new Num(5)) * new Num(6)) * new Num(5) * (new Num(7) * new Num(3) * new Num(3) + new Num(9) * (new Num(4) + new Num(8) + new Num(4)) * new Num(7)) + ((new Num(8) * new Num(9)) + new Num(9) + new Num(6) + new Num(4)) + new Num(5)).ToInt();
sum += (new Num(3) + new Num(2) + new Num(2) * new Num(2) + new Num(6) + (new Num(7) * new Num(5))).ToInt();
sum += (new Num(5) * new Num(3) * (new Num(4) * new Num(2)) + new Num(8) * new Num(5) + (new Num(5) + new Num(8) + new Num(6))).ToInt();
sum += (new Num(5) * (new Num(6) * (new Num(5) * new Num(8) + new Num(6) * new Num(4) * new Num(6) * new Num(7)))).ToInt();
sum += ((new Num(7) + new Num(4)) * new Num(9) + new Num(3) + new Num(4) * (new Num(4) + new Num(7) * new Num(5) + new Num(6) + new Num(9) + new Num(4))).ToInt();
sum += (new Num(8) * new Num(9) * new Num(7) * new Num(7) * ((new Num(5) * new Num(8) + new Num(8) * new Num(5)) + (new Num(8) + new Num(4) * new Num(9) * new Num(4)) * new Num(9))).ToInt();
sum += (new Num(4) + new Num(3) * (new Num(6) + new Num(2))).ToInt();
sum += ((new Num(5) * new Num(8) * new Num(8) + new Num(7)) + new Num(2) + new Num(6)).ToInt();
sum += (new Num(4) * new Num(5) + (new Num(6) + new Num(8) + new Num(2)) * new Num(4) * new Num(2) * new Num(7)).ToInt();
sum += ((new Num(2) * (new Num(5) + new Num(6)) + new Num(6) * new Num(9)) + new Num(4) * new Num(2) * new Num(8)).ToInt();
sum += (((new Num(7) * new Num(9) + new Num(5) * new Num(6) * new Num(6) * new Num(7)) * new Num(3) * (new Num(8) + new Num(8) * new Num(8) * new Num(4) * new Num(4) * new Num(4)) * new Num(5) * new Num(6) * new Num(6)) + new Num(2) * new Num(6) + (new Num(5) + new Num(3) + new Num(6) + (new Num(3) + new Num(8) * new Num(9) * new Num(5) + new Num(6)) * new Num(2)) * ((new Num(7) + new Num(3) * new Num(9) * new Num(5)) + new Num(3) + new Num(7)) * new Num(8)).ToInt();
sum += (new Num(5) + new Num(7) + new Num(6) * (new Num(5) * new Num(6) + (new Num(7) * new Num(8))) + new Num(8) + new Num(5)).ToInt();
sum += (new Num(3) * new Num(9) + (new Num(8) + (new Num(2) + new Num(4) + new Num(5) + new Num(4) + new Num(4) * new Num(2)) + new Num(6) + (new Num(7) * new Num(6)) * new Num(2) + new Num(8)) + new Num(7) * (new Num(9) + new Num(9) + (new Num(6) + new Num(2) * new Num(8) + new Num(5) + new Num(7)))).ToInt();
sum += ((new Num(6) * new Num(5) + (new Num(6) * new Num(7) * new Num(9) + new Num(4)) * new Num(4) + new Num(7) + new Num(3)) * new Num(4) * new Num(8) * (new Num(4) + new Num(5) * (new Num(5) + new Num(6) * new Num(8))) + ((new Num(9) * new Num(6) + new Num(7)) * new Num(8) * new Num(6) * new Num(2) * new Num(3) + new Num(8))).ToInt();
sum += (((new Num(9) + new Num(4)) * new Num(8)) + (new Num(5) * new Num(7) + (new Num(8) * new Num(7) + new Num(6))) + ((new Num(4) + new Num(5)) + new Num(5) * new Num(2) * (new Num(8) + new Num(7)) * new Num(5) * new Num(8)) + new Num(8) + new Num(5) * new Num(5)).ToInt();
sum += (new Num(7) * (new Num(3) + new Num(5) + new Num(2) * new Num(6) + new Num(6)) * new Num(3) + new Num(6) + new Num(6)).ToInt();
sum += (new Num(9) * (new Num(5) + new Num(9) + (new Num(5) * new Num(5) + new Num(6) + new Num(8)) * new Num(3) * new Num(4) + new Num(6)) * new Num(7) * new Num(9)).ToInt();
sum += (new Num(6) * (new Num(9) + new Num(9) * new Num(2)) + new Num(4) * (new Num(4) * (new Num(9) * new Num(4) * new Num(4)) + (new Num(5) + new Num(2)) + (new Num(8) * new Num(9) * new Num(7) * new Num(2) * new Num(6))) * new Num(4) * new Num(3)).ToInt();
sum += (new Num(6) * new Num(8) * ((new Num(7) * new Num(2) + new Num(6) * new Num(5) * new Num(5)) + new Num(9) * new Num(9))).ToInt();
sum += (new Num(8) + new Num(2) * new Num(8) + ((new Num(9) + new Num(5) + new Num(3)) + new Num(9) * new Num(5) * new Num(6) + new Num(4)) * new Num(9)).ToInt();
sum += ((new Num(9) + new Num(7) + new Num(4)) * (new Num(3) + new Num(7) * new Num(9) + (new Num(7) * new Num(9) * new Num(8))) * new Num(5)).ToInt();
sum += (((new Num(9) * new Num(2) * new Num(5) * new Num(5) * new Num(5)) * new Num(7) + new Num(7) + new Num(8) + new Num(7)) + new Num(3) * new Num(2) * (new Num(3) + (new Num(7) + new Num(2)))).ToInt();
sum += (new Num(7) + new Num(4) + new Num(8) + new Num(4) + new Num(8)).ToInt();
sum += ((new Num(4) + (new Num(4) * new Num(2) + new Num(9) + new Num(5)) + new Num(5) * (new Num(8) + new Num(5)) * new Num(5)) + new Num(4) * new Num(6)).ToInt();
sum += (new Num(7) + (new Num(8) + new Num(2) + (new Num(8) * new Num(6) * new Num(6)) * (new Num(5) * new Num(9) + new Num(4) + new Num(3)) + new Num(4)) + new Num(2) * new Num(9) * (new Num(7) + new Num(3)) * new Num(2)).ToInt();
sum += (new Num(4) * (new Num(4) + (new Num(8) + new Num(9) * new Num(6) * new Num(6) + new Num(5) * new Num(7)) + new Num(5) * new Num(9) * new Num(3)) + new Num(2)).ToInt();
sum += (new Num(5) + new Num(4) * (new Num(6) * new Num(8) + new Num(8) + new Num(3) * new Num(5)) * new Num(9) + new Num(8) + new Num(8)).ToInt();
sum += (new Num(5) + new Num(2) * (new Num(5) + new Num(6) + new Num(3))).ToInt();
sum += ((new Num(6) + new Num(6)) * new Num(4) * ((new Num(6) * new Num(6) * new Num(4) * new Num(5) * new Num(5) * new Num(5)) + new Num(2) * (new Num(3) + new Num(4) * new Num(2)) + new Num(5)) * new Num(2) + (new Num(4) * new Num(6)) * (new Num(8) + new Num(6) + new Num(9))).ToInt();
sum += (new Num(9) + new Num(8) * new Num(3)).ToInt();
sum += ((new Num(9) + new Num(8)) + (new Num(4) + new Num(4) * new Num(2)) + new Num(3) + new Num(7)).ToInt();
sum += ((new Num(4) * (new Num(6) + new Num(5) * new Num(3) * new Num(2) + new Num(4)) * new Num(5)) * new Num(3) * ((new Num(9) + new Num(8) * new Num(4) * new Num(9) + new Num(4) + new Num(6)) + new Num(8) * new Num(3) + new Num(7) * new Num(5)) * (new Num(5) * (new Num(9) + new Num(5)) + new Num(2) * new Num(3))).ToInt();
sum += (new Num(9) * new Num(9) * (new Num(5) + (new Num(3) + new Num(2))) + new Num(3) * new Num(3)).ToInt();
sum += (new Num(9) * new Num(5) + (new Num(7) + new Num(8) * new Num(8)) + (new Num(5) * (new Num(4) * new Num(8) + new Num(2) * new Num(4) + new Num(5) * new Num(3))) * new Num(9)).ToInt();
sum += (new Num(6) * new Num(9) * ((new Num(3) * new Num(4) + new Num(6) + new Num(8) + new Num(7)) * (new Num(5) + new Num(6) * new Num(4) + new Num(4) + new Num(7)) * new Num(2) + new Num(7) + new Num(7))).ToInt();
sum += (((new Num(9) + new Num(7) * new Num(2)) + new Num(7) * new Num(3)) * new Num(9) + new Num(7) + new Num(9) * new Num(3)).ToInt();
sum += (new Num(8) + new Num(9) + new Num(7) + (new Num(7) * new Num(7) + new Num(2) * (new Num(8) * new Num(9) * new Num(4) + new Num(6) * new Num(5)) * new Num(7)) * new Num(8) * (new Num(2) + new Num(3))).ToInt();
sum += ((new Num(5) * (new Num(5) + new Num(5)) * (new Num(7) * new Num(9) * new Num(3) * new Num(9) * new Num(3) * new Num(7)) * new Num(5) * (new Num(2) * new Num(7))) + (new Num(5) * (new Num(9) * new Num(7) + new Num(6) + new Num(9) + new Num(4))) * (new Num(3) * new Num(3) + new Num(5) * (new Num(8) + new Num(9) + new Num(8) + new Num(9) + new Num(7) + new Num(6)) * new Num(5)) + new Num(3)).ToInt();
sum += ((new Num(6) + new Num(3) * new Num(4) + (new Num(4) * new Num(5) + new Num(8) * new Num(7) + new Num(7))) + new Num(2) * new Num(7) + (new Num(6) * new Num(7)) + new Num(8) + new Num(6)).ToInt();
sum += (new Num(4) + ((new Num(6) * new Num(7) + new Num(3) * new Num(7) + new Num(4) * new Num(7)) * new Num(6) + new Num(6) * new Num(9)) * ((new Num(3) + new Num(7) * new Num(5) + new Num(6)) + new Num(4)) + new Num(8)).ToInt();
sum += (new Num(2) * (new Num(6) * new Num(2) * (new Num(5) * new Num(8) + new Num(3) + new Num(5) * new Num(4) * new Num(9))) * new Num(7) * new Num(9) + new Num(4) + (new Num(4) * new Num(3))).ToInt();
sum += (new Num(9) * (new Num(9) + new Num(3) * (new Num(2) * new Num(4) * new Num(6)) * new Num(8) * new Num(6)) * (new Num(5) * new Num(3) * (new Num(9) * new Num(9) * new Num(3) * new Num(9) + new Num(9) * new Num(4))) * new Num(2)).ToInt();
sum += ((new Num(7) + new Num(8)) + (new Num(4) + new Num(6)) * new Num(4) + new Num(6)).ToInt();
sum += (new Num(5) + (new Num(8) + new Num(9) * new Num(7) + new Num(4)) * new Num(2) * (new Num(3) * new Num(5) + new Num(9) + new Num(8)) * new Num(9) + new Num(7)).ToInt();
sum += ((new Num(8) + (new Num(2) + new Num(4) * new Num(3) + new Num(7) + new Num(3)) * new Num(2) * new Num(4) + new Num(6)) * new Num(3) * new Num(5) * new Num(4) * (new Num(8) + (new Num(6) * new Num(6) * new Num(5) * new Num(9) + new Num(2)) + new Num(2))).ToInt();
sum += (new Num(2) * (new Num(9) + new Num(6) + new Num(8) * (new Num(6) * new Num(4) + new Num(8) + new Num(2) + new Num(4)))).ToInt();
sum += (new Num(2) * new Num(8) * ((new Num(2) * new Num(4) + new Num(9) + new Num(9) + new Num(6) + new Num(7)) * new Num(9) + new Num(4) * (new Num(4) * new Num(3) + new Num(5)) + new Num(9) * new Num(6)) + new Num(9) + new Num(6)).ToInt();
sum += (new Num(8) * new Num(2) + (new Num(4) + new Num(4)) + (new Num(5) + new Num(9) * (new Num(7) + new Num(2)) + new Num(3)) * (new Num(9) + new Num(7) * new Num(8) * new Num(3) * new Num(5))).ToInt();
sum += (new Num(9) * new Num(6) + new Num(6) * (new Num(4) * new Num(7) * new Num(7) + new Num(9)) + (new Num(7) * (new Num(2) + new Num(7) + new Num(5)) * (new Num(5) + new Num(2)) + new Num(9) + new Num(7) * new Num(7)) + ((new Num(4) * new Num(4) + new Num(5) + new Num(7) + new Num(7) * new Num(2)) * new Num(6) + new Num(4) + new Num(2) * new Num(2))).ToInt();
sum += (((new Num(5) + new Num(4) * new Num(5) * new Num(7)) * (new Num(4) + new Num(8) * new Num(5) + new Num(8)) + new Num(3)) + new Num(6) + new Num(9)).ToInt();
sum += (new Num(2) + (new Num(9) * new Num(5) * new Num(8) + (new Num(4) * new Num(2) * new Num(8)) * new Num(9) * new Num(4)) + new Num(4)).ToInt();
sum += (new Num(8) + (new Num(4) * (new Num(2) + new Num(9) + new Num(5)) * new Num(2) * (new Num(4) * new Num(3) + new Num(3) + new Num(4) * new Num(7) * new Num(6)) * new Num(4) * (new Num(2) + new Num(2) + new Num(5) * new Num(6) * new Num(6))) + new Num(8) * new Num(2) * (new Num(7) * new Num(5) * new Num(6) * (new Num(9) + new Num(6)) + new Num(5))).ToInt();
sum += (new Num(4) * new Num(5) + new Num(9) * new Num(3) * new Num(3) + new Num(3)).ToInt();
sum += (new Num(2) + new Num(7) + new Num(3) * new Num(4) + (new Num(5) * new Num(9) + (new Num(5) + new Num(6) * new Num(8) * new Num(4)) + new Num(5)) + new Num(4)).ToInt();
sum += (new Num(6) * (new Num(3) * new Num(4) + new Num(5) + new Num(3) + new Num(9)) * new Num(3) + (new Num(3) * new Num(5) + new Num(6)) + new Num(6)).ToInt();
sum += (new Num(3) * new Num(6) + new Num(5) + (new Num(4) + new Num(5))).ToInt();
sum += (new Num(4) + (new Num(7) + new Num(9) * new Num(5) * new Num(5) + new Num(3) + new Num(4)) * new Num(8) * (new Num(3) + new Num(5) * new Num(4) + new Num(3) * new Num(7) + new Num(3)) + (new Num(7) + new Num(8) + new Num(4) * new Num(5) + new Num(3) * new Num(2))).ToInt();
sum += ((new Num(3) + (new Num(5) + new Num(4) + new Num(2) + new Num(2) + new Num(9) + new Num(9)) * new Num(3) + new Num(7) * new Num(7) * new Num(3)) * new Num(8) + new Num(5) * new Num(6) * new Num(5) + new Num(9)).ToInt();
sum += (new Num(9) + new Num(3) * new Num(6) * ((new Num(5) * new Num(5) * new Num(7) + new Num(3) + new Num(6) * new Num(5)) * (new Num(5) * new Num(6)) * new Num(7))).ToInt();
sum += (new Num(3) + new Num(7) + (new Num(9) * (new Num(7) + new Num(3) * new Num(2) + new Num(8))) * (new Num(3) * new Num(4) + new Num(2) + new Num(5) * new Num(5))).ToInt();
sum += (new Num(8) + new Num(6) + new Num(3) + new Num(9) + new Num(6) + (new Num(5) * new Num(4) + new Num(3) + (new Num(8) + new Num(3) + new Num(7) * new Num(4) * new Num(4) * new Num(2)) * new Num(2))).ToInt();
sum += (new Num(6) * new Num(9) + new Num(2) + (new Num(3) * new Num(9) * new Num(6) + new Num(8) + new Num(8) * new Num(5)) + (new Num(5) + new Num(8) + new Num(5) * new Num(3)) + new Num(9)).ToInt();
sum += (new Num(3) + (new Num(5) + new Num(4) * new Num(4) + new Num(2) + new Num(6) * new Num(4))).ToInt();
sum += (new Num(3) * new Num(2) * new Num(4) + (new Num(9) + new Num(6) + new Num(9) * new Num(8) * new Num(4)) * new Num(4)).ToInt();
sum += ((new Num(5) * new Num(2) * new Num(5) + new Num(5) * new Num(3) * new Num(3)) * new Num(7) * new Num(9) + new Num(3)).ToInt();
sum += (new Num(5) + (new Num(8) * (new Num(3) * new Num(9) + new Num(8)) + new Num(4) * new Num(9)) * new Num(4) + (new Num(2) * new Num(4) * new Num(4) * new Num(3)) * (new Num(7) + (new Num(9) * new Num(5) * new Num(6) + new Num(9)) + new Num(5) * (new Num(4) * new Num(4) + new Num(3) * new Num(2) * new Num(8) + new Num(7)) + new Num(5) + (new Num(6) * new Num(9) + new Num(7) * new Num(2) * new Num(4) * new Num(7)))).ToInt();
sum += (new Num(6) + new Num(3) + (new Num(4) * new Num(4) + new Num(7) * new Num(2)) + new Num(3)).ToInt();
sum += (new Num(9) + (new Num(6) + (new Num(7) * new Num(3) * new Num(7) + new Num(3) + new Num(8) + new Num(2)) + new Num(4) + new Num(2) + new Num(3) + new Num(9)) * new Num(9) + new Num(7) * new Num(9) * new Num(5)).ToInt();
sum += ((new Num(9) + new Num(7) + new Num(2)) + new Num(6) * (new Num(4) + (new Num(6) + new Num(4))) + new Num(8) * new Num(4) + new Num(4)).ToInt();
sum += ((new Num(7) + new Num(8) + new Num(4) * new Num(9) + new Num(6)) + (new Num(5) + (new Num(5) * new Num(5) * new Num(5)) + (new Num(4) * new Num(7) * new Num(7)) + new Num(4) * new Num(7)) * new Num(4)).ToInt();
sum += (new Num(7) + new Num(4) * new Num(5) * (new Num(8) + new Num(7) + new Num(8))).ToInt();
sum += (new Num(9) + new Num(5) + (new Num(9) * new Num(6) * new Num(6) + new Num(5)) * (new Num(9) * new Num(3) + (new Num(8) + new Num(8) + new Num(8) * new Num(9) + new Num(8))) + new Num(6)).ToInt();
sum += ((new Num(9) * new Num(3) * (new Num(5) + new Num(4) + new Num(2) + new Num(4) * new Num(7) + new Num(7)) * (new Num(2) * new Num(4))) + (new Num(9) + (new Num(3) + new Num(9) * new Num(7) * new Num(4) + new Num(3) * new Num(4)) * (new Num(6) + new Num(5) + new Num(3) + new Num(4) + new Num(9) + new Num(3)) + new Num(3)) * new Num(5) * new Num(8) + (new Num(5) + new Num(5)) + new Num(9)).ToInt();
sum += ((new Num(3) + new Num(2)) * new Num(3) + new Num(8) * new Num(5) + (new Num(3) * new Num(3) + (new Num(2) + new Num(3) * new Num(3) + new Num(3) * new Num(5) * new Num(8)) + new Num(7)) + ((new Num(9) + new Num(8)) * new Num(6) * (new Num(4) + new Num(9) + new Num(5)) + (new Num(8) * new Num(6) + new Num(3) + new Num(5) + new Num(5)) + new Num(7) * new Num(5))).ToInt();
sum += (new Num(7) + new Num(3) * new Num(6) + (new Num(5) * new Num(6) + new Num(6) * new Num(3) + new Num(4)) * (new Num(3) + (new Num(3) * new Num(7)) + new Num(6) + new Num(7)) + new Num(4)).ToInt();
sum += (new Num(5) + (new Num(4) + (new Num(5) + new Num(5)) * new Num(6) * new Num(9) + new Num(2)) * (new Num(4) + new Num(5))).ToInt();
sum += (new Num(2) * new Num(9) * ((new Num(6) * new Num(3)) * new Num(2) + new Num(6) + new Num(6) + new Num(7) * new Num(9))).ToInt();
sum += (new Num(4) * new Num(3)).ToInt();
sum += ((new Num(7) + new Num(4) * (new Num(5) * new Num(9) * new Num(2)) + (new Num(9) * new Num(7) * new Num(8) + new Num(9)) * new Num(7)) + new Num(9) * new Num(5) * new Num(3) * new Num(7)).ToInt();
sum += (new Num(8) + new Num(6) + (new Num(5) * new Num(5) + new Num(6) + (new Num(9) + new Num(9) + new Num(5) * new Num(5)) * new Num(6))).ToInt();
sum += ((new Num(6) * new Num(5) * new Num(6)) * new Num(2) * (new Num(5) * (new Num(5) + new Num(4) * new Num(3) * new Num(6)) + new Num(9) * new Num(2))).ToInt();
sum += (((new Num(7) + new Num(6) * new Num(5) * new Num(7)) + new Num(8) + new Num(5) * new Num(2) * (new Num(2) * new Num(2))) + new Num(6) * new Num(8) * new Num(3)).ToInt();
sum += (new Num(9) * (new Num(7) + new Num(8) + new Num(7) + new Num(7) * new Num(3)) * new Num(9) * new Num(7)).ToInt();
sum += ((new Num(6) + new Num(2) * new Num(9) + new Num(5) * new Num(8)) + new Num(9)).ToInt();
sum += (new Num(5) + new Num(6) + new Num(5) + ((new Num(5) + new Num(7) + new Num(3) * new Num(4)) + (new Num(9) + new Num(9) + new Num(8) * new Num(8) * new Num(8)) + new Num(4) * new Num(2)) + (new Num(8) + (new Num(8) * new Num(7)) * new Num(6) + new Num(8) * new Num(5))).ToInt();
sum += (new Num(5) * (new Num(5) * new Num(3) + new Num(6))).ToInt();
sum += (new Num(5) * new Num(4) * new Num(3) * (new Num(9) * new Num(8) + new Num(3) * new Num(7)) * new Num(7)).ToInt();
sum += (((new Num(5) + new Num(9) + new Num(6) + new Num(9) + new Num(7) + new Num(2)) * new Num(4) * (new Num(6) + new Num(8) * new Num(6) + new Num(6))) + new Num(5)).ToInt();
sum += ((new Num(3) + new Num(2) * new Num(2) + new Num(8)) * new Num(5) * (new Num(3) * (new Num(8) * new Num(8) * new Num(7) + new Num(4)) * new Num(4) * new Num(6) * new Num(7)) * new Num(6)).ToInt();
sum += (new Num(2) * new Num(3) + new Num(7) * (new Num(9) * (new Num(3) + new Num(3) * new Num(8) + new Num(7)) + new Num(5) * new Num(7))).ToInt();
sum += (new Num(9) * (new Num(8) + new Num(8) + (new Num(4) + new Num(6)) * new Num(2) + new Num(5)) + new Num(9) + new Num(8)).ToInt();
sum += (new Num(4) + new Num(5) + new Num(6) + new Num(7) + (new Num(8) * (new Num(3) + new Num(5) + new Num(5)) + (new Num(9) * new Num(6) + new Num(2) * new Num(3) + new Num(3)) * new Num(8) + (new Num(5) + new Num(6) * new Num(4) + new Num(2) * new Num(9)))).ToInt();
sum += (((new Num(2) + new Num(7) + new Num(6) + new Num(8) + new Num(4)) + (new Num(6) * new Num(8) * new Num(4) + new Num(9) * new Num(6))) * new Num(6) * new Num(4)).ToInt();
sum += (new Num(4) + ((new Num(9) * new Num(8) + new Num(4) * new Num(9)) + new Num(9) * (new Num(6) + new Num(9)) + (new Num(8) * new Num(4))) * new Num(5) * new Num(7) + new Num(9) + new Num(3)).ToInt();
sum += (new Num(8) * new Num(4) + new Num(8) + new Num(7) * (new Num(3) * new Num(8))).ToInt();
sum += (new Num(2) + ((new Num(8) + new Num(2) * new Num(2) * new Num(3) * new Num(7)) + (new Num(8) + new Num(8) * new Num(2) * new Num(8) + new Num(2) + new Num(9)) + new Num(5)) * ((new Num(2) * new Num(6) + new Num(3)) * new Num(4)) * (new Num(8) + new Num(5) + new Num(7) + (new Num(6) + new Num(9) + new Num(8) * new Num(4) * new Num(3))) + new Num(4) + new Num(6)).ToInt();
sum += (((new Num(4) + new Num(5) + new Num(3)) + new Num(5)) + (new Num(2) + new Num(7) * new Num(4) + (new Num(9) + new Num(3) + new Num(2) + new Num(3)) * new Num(3))).ToInt();
sum += (new Num(2) + (new Num(3) + new Num(6)) + (new Num(2) + new Num(3) * new Num(5) + new Num(6) + new Num(5)) + new Num(3)).ToInt();
sum += ((new Num(3) * new Num(9) + new Num(4) + new Num(7) + new Num(5)) + new Num(3) + ((new Num(6) * new Num(4) * new Num(6) + new Num(6)) * new Num(2) * new Num(7) + new Num(8) * new Num(2)) * (new Num(8) * new Num(5)) * new Num(8)).ToInt();
sum += (new Num(5) + (new Num(4) * new Num(5) * new Num(4) * new Num(4)) + new Num(9)).ToInt();
sum += (new Num(4) + new Num(4) * new Num(9) + new Num(2) + new Num(7) + (new Num(7) * new Num(9) * new Num(3))).ToInt();
sum += ((new Num(4) + new Num(6) + new Num(8) + new Num(6) + new Num(4) * (new Num(4) + new Num(7) * new Num(7) * new Num(9) + new Num(5))) * new Num(3)).ToInt();
sum += (new Num(5) * (new Num(6) * new Num(4) * (new Num(2) + new Num(3)) * (new Num(7) * new Num(7) + new Num(7) + new Num(5) * new Num(7) + new Num(3)) + new Num(3)) + new Num(3) * new Num(3)).ToInt();
sum += ((new Num(2) + new Num(4) * new Num(9) * (new Num(7) * new Num(6) + new Num(5) * new Num(9) + new Num(6)) + new Num(3)) * new Num(6) + new Num(2) * new Num(4) + new Num(6)).ToInt();
sum += (new Num(5) + (new Num(8) + new Num(7) + (new Num(9) * new Num(2) + new Num(5))) + (new Num(4) * new Num(6) + new Num(9) * (new Num(7) * new Num(5) + new Num(6) + new Num(9)) + new Num(2)) * new Num(6) * (new Num(8) + (new Num(2) * new Num(5) * new Num(4) + new Num(9)) + new Num(3) + new Num(4))).ToInt();
sum += (new Num(6) + (new Num(8) * new Num(6) + new Num(6) * new Num(9) * new Num(2) + new Num(2)) * (new Num(8) + new Num(3) * new Num(5) * new Num(9) * new Num(7)) * new Num(5)).ToInt();
sum += ((new Num(8) + new Num(7) * new Num(7)) + new Num(2) + new Num(6) * new Num(8) * new Num(2)).ToInt();
sum += (new Num(8) + new Num(4) + ((new Num(4) * new Num(7) + new Num(7) + new Num(7) * new Num(4)) + new Num(8) * new Num(3) + new Num(6) + new Num(5)) + new Num(9)).ToInt();
sum += (new Num(4) * (new Num(6) + new Num(3)) + (new Num(7) * new Num(6) * (new Num(2) + new Num(7) * new Num(9) + new Num(5) * new Num(6) + new Num(8))) + new Num(9) + new Num(8) * new Num(3)).ToInt();
sum += ((new Num(7) * new Num(5)) * new Num(5) * ((new Num(2) + new Num(7) + new Num(5)) * new Num(7)) * new Num(6) + new Num(4)).ToInt();
sum += (new Num(7) + (new Num(7) + new Num(6)) * new Num(8) + new Num(2) * (new Num(9) + new Num(2) * new Num(3) * new Num(5)) * new Num(9)).ToInt();
sum += (new Num(9) + (new Num(3) + new Num(4)) * new Num(7) * new Num(8) + (new Num(3) * new Num(2) + new Num(9) + new Num(2))).ToInt();
sum += (new Num(5) * new Num(4) + new Num(6) + new Num(8)).ToInt();
sum += (new Num(9) + (new Num(2) + new Num(8) * new Num(7) + new Num(2) * new Num(3) * new Num(4)) * new Num(4) + new Num(9)).ToInt();
sum += ((new Num(2) * new Num(6) * new Num(3)) * new Num(2) + new Num(4) * new Num(3) * new Num(5) * new Num(6)).ToInt();
sum += ((new Num(8) + new Num(8)) * new Num(6) + (new Num(7) + (new Num(5) + new Num(9) * new Num(3) + new Num(4)) + new Num(3) + new Num(2)) * new Num(6) + new Num(7)).ToInt();
sum += (new Num(2) * ((new Num(5) + new Num(2) + new Num(3) * new Num(3) + new Num(9)) * new Num(8) * new Num(3) * new Num(7) * new Num(3)) * (new Num(3) + new Num(6) + new Num(2) * new Num(4) * new Num(6) * new Num(2)) + new Num(3) * new Num(8) + new Num(7)).ToInt();
sum += ((new Num(7) + new Num(8) + new Num(6) + (new Num(9) + new Num(2) + new Num(2) + new Num(8) + new Num(5) * new Num(3)) + new Num(7)) * new Num(8) * new Num(9)).ToInt();
sum += (new Num(8) * (new Num(4) + new Num(4) * new Num(9) + new Num(8)) * new Num(3) + new Num(5) + new Num(8)).ToInt();
sum += ((new Num(3) + new Num(6)) + new Num(8) + new Num(5) * new Num(8) + new Num(5)).ToInt();
sum += ((new Num(5) + (new Num(3) * new Num(6) + new Num(7) * new Num(5) + new Num(4) + new Num(4)) + new Num(7) + new Num(2) * new Num(3)) * ((new Num(3) + new Num(8) + new Num(5) * new Num(5) * new Num(3) + new Num(8)) * (new Num(2) + new Num(6)) * new Num(6) * new Num(3) * new Num(5) + new Num(6)) + (new Num(6) * new Num(5) + new Num(5)) + new Num(4) * (new Num(7) * new Num(5) + new Num(4)) * new Num(4)).ToInt();
sum += ((new Num(5) * new Num(4) * new Num(3) * new Num(9) * new Num(3)) * (new Num(7) * new Num(4) * new Num(8) * new Num(4)) + (new Num(2) * new Num(7) + new Num(7) + new Num(8))).ToInt();
sum += (new Num(2) + (new Num(8) + new Num(5) + (new Num(5) * new Num(8) + new Num(4) * new Num(9) * new Num(7) + new Num(6)) + new Num(2)) * new Num(7)).ToInt();
sum += (new Num(9) * new Num(6) + (new Num(9) + new Num(3) + new Num(4) + new Num(2) + new Num(8))).ToInt();
sum += (((new Num(3) + new Num(2) + new Num(6) * new Num(6) + new Num(4) + new Num(5)) + new Num(9) + new Num(8) * new Num(5)) * (new Num(2) * new Num(3) + (new Num(6) * new Num(3) + new Num(2) + new Num(3)) * (new Num(8) + new Num(7) * new Num(3) + new Num(7) + new Num(4)) * new Num(3)) + new Num(6) * ((new Num(9) + new Num(4) * new Num(7) * new Num(2)) * new Num(6) + new Num(9) * new Num(7))).ToInt();
sum += (new Num(9) * (new Num(9) + (new Num(4) + new Num(3) * new Num(7) + new Num(7) * new Num(6) * new Num(8)) + new Num(3) + (new Num(5) * new Num(9) * new Num(3) + new Num(7) + new Num(2)) * new Num(6)) + new Num(9)).ToInt();
sum += (new Num(6) + new Num(6) * (new Num(7) + (new Num(9) + new Num(4) * new Num(2) + new Num(6) + new Num(4)) + (new Num(8) * new Num(5)) + new Num(4) + (new Num(8) * new Num(4) * new Num(5) + new Num(4) * new Num(4)) + new Num(2)) + new Num(2)).ToInt();
sum += (new Num(2) + (new Num(4) + (new Num(6) + new Num(6) * new Num(4))) + new Num(8) + new Num(6) + (new Num(3) * (new Num(4) * new Num(5) + new Num(9) * new Num(2) * new Num(6) * new Num(7))) * new Num(9)).ToInt();
sum += (new Num(4) + new Num(4) * ((new Num(3) * new Num(8) * new Num(7) + new Num(2) + new Num(7) * new Num(6)) * new Num(7) * new Num(2) + new Num(6) * new Num(3) * new Num(4)) + new Num(8) + new Num(7) * new Num(6)).ToInt();
sum += ((new Num(2) * (new Num(9) + new Num(4) * new Num(4) * new Num(4) * new Num(3) * new Num(3)) + (new Num(4) + new Num(3) * new Num(6))) + new Num(5) * new Num(7) + new Num(7) * (new Num(4) * new Num(2) + new Num(8))).ToInt();
sum += (new Num(2) + (new Num(8) + (new Num(2) + new Num(4))) + new Num(9) + new Num(7)).ToInt();
sum += (new Num(6) * new Num(5) + new Num(7) + (new Num(9) * new Num(6) * new Num(2)) + new Num(9) + new Num(9)).ToInt();
sum += ((new Num(4) * new Num(7) * (new Num(2) + new Num(4) * new Num(8)) + new Num(3)) * (new Num(9) * new Num(6) + new Num(8) * new Num(4)) * (new Num(8) + new Num(3) + new Num(4) + (new Num(9) + new Num(8) * new Num(2) * new Num(4) * new Num(4)) * (new Num(7) * new Num(7) * new Num(4)) + new Num(4)) + new Num(5) * new Num(5)).ToInt();
sum += ((new Num(9) + (new Num(4) * new Num(7) * new Num(9) + new Num(3) * new Num(7)) * new Num(5) + new Num(7)) + ((new Num(2) + new Num(7) + new Num(3) + new Num(9) * new Num(7) + new Num(8)) * (new Num(6) * new Num(5) * new Num(2)) + new Num(7) * (new Num(2) + new Num(9) + new Num(4) * new Num(2) * new Num(9)) * (new Num(2) + new Num(2) + new Num(7) * new Num(5)) * new Num(7)) * new Num(2) * new Num(5) + new Num(8)).ToInt();
sum += (new Num(5) * new Num(6) * new Num(5) + (new Num(9) + (new Num(2) * new Num(8) + new Num(7) * new Num(3)) + (new Num(5) + new Num(4) + new Num(3) * new Num(2))) + new Num(7)).ToInt();
sum += ((new Num(7) * new Num(3)) * new Num(6)).ToInt();
sum += ((new Num(7) + new Num(7) * new Num(2)) + new Num(5) * new Num(6)).ToInt();
sum += (new Num(9) * new Num(2) * new Num(3) + (new Num(7) * new Num(5) * (new Num(8) * new Num(9) + new Num(6) + new Num(3) * new Num(6) + new Num(4)) + new Num(6)) * new Num(4) + new Num(5)).ToInt();
sum += ((new Num(6) + new Num(3)) + new Num(8) * new Num(9) * new Num(3) + ((new Num(7) * new Num(6) * new Num(6)) + new Num(9) + (new Num(5) + new Num(8)) * new Num(5) + new Num(4) * new Num(7)) + new Num(8)).ToInt();
sum += (new Num(2) * ((new Num(5) * new Num(9) + new Num(4) * new Num(5) + new Num(7)) + new Num(2))).ToInt();
sum += (new Num(7) * new Num(5) + ((new Num(3) * new Num(4) + new Num(5) + new Num(9) + new Num(2)) + new Num(7) * new Num(8) + (new Num(8) * new Num(6) * new Num(6) * new Num(9) + new Num(7))) * new Num(5)).ToInt();
sum += (new Num(8) * (new Num(8) * new Num(3) + (new Num(4) * new Num(7) * new Num(6) + new Num(6) + new Num(6) * new Num(7)) * new Num(4) * new Num(8))).ToInt();
sum += (new Num(3) * new Num(9) * (new Num(8) * (new Num(3) + new Num(4) * new Num(5) + new Num(3) * new Num(6) + new Num(6))) * new Num(5) * new Num(4) + (new Num(5) + new Num(7) + new Num(7) * new Num(7) + new Num(4))).ToInt();
sum += (new Num(4) + new Num(7) * new Num(9) * new Num(5) * (new Num(4) * new Num(8) + new Num(8) * (new Num(2) + new Num(6) * new Num(9)) * new Num(8)) + ((new Num(8) + new Num(7)) * new Num(2) + new Num(8) + new Num(2))).ToInt();
sum += (new Num(8) + (new Num(7) * new Num(3) + new Num(9) + new Num(9) + (new Num(8) * new Num(3))) * (new Num(4) + new Num(3) + new Num(2) + new Num(5) + (new Num(8) * new Num(7)))).ToInt();
sum += (((new Num(7) * new Num(8) * new Num(2)) + new Num(8) + new Num(4) + new Num(5) + (new Num(9) * new Num(8) + new Num(4))) * new Num(9) * new Num(3) * new Num(7) * new Num(3)).ToInt();
sum += ((new Num(8) + new Num(7) * new Num(4) + new Num(2) * new Num(5) + new Num(4)) * new Num(7) + new Num(9) + new Num(8) * (new Num(2) * new Num(6) + new Num(8) + (new Num(9) + new Num(6)) * (new Num(8) + new Num(6) + new Num(3) * new Num(5) + new Num(3)))).ToInt();
sum += (new Num(7) + new Num(8) * (new Num(6) + new Num(5) * new Num(8)) * new Num(8) * new Num(6) + (new Num(3) * new Num(4) + new Num(8) * (new Num(6) + new Num(7) * new Num(3) + new Num(4)))).ToInt();
sum += (new Num(2) + new Num(7) * new Num(2) + new Num(7) * ((new Num(9) * new Num(2)) * (new Num(4) * new Num(7) + new Num(9) * new Num(8) + new Num(5)) * new Num(7)) * new Num(9)).ToInt();
sum += (new Num(2) * new Num(6) * new Num(8) + new Num(2) + (new Num(9) + new Num(2) * new Num(2) * new Num(4) + new Num(7))).ToInt();
sum += (new Num(3) + (new Num(3) + new Num(3) + new Num(6) + new Num(3) * new Num(2) + new Num(5)) * new Num(6) * (new Num(2) + new Num(7) * new Num(8))).ToInt();
sum += (new Num(2) + new Num(3) * new Num(8) + (new Num(6) * new Num(2) + new Num(7) * (new Num(7) * new Num(6) * new Num(9) + new Num(7) * new Num(4) * new Num(3))) + (new Num(4) * new Num(6) + new Num(3))).ToInt();
sum += ((new Num(5) * new Num(8) + new Num(4)) + new Num(5) * new Num(2) + new Num(5)).ToInt();
sum += ((new Num(9) * new Num(5)) + new Num(4) + new Num(6) * new Num(8) * new Num(7) * new Num(9)).ToInt();
sum += (new Num(3) * new Num(7) + (new Num(8) * (new Num(7) * new Num(2) * new Num(6) + new Num(3)) + (new Num(2) * new Num(6) * new Num(6) * new Num(6) + new Num(4) + new Num(3)) * new Num(5) * new Num(6) * new Num(7)) * new Num(8)).ToInt();
sum += (new Num(4) + (new Num(8) * new Num(6) * new Num(9) * new Num(3) * new Num(7) * (new Num(4) * new Num(3) + new Num(7)))).ToInt();
sum += (new Num(8) + new Num(8) * new Num(7) + new Num(8)).ToInt();
sum += (new Num(6) + new Num(9) + (new Num(2) * (new Num(4) * new Num(4) + new Num(7))) + (new Num(7) * (new Num(7) * new Num(7) * new Num(4) + new Num(5) + new Num(3) * new Num(8)) * new Num(3) + new Num(2) + new Num(9) + new Num(5))).ToInt();
sum += (new Num(7) * new Num(4) + (new Num(5) + new Num(5) * new Num(9) * new Num(4) + new Num(2)) + new Num(6) * new Num(8)).ToInt();
sum += ((new Num(9) * new Num(6) * new Num(9) * new Num(2) + new Num(4)) * (new Num(3) * new Num(3)) + new Num(3)).ToInt();
sum += (new Num(4) * new Num(5) + new Num(7)).ToInt();
sum += (new Num(4) + new Num(2) * new Num(8) + new Num(5) * new Num(8)).ToInt();
sum += ((new Num(8) + new Num(9)) + (new Num(7) + new Num(2)) * new Num(3) + new Num(7) * new Num(6) * new Num(4)).ToInt();
sum += (new Num(3) + new Num(4) * new Num(7) * (new Num(4) + (new Num(3) + new Num(3) + new Num(9)) + new Num(9)) * new Num(9) + (new Num(7) + (new Num(5) + new Num(4) + new Num(4) * new Num(3) * new Num(5)) * new Num(6) * new Num(7) * new Num(7))).ToInt();
sum += (new Num(6) + (new Num(5) * (new Num(4) * new Num(4) * new Num(2)) * new Num(2) * (new Num(7) + new Num(3) + new Num(4) + new Num(6) + new Num(9))) * new Num(9) + new Num(9) + new Num(7)).ToInt();
sum += (new Num(9) * new Num(3) * new Num(4) * ((new Num(2) + new Num(7) * new Num(4) * new Num(5) * new Num(4)) + (new Num(3) * new Num(5) * new Num(4)) + (new Num(8) * new Num(4) * new Num(7) + new Num(8) * new Num(2) + new Num(6)) + new Num(5) * new Num(2) + new Num(2)) * ((new Num(7) * new Num(8) + new Num(4)) * new Num(5) + new Num(3) + new Num(3) + new Num(6) + new Num(3))).ToInt();
sum += (new Num(4) * new Num(7) + new Num(6) + new Num(4) + new Num(8) + new Num(8)).ToInt();
sum += (new Num(6) + (new Num(7) * new Num(7))).ToInt();
sum += ((new Num(4) + new Num(9)) * ((new Num(7) * new Num(8) + new Num(8)) + (new Num(9) * new Num(9) * new Num(4)) + (new Num(9) + new Num(4) + new Num(5) + new Num(9) * new Num(3) + new Num(6)) + new Num(9) * (new Num(5) * new Num(3) + new Num(3) * new Num(4) * new Num(7) + new Num(2))) * new Num(4)).ToInt();
sum += ((new Num(6) + new Num(5) + new Num(9) + new Num(7)) + new Num(5) + new Num(7) * ((new Num(8) + new Num(4) * new Num(5)) * new Num(5) + new Num(6) * new Num(2) + new Num(6))).ToInt();
sum += (new Num(2) * ((new Num(4) * new Num(2) * new Num(8) + new Num(8) * new Num(5)) + (new Num(7) + new Num(8) + new Num(8) + new Num(2)) * new Num(4) + new Num(4))).ToInt();
sum += (new Num(8) * new Num(6) * new Num(4) + (new Num(7) + new Num(5) + new Num(4) * (new Num(3) * new Num(6) + new Num(7) + new Num(4)) + new Num(3)) * new Num(7)).ToInt();
sum += (new Num(5) + new Num(9) * (new Num(3) + (new Num(5) + new Num(6) + new Num(7) + new Num(6)) * new Num(7) * new Num(8) + new Num(8) + new Num(6))).ToInt();
sum += ((new Num(5) * new Num(2) * new Num(9)) * new Num(5) + new Num(8) + (new Num(7) * new Num(9) + new Num(2) * (new Num(6) * new Num(3)) * new Num(7) + new Num(4)) * new Num(5)).ToInt();
sum += (new Num(3) * new Num(7) + (new Num(5) + new Num(2) * new Num(7)) + new Num(5) * ((new Num(6) * new Num(9)) + (new Num(7) + new Num(4) + new Num(9) + new Num(3) + new Num(3) * new Num(6)) * (new Num(6) + new Num(9) * new Num(4)) * new Num(3))).ToInt();
sum += (new Num(7) + new Num(2) + new Num(7) * (new Num(4) + new Num(6)) + new Num(6)).ToInt();
sum += (new Num(6) * new Num(3) * new Num(8) * new Num(9) + (new Num(8) + new Num(4) * new Num(3) + new Num(6)) + new Num(4)).ToInt();
sum += (new Num(2) + new Num(7) + new Num(3) + new Num(7) * (new Num(7) * new Num(5) + (new Num(2) * new Num(4) + new Num(3) * new Num(6)) * (new Num(7) * new Num(5) + new Num(4) * new Num(9) + new Num(6) + new Num(5)) + new Num(4) + new Num(8))).ToInt();
sum += (new Num(5) * new Num(4) + (new Num(5) + new Num(2) * new Num(8)) * new Num(8) * new Num(7)).ToInt();
sum += (new Num(3) + ((new Num(4) + new Num(7) + new Num(8) * new Num(7) + new Num(3)) * new Num(4) + new Num(2) + new Num(5) * (new Num(2) + new Num(6) * new Num(3) * new Num(5) * new Num(7))) + (new Num(8) * new Num(3)) * new Num(5) * new Num(4)).ToInt();
sum += (new Num(8) + new Num(9) + new Num(6) * (new Num(3) * new Num(8) + new Num(8) * new Num(7) + new Num(3))).ToInt();
sum += (new Num(5) * (new Num(6) + new Num(4) * (new Num(3) * new Num(3) + new Num(9) * new Num(6) * new Num(9)) + new Num(5)) * new Num(5) * (new Num(9) + new Num(5) * new Num(6) + (new Num(9) + new Num(3) + new Num(7)) * new Num(5)) * new Num(4)).ToInt();
sum += ((new Num(6) * new Num(7) + new Num(4)) + new Num(4) + (new Num(7) * new Num(7) + new Num(9)) + (new Num(4) * new Num(6) + new Num(3) * new Num(3)) + new Num(3) + new Num(7)).ToInt();
sum += (new Num(9) * new Num(3) * new Num(9) * new Num(7) + ((new Num(3) + new Num(7) * new Num(9) * new Num(8) * new Num(4)) + new Num(9) * new Num(4) * new Num(5))).ToInt();
sum += (new Num(9) + (new Num(2) + (new Num(7) + new Num(2)) + new Num(9) * new Num(7) * new Num(3))).ToInt();
sum += ((new Num(8) * new Num(5) * new Num(2) * new Num(9) * new Num(3)) + new Num(5) + (new Num(9) + new Num(4)) + new Num(6) + new Num(7)).ToInt();
sum += ((new Num(9) * (new Num(4) + new Num(8)) * new Num(8)) + new Num(3) * new Num(4) * new Num(9)).ToInt();
sum += (new Num(8) * (new Num(2) * (new Num(6) + new Num(6) + new Num(3) * new Num(8)) * new Num(5) * new Num(7) + new Num(5)) + (new Num(7) + new Num(4)) * new Num(9) * new Num(4)).ToInt();
sum += (new Num(7) * (new Num(7) * new Num(3) * new Num(7) + new Num(3) * new Num(5)) * ((new Num(3) + new Num(5) + new Num(4) * new Num(4)) + new Num(5) * new Num(8)) * (new Num(6) + (new Num(5) + new Num(7) + new Num(7) * new Num(8)) + new Num(2) + new Num(9) * (new Num(3) + new Num(3) + new Num(4))) + new Num(8)).ToInt();
sum += (new Num(9) + new Num(4) * ((new Num(2) + new Num(2) * new Num(3) + new Num(4) + new Num(2) + new Num(7)) + new Num(5)) + new Num(8) * new Num(7)).ToInt();
sum += ((new Num(2) + (new Num(5) + new Num(7) * new Num(9)) + new Num(2)) * new Num(7) * (new Num(4) + new Num(9) * new Num(2) * new Num(8) + (new Num(7) * new Num(4) * new Num(8) * new Num(8) + new Num(9)) * new Num(2)) * new Num(3) * new Num(3)).ToInt();
sum += ((new Num(9) * (new Num(9) * new Num(3) * new Num(2) + new Num(5) * new Num(5)) * new Num(6) * new Num(8)) + new Num(7)).ToInt();
sum += (new Num(5) * new Num(2) + new Num(6) + new Num(7) * new Num(7)).ToInt();
sum += ((new Num(9) + (new Num(4) + new Num(3) * new Num(8) + new Num(6) + new Num(4)) + new Num(4)) * new Num(7) * new Num(6) * new Num(3) + new Num(4)).ToInt();
sum += (new Num(7) + new Num(4) * ((new Num(3) + new Num(7) * new Num(4)) + new Num(3) + new Num(6) * new Num(7) + (new Num(3) * new Num(5) * new Num(3))) + new Num(2)).ToInt();
sum += (new Num(7) + (new Num(8) * new Num(9) + new Num(3)) + new Num(3) + new Num(5)).ToInt();
sum += (new Num(8) + (new Num(8) + (new Num(6) * new Num(8)) + new Num(6) * new Num(9) + (new Num(8) * new Num(6) + new Num(7) + new Num(8) + new Num(7) + new Num(5)))).ToInt();
sum += (new Num(6) * new Num(7) + new Num(7) + new Num(3) * new Num(8) * new Num(8)).ToInt();
sum += (new Num(5) * ((new Num(2) * new Num(8) * new Num(8) + new Num(2)) * new Num(3)) + new Num(8) + new Num(4) + new Num(8)).ToInt();
sum += ((new Num(4) * new Num(5) + new Num(5) + (new Num(9) + new Num(2)) + new Num(6)) + new Num(9) * new Num(2) + new Num(3)).ToInt();
sum += (new Num(8) * new Num(7) + (new Num(3) + (new Num(7) + new Num(8) * new Num(3) * new Num(7)) + new Num(8) + new Num(4) + new Num(5) * (new Num(4) * new Num(3) + new Num(5) * new Num(2))) + new Num(4) * new Num(3) + new Num(6)).ToInt();
sum += (new Num(2) * new Num(3) * (new Num(3) * new Num(6) + new Num(9) + new Num(7) + new Num(7)) + new Num(7)).ToInt();
sum += ((new Num(7) + new Num(2) + new Num(8)) + new Num(8) + new Num(6) * (new Num(2) + new Num(9) + new Num(8) + new Num(5) + new Num(3)) * new Num(7)).ToInt();
sum += ((new Num(8) + (new Num(3) * new Num(9) * new Num(7) + new Num(5) + new Num(3) + new Num(2)) + new Num(4)) + (new Num(2) + new Num(7) * new Num(9))).ToInt();
sum += (new Num(3) + (new Num(9) + (new Num(4) * new Num(4) * new Num(8)) + new Num(2) * new Num(4) + new Num(6) * (new Num(5) + new Num(6) + new Num(4))) + new Num(4) + new Num(7) + (new Num(4) + new Num(8) * new Num(9) * (new Num(5) * new Num(6) * new Num(3) + new Num(3)) + new Num(9)) * new Num(9)).ToInt();
sum += (new Num(5) + new Num(6) + (new Num(5) + new Num(8) + new Num(2) + new Num(6) * new Num(2) + (new Num(4) * new Num(4) + new Num(5) + new Num(6) * new Num(4)))).ToInt();
sum += (new Num(5) + (new Num(4) * new Num(6) * new Num(5) * new Num(8) + new Num(4))).ToInt();
sum += (new Num(9) + (new Num(3) * new Num(9) + new Num(8) * new Num(6) * new Num(7) + new Num(4)) + (new Num(9) + new Num(8) + new Num(9) + new Num(3)) + new Num(2) + new Num(7)).ToInt();
sum += ((new Num(7) * new Num(5) * new Num(8) + new Num(2) + new Num(3)) + new Num(4) + new Num(9) + new Num(6)).ToInt();
sum += ((new Num(6) * new Num(9) + new Num(4) + (new Num(3) + new Num(4) + new Num(2))) * new Num(5) + new Num(4) + new Num(8)).ToInt();
sum += (new Num(9) * new Num(2) + new Num(7) + new Num(2)).ToInt();
sum += (new Num(8) + new Num(4) + (new Num(3) + new Num(2) * new Num(2) * (new Num(6) * new Num(9) + new Num(8) * new Num(4) + new Num(5)) * (new Num(6) * new Num(8) * new Num(4) * new Num(5) * new Num(7) + new Num(3))) * new Num(9) + new Num(6) + ((new Num(6) * new Num(4) + new Num(9) + new Num(7) * new Num(7) * new Num(2)) + new Num(8) + (new Num(3) * new Num(6)) * new Num(6) * (new Num(3) * new Num(2) * new Num(9) * new Num(5)) + new Num(4))).ToInt();
sum += (new Num(3) + (new Num(9) + new Num(6)) * new Num(7)).ToInt();
sum += ((new Num(2) * new Num(9) * new Num(9) * new Num(7)) + new Num(3) + new Num(5) + new Num(7) * new Num(6)).ToInt();
sum += ((new Num(5) * (new Num(6) * new Num(3)) * new Num(8) * new Num(3) + (new Num(8) + new Num(9) + new Num(7))) + new Num(7) + ((new Num(2) + new Num(6) + new Num(4) * new Num(8)) * new Num(9) * (new Num(6) + new Num(2) + new Num(4) + new Num(6) * new Num(6)) * (new Num(7) + new Num(6)) * new Num(7) * new Num(7))).ToInt();
sum += (new Num(7) * new Num(2) + (new Num(3) * new Num(5) + (new Num(3) + new Num(7) * new Num(2) * new Num(5) * new Num(9)) * (new Num(9) * new Num(9) + new Num(8) * new Num(2)) + new Num(9) * new Num(8))).ToInt();
sum += ((new Num(2) * new Num(6) + new Num(2) + new Num(7) * (new Num(6) + new Num(6) + new Num(2) * new Num(2) + new Num(9)) * new Num(2)) * new Num(3) + (new Num(6) + (new Num(6) * new Num(8) + new Num(9))) + new Num(9)).ToInt();
sum += (new Num(9) * new Num(4) * new Num(3) + new Num(5) * new Num(7) + (new Num(5) * new Num(4) + new Num(3) + new Num(8))).ToInt();
sum += (new Num(5) + new Num(4) * ((new Num(2) + new Num(2)) + new Num(3) + (new Num(7) + new Num(9)) * new Num(9)) * new Num(9) + new Num(9)).ToInt();
sum += (new Num(8) * new Num(3) + new Num(9) + (new Num(5) + new Num(6) * new Num(2) * new Num(6) + new Num(6)) + new Num(8) + new Num(4)).ToInt();
sum += ((new Num(5) * new Num(4) + new Num(6) + new Num(5) + new Num(6) * new Num(4)) * new Num(3) * new Num(6) + new Num(9) + new Num(8)).ToInt();
sum += (new Num(7) * ((new Num(3) * new Num(8)) * (new Num(8) * new Num(7) + new Num(2) + new Num(2) + new Num(5))) * new Num(3) * new Num(5)).ToInt();
sum += (new Num(4) + (new Num(7) + new Num(7)) + new Num(2) * new Num(5)).ToInt();
sum += ((new Num(6) * new Num(4) + new Num(8) * new Num(9)) + new Num(9) + new Num(7) + (new Num(6) + new Num(9) + new Num(4) * new Num(5)) + new Num(8) + (new Num(5) * new Num(4) + new Num(3) + new Num(9))).ToInt();
sum += ((new Num(4) + new Num(2) + new Num(4)) * new Num(7) + new Num(3) * new Num(2) + (new Num(2) * new Num(4) * new Num(9) * (new Num(7) * new Num(3) + new Num(7) + new Num(8) * new Num(7)) + new Num(8) * new Num(9)) + new Num(5)).ToInt();
sum += ((new Num(4) * new Num(6)) * new Num(8) + new Num(7)).ToInt();
sum += (((new Num(3) * new Num(8) * new Num(4) + new Num(4)) * new Num(6)) + new Num(9) * new Num(8) + new Num(6) * new Num(4) + (new Num(9) * new Num(6) * new Num(8) * (new Num(3) + new Num(3) * new Num(4) + new Num(6) + new Num(2)) + (new Num(8) + new Num(3) * new Num(6) * new Num(2) + new Num(3) * new Num(6)))).ToInt();
sum += (new Num(5) * new Num(8) * (new Num(3) * (new Num(5) + new Num(3) * new Num(5)) * (new Num(5) + new Num(4)) + new Num(9)) * new Num(7)).ToInt();
sum += (new Num(8) + (new Num(5) + new Num(7) * new Num(7)) + (new Num(4) + new Num(4) * (new Num(9) * new Num(3)) + new Num(6)) * (new Num(8) * new Num(8) * new Num(8) + (new Num(3) + new Num(3) * new Num(4) + new Num(9) + new Num(6) + new Num(4))) + new Num(9) + new Num(7)).ToInt();
sum += ((new Num(9) + (new Num(7) + new Num(4) * new Num(6)) + new Num(8) + (new Num(7) + new Num(4) * new Num(2) * new Num(3) + new Num(6))) + ((new Num(8) + new Num(6)) + new Num(5)) + (new Num(7) * new Num(5) + new Num(5) + (new Num(4) * new Num(7)) + new Num(8) + new Num(6)) + new Num(8)).ToInt();
sum += (new Num(4) * new Num(7) + new Num(4) * ((new Num(2) * new Num(2) + new Num(2) + new Num(4) * new Num(2) * new Num(9)) * new Num(7) * (new Num(9) + new Num(5) * new Num(3))) + new Num(9) * (new Num(7) + new Num(6) + new Num(3) + new Num(3))).ToInt();
sum += (new Num(5) * new Num(4) + (new Num(5) + (new Num(7) * new Num(2) + new Num(6) * new Num(2) * new Num(5) + new Num(8)) * new Num(2))).ToInt();


            return sum;
        }

        public static string translate(string str) {
            // swap + and * operators
            str = str.Replace("+", "p");
            str = str.Replace("*", "+");
            str = str.Replace("p", "*");
            str = str.Replace("1", "new Num(1)");
            str = str.Replace("2", "new Num(2)");
            str = str.Replace("3", "new Num(3)");
            str = str.Replace("4", "new Num(4)");
            str = str.Replace("5", "new Num(5)");
            str = str.Replace("6", "new Num(6)");
            str = str.Replace("7", "new Num(7)");
            str = str.Replace("8", "new Num(8)");
            str = str.Replace("9", "new Num(9)");

            return str;
        }

        public static string[] getInput() {
            string inp = @"3 * 4 * 2 * 5 * (3 + 4 * (6 + 3 + 2 + 8 + 4) + 5 * 7)
2 + 6 * 2 * 4 * (9 + 6 * 7 + 2 * 7) + 3
(9 + 4 * 4 + 5 * 2) * 2 * 7
5 * 9 * (6 + 6 + 8 * (5 + 2 + 2 * 6 * 8) * 8 + 9) * 3 + ((8 * 9 + 6 * 5) + 2 * 5 + 4 * 6 * 4) + 4
3 + (4 + 9 + 6 + 6 * 4) + 9
7 * 2 * 7 * ((7 * 6 + 8 * 9) + 2)
2 * (7 * 5) + (7 * 9 * 7) + 9
(6 * (6 + 8) + (4 + 7 + 4 + 8 + 2 + 8) * 8 + (4 + 9 * 9 * 5 + 7)) + 6 + 6 * 6
4 + (4 * 3 * 9) + (8 + 4 + 4 + (3 + 8 + 8)) + 8 * 6 * (8 * 5 + 4 * 5 * (9 + 8 * 4 + 2))
9 + (8 * (3 + 2 + 9 + 8 * 8) + (3 * 7 * 7 + 8) * 2) * 6 * 9
2 + (4 + 3 * 7 * 8) * ((6 * 3 + 4 + 6) + 8 + 2 + 4 * 5)
2 + (5 * 9 + (6 + 7 + 4 + 3) * 4) + 3 + 4 * (9 * 2 + (5 * 7 * 5 * 6 + 9)) * 9
6 * 7 + 8
7 * 5 + (4 * 6 + 7 * (3 + 9 + 4 + 7 * 7) + 6 * 2)
7 + 9 * 6 * (6 + (2 * 7 + 5 + 4)) + 5 + (2 + 9 + (4 + 5 + 6))
5 * (5 + 8 * 3) + (6 * (5 * 8) * 4)
5 * (3 + 8 + 6 + 9 * 7) * (3 * 6 * 3) * (8 + (5 * 9 + 7 * 5) + 4 + 5 + 5 + 9) + 5
4 + (6 + 2 * 8 + 7) * 6 * 5 + (2 * 9)
((5 + 7 * 6 + 4 * 3) + 7 + 2 * 2) + 7 * 7 + 2
9 + 8 * ((2 + 4 * 7) + 7 * 9 + (2 * 5 + 7 * 9 + 4 * 4))
(7 + 5) + 5 * (5 + 2 * 5 + 3 * 7 * 6) + 7
4 + (4 + (6 * 2 * 8 + 6 + 3) * (6 * 6 * 4 * 7 * 2)) * 5 * 2 + 2 + 6
(2 * (6 * 2 + 4)) + 5 + 7 * 2 * 8 + 8
5 * 4 + 8 + 9 + 6
(3 * 4 + 3 + 5) + 7 + (7 + 9)
(2 * 8 + 2 + 2 + 2 + (4 + 2 * 8 * 6 * 5 + 6)) + (8 + 7 + 8 * (4 * 5 * 5 * 4)) * 7 * 6 * (7 + 3 + 3 * 8 + 5) + 8
8 * ((6 + 5 * 3) * 3 + 5) + 3 * (4 + (9 + 4 * 4 + 8 + 9) * 6 * (9 * 4 * 2)) * 6
4 * 6 + (3 * 8 * 8) * 2
8 * 2 * 8 * 4 * (7 + 8 + 2 + (7 + 2 + 5 * 6 * 8 + 2) * 3 + 4)
3 + 8 * 5 + 4 * (7 * (7 + 6) + 9 + (9 + 8 + 6))
9 + (2 * 2 + (7 + 9 + 7 + 7 * 2) + 5 * 6 + 4)
7 + (6 + 2 + (5 * 7 * 5 * 3) * 8)
2 * (8 * 6) + 7 * 6 * 8 * 8
7 + (2 + 8 * 6) * 9
((7 + 4 + 9) * (7 * 6 * 7 * 3 + 2 * 6)) * (4 * 8 + 6) + 4
5 + 6 + (2 + 2 * (6 * 9 + 8 * 4) + 4)
8 + (5 + 8 * 9 + 3 * 3) * 8 + 5 * 5 * 3
4 + ((2 * 7 * 3 * 2 * 5 + 3) + (8 + 6 + 5 * 3 + 2 + 4) + 7 * 8 + 2 + 6) * 2
((9 + 4) + 4 + 9 * (6 + 7)) + 3 * 2
9 * 6
(3 + (2 + 5 * 2 * 7 * 9 * 6) * 5 + 7 + 4 * 8) * 3 + (2 + 8 * 5 + 6 * 8) * 7
(9 + 5 + (9 * 8 + 2 + 6) + 5) + (4 * 5 * 4) + 6 + 4
(4 + (7 + 3 + 3 * 5 * 5)) + 6 + ((4 * 4 * 8 + 3 * 9) + (6 + 2 + 3) + 2) * 7 + 2
(8 + 9 * (5 * 7)) * 8 * 9 * (3 * 6 * (4 + 4 + 6) * 9 + (2 + 7 * 6 * 2 * 2)) + 8
4 + 7 + (8 + (5 * 9 * 5 + 4 * 5 * 3) + 7 * (8 * 4 + 5 + 9 + 4 * 5) + 2 * 7) * 5 * 8
4 * 9 * (7 * 2 * 8 + (8 * 2 * 9 + 2 + 3) * 7)
(5 * 2) * 9 + 7 * (9 + 9 * 2) + ((2 + 5 + 8 + 6 * 2) * 6 + 4)
5 * 4 * ((2 + 8 + 9) + 3 + 4 * (8 * 9 + 2) * 8) + 2 * 5
(3 + (5 * 4 * 6 + 2) * 3 + 8 + (2 * 6 + 2 * 5 + 9 * 8)) * 4 + 4 + (4 + 7 + (3 + 8 * 3) + 5 + 6 + 5)
6 + 3 * 7
6 + (6 + (5 * 9 + 5 * 2 * 2 + 6) * 8) + 5 + (3 + 6 + 5) + 3 * 4
4 + 9 + ((7 + 7) + 2 + (2 * 3 + 4 * 2) + 3 + 6) * 9 + 7 * 9
(5 + 8 * 5) + 8
4 * 5 * 5 * (9 + 2 * (7 * 5 * 8 + 6 + 4) * (5 + 8 + 7) + 5 + (7 + 9 * 8 * 9))
7 + ((9 * 6 + 6 * 5 * 2 * 6) + 7 + 2 * 4 * 7 + 7) * (7 * 4 * 3)
2 + 5 + (7 + (6 + 5 * 5) + 9 + 7 + 9 * 8) + 7 + 7 * 2
7 + 9 * (9 + 6 + 3 + 7 * 4 + (6 * 6)) * 9 * 2 + (4 + 8 * (6 * 6) * 2 + 3)
((4 * 3) * 6 * 7 + 7) * 3 * 8 + (7 * (5 + 6 + 8 * 2)) + (8 * (5 + 4 * 5 + 9 * 3 + 4) * 3 + 9 * 4)
9 * ((8 + 9 + 7) + 2) + 8 * 3
4 + 3 + 9 + 4 + (2 + 8) + (2 + 4 * 8 + 6 * 5)
7 * ((7 * 2) * (3 * 4) + 8 + (8 * 6 + 5 + 2) * 8 * (6 * 9 * 3)) * 3 + (8 * (4 * 3 + 8 * 9 * 6 + 3) * 7 * 6 * 3)
5 + 3 * 4 + 9 + 5 + ((5 + 6 * 3 + 7 * 9) + 5)
9 + 9 * 8 * 8 * 5 * (6 * 7 * 8 + 5 * (6 * 7) + 9)
7 * (6 * (4 + 2 * 7 * 5 + 8 * 5) + 5 * 3 * 9 * 4) + 9 + 7
4 * 7
2 + 9 + 3 + ((9 * 5 + 5) * 6 * 9 + (9 * 9) * 2 + (6 + 5 + 2)) * 6 + (5 * 8)
(6 + 6) + 3 * 3 + 2 + (6 * (2 * 3 + 3) + 3 + 6) + 6
(5 + 3 + 5 * 8 + 6) * 9 + (9 * 3 * 3 * 9 * 5)
9 + (3 + (5 * 4) * 7 + 4) + 3
(4 * 5 * 5 + 2 * (5 + 2 + 3)) * 7 * (4 + 7) * 9 + 4 + 8
(8 * (2 + 9 * 7) + 8 + (7 + 9 + 6 + 4 + 3 * 9)) + 4 + (3 + 3 + 7) * 4 + 7 + 3
7 + 2 * 4 + (7 + 7 * 5 * 3)
7 + 9 + (6 + (9 + 6 + 6 + 8 * 4) * (5 * 2 * 9)) * (9 * 2 * 8 * 5 * 8) + 3
8 + (8 + 9 + (9 + 9 * 9 + 9) + 4 * (6 * 6 + 2 * 9 * 8 * 3))
(5 * 4 + 4) + 3 * ((9 * 5 + 8 * 8 + 9 * 8) + 3 * 2 + 3 * 5 + (3 * 9 * 8 + 3)) * (5 * 4 * 6 * 7)
5 + 2 + (9 * (7 * 7 * 6 + 8 * 6) * 9 + 6 + (6 + 9 * 9 + 2) + (4 + 5 * 4 * 2 + 5 + 4)) + 9
(6 + 2 * (6 * 3 * 9)) + 4 * 5 * 2
(3 + (8 + 4 + 7) + 9 + 6 * 3) * 9 + 3 * 7 * (9 * (6 * 8 + 4 * 9) + 2)
((9 + 5 * 7) * (2 + 4) * 3) * 4 * 5 + 2 * 3
4 * ((7 * 7 + 5 + 6) + 8 + 7 * 6) + (8 + 9 + 6) + 8 + (8 * 6 + 4 + 8 + 6) + 3
(9 + 9 + 8) + 3 * (6 + 6) + 6 + 2
((6 + 8) + (9 + 5 * 8) * 4 + 4) * 2 + 6 * 7
9 * 2 + (6 + 9 + (6 + 8 * 2 + 4) * (5 + 5 * 9 + 9 + 9 + 6) * (8 * 4 + 6 + 8 + 3 * 7)) + 8
4 * (7 * 9 * 5 * 2) * (5 + 6 * (5 + 4 + 5 + 5) + 4 + 5 + 7) * (3 * 8 + 3 * 4 * 6 * 7)
6 + (8 * 9 + 2) + 7 + 5 * 8 * 4
((5 * 4 * 6 * 5) + 5 + 5 * 5 + 9 + 8) * 3
(2 + (4 + 3 + 8 + 2 + 5 * 2) * 3) * 3 + 5 * (4 + 6 * 9 * 7 * 2) * (2 * 2 + 8 + 7 + 9) * 9
(7 + 4 + 3 + 5 + 4 + 7) + 6
8 + 5 * 2 * 6
5 * 6 + 6 + 5 + 4 + 5
3 + (6 * 5 + 7 * 5 + 8 * 6) * 6
((6 * 2 * 3 + 6) * (2 * 6 * 4 * 4 * 6) + 5) * 8 + 5 + 8
(4 + 4 + 9 + 7) + 3
7 * (2 + 5 * (5 * 8 * 9 * 3 * 4) + 7 + 8) + 6 + 8 * 6 + 3
3 * 4 * (7 * 2) * 2 + 8
2 + 5 + 8 * 4 * (4 + 3 + 6 * 6 * 3 * 9) + 2
9 * (6 + 4 + (7 + 3 + 3 * 3) + (2 + 4 * 2 + 8 + 7)) * (9 + 2) * 2
8 * 9 * 3 + 8 * 4
3 + 6 + 9 * (5 * 2 + 8) + 3 + (9 + 4 + 8 + 5 + 6)
(4 * 3) + 7 + 7 + 3
3 * 5 * (2 * 9 * 5 * 7 * 9 * 5)
2 * (7 * 9 * 6) * 8 + 4 + (8 + 5 * 2) * 4
(6 + 4 * 3 * 3) * (5 * 7) * 2
6 * 7 * (2 * (2 * 4 * 9 + 4 + 2 * 3) + 6 + (9 + 8 + 8 + 7 + 6) * 3) + 7 * (3 * (7 * 2 + 5 * 8 + 2) + 4 + 7 * 8) + 2
((9 + 4) + (2 * 8 + 4 * 9 + 3) + 9 * 5 + 7) * 6
4 + 4 * (2 + 4) + ((9 * 6 + 2 + 6 * 2 + 4) * 9 + 6) * 3 * 7
9 + ((4 + 6 + 9 + 6 + 5 + 9) + 8 * 3 + 2 + 5)
4 * 6 * 3 + 7
7 + ((8 * 2 * 8 * 6) + 6 * 9)
(7 * 3 * 4 * (5 * 2 + 3 * 6 * 4 + 5) * 5) + 3
3 + 4 + (3 + 5 + 8 + 5 * 8 * (3 * 4)) + 2 * (9 * 4 + 5) + 7
((8 * 5 + 3) + 7 * 8) * (3 * 8 * 6 * 8 + 3)
8 * 8 + ((4 * 5 + 5) * 7 + 4 * 7 * 4 * 5) + 3 + (4 + 5 + 8)
(4 + 6) + (2 * 7 + 2 * 2 + 7) * 6
((9 * 6 * 7 + 5 + 4) + 2 + (7 + 6 + 5 + 6 + 3) * 4) + 5 + 4 * 9
4 + 6 + (7 * (3 + 6 * 6) + 5)
9 * (4 * (4 + 5 * 4) * 6 * (2 * 9 * 8) + 8)
(8 + 6 * 4 * (7 + 4 * 8 + 9 * 5 * 5) + 7) + (6 * 7 + 7 * 2 * 8 + (9 * 2 * 6))
(5 + 2 * (7 + 6 * 5 * 8 + 8 + 2) + 6 * 5) * 7 * 9 * 6 + 3 * 5
6 + 6 * ((7 + 4 + 7 * 5 * 8) + 7 * 6 + 2 * 9) + 3 + 8 * 4
4 + 3 * (3 + 5 + 3 + 4 * 5 + 2) * (3 * 9) * 2 + 6
((8 + 6 + 3 + 5 * 9 + 8) * 3 + 6 * 8) + 9 * 7
(7 * 3 * 6 * 3 + 5 * (3 * 3 * 7 * 9)) + 8
5 * (4 * 8 * 4 * 7)
(5 + 8 + (5 + 3 + 6 * 8) * 3) * 9
4 * 6 * 9
(4 * 5 * (2 + 7 + 5)) * 7 + (6 + 5 + (7 * 6 * 8) * 4 + 5 * (2 * 9 + 6 * 4 * 4 * 2)) + ((5 + 3 + 7 * 2 * 7 * 8) + 7 * 3 + 5 + (5 * 2)) * 3 + 7
((7 * 5 + 9 * 9) + 9 + (3 * 5 + 9 * 5 + 3)) + (9 + 5 * (5 + 4 * 7 + 6 + 7) + 4) * 2
4 * 2
9 + 6 * 6 + (8 * (8 * 8 + 5))
7 + 9 + (4 * 6 * 4) * 2 + (7 + (7 + 3 * 4 * 6 * 2) + (6 + 8 + 8 * 7)) * 3
7 + 8 * 2 * 7 * (2 + 6 * (7 * 2 + 6) + 6 + 2) * 4
(4 + 3 * (2 + 3 + 8 + 7 + 6) * (6 * 7) * (2 * 6 + 2 * 4) + 5) * 2 + 8 + 8 * 4
6 * 8 + ((7 * 9 + 9 * 3) * 2 + 7 + (8 * 5 + 4 * 8) + 6) + ((4 + 2 + 3 * 5) * 5 + 5 * 8 * 8) * (3 + 4)
6 * 2
6 + (7 + 4) * (6 + 3 + 8 * 8 + 8) * 9 + (2 + (9 + 8 * 8) * 6 + 9)
8 * 7 + (7 * 3 + (2 * 5) + 3) + 5
6 * 4 + 3 + 3 + 2 * 3
(2 + (3 + 4 + 5 * 7 + 2) * 8 + 4) * 3 + 5 * 7 * (5 * 8 * 4 * 8 * 9 + 2)
(9 + 9 * 7 + 9 * 4 * 2) + ((4 + 5 * 6 + 2 * 5 * 2) * 3 * 3 + 2 * 7) * 4 + 6 * 4
(4 * 4 + 6 + (4 * 5 * 8 * 7 * 9)) + 3 * 7 * (3 * 8 * 5 * 8 * 9 + 2)
(3 + (9 * 4 * 6 * 2 + 4) + (4 + 6 + 2 + 6 * 3 * 3)) + (4 + 7 + 8 * 4) * ((7 * 9) + 9 + 3 * 4) + 4 * 8
(9 * (2 * 3 * 4 * 2 + 4) * (8 * 7 + 5 * 7 + 9)) * 9 + 6 + 5 * (8 + 4 + 5 * (7 + 9 + 5))
5 + ((9 * 5 + 6 + 6 * 5) + 6) + 5 + (7 + 3 + 3 * 9 + (4 * 8 * 4) + 7) * ((8 + 9) * 9 * 6 * 4) * 5
3 * 2 * 2 + 2 * 6 * (7 + 5)
5 + 3 + (4 + 2) * 8 + 5 * (5 * 8 * 6)
5 + (6 + (5 + 8 * 6 + 4 + 6 + 7))
(7 * 4) + 9 * 3 * 4 + (4 * 7 + 5 * 6 * 9 * 4)
8 + 9 + 7 + 7 + ((5 + 8 * 8 + 5) * (8 * 4 + 9 + 4) + 9)
4 * 3 + (6 * 2)
(5 + 8 + 8 * 7) * 2 * 6
4 + 5 * (6 * 8 * 2) + 4 + 2 + 7
(2 + (5 * 6) * 6 + 9) * 4 + 2 + 8
((7 + 9 * 5 + 6 + 6 + 7) + 3 + (8 * 8 + 8 + 4 + 4 + 4) + 5 + 6 + 6) * 2 + 6 * (5 * 3 * 6 * (3 * 8 + 9 + 5 * 6) + 2) + ((7 * 3 + 9 + 5) * 3 * 7) + 8
5 * 7 * 6 + (5 + 6 * (7 + 8)) * 8 * 5
3 + 9 * (8 * (2 * 4 * 5 * 4 * 4 + 2) * 6 * (7 + 6) + 2 * 8) * 7 + (9 * 9 * (6 * 2 + 8 * 5 * 7))
(6 + 5 * (6 + 7 + 9 * 4) + 4 * 7 * 3) + 4 + 8 + (4 * 5 + (5 * 6 + 8)) * ((9 + 6 * 7) + 8 + 6 + 2 + 3 * 8)
((9 * 4) + 8) * (5 + 7 * (8 + 7 * 6)) * ((4 * 5) * 5 + 2 + (8 * 7) + 5 + 8) * 8 * 5 + 5
7 + (3 * 5 * 2 + 6 * 6) + 3 * 6 * 6
9 + (5 * 9 * (5 + 5 * 6 * 8) + 3 + 4 * 6) + 7 + 9
6 + (9 * 9 + 2) * 4 + (4 + (9 + 4 + 4) * (5 * 2) * (8 + 9 + 7 + 2 + 6)) + 4 + 3
6 + 8 + ((7 + 2 * 6 + 5 + 5) * 9 + 9)
8 * 2 + 8 * ((9 * 5 * 3) * 9 + 5 + 6 * 4) + 9
(9 * 7 * 4) + (3 * 7 + 9 * (7 + 9 + 8)) + 5
((9 + 2 + 5 + 5 + 5) + 7 * 7 * 8 * 7) * 3 + 2 + (3 * (7 * 2))
7 * 4 * 8 * 4 * 8
(4 * (4 + 2 * 9 * 5) * 5 + (8 * 5) + 5) * 4 + 6
7 * (8 * 2 * (8 + 6 + 6) + (5 + 9 * 4 * 3) * 4) * 2 + 9 + (7 * 3) + 2
4 + (4 * (8 * 9 + 6 + 6 * 5 + 7) * 5 + 9 + 3) * 2
5 * 4 + (6 + 8 * 8 * 3 + 5) + 9 * 8 * 8
5 * 2 + (5 * 6 * 3)
(6 * 6) + 4 + ((6 + 6 + 4 + 5 + 5 + 5) * 2 + (3 * 4 + 2) * 5) + 2 * (4 + 6) + (8 * 6 * 9)
9 * 8 + 3
(9 * 8) * (4 * 4 + 2) * 3 * 7
(4 + (6 * 5 + 3 + 2 * 4) + 5) + 3 + ((9 * 8 + 4 + 9 * 4 * 6) * 8 + 3 * 7 + 5) + (5 + (9 * 5) * 2 + 3)
9 + 9 + (5 * (3 * 2)) * 3 + 3
9 + 5 * (7 * 8 + 8) * (5 + (4 + 8 * 2 + 4 * 5 + 3)) + 9
6 + 9 + ((3 + 4 * 6 * 8 * 7) + (5 * 6 + 4 * 4 * 7) + 2 * 7 * 7)
((9 * 7 + 2) * 7 + 3) + 9 * 7 * 9 + 3
8 * 9 * 7 * (7 + 7 * 2 + (8 + 9 + 4 * 6 + 5) + 7) + 8 + (2 * 3)
(5 + (5 * 5) + (7 + 9 + 3 + 9 + 3 + 7) + 5 + (2 + 7)) * (5 + (9 + 7 * 6 * 9 * 4)) + (3 + 3 * 5 + (8 * 9 * 8 * 9 * 7 * 6) + 5) * 3
(6 * 3 + 4 * (4 + 5 * 8 + 7 * 7)) * 2 + 7 * (6 + 7) * 8 * 6
4 * ((6 + 7 * 3 + 7 * 4 + 7) + 6 * 6 + 9) + ((3 * 7 + 5 * 6) * 4) * 8
2 + (6 + 2 + (5 + 8 * 3 * 5 + 4 + 9)) + 7 + 9 * 4 * (4 + 3)
9 + (9 * 3 + (2 + 4 + 6) + 8 + 6) + (5 + 3 + (9 + 9 + 3 + 9 * 9 + 4)) + 2
(7 * 8) * (4 * 6) + 4 * 6
5 * (8 * 9 + 7 * 4) + 2 + (3 + 5 * 9 * 8) + 9 * 7
(8 * (2 * 4 + 3 * 7 * 3) + 2 + 4 * 6) + 3 + 5 + 4 + (8 * (6 + 6 + 5 + 9 * 2) * 2)
2 + (9 * 6 * 8 + (6 + 4 * 8 * 2 * 4))
2 + 8 + ((2 + 4 * 9 * 9 * 6 * 7) + 9 * 4 + (4 + 3 * 5) * 9 + 6) * 9 * 6
8 + 2 * (4 * 4) * (5 * 9 + (7 * 2) * 3) + (9 * 7 + 8 + 3 + 5)
9 + 6 * 6 + (4 + 7 + 7 * 9) * (7 + (2 * 7 * 5) + (5 * 2) * 9 * 7 + 7) * ((4 + 4 * 5 * 7 * 7 + 2) + 6 * 4 * 2 + 2)
((5 * 4 + 5 + 7) + (4 * 8 + 5 * 8) * 3) * 6 * 9
2 * (9 + 5 + 8 * (4 + 2 + 8) + 9 + 4) * 4
8 * (4 + (2 * 9 * 5) + 2 + (4 + 3 * 3 * 4 + 7 + 6) + 4 + (2 * 2 * 5 + 6 + 6)) * 8 + 2 + (7 + 5 + 6 + (9 * 6) * 5)
4 + 5 * 9 + 3 + 3 * 3
2 * 7 * 3 + 4 * (5 + 9 * (5 * 6 + 8 + 4) * 5) * 4
6 + (3 + 4 * 5 * 3 * 9) + 3 * (3 + 5 * 6) * 6
3 + 6 * 5 * (4 * 5)
4 * (7 * 9 + 5 + 5 * 3 * 4) + 8 + (3 * 5 + 4 * 3 + 7 * 3) * (7 * 8 * 4 + 5 * 3 + 2)
(3 * (5 * 4 * 2 * 2 * 9 * 9) + 3 * 7 + 7 + 3) + 8 * 5 + 6 + 5 * 9
9 * 3 + 6 + ((5 + 5 + 7 * 3 * 6 + 5) + (5 + 6) + 7)
3 * 7 * (9 + (7 * 3 + 2 * 8)) + (3 + 4 * 2 * 5 + 5)
8 * 6 * 3 * 9 * 6 * (5 + 4 * 3 * (8 * 3 * 7 + 4 + 4 + 2) + 2)
6 + 9 * 2 * (3 + 9 + 6 * 8 * 8 + 5) * (5 * 8 * 5 + 3) * 9
3 * (5 * 4 + 4 * 2 * 6 + 4)
3 + 2 + 4 * (9 * 6 * 9 + 8 + 4) + 4
(5 + 2 + 5 * 5 + 3 + 3) + 7 + 9 * 3
5 * (8 + (3 + 9 * 8) * 4 + 9) + 4 * (2 + 4 + 4 + 3) + (7 * (9 + 5 + 6 * 9) * 5 + (4 + 4 * 3 + 2 + 8 * 7) * 5 * (6 + 9 * 7 + 2 + 4 + 7))
6 * 3 * (4 + 4 * 7 + 2) * 3
9 * (6 * (7 + 3 + 7 * 3 * 8 * 2) * 4 * 2 * 3 * 9) + 9 * 7 + 9 + 5
(9 * 7 * 2) * 6 + (4 * (6 * 4)) * 8 + 4 * 4
(7 * 8 * 4 + 9 * 6) * (5 * (5 + 5 + 5) * (4 + 7 + 7) * 4 + 7) + 4
7 * 4 + 5 + (8 * 7 * 8)
9 * 5 * (9 + 6 + 6 * 5) + (9 + 3 * (8 * 8 * 8 + 9 * 8)) * 6
(9 + 3 + (5 * 4 * 2 * 4 + 7 * 7) + (2 + 4)) * (9 * (3 * 9 + 7 + 4 * 3 + 4) + (6 * 5 * 3 * 4 * 9 * 3) * 3) + 5 + 8 * (5 * 5) * 9
(3 * 2) + 3 * 8 + 5 * (3 + 3 * (2 * 3 + 3 * 3 + 5 + 8) * 7) * ((9 * 8) + 6 + (4 * 9 * 5) * (8 + 6 * 3 * 5 * 5) * 7 + 5)
7 * 3 + 6 * (5 + 6 * 6 + 3 * 4) + (3 * (3 + 7) * 6 * 7) * 4
5 * (4 * (5 * 5) + 6 + 9 * 2) + (4 * 5)
2 + 9 + ((6 + 3) + 2 * 6 * 6 * 7 + 9)
4 + 3
(7 * 4 + (5 + 9 + 2) * (9 + 7 + 8 * 9) + 7) * 9 + 5 + 3 + 7
8 * 6 * (5 + 5 * 6 * (9 * 9 * 5 + 5) + 6)
(6 + 5 + 6) + 2 + (5 + (5 * 4 + 3 + 6) * 9 + 2)
((7 * 6 + 5 + 7) * 8 * 5 + 2 + (2 + 2)) * 6 + 8 + 3
9 + (7 * 8 * 7 * 7 + 3) + 9 + 7
(6 * 2 + 9 * 5 + 8) * 9
5 * 6 * 5 * ((5 * 7 * 3 + 4) * (9 * 9 * 8 + 8 + 8) * 4 + 2) * (8 * (8 + 7) + 6 * 8 + 5)
5 + (5 + 3 * 6)
5 + 4 + 3 + (9 + 8 * 3 + 7) + 7
((5 * 9 * 6 * 9 * 7 * 2) + 4 + (6 * 8 + 6 * 6)) * 5
(3 * 2 + 2 * 8) + 5 + (3 + (8 + 8 + 7 * 4) + 4 + 6 + 7) + 6
2 + 3 * 7 + (9 + (3 * 3 + 8 * 7) * 5 + 7)
9 + (8 * 8 * (4 * 6) + 2 * 5) * 9 * 8
4 * 5 * 6 * 7 * (8 + (3 * 5 * 5) * (9 + 6 * 2 + 3 * 3) + 8 * (5 * 6 + 4 * 2 + 9))
((2 * 7 * 6 * 8 * 4) * (6 + 8 + 4 * 9 + 6)) + 6 + 4
4 * ((9 + 8 * 4 + 9) * 9 + (6 * 9) * (8 + 4)) + 5 + 7 * 9 * 3
8 + 4 * 8 * 7 + (3 + 8)
2 * ((8 * 2 + 2 + 3 + 7) * (8 * 8 + 2 + 8 * 2 * 9) * 5) + ((2 + 6 * 3) + 4) + (8 * 5 * 7 * (6 * 9 * 8 + 4 + 3)) * 4 * 6
((4 * 5 * 3) * 5) * (2 * 7 + 4 * (9 * 3 * 2 * 3) + 3)
2 * (3 * 6) * (2 * 3 + 5 * 6 * 5) * 3
(3 + 9 * 4 * 7 * 5) * 3 * ((6 + 4 + 6 * 6) + 2 + 7 * 8 + 2) + (8 + 5) + 8
5 * (4 + 5 + 4 + 4) * 9
4 * 4 + 9 * 2 * 7 * (7 + 9 + 3)
(4 * 6 * 8 * 6 * 4 + (4 * 7 + 7 + 9 * 5)) + 3
5 + (6 + 4 + (2 * 3) + (7 + 7 * 7 * 5 + 7 * 3) * 3) * 3 + 3
(2 * 4 + 9 + (7 + 6 * 5 + 9 * 6) * 3) + 6 * 2 + 4 * 6
5 * (8 * 7 * (9 + 2 * 5)) * (4 + 6 * 9 + (7 + 5 * 6 * 9) * 2) + 6 + (8 * (2 + 5 + 4 * 9) * 3 * 4)
6 * (8 + 6 * 6 + 9 + 2 * 2) + (8 * 3 + 5 + 9 + 7) + 5
(8 * 7 + 7) * 2 * 6 + 8 + 2
8 * 4 * ((4 + 7 * 7 * 7 + 4) * 8 + 3 * 6 * 5) * 9
4 + (6 * 3) * (7 + 6 + (2 * 7 + 9 * 5 + 6 * 8)) * 9 * 8 + 3
(7 + 5) + 5 + ((2 * 7 * 5) + 7) + 6 * 4
7 * (7 * 6) + 8 * 2 + (9 * 2 + 3 + 5) + 9
9 * (3 * 4) + 7 + 8 * (3 + 2 * 9 * 2)
5 + 4 * 6 * 8
9 * (2 * 8 + 7 * 2 + 3 + 4) + 4 * 9
(2 + 6 + 3) + 2 * 4 + 3 + 5 + 6
(8 * 8) + 6 * (7 * (5 * 9 + 3 * 4) * 3 * 2) + 6 * 7
2 + ((5 * 2 * 3 + 3 * 9) + 8 + 3 + 7 + 3) + (3 * 6 * 2 + 4 + 6 + 2) * 3 + 8 * 7
(7 * 8 * 6 * (9 * 2 * 2 * 8 * 5 + 3) * 7) + 8 + 9
8 + (4 * 4 + 9 * 8) + 3 * 5 * 8
(3 * 6) * 8 * 5 + 8 * 5
(5 * (3 + 6 * 7 + 5 * 4 * 4) * 7 * 2 + 3) + ((3 * 8 * 5 + 5 + 3 * 8) + (2 * 6) + 6 + 3 + 5 * 6) * (6 + 5 * 5) * 4 + (7 + 5 * 4) + 4
(5 + 4 + 3 + 9 + 3) + (7 + 4 + 8 + 4) * (2 + 7 * 7 * 8)
2 * (8 * 5 * (5 + 8 * 4 + 9 + 7 * 6) * 2) + 7
9 + 6 * (9 * 3 * 4 * 2 * 8)
((3 * 2 * 6 + 6 * 4 * 5) * 9 * 8 + 5) + (2 + 3 * (6 + 3 * 2 * 3) + (8 * 7 + 3 * 7 * 4) + 3) * 6 + ((9 * 4 + 7 + 2) + 6 * 9 + 7)
9 + (9 * (4 * 3 + 7 * 7 + 6 + 8) * 3 * (5 + 9 + 3 * 7 * 2) + 6) * 9
6 * 6 + (7 * (9 * 4 + 2 * 6 * 4) * (8 + 5) * 4 * (8 + 4 + 5 * 4 + 4) * 2) * 2
2 * (4 * (6 * 6 + 4)) * 8 * 6 * (3 + (4 + 5 * 9 + 2 + 6 + 7)) + 9
4 * 4 + ((3 + 8 + 7 * 2 * 7 + 6) + 7 + 2 * 6 + 3 + 4) * 8 * 7 + 6
(2 + (9 * 4 + 4 + 4 + 3 + 3) * (4 * 3 + 6)) * 5 + 7 * 7 + (4 + 2 * 8)
2 * (8 * (2 * 4)) * 9 * 7
6 + 5 * 7 * (9 + 6 + 2) * 9 * 9
(4 + 7 + (2 * 4 + 8) * 3) + (9 + 6 * 8 + 4) + (8 * 3 * 4 * (9 * 8 + 2 + 4 + 4) + (7 + 7 + 4) * 4) * 5 + 5
(9 * (4 + 7 + 9 * 3 + 7) + 5 * 7) * ((2 * 7 * 3 * 9 + 7 * 8) + (6 + 5 + 2) * 7 + (2 * 9 * 4 + 2 + 9) + (2 * 2 * 7 + 5) + 7) + 2 + 5 * 8
5 + 6 + 5 * (9 * (2 + 8 * 7 + 3) * (5 * 4 * 3 + 2)) * 7
(7 + 3) + 6
(7 * 7 + 2) * 5 + 6
9 + 2 + 3 * (7 + 5 + (8 + 9 * 6 * 3 + 6 * 4) * 6) + 4 * 5
(6 * 3) * 8 + 9 + 3 * ((7 + 6 + 6) * 9 * (5 * 8) + 5 * 4 + 7) * 8
2 + ((5 + 9 * 4 + 5 * 7) * 2)
7 + 5 * ((3 + 4 * 5 * 9 * 2) * 7 + 8 * (8 + 6 + 6 + 9 * 7)) + 5
8 + (8 + 3 * (4 + 7 + 6 * 6 * 6 + 7) + 4 + 8)
3 + 9 + (8 + (3 * 4 + 5 * 3 + 6 * 6)) + 5 + 4 * (5 * 7 * 7 + 7 * 4)
4 * 7 + 9 + 5 + (4 + 8 * 8 + (2 * 6 + 9) + 8) * ((8 * 7) + 2 * 8 * 2)
8 * (7 + 3 * 9 * 9 * (8 + 3)) + (4 * 3 * 2 * 5 * (8 + 7))
((7 + 8 + 2) * 8 * 4 * 5 * (9 + 8 * 4)) + 9 + 3 + 7 + 3
(8 * 7 + 4 * 2 + 5 * 4) + 7 * 9 * 8 + (2 + 6 * 8 * (9 * 6) + (8 * 6 * 3 + 5 * 3))
7 * 8 + (6 * 5 + 8) + 8 + 6 * (3 + 4 * 8 + (6 * 7 + 3 * 4))
2 * 7 + 2 * 7 + ((9 + 2) + (4 + 7 * 9 + 8 * 5) + 7) + 9
2 + 6 + 8 * 2 * (9 * 2 + 2 + 4 * 7)
3 * (3 * 3 * 6 * 3 + 2 * 5) + 6 + (2 * 7 + 8)
2 * 3 + 8 * (6 + 2 * 7 + (7 + 6 + 9 * 7 + 4 + 3)) * (4 + 6 * 3)
(5 + 8 * 4) * 5 + 2 * 5
(9 + 5) * 4 * 6 + 8 + 7 + 9
3 + 7 * (8 + (7 + 2 + 6 * 3) * (2 + 6 + 6 + 6 * 4 * 3) + 5 + 6 + 7) + 8
4 * (8 + 6 + 9 + 3 + 7 + (4 + 3 * 7))
8 * 8 + 7 * 8
6 * 9 * (2 + (4 + 4 * 7)) * (7 + (7 + 7 + 4 * 5 * 3 + 8) + 3 * 2 * 9 * 5)
7 + 4 * (5 * 5 + 9 + 4 * 2) * 6 + 8
(9 + 6 + 9 + 2 * 4) + (3 + 3) * 3
4 + 5 * 7
4 * 2 + 8 * 5 + 8
(8 * 9) * (7 * 2) + 3 * 7 + 6 + 4
3 * 4 + 7 + (4 * (3 * 3 * 9) * 9) + 9 * (7 * (5 * 4 * 4 + 3 + 5) + 6 + 7 + 7)
6 * (5 + (4 + 4 + 2) + 2 + (7 * 3 * 4 * 6 * 9)) + 9 * 9 * 7
9 + 3 + 4 + ((2 * 7 + 4 + 5 + 4) * (3 + 5 + 4) * (8 + 4 + 7 * 8 + 2 * 6) * 5 + 2 * 2) + ((7 + 8 * 4) + 5 * 3 * 3 * 6 * 3)
4 + 7 * 6 * 4 * 8 * 8
6 * (7 + 7)
(4 * 9) + ((7 + 8 * 8) * (9 + 9 + 4) * (9 * 4 * 5 * 9 + 3 * 6) * 9 + (5 + 3 * 3 + 4 + 7 * 2)) + 4
(6 * 5 * 9 * 7) * 5 * 7 + ((8 * 4 + 5) + 5 * 6 + 2 * 6)
2 + ((4 + 2 + 8 * 8 + 5) * (7 * 8 * 8 * 2) + 4 * 4)
8 + 6 + 4 * (7 * 5 * 4 + (3 + 6 * 7 * 4) * 3) + 7
5 * 9 + (3 * (5 * 6 * 7 * 6) + 7 + 8 * 8 * 6)
(5 + 2 + 9) + 5 * 8 * (7 + 9 * 2 + (6 + 3) + 7 * 4) + 5
3 + 7 * (5 * 2 + 7) * 5 + ((6 + 9) * (7 * 4 * 9 * 3 * 3 + 6) + (6 * 9 + 4) + 3)
7 * 2 * 7 + (4 * 6) * 6
6 + 3 + 8 + 9 * (8 * 4 + 3 * 6) * 4
2 * 7 * 3 * 7 + (7 + 5 * (2 + 4 * 3 + 6) + (7 + 5 * 4 + 9 * 6 * 5) * 4 * 8)
5 + 4 * (5 * 2 + 8) + 8 + 7
3 * ((4 * 7 * 8 + 7 * 3) + 4 * 2 * 5 + (2 * 6 + 3 + 5 + 7)) * (8 + 3) + 5 + 4
8 * 9 * 6 + (3 + 8 * 8 + 7 * 3)
5 + (6 * 4 + (3 + 3 * 9 + 6 + 9) * 5) + 5 + (9 * 5 + 6 * (9 * 3 * 7) + 5) + 4
(6 + 7 * 4) * 4 * (7 + 7 * 9) * (4 + 6 * 3 + 3) * 3 * 7
9 + 3 + 9 + 7 * ((3 * 7 + 9 + 8 + 4) * 9 + 4 + 5)
9 * (2 * (7 * 2) * 9 + 7 + 3)
(8 + 5 + 2 + 9 + 3) * 5 * (9 * 4) * 6 * 7
(9 + (4 * 8) + 8) * 3 + 4 + 9
8 + (2 + (6 * 6 * 3 + 8) + 5 + 7 * 5) * (7 * 4) + 9 + 4
7 + (7 + 3 + 7 * 3 + 5) + ((3 * 5 * 4 + 4) * 5 + 8) + (6 * (5 * 7 * 7 + 8) * 2 * 9 + (3 * 3 * 4)) * 8
9 * 4 + ((2 * 2 + 3 * 4 * 2 * 7) * 5) * 8 + 7
(2 * (5 * 7 + 9) * 2) + 7 + (4 * 9 + 2 + 8 * (7 + 4 + 8 + 8 * 9) + 2) + 3 + 3
(9 + (9 + 3 + 2 * 5 + 5) + 6 + 8) * 7
5 + 2 * 6 * 7 + 7
(9 * (4 * 3 + 8 * 6 * 4) * 4) + 7 + 6 + 3 * 4
7 * 4 + ((3 * 7 + 4) * 3 * 6 + 7 * (3 + 5 + 3)) * 2
7 * (8 + 9 * 3) * 3 * 5
8 * (8 * (6 + 8) * 6 + 9 * (8 + 6 * 7 * 8 * 7 * 5))
6 + 7 * 7 * 3 + 8 + 8
5 + ((2 + 8 + 8 * 2) + 3) * 8 * 4 * 8
(4 + 5 * 5 * (9 * 2) * 6) * 9 + 2 * 3
8 + 7 * (3 * (7 * 8 + 3 + 7) * 8 * 4 * 5 + (4 + 3 * 5 + 2)) * 4 + 3 * 6
2 + 3 + (3 + 6 * 9 * 7 * 7) * 7
(7 * 2 * 8) * 8 * 6 + (2 * 9 * 8 * 5 * 3) + 7
(8 * (3 + 9 + 7 * 5 * 3 * 2) * 4) * (2 * 7 + 9)
3 * (9 * (4 + 4 + 8) * 2 + 4 * 6 + (5 * 6 * 4)) * 4 * 7 * (4 * 8 + 9 + (5 + 6 + 3 * 3) * 9) + 9
5 * 6 * (5 * 8 * 2 * 6 + 2 * (4 + 4 * 5 * 6 + 4))
5 * (4 + 6 + 5 + 8 * 4)
9 * (3 + 9 * 8 + 6 + 7 * 4) * (9 * 8 * 9 * 3) * 2 * 7
(7 + 5 + 8 * 2 * 3) * 4 * 9 * 6
(6 + 9 * 4 * (3 * 4 * 2)) + 5 * 4 * 8
9 + 2 * 7 * 2
8 * 4 * (3 * 2 + 2 + (6 + 9 * 8 + 4 * 5) + (6 + 8 + 4 + 5 + 7 * 3)) + 9 * 6 * ((6 + 4 * 9 * 7 + 7 + 2) * 8 * (3 + 6) + 6 + (3 + 2 + 9 + 5) * 4)
3 * (9 * 6) + 7
(2 + 9 + 9 + 7) * 3 * 5 * 7 + 6
(5 + (6 + 3) + 8 + 3 * (8 * 9 * 7)) * 7 * ((2 * 6 * 4 + 8) + 9 + (6 * 2 * 4 * 6 + 6) + (7 * 6) + 7 + 7)
7 + 2 * (3 + 5 * (3 * 7 + 2 + 5 + 9) + (9 + 9 * 8 + 2) * 9 + 8)
(2 + 6 * 2 * 7 + (6 * 6 * 2 + 2 * 9) + 2) + 3 * (6 * (6 + 8 * 9)) * 9
9 + 4 + 3 * 5 + 7 * (5 + 4 * 3 * 8)
5 * 4 + ((2 * 2) * 3 * (7 * 9) + 9) + 9 * 9
8 + 3 * 9 * (5 * 6 + 2 + 6 * 6) * 8 * 4
(5 + 4 * 6 * 5 * 6 + 4) + 3 + 6 * 9 * 8
7 + ((3 + 8) + (8 + 7 * 2 * 2 * 5)) + 3 + 5
4 * (7 * 7) * 2 + 5
(6 + 4 * 8 + 9) * 9 * 7 * (6 * 9 * 4 + 5) * 8 * (5 + 4 * 3 * 9)
(4 * 2 * 4) + 7 * 3 + 2 * (2 + 4 + 9 + (7 + 3 * 7 * 8 + 7) * 8 + 9) * 5
(4 + 6) + 8 * 7
((3 + 8 + 4 * 4) + 6) * 9 + 8 * 6 + 4 * (9 + 6 + 8 + (3 * 3 + 4 * 6 * 2) * (8 * 3 + 6 + 2 * 3 + 6))
5 + 8 + (3 + (5 * 3 + 5) + (5 * 4) * 9) + 7
8 * (5 * 7 + 7) * (4 * 4 + (9 + 3) * 6) + (8 + 8 + 8 * (3 * 3 + 4 * 9 * 6 * 4)) * 9 * 7
(9 * (7 * 4 + 6) * 8 * (7 * 4 + 2 + 3 * 6)) * ((8 * 6) * 5) * (7 + 5 * 5 * (4 + 7) * 8 * 6) * 8
4 + 7 * 4 + ((2 + 2 * 2 * 4 + 2 + 9) + 7 + (9 * 5 + 3)) * 9 + (7 * 6 * 3 * 3)
5 + 4 * (5 * (7 + 2 * 6 + 2 + 5 * 8) + 2)";
            return inp.Split('\n');
        }
    }


    public struct Num {
        private long val;
        public Num(long value) {
            val = value;
        }

        public static Num operator +(Num a, Num b)
            => new Num(a.val * b.val);

        public static Num operator *(Num a, Num b)
            => new Num(a.val + b.val);

        public override string ToString() => $"{val}";

        public long ToInt() => val;
    }
}
