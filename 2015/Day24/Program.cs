using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Sort of cheating  It assumes that if we find one subset of the correct weight, others exist and that the minimum QE doesn't overflow an int64
    class Program
    {
        static void Main(string[] args)
        {
            string inpStr = @"1
2
3
5
7
13
17
19
23
29
31
37
41
43
53
59
61
67
71
73
79
83
89
97
101
103
107
109
113";
            // total weight = 1536
            // weight of each group = 512 (Part 1)
            // weight of each group = 384(Part 2)
            int[] input = new int[29];
            string[] splits = inpStr.Split('\n');
            long minQE = long.MaxValue;
            for(int i=0; i<splits.Length; i++)
            {
                input[i] = int.Parse(splits[i].Trim());
            }
            int shortest1 = int.MaxValue;
            // look for subsets that weigh 512
            for(int i = 0; i< Math.Pow(2, 29); i++)
            {
                int setBits = countSetBits(i);
                if (setBits > shortest1)
                {
                    continue;
                }
                int weight1 = 0;
                List<int> remaining = new List<int>();
                List<int> c1 = new List<int>();
                for (int j = 0; j< 29; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        weight1 += input[j];
                        c1.Add(input[j]);
                    }
                }
                if (weight1 == 384)
                {
                    shortest1 = setBits;
                    long qe1 = 1;
                    for (int q = 0; q < c1.Count(); q++)
                    {
                        qe1 *= c1[q];
                    }
                    if (qe1<minQE && qe1 > 0)
                    {
                        minQE = qe1;
                    }
                }
            }
            Console.WriteLine(minQE);
            Console.ReadLine();
        }
        static int countSetBits(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
    }
}
