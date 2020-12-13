using System;
using System.Collections.Generic;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1: " + part1());
            Console.WriteLine("Part 2: " + part2());
        }

        static int part1() {
            string[] input = getInput();
            int arrival = int.Parse(input[0]);
            string[] buses = input[1].Split(',');
            int minWait = int.MaxValue;
            int minWaitBus = 0;
            foreach(string bus in buses) {
                if (bus != "x") {
                    int busId = int.Parse(bus);
                    if(arrival%busId == 0) {
                        // bus is there when we arrive
                        return 0;
                    }
                    int fullCycles = arrival/busId; // int division.  How many cycles does the bus run before we arrive
                    int nextDeparture = busId * (fullCycles + 1); //when is the first departure of this bus after we arrive
                    int wait = nextDeparture - arrival; // how long would we wait on this bus

                    if (wait<minWait) {
                        minWait = wait;
                        minWaitBus = busId;
                    }
                }
            }
            return minWaitBus * minWait;
        }


        // the idea here is that the possible timestamps for any group of buses
        // can be given by t=mx+b where x is 0,1,2,3.  Start with the first bus: m will be the
        // bus number and b will be 0.  Then add in the rest of the buses one at a time by
        // finding the first two times given by the current values of m and b that satisfy the 
        // new bus.  Then calculate new m and b using the ordered pairs (0,firstFoundTime) and (1, secondFoundTime).
        // After all buses are accounted for, b will be the lowest time that satisfies all buses (i.e. x=0).
        static long part2() {
            string input = getInput()[1];
            string[] buses = input.Split(',');
            //init stuff for the first bus
            long m = int.Parse(buses[0]);
            long b = 0;
            
            // figure in the rest of the buses
            for(int i=1; i<buses.Length; i++) {
                if (buses[i] == "x") { continue; }
                long first = 0;
                long second = 0;
                int x = 0;
                int busNum = int.Parse(buses[i]);
                while (second == 0) {
                    long time = m*x + b;
                    if ((time + i) % busNum == 0) {
                        if (first == 0) {
                            first = time;
                        } else {
                            second = time;
                        }
                    }
                    x++;
                }
                m = second - first;
                b = first;
            }
            return b;
        }

 
        static string[] getInput() {
            string inp = @"1002462
37,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,41,x,x,x,x,x,x,x,x,x,601,x,x,x,x,x,x,x,x,x,x,x,19,x,x,x,x,17,x,x,x,x,x,23,x,x,x,x,x,29,x,443,x,x,x,x,x,x,x,x,x,x,x,x,13";
            return inp.Split('\n');
        }
    }
}
