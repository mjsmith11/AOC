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
            //List<int> runningBuses = new List<int>();
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

        static long part2() {
            string input = getInput()[1];
            string[] buses = input.Split(',');
            int firstBus = int.Parse(buses[0]);
            long time = 601 + 37; //this is a hack because I know my largest bus number is 601 at t+37
            bool foundSolution = false;
            long timecheck = 1;
            while(!foundSolution) {
                if (time > timecheck) {
                    Console.WriteLine("Time exceeded " + timecheck);
                    timecheck *= 10;
                }
                //assume this time will work
                foundSolution = true;
                for(int i = 0; i<buses.Length; i++) {
                    if(buses[i] == "x") { continue; }
                    if ((time + i) % int.Parse(buses[i]) != 0) {
                        foundSolution = false;
                        break;
                    }
                }
                if (!foundSolution) {
                    time += 601; //this is a hack because I know my largest bus number is 601 at t+37
                }
            }
            return time;
        }

        static string[] getInput() {
            string inp = @"1002462
37,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,41,x,x,x,x,x,x,x,x,x,601,x,x,x,x,x,x,x,x,x,x,x,19,x,x,x,x,17,x,x,x,x,x,23,x,x,x,x,x,29,x,443,x,x,x,x,x,x,x,x,x,x,x,x,13";
            return inp.Split('\n');
        }
    }
}
