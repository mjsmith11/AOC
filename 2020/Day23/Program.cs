using System;
using System.Collections.Generic;

namespace Day23
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Part 1: " + part1("963275481"));
            Console.WriteLine("Part 2: " + part2("389125467"));
        }

        static string part1(string input) {
            List<int> cups = new List<int>();
            for(int i=0; i<input.Length; i++) {
                cups.Add(int.Parse(input.Substring(i,1)));
            }
            int current = 0;
            for(int i=0; i<100; i++) {
                int currentLabel = cups[current];

                // pick up 3 cups
                int myIndex = getNextIndex(current);
                // take the cup at myIndex 3 times b/c when you remove it, everything shifts up
                int myCup1 = cups[myIndex];
                cups.RemoveAt(myIndex);
                if(myIndex == 8) { myIndex = 0; } //check if we need to wrap.  There are now 8 cups
                int myCup2 = cups[myIndex];
                cups.RemoveAt(myIndex);
                if(myIndex == 7) { myIndex = 0; } //check if we need to wrap.  There are now 7 cups
                int myCup3 = cups[myIndex];
                cups.RemoveAt(myIndex);

                // pick destination
                int destination = -1;
                int desiredLabel = currentLabel - 1;
                if (desiredLabel<1) {desiredLabel += 9; }
                while (destination == -1) {
                    destination = cups.IndexOf(desiredLabel);
                    desiredLabel--;
                    if (desiredLabel<1) {desiredLabel += 9; }
                }

                cups.Insert(destination + 1, myCup1);
                cups.Insert(destination + 2, myCup2);
                cups.Insert(destination + 3, myCup3);

                // find the current cup again in case it moved
                current = cups.IndexOf(currentLabel);
                //pick the new current
                current = getNextIndex(current);
            }
            string answer = "";
            //find 1
            int index = cups.IndexOf(1);
            int origIndex = index;
            index = getNextIndex(index);
            while(index != origIndex) {
                answer += cups[index];
                index = getNextIndex(index);
            }

            return answer;
        }

        static int getNextIndex(int currentIndex) {
            currentIndex++;
            if (currentIndex>8) {currentIndex -= 9; }
            return currentIndex;
        }

        static long part2(string input) {
            List<int> cups = new List<int>();
            for(int i=0; i<input.Length; i++) {
                cups.Add(int.Parse(input.Substring(i,1)));
            }
            for(int i=10; i<=1000000; i++) {
                cups.Add(i);
            }
            int current = 0;
            for(int i=0; i<10000000; i++) {
                Console.WriteLine(i);
                int currentLabel = cups[current];

                // pick up 3 cups
                int myIndex = getNextIndex2(current);
                // take the cup at myIndex 3 times b/c when you remove it, everything shifts up
                int myCup1 = cups[myIndex];
                cups.RemoveAt(myIndex);
                if(myIndex == 999999) { myIndex = 0; } //check if we need to wrap.  There are now 999999 cups
                int myCup2 = cups[myIndex];
                cups.RemoveAt(myIndex);
                if(myIndex == 999998) { myIndex = 0; } //check if we need to wrap.  There are now 999998 cups
                int myCup3 = cups[myIndex];
                cups.RemoveAt(myIndex);

                // pick destination
                int destination = -1;
                int desiredLabel = currentLabel - 1;
                if (desiredLabel<1) {desiredLabel += 1000000; }
                while (destination == -1) {
                    destination = cups.IndexOf(desiredLabel);
                    desiredLabel--;
                    if (desiredLabel<1) {desiredLabel += 1000000; }
                }

                cups.Insert(destination + 1, myCup1);
                cups.Insert(destination + 2, myCup2);
                cups.Insert(destination + 3, myCup3);

                // find the current cup again in case it moved
                current = cups.IndexOf(currentLabel);
                //pick the new current
                current = getNextIndex2(current);
            }
            
            //find 1
            int index = cups.IndexOf(1);
            int next1 = getNextIndex2(index);
            int next2 = getNextIndex2(next1);

            return (long)cups[next1] * (long)cups[next2];
        }

        static int getNextIndex2(int currentIndex) {
            currentIndex++;
            if (currentIndex>999999) {currentIndex -= 1000000; }
            return currentIndex;
        }
    }
}
