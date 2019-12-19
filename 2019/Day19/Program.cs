﻿using System;

namespace Day19
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"109,424,203,1,21102,11,1,0,1106,0,282,21101,18,0,0,1106,0,259,1202,1,1,221,203,1,21101,31,0,0,1105,1,282,21101,0,38,0,1106,0,259,20101,0,23,2,22101,0,1,3,21102,1,1,1,21102,57,1,0,1105,1,303,2102,1,1,222,21002,221,1,3,21001,221,0,2,21101,0,259,1,21101,80,0,0,1106,0,225,21101,0,149,2,21101,91,0,0,1106,0,303,1202,1,1,223,21002,222,1,4,21102,1,259,3,21101,225,0,2,21101,0,225,1,21101,118,0,0,1106,0,225,21001,222,0,3,21102,1,58,2,21102,1,133,0,1106,0,303,21202,1,-1,1,22001,223,1,1,21101,148,0,0,1105,1,259,1201,1,0,223,21002,221,1,4,20102,1,222,3,21101,21,0,2,1001,132,-2,224,1002,224,2,224,1001,224,3,224,1002,132,-1,132,1,224,132,224,21001,224,1,1,21102,195,1,0,105,1,109,20207,1,223,2,20102,1,23,1,21101,0,-1,3,21102,1,214,0,1106,0,303,22101,1,1,1,204,1,99,0,0,0,0,109,5,2101,0,-4,249,22101,0,-3,1,21201,-2,0,2,22101,0,-1,3,21101,250,0,0,1106,0,225,22101,0,1,-4,109,-5,2106,0,0,109,3,22107,0,-2,-1,21202,-1,2,-1,21201,-1,-1,-1,22202,-1,-2,-2,109,-3,2105,1,0,109,3,21207,-2,0,-1,1206,-1,294,104,0,99,22101,0,-2,-2,109,-3,2106,0,0,109,5,22207,-3,-4,-1,1206,-1,346,22201,-4,-3,-4,21202,-3,-1,-1,22201,-4,-1,2,21202,2,-1,-1,22201,-4,-1,1,22101,0,-2,3,21101,0,343,0,1105,1,303,1105,1,415,22207,-2,-3,-1,1206,-1,387,22201,-3,-2,-3,21202,-2,-1,-1,22201,-3,-1,3,21202,3,-1,-1,22201,-3,-1,2,22102,1,-4,1,21102,1,384,0,1105,1,303,1105,1,415,21202,-4,-1,-4,22201,-4,-3,-4,22202,-3,-2,-2,22202,-2,-4,-4,22202,-3,-2,-3,21202,-4,-1,-2,22201,-3,-2,1,21202,1,1,-4,109,-5,2105,1,0";
            int size = 50;
            int total = 0;
            char[,] map = new char[size,size];
            for(int x=0; x<size; x++) {
                for(int y=0; y<size; y++) {
                    Computer c = new Computer(input);
                    long[] output = c.execute(new long[]{x,y});
                    if (output[0] == 1) { 
                        total++;
                        map[x,y] = '#';
                    } else {
                        map[x,y] = '.';
                    }
                }
            }
            Console.WriteLine("Part 1: " + total);
            Part2();
        }

        // Honestly dumb luck.  Slightly optimized brute force with a size of 10000 which is smaller than the true search space
        static void Part2() {
            string input = @"109,424,203,1,21102,11,1,0,1106,0,282,21101,18,0,0,1106,0,259,1202,1,1,221,203,1,21101,31,0,0,1105,1,282,21101,0,38,0,1106,0,259,20101,0,23,2,22101,0,1,3,21102,1,1,1,21102,57,1,0,1105,1,303,2102,1,1,222,21002,221,1,3,21001,221,0,2,21101,0,259,1,21101,80,0,0,1106,0,225,21101,0,149,2,21101,91,0,0,1106,0,303,1202,1,1,223,21002,222,1,4,21102,1,259,3,21101,225,0,2,21101,0,225,1,21101,118,0,0,1106,0,225,21001,222,0,3,21102,1,58,2,21102,1,133,0,1106,0,303,21202,1,-1,1,22001,223,1,1,21101,148,0,0,1105,1,259,1201,1,0,223,21002,221,1,4,20102,1,222,3,21101,21,0,2,1001,132,-2,224,1002,224,2,224,1001,224,3,224,1002,132,-1,132,1,224,132,224,21001,224,1,1,21102,195,1,0,105,1,109,20207,1,223,2,20102,1,23,1,21101,0,-1,3,21102,1,214,0,1106,0,303,22101,1,1,1,204,1,99,0,0,0,0,109,5,2101,0,-4,249,22101,0,-3,1,21201,-2,0,2,22101,0,-1,3,21101,250,0,0,1106,0,225,22101,0,1,-4,109,-5,2106,0,0,109,3,22107,0,-2,-1,21202,-1,2,-1,21201,-1,-1,-1,22202,-1,-2,-2,109,-3,2105,1,0,109,3,21207,-2,0,-1,1206,-1,294,104,0,99,22101,0,-2,-2,109,-3,2106,0,0,109,5,22207,-3,-4,-1,1206,-1,346,22201,-4,-3,-4,21202,-3,-1,-1,22201,-4,-1,2,21202,2,-1,-1,22201,-4,-1,1,22101,0,-2,3,21101,0,343,0,1105,1,303,1105,1,415,22207,-2,-3,-1,1206,-1,387,22201,-3,-2,-3,21202,-2,-1,-1,22201,-3,-1,3,21202,3,-1,-1,22201,-3,-1,2,22102,1,-4,1,21102,1,384,0,1105,1,303,1105,1,415,21202,-4,-1,-4,22201,-4,-3,-4,22202,-3,-2,-2,22202,-2,-4,-4,22202,-3,-2,-3,21202,-4,-1,-2,22201,-3,-2,1,21202,1,1,-4,109,-5,2105,1,0";
            int size = 10000;
            char[,] map = new char[size,size];
            int startY = 0; // start at the first Y that had a beam last round
            for(int x=0; x<size; x++) {
                //Console.WriteLine("Now building column " + x);
                bool gotBeamThisCol = false;
                bool setStartYThisRound = false;
                for(int y=startY; y<size; y++) {
                    Computer c = new Computer(input);
                    long[] output = c.execute(new long[]{x,y});
                    if (output[0] == 1) { 
                        map[x,y] = '#';
                        gotBeamThisCol = true;
                        if(!setStartYThisRound) {
                            startY = y;
                            setStartYThisRound = true;
                        }
                    } else {
                        map[x,y] = '.';
                        if (gotBeamThisCol) { break; } //small optimization since we've seen all of the beam in this column
                    }
                }
            }
            //Console.WriteLine("Build Done");
            // look for a block
            int searchSize = 100;
            bool found = false;
            for(int y=0; y<size; y++) {
                for(int x=0; x<size; x++) {
                    if(map[x,y] == '#') {
                        bool missed = false;
                        for(int searchX = x; searchX < (x+searchSize); searchX++) {
                            for(int searchY = y; searchY<(y+searchSize); searchY++) {
                                if(map[searchX,searchY] != '#' || searchX>=size || searchY >= size) {
                                    missed = true;
                                    break;
                                }
                            }
                            if (missed) { break; }
                        }
                        if (!missed) { 
                            //Console.WriteLine("("+x+","+y+")"); 
                            Console.WriteLine("Part 2: " + (10000*x + y));
                            found = true;
                            break;
                        }
                    }
                }
                if (found) { break; }
            }
            
        }
    }
}
