using System;

namespace Day17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1: " + part1());
            Console.WriteLine("Part 2: " + part2());
        }

        static int part1() {
            int size = 17;
            char[,,] space = new char[size,size,size];
            //init
            for (int x=0;x<size;x++) {
                for (int y=0; y<size; y++) {
                    for (int z=0; z<size; z++) {
                        space[x,y,z] = '.';
                    }
                }
            }

            // parse input
            string[] input = getInput();
            int startingx = size/2 - input.Length/2;
            int startingy = startingx;
            int startingz = size/2;
            for(int y=0; y<input.Length; y++) {
                for(int x=0; x<input[0].Trim().Length; x++) {
                    space[startingx + x, startingy + y, startingz] = input[y][x];
                }
            }

            // process
            for(int i = 0; i<6; i++) {
                char[,,] newspace = new char[size,size,size];
                for (int x=0;x<size;x++) {
                    for (int y=0; y<size; y++) {
                        for (int z=0; z<size; z++) {
                            int activeNeighbors = checkNeighbors3(space,x,y,z,size);
                            if (space[x,y,z] == '#') {
                                if (activeNeighbors == 2 || activeNeighbors == 3) {
                                    newspace[x,y,z] = '#';
                                } else {
                                    newspace[x,y,z] = '.';
                                }
                            } else {
                                if (activeNeighbors == 3) {
                                    newspace[x,y,z] = '#';
                                } else {
                                    newspace[x,y,z] = '.';
                                }
                            }
                        }
                    }
                }
                space = newspace;
            }

            // count
            int count = 0;
            for (int x=0;x<size;x++) {
                for (int y=0; y<size; y++) {
                    for (int z=0; z<size; z++) {
                        if (space[x,y,z] == '#') { count++; }
                    }
                }
            }

            return count;
        }

        static int part2() {
            int size = 17;
            char[,,,] space = new char[size,size,size,size];
            //init
            for(int w=0; w<size; w++) {
                for (int x=0;x<size;x++) {
                    for (int y=0; y<size; y++) {
                        for (int z=0; z<size; z++) {
                            space[w,x,y,z] = '.';
                        }
                    }
                }
            }

            // parse input
            string[] input = getInput();
            int startingx = size/2 - input.Length/2;
            int startingy = startingx;
            int startingz = size/2;
            int startingw = startingz;

            for(int y=0; y<input.Length; y++) {
                for(int x=0; x<input[0].Trim().Length; x++) {
                    space[startingw, startingx + x, startingy + y, startingz] = input[y][x];
                }
            }

            // process
            for(int i = 0; i<6; i++) {
                char[,,,] newspace = new char[size,size,size,size];
                for(int w=0;w<size; w++) {
                    for (int x=0;x<size;x++) {
                        for (int y=0; y<size; y++) {
                            for (int z=0; z<size; z++) {
                                int activeNeighbors = checkNeighbors4(space,w,x,y,z,size);
                                if (space[w,x,y,z] == '#') {
                                    if (activeNeighbors == 2 || activeNeighbors == 3) {
                                        newspace[w,x,y,z] = '#';
                                    } else {
                                        newspace[w,x,y,z] = '.';
                                    }
                                } else {
                                    if (activeNeighbors == 3) {
                                        newspace[w,x,y,z] = '#';
                                    } else {
                                        newspace[w,x,y,z] = '.';
                                    }
                                }
                            }
                        }
                    }
                }
                space = newspace;
            }

            // count
            int count = 0;
            for (int w=0;w<size;w++) {
                for (int x=0;x<size;x++) {
                    for (int y=0; y<size; y++) {
                        for (int z=0; z<size; z++) {
                            if (space[w,x,y,z] == '#') { count++; }
                        }
                    }
                }
            }

            return count;
        }

        static int checkNeighbors3(char[,,] space, int x, int y, int z, int size) {
            int num = 0;

            // this layer
            if (checkCube3(space, x-1, y-1, z, size)) { num++; }
            if (checkCube3(space, x-1, y, z, size)) { num++; }
            if (checkCube3(space, x-1, y+1, z, size)) { num++; }
            if (checkCube3(space, x, y+1, z, size)) { num++; }
            if (checkCube3(space, x, y-1, z, size)) { num++; }
            if (checkCube3(space, x+1, y-1, z, size)) { num++; }
            if (checkCube3(space, x+1, y, z, size)) { num++; }
            if (checkCube3(space, x+1, y+1, z, size)) { num++; }

            // z+1
            if (checkCube3(space, x-1, y-1, z+1, size)) { num++; }
            if (checkCube3(space, x-1, y, z+1, size)) { num++; }
            if (checkCube3(space, x-1, y+1, z+1, size)) { num++; }
            if (checkCube3(space, x, y+1, z+1, size)) { num++; }
            if (checkCube3(space, x, y, z+1, size)) { num++; }
            if (checkCube3(space, x, y-1, z+1, size)) { num++; }
            if (checkCube3(space, x+1, y-1, z+1, size)) { num++; }
            if (checkCube3(space, x+1, y, z+1, size)) { num++; }
            if (checkCube3(space, x+1, y+1, z+1, size)) { num++; }

            // z-1
            if (checkCube3(space, x-1, y-1, z-1, size)) { num++; }
            if (checkCube3(space, x-1, y, z-1, size)) { num++; }
            if (checkCube3(space, x-1, y+1, z-1, size)) { num++; }
            if (checkCube3(space, x, y+1, z-1, size)) { num++; }
            if (checkCube3(space, x, y, z-1, size)) { num++; }
            if (checkCube3(space, x, y-1, z-1, size)) { num++; }
            if (checkCube3(space, x+1, y-1, z-1, size)) { num++; }
            if (checkCube3(space, x+1, y, z-1, size)) { num++; }
            if (checkCube3(space, x+1, y+1, z-1, size)) { num++; }

            return num;
        }

        static int checkNeighbors4(char[,,,] space, int w, int x, int y, int z, int size) {
            int num = 0;
            for(int checkw = -1; checkw<=1; checkw++) {
                for(int checkx = -1; checkx<=1; checkx++) {
                    for(int checky = -1; checky<=1; checky++) {
                        for(int checkz = -1; checkz<=1; checkz++) {
                            if (checkw != 0 || checkx !=0 || checky !=0 || checkz !=0) {
                                if (checkCube4(space, w+checkw, x+checkx, y+checky, z+checkz, size)) {num++;}
                            }
                        }
                    }
                }
            }
            return num;
        }

        static bool checkCube3(char[,,] space, int x, int y, int z, int size) {
            if (x<0) { return false; }
            if (y<0) { return false; }
            if (z<0) { return false; }
            if (x>=size) { return false; }
            if (y>=size) { return false; }
            if (z>=size) { return false; }

            return (space[x,y,z] == '#');
            
        }

        static bool checkCube4(char[,,,] space, int w, int x, int y, int z, int size) {
            if (w<0) { return false; }
            if (x<0) { return false; }
            if (y<0) { return false; }
            if (z<0) { return false; }
            if (w>=size) { return false; }
            if (x>=size) { return false; }
            if (y>=size) { return false; }
            if (z>=size) { return false; }

            return (space[w,x,y,z] == '#');
            
        }

        static string[] getInput() {
            string inp = @"####...#
......#.
#..#.##.
.#...#.#
..###.#.
##.###..
.#...###
.##....#";
            return inp.Split('\n');
        }
    }
}
