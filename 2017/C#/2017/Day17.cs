using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _2017
{
    class Day17
    {
        public static int part1(int input)
        {
            ArrayList buffer = new ArrayList();
            buffer.Add(0);
            int current = 0;
            int num2Add = 1;
            while(num2Add<=2017)
            {
                if (buffer.Count == 0)
                    current = 1;
                else
                {
                    current = ((current + input) + 1) % buffer.Count;
                }
                buffer.Insert(current, num2Add);
                num2Add++;
            }

            return (int)buffer[current + 1];
        }

        public static int part2(int input)
        {
            int z = 0;
            int neighbor = 0;
            int pos = 0;
            for(int i=1; i<50000000; i++, pos++)
            {
                pos = (pos + input) % i;
                if (pos == z)
                    neighbor = i;
                if (pos < z)
                    z++;
            }
            return neighbor;
        }
    }
}
