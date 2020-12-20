using System;

namespace Day20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1: " + part1());
            Console.WriteLine("Part 2: " + part2());
        }

        static long part1() {
            // load up input
            string[] input = getInput();
            int numTiles = input.Length/12;
            Tile[] myTiles = new Tile[numTiles];
            for(int i=0; i<numTiles; i++) {
                string[] oneTileInput = new string[11];
                for(int j=0; j<11; j++) {
                    oneTileInput[j] = input[12*i + j];
                }
                myTiles[i] = new Tile(oneTileInput);
            }

            // setup to try a recursive backtrack
            int s = (int)Math.Sqrt(numTiles);
            Tile[,] image = new Tile[s,s];
            int curx = 0;
            int cury = 0;
            solve(image,curx,cury,myTiles,s);
            
            return (long)image[0,0].number * (long)image[0,s-1].number * (long)image[s-1,0].number * (long)image[s-1,s-1].number;
        }

        static int part2() {
            // load up input
            string[] input = getInput();
            int numTiles = input.Length/12;
            Tile[] myTiles = new Tile[numTiles];
            for(int i=0; i<numTiles; i++) {
                string[] oneTileInput = new string[11];
                for(int j=0; j<11; j++) {
                    oneTileInput[j] = input[12*i + j];
                }
                myTiles[i] = new Tile(oneTileInput);
            }

            // setup to try a recursive backtrack
            int s = (int)Math.Sqrt(numTiles);
            Tile[,] image = new Tile[s,s];
            int curx = 0;
            int cury = 0;
            solve(image,curx,cury,myTiles,s);

            // stitch the tiles from part 1
            int stitchedSize = 8 * s;  // each tile will be 8x8 after removing the border
            char[,] stitchedImage = new char[stitchedSize,stitchedSize];
            for(int tx=0; tx<s; tx++) {
                for(int ty=0; ty<s; ty++) {
                    for(int x=0; x<8; x++) {
                        for(int y=0; y<8; y++) {
                            stitchedImage[x+8*tx,y+8*ty] = image[tx,ty].map[x+1,y+1]; // lhs offsetting by the current tile.  rhs offsetting by 1 to remove border
                        }
                    }
                }
            }

            bool foundMonsters = false;
            foundMonsters = checkWholeGrid(stitchedImage,stitchedSize) > 0;
            
            if (!foundMonsters) {
                stitchedImage = rotateClockwise(stitchedImage,stitchedSize);
                foundMonsters = checkWholeGrid(stitchedImage,stitchedSize) > 0;
            }

            if (!foundMonsters) {
                stitchedImage = rotateClockwise(stitchedImage,stitchedSize);
                foundMonsters = checkWholeGrid(stitchedImage,stitchedSize) > 0;
            }

            if (!foundMonsters) {
                stitchedImage = rotateClockwise(stitchedImage,stitchedSize);
                foundMonsters = checkWholeGrid(stitchedImage,stitchedSize) > 0;
            }

            if (!foundMonsters) {
                stitchedImage = rotateClockwise(stitchedImage,stitchedSize);
                stitchedImage = flip(stitchedImage,stitchedSize);
                foundMonsters = checkWholeGrid(stitchedImage,stitchedSize) > 0;
            }

            if (!foundMonsters) {
                stitchedImage = rotateClockwise(stitchedImage,stitchedSize);
                foundMonsters = checkWholeGrid(stitchedImage,stitchedSize) > 0;
            }

            if (!foundMonsters) {
                stitchedImage = rotateClockwise(stitchedImage,stitchedSize);
                foundMonsters = checkWholeGrid(stitchedImage,stitchedSize) > 0;
            }

            if (!foundMonsters) {
                stitchedImage = rotateClockwise(stitchedImage,stitchedSize);
                foundMonsters = checkWholeGrid(stitchedImage,stitchedSize) > 0;
            }

            int count = 0;
            for(int y=0; y<stitchedSize; y++){
                for(int x=0; x<stitchedSize; x++) {
                    if (stitchedImage[x,y] == '#') { count++; }
                }
            }
            
            return count;
        }

        static bool solve(Tile[,] image, int curx, int cury, Tile[] list, int size) {
            for(int j=0; j<list.Length; j++) {
                Tile t = list[j];
                if (!t.used) {
                    for(int i = 0; i<8; i++) {
                        t = getOrientation(t,i);
                        // see if it will work
                        if (check(image,t,curx,cury)) {
                            // put t in
                            t.used = true;
                            image[curx,cury] = t;

                            // was that the last piece?
                            if((curx == size-1) &&(cury == size-1)) { return true; }

                            //figure out next spot
                            int newx = curx+1;
                            int newy = cury;
                            if (newx==size) {
                                newx = 0;
                                newy++;
                            }

                            // recurse
                            if (solve(image,newx,newy,list,size)) { 
                                return true;
                            } else {
                                // take it back out and move on
                                t.used = false;
                                image[curx,cury] = null;
                            }
                        }
                    }
                }
            }
            return false;
        }

        static bool check(Tile[,] image, Tile tryTile, int tryx, int tryy) {
            // look left
            if (tryx>0) {
                //if (tryTile.leftActive != image[tryx-1,tryy].rightActive) { return false; }
                for(int i=0;i<10;i++) {
                    if (tryTile.map[0,i] != image[tryx-1,tryy].map[9,i]) { return false; }
                }
            }
            // look up
            if (tryy>0) {
                //if (tryTile.topActive != image[tryx,tryy-1].bottomActive) { return false; }
                for(int i=0;i<10;i++) {
                    if (tryTile.map[i,0] != image[tryx,tryy-1].map[i,9]) { return false; }
                }
            }
            return true;
        }

        static Tile getOrientation(Tile t, int orientation) {
            // there are 8 identified orientations and this method is intended to return the tile in an
            // orientation identified by an integer given that it gets the tile in the previous orientation.
            // 0-original
            // 1-90 degrees clockwise
            // 2-180 degrees clockwise
            // 3-270 degrees clockwise
            // 4-flip horizontal
            // 5-flip H + 90 degrees clockwise
            // 6-flip H + 180 degrees clockwise
            // 7-flip H + 270 degrees clockwise
            // 8-reset
            if ((orientation >=1) && (orientation<=3)) {
                t.clockwiseRotate();
            } 
            if (orientation==4) {
                t.clockwiseRotate(); // get it back right side up
                t.flipLR();
            }
            if ((orientation >=5) && (orientation<=7)) {
                t.clockwiseRotate();
            } 
            //put it back
            if (orientation==8) {
                t.clockwiseRotate(); // get it back right side up
                t.flipLR();
            }
            return t;
        }
        
        static int checkWholeGrid(char[,] grid, int size) {
            int monsters = 0;
            for(int x=0; x<size; x++) {
                for(int y=0; y<size; y++) {
                    if (checkForSeamonster(grid,x,y,size)) { 
                        monsters++; 
                        markMoster(grid,x,y);
                    }
                }
            }
            return monsters;
        }

        static void markMoster(char[,] grid, int x, int y) {
            grid[x,y] = 'O';

            grid[x-18,y+1] = 'O';
            grid[x-13,y+1] = 'O';
            grid[x-12,y+1] = 'O';
            grid[x-7,y+1] = 'O';
            grid[x-6,y+1] = 'O';
            grid[x-1,y+1] = 'O';
            grid[x,y+1] = 'O';
            grid[x+1,y+1] = 'O';

            grid[x-17,y+2] = 'O';
            grid[x-14,y+2] = 'O';
            grid[x-11,y+2] = 'O';
            grid[x-8,y+2] = 'O';
            grid[x-5,y+2] = 'O';
            grid[x-2,y+2] = 'O';

        }

        static bool checkForSeamonster(char[,] grid, int x, int y, int size) {
            if (!checkForHash(grid,x,y,size)) { return false; }

            if (!checkForHash(grid,x-18,y+1,size)) { return false; }
            if (!checkForHash(grid,x-13,y+1,size)) { return false; }
            if (!checkForHash(grid,x-12,y+1,size)) { return false; }
            if (!checkForHash(grid,x-7,y+1,size)) { return false; }
            if (!checkForHash(grid,x-6,y+1,size)) { return false; }
            if (!checkForHash(grid,x-1,y+1,size)) { return false; }
            if (!checkForHash(grid,x,y+1,size)) { return false; }
            if (!checkForHash(grid,x+1,y+1,size)) { return false; }

            if (!checkForHash(grid,x-17,y+2,size)) { return false; }
            if (!checkForHash(grid,x-14,y+2,size)) { return false; }
            if (!checkForHash(grid,x-11,y+2,size)) { return false; }
            if (!checkForHash(grid,x-8,y+2,size)) { return false; }
            if (!checkForHash(grid,x-5,y+2,size)) { return false; }
            if (!checkForHash(grid,x-2,y+2,size)) { return false; }

            return true;
        }

        static bool checkForHash(char[,] grid, int x, int y, int size) {
            if (x<0) {return false; }
            if (y<0) {return false; }
            if (x >= size ) { return false; }
            if (y >= size ) { return false; }
            return (grid[x,y] == '#');
        }

        static char[,] rotateClockwise(char[,] map, int size) {
            char[,] newmap = new char[size,size];
            for(int y=0; y<size; y++) {
                for(int x=0; x<size; x++) {
                    newmap[x,y] = map[y,size-1-x];
                }
            }
            return newmap;
        }

        static char[,] flip(char[,] map, int size) {
            char[,] newmap = new char[size, size];
            for(int y=0; y<size; y++) {
                for(int x=0; x<size; x++) {
                    newmap[x,y] = map[size-1-x,y];
                }
            }
            return newmap;
        }

        static string[] getInput() {
            string input = System.IO.File.ReadAllText(@"input.txt");
            return input.Split('\n');
        }
    }
}
