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
            for(int x = 1; x<=298; x++)
            {
                for(int y = 1; y<=298; y++)
                {
                    int total = cells[x, y];
                    total += cells[x + 1, y];
                    total += cells[x + 2, y];
                    total += cells[x, y + 1];
                    total += cells[x + 1, y + 1];
                    total += cells[x + 2, y + 1];
                    total += cells[x, y + 2];
                    total += cells[x + 1, y + 2];
                    total += cells[x + 2, y + 2];

                    if (total > maxPower)
                    {
                        maxPower = total;
                        maxX = x;
                        maxY = y;
                    }

                }
            }
            Console.WriteLine(maxX + "," + maxY);
            Console.ReadLine();
        }

    }
}
