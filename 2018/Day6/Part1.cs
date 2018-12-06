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
            Dictionary<int, int> usage = new Dictionary<int, int>();
            int[,] grid = new int[1700, 1700];
            for (int x = 0; x < 1700; x++)
            {
                for (int y = 0; y < 1700; y++)
                {
                    int minDist = 25000;
                    int minLoc = 0;
                    int numTied = 0;
                    int curX = x - 850;
                    int curY = y - 850;
                    for (int i = 0; i < splits.Length; i++)
                    {
                        string s = splits[i];
                        string trimmed = s.Trim();
                        string[] coords = trimmed.Split(',');
                        int xcoord = int.Parse(coords[0]);
                        int ycoord = int.Parse(coords[1].Trim());
                        if ((Math.Abs(curX - xcoord) + Math.Abs(curY - ycoord)) < minDist)
                        {
                            minDist = Math.Abs(curX - xcoord) + Math.Abs(curY - ycoord);
                            minLoc = i;
                            numTied = 1;
                        }
                        else if ((Math.Abs(curX - xcoord) + Math.Abs(curY - ycoord)) == minDist)
                        {
                            numTied++;
                        }
                    }
                    if (numTied == 1)
                    {
                        grid[x, y] = minLoc;
                        if (usage.ContainsKey(minLoc))
                        {
                            usage[minLoc]++;
                        }
                        else
                        {
                            usage[minLoc] = 1;
                        }
                    }
                    else
                    {
                        grid[x, y] = -1;
                    }
                }
            }
            var sortedDict = from entry in usage orderby entry.Value descending select entry;
            foreach (KeyValuePair<int, int> kv in sortedDict)
            {
                bool xOk = true;
                for (int x = 0; x < 1700; x++)
                {
                    if (grid[x, 0] == kv.Key)
                    {
                        xOk = false;
                        break;
                    }
                    if (grid[x, 1699] == kv.Key)
                    {
                        xOk = false;
                        break;
                    }
                }

                bool yOk = true;
                for (int y = 0; y < 1700; y++)
                {
                    if (grid[0, y] == kv.Key)
                    {
                        yOk = false;
                        break;
                    }
                    if (grid[1699, y] == kv.Key)
                    {
                        yOk = false;
                        break;
                    }
                }
                if (xOk && yOk)
                {
                    Console.WriteLine(kv.Value);
                    break;
                }
            }

            Console.ReadLine();
        }


    }
}
