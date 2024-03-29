﻿
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Part 1 : " + solve(2));
Console.WriteLine("Part 2 : " + solve(50));

static string getEnhancement() {
    return "###..#....#####.#.###..#####.#...##.#.#.#...#.###.#..###.###.....######..##..#.#.#...#..#.#..##...####..#.....#.#...####.#...#######.##..#.#.#....###.#..##.#...#.#.#.#....#..........#....##.#..##..#.#.#.....##.#....##.##.##.#.##.....#....######.###..##.#...###.###.#.#.#####..#.##.#.#####...#.##....#...#..#..#.###..##...###...#...#.##...#..#..##.#...#.#...#...#...#....##.##.#.###.###...##...###....#...#.#.#...#....##.#..##.#....#...#.###.#..##.....#.#.#.#####....#.#.#.###.#...#.#..###...##....####...#..####.";
}

static int solve(int iterations) {
    int gridSize = 300;
    string enhancement = getEnhancement();
    char[,] grid = getImage();
    for(int i=0; i<iterations; i++) {
        char[,] newgrid = new char[gridSize,gridSize];
        for(int k=0; k<gridSize; k++) {
            for(int j=0; j<gridSize; j++) {
                newgrid[k,j] ='.';
            }
        }
        for(int y=1; y<gridSize-1; y++) {
            for(int x=1; x<gridSize-1; x++) {
                string binary = "";
                binary += grid[x-1,y-1]=='#'?"1":"0";
                binary += grid[x,y-1]=='#'?"1":"0";
                binary += grid[x+1,y-1]=='#'?"1":"0";
                binary += grid[x-1,y]=='#'?"1":"0";
                binary += grid[x,y]=='#'?"1":"0";
                binary += grid[x+1,y]=='#'?"1":"0";
                binary += grid[x-1,y+1]=='#'?"1":"0";
                binary += grid[x,y+1]=='#'?"1":"0";
                binary += grid[x+1,y+1]=='#'?"1":"0";
                int value = binToInt(binary);
                newgrid[x,y] = enhancement[value];                
            }
        }
        grid = newgrid;
    }
    int count = 0;
    // don't consider whole grid because there can be some noise at the edges
    // due to the fact that the picture is infinite
    for(int y=iterations; y<gridSize-iterations; y++) {
        for(int x=iterations; x<gridSize-iterations; x++) { 
            if (grid[x,y]=='#') { count++; }
        }
    }
    return count;
}

static int binToInt(string bin) {
    int num = 0;
    for(int i=0; i<bin.Length; i++) {
        int index = bin.Length - 1 - i;
        if (bin.Substring(index,1)=="1") {
            num += (int)Math.Pow(2,i);
        }
    }
    return num;
}

static char[,] getImage()  {
    int gridSize = 300;
    int start = 100;
    string image = @".#..#####.#...##..#.###.#...##.###....###.#.#.##.###..###..#..#.###.###..##.#...#..#..#.....#...###.
##.###.######..##..##.#.#.##.#..#...#..#....#.###........###.###..####..#....#..##.....########.###.
#.##.##.#...##.##.......##..#.######.###...##.#####..##...#..###.###.###.##..#...#.#...#..#...#..#.#
#.#...#####.####.#...#.#....####..##.#.####..####..#.#..#.##.....#..##...##......#..#...#.#.##..###.
...###..#.#.##.#.#.##...##.####.#.##.#..#.#.###..#.##..##..#.#.#.##.#.#.####.........####...#####.##
#.#..#...#..###.##.#.##.##.##.#.#...##.###.#.#######..#.#.#..#####.....##.##...#.#....#.###.#.#..##.
##.##....##.##.#....###.#.....##.##...#.#....####...###.#.#.#...##.####.#..##......##...#..#.#.##...
##...#....#####.#.##.##..#.##.##.###..#..#....#..#....#.#.##.##.##.#.##...#...##.#.#....###...##..##
..#.##.#...###.....#..#.##..##.##.##.########.####...#..##..#..#..####.####.#.#.#..#...##.##.#.#..#.
#..........#.....###.........##.#...###....#....#.#........####.#.#...#.##...####.####.##.##.#...#..
#.##...##...#.##...#..#..#.#...........#..##...#.#..#.#..#...#.###..##...#####..#....#.#..#.##..#...
#.#...#####.......###.#.##.#.##.###.#.##.##..#.##.##...#.##.#...#..#...###.##.###.#..#..##.###.##..#
...#...#.#.#.##...#.##.#.####......#..#......#..##...#..#....#...#####...#####..#.#..###....#.#.###.
.#..#.###.##.....##..####......#..###.#..#...#.#.##.....#.#...##.##.##.####.###.#.##..##...###.#.###
###..###.##.##....#..#......#..#...####.#....##.#.#####.###..#..#.##.....#.##.###..##..#.#..###.##.#
....#..##.......##.#...###..##...##....#...###.#....#.#..###......###.....##..###.....##..##.##..###
###...#..#...##..#.....#.#.########.#.###.#.....##....#.#.#..#.#.#..###....##.#.#.##.##.##.##...#.#.
##....#.##....##.....#.####..####.#.#..#.###.#.#.#.###..##.####..#..#######.#..#.#.###.#...##.....##
.#.#.#.#####...#.##...#.###....#.##.##..##.#..###..####..##..############.####.#.#..###...##.#.....#
..##..#.#.#.#..#####.##..#..#..#...#.###.##..#.###....#.#.###.#.#..######.###.#.#.#.#..####..##.####
.....#.#...#..#.######.###..####.##...#...######..#...####.#.####.###.#.#..#....#..####..##.....#..#
....##.#####........#..##....#########.#...##....#...#.####.#....####.####.######..###...##.#......#
#...###.##.#.#..#.#..##....#.....#...#.##..#.#..#...###.#.##.#....##..###..##.##.##..###.########.##
.#...#..####....#..#..##..#....###..#..#..#.###.##.#...#.###.....##...#.###..##..###.#..###.#.##.###
###..#...#..#..###.####.###.####.#.###..#.#..##.##..###...#.#.....#..#.##....#.#.#.#.##.#..###..##.#
.#.####.#....##...##.###.#.#.#.#..##.##....##.###...#.#.##.#.#..##..##.#..#.#.##......###.....###.##
.##..##..#.##...####....###....#.###.#.##.##......#.##..#.#....##.####.##....##...#.####....###.#...
##...#.##..##...##.##.##.########..#..##.#########.#.......##.#..###..#..###.#.#....########..##.##.
.###...#....##.#..#..#...###...###########.#..#####..#..##........#.#...##...######..#.###.#.....##.
...###..#.#.#####..#.#######.##.#......###..#..#####...###.#..##.##....###....##.####...#.##.###..#.
....#....####.#.....###.......#..####...##...#..####......##.##..##.......##.#...#..##.##.#.###.####
###...#..#......#...##.###..#.##.#.#....###.#..#.#.#........####.#...##.##...#...#..####.#....#..###
##.#..##.##....##...########.#.#.#.###...#...#.##..##..####..###...###..#.###..#..###.###....##....#
###...##....###.##.##.###......#..#..#.##.#.##..#..#.....##...##......##.###.######.##.#.#.##.#.##.#
...##....#.###..##.##.#.##.#.#.....#.#.##..####..#.######....#.#..###...#.#.#......#.#.#.#.#..#.#.#.
..####..##.#.#####.#........#..###..##..##..#..##.#.###..#..#..##.#.#.##.##.#...####..##.#.##..#.#.#
...###.#...####..#..####.#..##########.######..##........##....#.#.###..####.#..#.##.....#..#.#.#.#.
###.....##..#......##.....#.#.####.####..####...#.#.#######..##...##...#.#.##.##..#.#####...####...#
.#.##.#.###.#..##...#####.#..#.##..###..#.#..##.###.###...#...#.##..##...###........##.......#.###..
.#...##.###.###....###...######.##.######..........##.....###.##..##.##.#.#..#.#.....#.#####.#.##..#
.#.#.##.#....##..#.###....#####.####..#.######..#..#..##.#..##..##.##.#..#....#..#.....###.###...#.#
.##...#...#.##...###.###.#.##..#.###.#.#.##...#.#..#.#.#..#..#..#..###..#....##.######.##..#..##.##.
.####.#...#....#........#.#..#######.####.#.####.#.#.#.###...#..#####.#.##.#.#.##.#...##...#......##
.###..#.####.......##.##.#.#.#..####.#..#.#.#####.##.##.##..####....##.#.##.#.#.#..#..#..#.#.....###
##...###.##.##.....#....##.###.##....#.#.###.....####.##..#.#####.....###.#..####..#.#....##......#.
#...####..#.####.#.###......##.#.#.##..#...#..#..########.#...#..##.#.#..#.#.#.##.#.##.#..#.####.###
..#..#.#..##..#.##...#..##....##.#.##..###.#...#....#.......###..#..#...####.#.###.#####.####...###.
..##.....####.#..#.##..#...#.##.##.#..#.####..##.##..#.########..##.##.#..#.###.#.#..##.#.......#..#
##..#####.............#######.##..#.#.#.##..#...#...#.##.#...#.##...####.##..##.#.#...#.#..##.#...#.
#.#.###.#..#.#..##.#..##.#.#...#..###.##...#.#....#.#....#.#.####..##.###..#.###.##..##.#...#..#..#.
###.##.#..#..##..#..#..###...#..##......#.####..#.###....###.......##...###....###..##.#.#..###.#..#
##.#.#.#.#..##..#...#..##.#.##...#.#.#..#.##.#######..#.#..#........#..#######..#.#.##..##.##..#.#..
###.....#.##.##.#.#.##...#...#.#..#.#.#.###..##...##.#..##.#.##.#..#....#..#..###.###....##.###...##
...##....##..##.##....#.#..########....##..##.##.....##..####..##.#.####...##..###.###.....#...##..#
.##.....#...#.#.#.###.#....#.#.######.#...###.#..###....#.#.#..#####.....###.######....#.##.#...###.
###.######..###..##.###.###.#.#.######..####.##.#.####..#.....###..####..#...##.##.......#.#.#.#####
###..########.#.#####..#.#...#.######.#.##..#..##...####..###..#...##..####.##..#......#..#..#.##.#.
..#.###.###.#.#..##..#..#..##....##..#####...#.##..##.....##..##..##.##..#....#.#....##...#..###...#
.#.....#.#.##.#.##..##....##.#.#.#..##.#...#####.#..#..#.##.#...##....##.####....#...#..##.#....#..#
#.#.#.........###..#.#.#...#.####......#.#..##..##.####.####...#.###.#.#.##.###...##..##.######.####
#.#.###..#..####.#######.....#...##.#.#.##.############..###.#.##...#.#.##.###.#######...#........#.
#..###..##.#..########.##.#.#.....#.###...#.###..#.##..###.##.......#..##.......#......##..##..###..
.#...#.##.#...##..##..#####...##.###.######...###.###.#.#.#..#..#...#..#.#######...####...#####.....
#.#.#......##.#.#####.#.#.###..####..##..#...#....###..#..##.#.####..##.###...#.###..#.###.###.##.#.
#.#..##.#...####.#####..........####..#.#.#..##....#.##.#.#..#####.#.#...##.##...###...#.##.#..###.#
..##.#.#.###.#.###...#####..##..#.###..#.#...#..##.##.#...##.#.####..####..####..#.#.#.....#..###...
..#.#...#.###...#........##...##..#..#...###.#...#.###..#..#....###..#..#########..###.###.##..##..#
..#.......#.....#####.##.##.#.#.##...####.##........######.....#.#.##.#..#.#.##..#..#####.#.##.#.#.#
##.#..#####.##..#####.#####.##.##.##.#.##.#..##......#..##.##..#.#..#.##..#.#..###.........#######..
..##.#......#####.#.###..###.#.##.#.##.#######..#.##..#.....####.#..#.######..#..#..###.....##.#..##
#.#.#.....#...###...#.##..###..##..##.#...#.#.#...###.....#.##.#.###.###.#..###...#..#.#.#...##...##
.#....##.##...#######...#.#..#.#.#.##.#..###.#....#.####.#.##..#.###.....#..#..######.#.##.##.######
#.#...##.....#######...#.##.#..#...#...####...#.####...####..#.##..#.#.##..#..##..#.#.##.####....###
##.#####.##...##.#.#.#...#####.####.#.#....###.#.#...#.#..##.#.#..###.#..##..#.###.##.##.#####.#..#.
.#####..#.#...#.##.##..#...#...#.##.#.#.######..####.#.##..#..#..#####..#.##..##.....###.#.##...##..
#####..#.#..#..#......#...#####......#.#...#.#.###..####.#...###..#..###..#.#......###.#..###.##...#
##.###.#.#.##.##...#.##....#..#.###.#####.#...##...##...#.##...##.#.####.#....##.##..#########..##.#
####.#.#..##....#...#.....#....#.#.#..##.##..####...#..#.#.#..#.##..#..###...#####.#.#.##...####....
.#..#..#######.#....####.######.......##.#.###...##.##.########.#.###...#....#..###.###.##.###..#.#.
##..##.###.#.##...##..#...##.###..#####.....#..####.##....#.#.#....###.#......#..#.##.#.##.#.#......
..#.##.#.#..###.####.###.#....#######.###.#..##.##.##.#.####.###.#...#...##...#.#####..##.#.#.....##
.......##.######..#.....####...####.###.####.##.#...##..###..###.#...#####....#....###.##.....#.#.##
..#.##.####..#.#.#.#.#.#...##.##.##.##...#########.###.#.#.##..#####.#.##..##......##.######..#.##..
.#.##..#...#..#....#....#.##.##.###...##...#....##.##.###.#..........##..##.#.##.##..##....#.#.##.##
##.#.#.###.#...#...####...#.#..##.#..##..#..#..#.###.####.##.##...#.#.###.#..###...#.#####..#.###.##
#..#######....####.##.#..###.####..#.#.........#.###....####....#..###.#.#.###.#####.#..#...#.##.#.#
...#..####...###...#..###....#..#.#..##.#..###.##.........###.###..##.##.###..###.....##.###.#..###.
###.##.####....##..#..##.#...#.#.##..#.#.##.##....#####.####....##...#...###.##......#.#..#.#####...
####...#.#.#..#.#.....##.##..#######.##.#####....##########.#....##......#...#####...#..#..#....##..
####.###.#.####..#..#.#.#.##........##..####.#.###.....#.#...#.#.#.##..#.#..#.##.#......#.#.#.###..#
#.###....#..###.###.##..##...#######...##.#...#....########...###.....######.##...###..#..#.###.#.##
.#.#...#..#.#########..###.#.#.#..#..##.#.....###.#.....##.########..####.###.#.#..#..#.#..##.#.#.#.
####.#..#....#####..###.#####..#..#..#...#..#..#.##.#.####....#.###..#.....###..#...#####..#.##.##..
....#.##.##.#.#.#...#####..#.#..###...##..##..####.#..#...#.#####...#.###..###....##.#.##.####.#.##.
#...###.###.##########.###..####..##....###.#..#.#..##.#.###..##..###.####.###..###..#..#......###..
#.##.##....##.#..###.##.##.#.......#.#....#######.###..#.###.....####..######..##.##.###.##.#.......
.##....###..#..###...##..####.#.###.#####....#.#....######..#.###......###..#.....#..#.###..#...#.##
##.#.##...##...#....###.#.###.##.#..##.###.#.#..#.#.#...##.#...#.###.#...#..##.###.###..#..###..#.##
##....#.#.#...##.....#..#.#..#..####......#####.##.#.#.#.########..#####..#....#.####.....#...#..#..
...#..##.#.#.#.#..###.##.#...#..#.#..#..#.##.....#.##..###.##.#.#..##.##..##..#.###...#.#..#.#..###.";
    string[] lines = image.Split("\n");
    char[,] grid = new char[gridSize,gridSize];
    for(int i=0; i<gridSize; i++) {
        for(int j=0; j<gridSize; j++) {
            grid[i,j] ='.';
        }
    }
    int x=start;
    int y=start;
    for(int i=0; i<lines.Length; i++) {
        string line = lines[i].Trim();
        for(int j=0; j<lines.Length; j++) {
            grid[j+start,i+start] = line[j];
        }
    }
    return grid;

}