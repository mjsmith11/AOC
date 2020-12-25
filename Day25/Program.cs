using System;

namespace Day25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1: " + part1());
        }
        static long part1() {
            // try to find the loop size
            long target = 5290733; // first input
            long value = 1;
            long subject = 7;
            int loops = 0;
            while(value != target) {
                value = value * subject;
                value = value % 20201227;
                loops++;
            }

            // transform the other key
            subject = 15231938; // input 2
            value = 1;
            for(int i=0; i< loops; i++) {
                value = value * subject;
                value = value % 20201227;
            }
            return value;
        }
    }
}
