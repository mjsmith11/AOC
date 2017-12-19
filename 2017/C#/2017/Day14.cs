using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017
{
    class Day14
    {
        public static int part1(string input)
        {
            int used = 0;
            for(int i=0; i<128; i++)
            {
                string hash = Day10.part2(input + "-" + i);
                used += hexToBinOnesCount(hash);
            }

            return used;
        }

        public static int part2(string input)
        {
            Cell[,] disk = new Cell[128, 128];

            //load up Cells
            for (int i = 0; i < 128; i++)
            {
                string hash = Day10.part2(input + "-" + i);
                string binaryhash = String.Join(String.Empty,
                    hash.Select(
                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                  )
                );

                for (int j = 0; j<128; j++)
                {
                    disk[j, i] = new Cell { used = (binaryhash[j] == '1'), inRegion = false };
                }
            }

            //find regions
            int regions = 0;
            for (int y=0; y<128; y++)
            {
                for (int x = 0; x<128; x++)
                {
                    if (!disk[x,y].inRegion && disk[x, y].used)
                    {
                        regions++;
                        markRegion(x, y, disk);
                    }
                }
            }
            return regions;
        }

        private static void markRegion(int x, int y, Cell[,] disk)
        {
            disk[x, y].inRegion = true;

            if (y != 0 && disk[x, y - 1].used && !disk[x, y - 1].inRegion)
                markRegion(x, y - 1, disk);
            //check down
            if (y != 127 && disk[x, y + 1].used && !disk[x, y + 1].inRegion)
                markRegion(x, y + 1, disk);
            //check left
            if (x != 0 && disk[x - 1, y].used && !disk[x - 1, y].inRegion)
                markRegion(x - 1, y, disk);
            if (x != 127 && disk[x + 1, y].used && !disk[x + 1, y].inRegion)
                markRegion(x + 1, y, disk);
        }

        //takes a hex string and returns the number of 1's in the binary representation
        private static int hexToBinOnesCount(string hex)
        {
            int total = 0;
            foreach(char c in hex)
            {
                total += singleHexToBinOnesCount(c);
            }
            return total;
        }

        private static int singleHexToBinOnesCount(char c)
        {
            switch(c)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 1;
                case '3': return 2;
                case '4': return 1;
                case '5': return 2;
                case '6': return 2;
                case '7': return 3;
                case '8': return 1;
                case '9': return 2;
                case 'a': return 2;
                case 'b': return 3;
                case 'c': return 2;
                case 'd': return 3;
                case 'e': return 3;
                case 'f': return 4;
            }
            return 0;
        }
    }
}

public class Cell
{
    public bool used { get; set; }
    public bool inRegion { get; set; }
}

public class OrderedPair
{
    public int x { get; set; }
    public int y { get; set; }
}
