using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            int serial = 4151;
            int[,] cells = new int[301, 301];

            for(int x=1; x<=300; x++)
            {
                for(int y=1; y<=300; y++)
                {
                    int rackId = x + 10;
                    int power = rackId * y;
                    power += serial;
                    power *= rackId;
                    power = power / 100;
                    power = power % 10;
                    power -= 5;
                    cells[x, y] = power;
                }
            }

            int maxPower = 0;
            int maxX = -1;
            int maxY = -1;
            int maxSize = 0;

            for (int size = 1; size <= 300; size++)
            {
                for (int x = 1; x <= (300-size+1); x++)
                {
                    for (int y = 1; y <= (300-size+1); y++)
                    {
                        int total = 0;
                        for(int i = 0; i<size-1; i++)
                        {
                            for(int j = 0; j<size-1; j++)
                            {
                                total += cells[x + i, y + j];
                            }
                        }

                        if (total > maxPower)
                        {
                            maxPower = total;
                            maxX = x;
                            maxY = y;
                            maxSize = size;
                        }

                    }
                }
            }
            Console.WriteLine(maxX + "," + maxY+","+(maxSize-1));
            Console.ReadLine();
        }

    }
}
