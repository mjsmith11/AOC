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
            string input = @"183, 157
331, 86
347, 286
291, 273
285, 152
63, 100
47, 80
70, 88
333, 86
72, 238
158, 80
256, 140
93, 325
343, 44
89, 248
93, 261
292, 250
240, 243
342, 214
192, 51
71, 92
219, 63
240, 183
293, 55
316, 268
264, 151
68, 98
190, 288
85, 120
261, 59
84, 222
268, 171
205, 134
80, 161
337, 326
125, 176
228, 122
278, 151
129, 287
293, 271
57, 278
104, 171
330, 69
141, 141
112, 127
201, 151
331, 268
95, 68
289, 282
221, 359";
            string[] splits = input.Split('\n');
            int inRegion = 0;
            for (int x = 0; x < 1400; x++)
            {
                for (int y = 0; y < 1400; y++)
                {
                    int curX = x - 500;
                    int curY = y - 500;
                    int totalDistance = 0;
                    for (int i = 0; i < splits.Length; i++)
                    {
                        string s = splits[i];
                        string trimmed = s.Trim();
                        string[] coords = trimmed.Split(',');
                        int xcoord = int.Parse(coords[0]);
                        int ycoord = int.Parse(coords[1].Trim());
                        totalDistance += (Math.Abs(curX - xcoord) + Math.Abs(curY - ycoord));
                    }
                    if (totalDistance < 10000)
                    {
                        inRegion++;
                    }
                }

            }

            Console.WriteLine(inRegion);
            Console.ReadLine();
        }


    }
}
