using System;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1: " + part1());
            Console.WriteLine("Part 2: " + part2());
        }


        static int part1() {
            int totalFlashes = 0;
            Octopus[,] grid = getInput();
            for(int round = 0; round<100; round++) {
                // bump every Octopus energy
                for(int x=0;x<10;x++) {
                    for(int y=0; y<10; y++) {
                        grid[x,y].energy++;
                    }
                }
                // process flashes
                int lastFlashCount = 0;
                do {
                    lastFlashCount = countFlashes(grid,false);
                    for(int x=0; x<10; x++) {
                        for(int y=0; y<10; y++) {
                            if (grid[x,y].energy > 9 && !grid[x,y].flashed) {
                                processFlash(grid,x,y);
                            }
                        }
                    }
                } while(lastFlashCount != countFlashes(grid,false));

                //reset
                int newFlashes = countFlashes(grid,true);
                /*for(int y=0; y<10; y++) {
                    for(int x=0;x<10; x++){
                        Console.Write(grid[x,y].energy);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine((round+1) + " : " + newFlashes);*/
                totalFlashes += newFlashes;
            }
            return totalFlashes;
        }

        static int part2() {
            int totalFlashes = 0;
            Octopus[,] grid = getInput();
            for(int round = 0; round<1000; round++) {
                // bump every Octopus energy
                for(int x=0;x<10;x++) {
                    for(int y=0; y<10; y++) {
                        grid[x,y].energy++;
                    }
                }
                // process flashes
                int lastFlashCount = 0;
                do {
                    lastFlashCount = countFlashes(grid,false);
                    for(int x=0; x<10; x++) {
                        for(int y=0; y<10; y++) {
                            if (grid[x,y].energy > 9 && !grid[x,y].flashed) {
                                processFlash(grid,x,y);
                            }
                        }
                    }
                } while(lastFlashCount != countFlashes(grid,false));

                //reset
                int newFlashes = countFlashes(grid,true);
                if (newFlashes==100){
                    return (round+1);
                }
                /*for(int y=0; y<10; y++) {
                    for(int x=0;x<10; x++){
                        Console.Write(grid[x,y].energy);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine((round+1) + " : " + newFlashes);*/
                totalFlashes += newFlashes;
            }
            return -1;
        }

        static int countFlashes(Octopus[,] grid, bool reset) {
            int count = 0;
            for(int x=0; x<10; x++) {
                for(int y=0; y<10; y++) {
                    if (grid[x,y].flashed) {
                        count++;
                        if (reset) { 
                            grid[x,y].flashed = false;
                            grid[x,y].energy = 0;
                        }
                    }
                }
            }
            return count;
        }

        static void processFlash(Octopus[,] grid, int x, int y) {
            grid[x,y].flashed = true;
            if (x>0) {
                // left
                grid[x-1,y].energy++;

                if (y>0) {
                    // up-left
                    grid[x-1,y-1].energy++;
                }
                if (y<9) {
                    // down-left
                    grid[x-1,y+1].energy++;
                }
            }
            if (x<9) {
                // right
                grid[x+1,y].energy++;
                if (y>0) {
                    // up-right
                    grid[x+1,y-1].energy++;
                }
                if (y<9) {
                    // down-right
                    grid[x+1,y+1].energy++;
                }
            }

            if (y>0) {
                // up
                grid[x,y-1].energy++;
            }
            if (y<9) {
                // down
                grid[x,y+1].energy++;
            }
        }

        static Octopus[,] getInput() {
            string input = @"4134384626
7114585257
1582536488
4865715538
5733423513
8532144181
1288614583
2248711141
6415871681
7881531438";
            Octopus[,] parsed = new Octopus[10,10];
            string[] splits = input.Split("\n");
            for(int x=0; x<10; x++) {
                for(int y=0; y<10; y++) {
                    int energy = Int32.Parse(splits[y].Substring(x,1));
                    parsed[x,y] = new Octopus(energy);
                }
            }
            return parsed;
        }
    }
}
