using System;
using System.Collections.Generic;

namespace Day23
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1: " + part1("963275481"));
            Console.WriteLine("Part 2: " + part2("963275481"));
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
            LinkedList<int> cups = new LinkedList<int>();
            Dictionary<int,LinkedListNode<int>> lookup = new Dictionary<int,LinkedListNode<int>>();
            for(int i=0; i<input.Length; i++) {
                cups.AddLast(int.Parse(input.Substring(i,1)));
                lookup[int.Parse(input.Substring(i,1))] = cups.Last;
            }
            for(int i=10; i<=1000000; i++) {
                cups.AddLast(i);
                lookup[i] = cups.Last;

            }
            LinkedListNode<int> current = cups.First;
            for(int i=0; i<10000000; i++) {
                int currentLabel = current.Value;

                LinkedListNode<int> cupNode1 = getNextNode(cups,current);
                LinkedListNode<int> cupNode2 = getNextNode(cups,cupNode1);
                LinkedListNode<int> cupNode3 = getNextNode(cups,cupNode2);

                int myCup1 = cupNode1.Value;
                cups.Remove(cupNode1);

                int myCup2 = cupNode2.Value;
                cups.Remove(cupNode2);

                int myCup3 =cupNode3.Value;
                cups.Remove(cupNode3);

                // pick destination
                int desiredLabel = currentLabel - 1;
                if (desiredLabel<1) {desiredLabel += 1000000; }
                while (myCup1 == desiredLabel || myCup2 == desiredLabel || myCup3 == desiredLabel) {
                    desiredLabel--;
                    if (desiredLabel<1) {desiredLabel += 1000000; }
                }
                LinkedListNode<int> destination = lookup[desiredLabel];

                cups.AddAfter(destination,cupNode1);
                cups.AddAfter(cupNode1,cupNode2);
                cups.AddAfter(cupNode2,cupNode3);

                //pick the new current
                current = getNextNode(cups,current);
            }
            
            //find 1
            LinkedListNode<int> one = cups.Find(1);
            LinkedListNode<int> next1 = one.Next;
            LinkedListNode<int> next2 = next1.Next;

            return (long)next1.Value * (long)next2.Value;
        }

        static int getNextIndex2(int currentIndex) {
            currentIndex++;
            if (currentIndex>999999) {currentIndex -= 1000000; }
            return currentIndex;
        }
        static LinkedListNode<int> getNextNode(LinkedList<int> list, LinkedListNode<int> node) {
            LinkedListNode<int> next = node.Next;
            if (next == null) { next = list.First; }
            return next;
        }
    }
}
