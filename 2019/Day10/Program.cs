using System;
﻿using System.Collections.Generic;
﻿using System.Linq;

namespace Day10
{
    class Program
    {
        static double calcSlope(int x1, int x2, int y1, int y2) {
            return ((double)(y2-y1))/(x2-x1);
        }
        static void Main(string[] args)
        {
            string input = @"....#...####.#.#...........#........
#####..#.#.#......#####...#.#...#...
##.##..#.#.#.....#.....##.#.#..#....
...#..#...#.##........#..#.......#.#
#...##...###...###..#...#.....#.....
##.......#.....#.........#.#....#.#.
..#...#.##.##.....#....##..#......#.
..###..##..#..#...#......##...#....#
##..##.....#...#.#...#......#.#.#..#
...###....#..#.#......#...#.......#.
#....#...##.......#..#.......#..#...
#...........#.....#.....#.#...#.##.#
###..#....####..#.###...#....#..#...
##....#.#..#.#......##.......#....#.
..#.#....#.#.#..#...#.##.##..#......
...#.....#......#.#.#.##.....#..###.
..#.#.###.......#..#.#....##.....#..
.#.#.#...#..#.#..##.#..........#...#
.....#.#.#...#..#..#...###.#...#.#..
#..#..#.....#.##..##...##.#.....#...
....##....#.##...#..........#.##....
...#....###.#...##........##.##..##.
#..#....#......#......###...........
##...#..#.##.##..##....#..#..##..#.#
.#....#..##.....#.#............##...
.###.........#....#.##.#..#.#..#.#..
#...#..#...#.#.#.....#....#......###
#...........##.#....#.##......#.#..#
....#...#..#...#.####...#.#..#.##...
......####.....#..#....#....#....#.#
.##.#..###..####...#.......#.#....#.
#.###....#....#..........#.....###.#
...#......#....##...##..#..#...###..
..#...###.###.........#.#..#.#..#...
.#.#.............#.#....#...........
..#...#.###...##....##.#.#.#....#.#.";
            string[] lines = input.Split('\n');
            char[,] map = new char[lines.Length, lines.Length];
            for(int y=0; y<lines.Length; y++) {
                string line = lines[y].Trim();
                for(int x=0; x<line.Length; x++) {
                    map[x,y] = line[x];
                }
            }
            int maxDetected = 0;
            int bestBaseX = 0;
            int bestBaseY = 0;
            // loop over grid and check each asteroid
            for(int baseY=0; baseY<lines.Length; baseY++){
                for(int baseX=0; baseX<lines.Length; baseX++) {
                    if(map[baseX,baseY]=='.') { continue; }  // only check asteroids
                    Dictionary<double, bool> slopesBiggerX = new Dictionary<double, bool>(); // the number of unique slopes is the number of asteroids we can see
                    Dictionary<double, bool> slopesSmallerX = new Dictionary<double, bool>();
                    bool sawUndefinedUp = false;
                    bool sawUndefinedDown = false;
                    for (int otherY=0; otherY<lines.Length; otherY++) {
                        for(int otherX=0; otherX<lines.Length; otherX++){
                            if(map[otherX,otherY]=='.') { continue; } // only check asteroids
                            if(baseX == otherX){
                                if (baseY == otherY) { continue; } // same place
                                else {
                                    // undefined slope;
                                    if(otherY<baseY) { sawUndefinedUp = true;}
                                    else { sawUndefinedDown = true;}
                                }
                            } else {
                                double slope = calcSlope(baseX, otherX, baseY, otherY);
                                if(otherX>baseX) { slopesBiggerX[slope] = true; }
                                else { slopesSmallerX[slope] = true; }
                            } 
                        }
                    }
                    int seen = slopesBiggerX.Count + slopesSmallerX.Count + (sawUndefinedDown?1:0) + (sawUndefinedUp?1:0);
                    if (seen>maxDetected) { 
                        maxDetected = seen; 
                        bestBaseX = baseX;
                        bestBaseY = baseY;
                    }
                }
            }
            Console.WriteLine("Part 1: " + maxDetected);
            
            //------Part 2-------------
            SortedList<int, Asteroid> undefinedUp = new SortedList<int, Asteroid>(); // asteroids directly above me sorted from closest to furthest
            SortedList<int, Asteroid> undefinedDown = new SortedList<int, Asteroid>(); // asteroids directly below me sorted from closest to furthest
            SortedList<double, SortedList<int, Asteroid>> biggerX = new SortedList<double, SortedList<int, Asteroid>>(); // asteroids on my right side sorted by slope to me ascending, then closest first
            SortedList<double, SortedList<int, Asteroid>> smallerX = new SortedList<double, SortedList<int, Asteroid>>(); // asteroids on my left side sorted by slope to me descending, then closest first
            for(int y=0; y<lines.Length; y++) {
                for(int x=0; x<lines.Length; x++) {
                    if(map[x,y]=='.') { continue; } // only check asteroids
                    if(bestBaseX == x){
                        if (bestBaseY == y) { continue; } // same place as me
                        else {
                            // undefined slope;
                            if(y<bestBaseY) { undefinedUp.Add(-y, new Asteroid(x,y,0));} // use -y as key for descending sort on y
                            else { undefinedDown.Add(y, new Asteroid(x,y,0));}
                        }
                    } else {
                        double slope = calcSlope(bestBaseX, x, bestBaseY, y);
                        if(x>bestBaseX) { insertIntoDictionary(biggerX, slope, new Asteroid(x,y,slope), x); }
                        else { insertIntoDictionary(smallerX, slope, new Asteroid(x,y,slope), -x); } // sort on -x for a descending sort
                    } 
                }
            }
            int counter = 0;
            Asteroid last = null;
            while (counter<200) {
                // starting from up rotate clockwise shooting 1 asteroid at each position
                if (undefinedUp.Count > 0) {
                    last = undefinedUp.Values[0];
                    undefinedUp.RemoveAt(0);
                    counter++;
                    if (counter==200) { break;}
                }
                foreach (KeyValuePair<double, SortedList<int, Asteroid>> kvp in biggerX) {
                    SortedList<int, Asteroid> val = kvp.Value;
                    if(val.Count > 0) {
                        last = val.Values[0];
                        val.RemoveAt(0);
                        counter++;
                        if (counter==200) { break;}
                    }
                }
                if (undefinedDown.Count > 0) {
                    last = undefinedDown.Values[0];
                    undefinedDown.RemoveAt(0);
                    counter++;
                    if (counter==200) { break;}
                }
                foreach(KeyValuePair<double, SortedList<int, Asteroid>> kvp in smallerX) {
                    SortedList<int, Asteroid> val = kvp.Value;
                    if(val.Count > 0) {
                        last = val.Values[0];
                        val.RemoveAt(0);
                        counter++;
                        if (counter==200) { break;}
                    }
                }
            }
            Console.WriteLine("Part 2: (" + last.x + ","+last.y+")");
        }
        public static void insertIntoDictionary(SortedList<double, SortedList<int, Asteroid>> d, double slope, Asteroid a, int sort)
        {
            if(d.ContainsKey(slope)) {
                d[slope].Add(sort, a);
            } else {
                SortedList<int, Asteroid> list = new SortedList<int, Asteroid>();
                list.Add(sort, a);
                d.Add(slope, list);
            }
        }
    }
}
