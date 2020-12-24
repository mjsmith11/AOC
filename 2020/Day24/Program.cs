using System;

namespace Day24
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1: " + part1());
            Console.WriteLine("Part 2: " + part2());
        }

        static int part1() {
            int size = 50;
            int halfSize = size/2;
            bool[,,] floor = new bool[size,size,size];
            for(int x=0;x<size;x++) {
                for(int y=0;y<size;y++) {
                    for(int z=0; z<size; z++) {
                        floor[x,y,z] = false;
                    }
                }
            }
            string[] data = getInput();
            foreach(string s in data) {
                int x = 0;
                int y = 0;
                int z = 0;
                int i = 0;
                while (i<s.Length) {
                    string instruction = "";
                    if (s[i] == 'e' || s[i] == 'w') {
                        instruction = s.Substring(i,1);
                        i++;
                    } else {
                        instruction = s.Substring(i,2);
                        i+=2;
                    }
                    if (instruction == "e") {
                        x++;
                        y--;
                    } else if (instruction == "w") {
                        x--;
                        y++;
                    } else if (instruction == "ne") {
                        x++;
                        z--;
                    } else if (instruction == "nw") {
                        y++;
                        z--;
                    } else if (instruction == "se") {
                        y--;
                        z++;
                    } else if (instruction == "sw") {
                        x--;
                        z++;
                    }
                }
                floor[x+halfSize,y+halfSize,z+halfSize] = !floor[x+halfSize,y+halfSize,z+halfSize];
            }
            int count = 0;
            for(int x=0;x<size;x++) {
                for(int y=0;y<size;y++) {
                    for(int z=0; z<size; z++) {
                        if (floor[x,y,z]) { count++; }
                    }
                }
            }
            return count;
        }

        static int part2() {
            // doing part 1 to get day 0
            int size = 141;  
            int halfSize = size/2;
            bool[,,] floor = new bool[size,size,size];
            for(int x=0;x<size;x++) {
                for(int y=0;y<size;y++) {
                    for(int z=0; z<size; z++) {
                        floor[x,y,z] = false;
                    }
                }
            }
            string[] data = getInput();
            foreach(string s in data) {
                int x = 0;
                int y = 0;
                int z = 0;
                int i = 0;
                while (i<s.Length) {
                    string instruction = "";
                    if (s[i] == 'e' || s[i] == 'w') {
                        instruction = s.Substring(i,1);
                        i++;
                    } else {
                        instruction = s.Substring(i,2);
                        i+=2;
                    }
                    if (instruction == "e") {
                        x++;
                        y--;
                    } else if (instruction == "w") {
                        x--;
                        y++;
                    } else if (instruction == "ne") {
                        x++;
                        z--;
                    } else if (instruction == "nw") {
                        y++;
                        z--;
                    } else if (instruction == "se") {
                        y--;
                        z++;
                    } else if (instruction == "sw") {
                        x--;
                        z++;
                    }
                }
                floor[x+halfSize,y+halfSize,z+halfSize] = !floor[x+halfSize,y+halfSize,z+halfSize];

            }
            for (int i=0; i<100; i++) {
                bool[,,] newFLoor = new bool[size,size,size];
                for(int x=0;x<size;x++) {
                    for(int y=0;y<size;y++) {
                        for(int z=0;z<size;z++) {
                            int black = countBlackAdj(floor,x,y,z,size);
                            if (floor[x,y,z] && (black==0 || black>2)) {
                                newFLoor[x,y,z] = false;
                            } else if (!floor[x,y,z] && black==2) {
                                newFLoor[x,y,z] = true;
                            } else {
                                newFLoor[x,y,z] = floor[x,y,z];
                            }
                        }
                    }
                }
                floor = newFLoor;
            }

            int count = 0;
            for(int x=0;x<size;x++) {
                for(int y=0;y<size;y++) {
                    for(int z=0; z<size; z++) {
                        if (floor[x,y,z]) { count++; }
                    }
                }
            }

            return count;

        }

        static int countBlackAdj(bool[,,] floor, int x, int y, int z, int size){
            int count = 0;
            if (isBlack(floor,x+1,y-1,z,size)) { count++; }
            if (isBlack(floor,x-1,y+1,z,size)) { count++; }
            if (isBlack(floor,x+1,y,z-1,size)) { count++; }
            if (isBlack(floor,x,y+1,z-1,size)) { count++; }
            if (isBlack(floor,x,y-1,z+1,size)) { count++; }
            if (isBlack(floor,x-1,y,z+1,size)) { count++; }
            return count;

        }

        static bool isBlack(bool[,,] floor, int x, int y, int z, int size) {
            if (x<0) { return false; }
            if (y<0) { return false; }
            if (z<0) { return false; }
            if (x>=size) { return false; }
            if (y>=size) { return false; }
            if (z>=size) { return false; }
            return floor[x,y,z];

        }

        static string[] getInput() {
            string input = System.IO.File.ReadAllText(@"input.txt");
            return input.Split('\n');
        }
    }
}
