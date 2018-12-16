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
            string input = @"8 2 0 0
8 1 2 3
8 3 2 2
1 3 2 2
1 2 3 2
6 1 2 1
5 1 0 0
8 3 1 1
8 0 0 2
1 3 2 3
1 3 3 3
6 0 3 0
5 0 1 1
8 2 2 2
8 1 0 3
1 0 0 0
9 0 1 0
5 0 2 3
1 3 1 3
6 3 1 1
5 1 2 2
8 3 3 3
8 0 2 0
8 2 1 1
8 1 3 3
1 3 2 3
6 3 2 2
5 2 3 0
8 3 2 2
8 0 2 3
12 1 2 3
1 3 2 3
6 3 0 0
5 0 3 1
1 0 0 0
9 0 2 0
8 2 2 3
12 0 2 2
1 2 2 2
6 2 1 1
5 1 1 2
8 0 0 1
8 1 3 3
13 0 3 1
1 1 3 1
1 1 1 1
6 1 2 2
5 2 3 0
1 3 0 3
9 3 3 3
8 2 3 1
8 0 2 2
3 3 2 3
1 3 1 3
6 3 0 0
8 0 2 3
1 1 0 2
9 2 2 2
1 0 0 1
9 1 0 1
4 3 2 1
1 1 1 1
1 1 3 1
6 1 0 0
8 1 2 1
8 3 2 2
7 3 2 2
1 2 3 2
1 2 2 2
6 2 0 0
5 0 1 2
8 1 2 0
8 3 1 1
8 3 0 0
1 0 1 0
6 0 2 2
5 2 2 0
8 2 0 2
4 3 2 3
1 3 3 3
6 0 3 0
5 0 1 2
1 1 0 3
9 3 1 3
8 1 2 0
6 3 3 1
1 1 2 1
6 2 1 2
8 2 0 3
1 0 0 0
9 0 2 0
1 3 0 1
9 1 1 1
10 0 3 0
1 0 3 0
6 2 0 2
8 2 3 0
8 3 0 1
2 1 0 0
1 0 2 0
6 0 2 2
5 2 0 0
8 3 0 2
8 0 3 3
8 2 3 1
7 3 2 1
1 1 2 1
6 1 0 0
5 0 2 3
8 0 0 2
8 3 0 0
8 0 0 1
8 2 0 2
1 2 1 2
1 2 1 2
6 3 2 3
5 3 2 1
8 0 3 3
8 1 2 2
1 1 0 0
9 0 2 0
0 0 3 0
1 0 3 0
1 0 3 0
6 1 0 1
5 1 2 3
8 1 1 0
8 2 0 2
8 0 2 1
5 0 2 1
1 1 1 1
6 1 3 3
5 3 2 1
8 3 1 2
1 2 0 3
9 3 1 3
8 2 0 2
1 2 2 2
1 2 1 2
6 1 2 1
5 1 2 3
8 3 2 0
8 0 1 1
8 0 3 2
11 2 0 0
1 0 2 0
1 0 2 0
6 0 3 3
5 3 3 0
8 1 1 1
8 3 3 3
1 1 2 3
1 3 3 3
1 3 2 3
6 0 3 0
5 0 1 1
8 2 0 3
8 3 2 2
8 2 1 0
0 0 3 0
1 0 2 0
6 0 1 1
8 3 3 0
8 2 0 2
1 0 0 3
9 3 0 3
15 2 0 3
1 3 2 3
6 1 3 1
8 1 2 0
8 0 3 3
8 0 2 2
6 0 0 3
1 3 3 3
6 1 3 1
5 1 0 2
1 3 0 3
9 3 0 3
8 1 3 1
8 3 0 3
1 3 2 3
6 2 3 2
5 2 2 1
8 1 1 3
8 2 2 2
6 0 3 3
1 3 3 3
6 3 1 1
8 2 1 0
8 2 1 3
10 0 3 3
1 3 2 3
6 3 1 1
5 1 0 2
1 2 0 1
9 1 1 1
8 2 1 3
14 1 0 1
1 1 3 1
6 2 1 2
5 2 3 1
8 2 3 2
1 2 0 0
9 0 1 0
5 0 2 2
1 2 2 2
6 2 1 1
5 1 3 0
8 3 2 1
8 1 1 3
8 0 1 2
3 1 2 2
1 2 1 2
6 0 2 0
5 0 3 3
8 2 0 0
8 3 1 2
12 0 2 2
1 2 2 2
6 3 2 3
5 3 3 1
8 2 1 2
8 0 0 3
8 0 2 0
4 3 2 0
1 0 2 0
1 0 3 0
6 1 0 1
5 1 0 0
8 2 2 1
4 3 2 1
1 1 3 1
6 0 1 0
5 0 1 3
1 1 0 0
9 0 2 0
8 1 3 1
8 1 3 2
14 1 0 2
1 2 1 2
6 3 2 3
5 3 2 2
8 2 3 3
8 0 3 1
8 3 3 0
8 1 3 1
1 1 2 1
1 1 2 1
6 1 2 2
5 2 0 1
8 1 0 3
8 0 0 2
11 2 0 2
1 2 2 2
6 2 1 1
5 1 2 0
8 0 1 1
1 1 0 2
9 2 3 2
8 3 1 3
8 1 2 1
1 1 2 1
1 1 1 1
6 0 1 0
5 0 1 2
8 2 3 3
8 3 2 1
8 2 2 0
0 0 3 0
1 0 1 0
6 2 0 2
5 2 1 0
1 2 0 2
9 2 2 2
8 2 0 1
8 0 3 3
4 3 2 2
1 2 1 2
6 2 0 0
8 3 1 1
1 2 0 2
9 2 2 2
15 2 1 3
1 3 3 3
1 3 2 3
6 0 3 0
5 0 3 1
8 2 2 3
8 1 0 0
14 0 3 0
1 0 3 0
6 1 0 1
5 1 2 2
8 3 3 1
8 1 3 0
14 0 3 1
1 1 3 1
6 2 1 2
5 2 0 3
8 2 0 2
8 1 2 1
5 0 2 0
1 0 1 0
1 0 2 0
6 0 3 3
5 3 0 1
8 1 1 3
8 2 1 0
6 3 3 0
1 0 1 0
6 0 1 1
8 3 1 3
8 3 1 0
12 2 0 3
1 3 2 3
1 3 3 3
6 3 1 1
5 1 0 2
1 2 0 3
9 3 2 3
8 1 1 1
2 0 3 1
1 1 2 1
6 1 2 2
5 2 1 1
8 3 3 2
1 0 0 3
9 3 3 3
8 2 2 0
11 0 2 3
1 3 1 3
6 3 1 1
8 1 1 3
8 0 1 2
1 3 2 0
1 0 2 0
6 0 1 1
5 1 3 0
8 2 0 1
8 3 3 3
8 3 1 2
12 1 2 1
1 1 1 1
1 1 1 1
6 0 1 0
5 0 2 1
8 1 3 3
8 0 3 2
8 0 2 0
6 3 3 0
1 0 3 0
6 0 1 1
5 1 3 0
8 3 2 3
8 0 2 1
1 1 0 2
9 2 3 2
3 3 2 1
1 1 3 1
6 0 1 0
8 0 1 3
8 3 3 1
8 2 3 2
4 3 2 1
1 1 2 1
1 1 2 1
6 1 0 0
1 2 0 1
9 1 1 1
1 3 0 3
9 3 2 3
0 2 3 1
1 1 1 1
6 1 0 0
5 0 0 3
8 3 2 2
8 1 3 1
8 1 1 0
6 1 0 1
1 1 1 1
6 1 3 3
5 3 1 0
1 0 0 1
9 1 2 1
8 2 1 3
8 1 2 2
0 1 3 1
1 1 2 1
6 1 0 0
5 0 0 2
8 3 2 3
8 3 2 1
8 2 1 0
2 3 0 3
1 3 2 3
6 3 2 2
5 2 3 3
8 0 0 0
8 3 1 2
8 2 2 1
12 1 2 0
1 0 1 0
1 0 3 0
6 3 0 3
5 3 2 2
8 2 1 0
1 3 0 3
9 3 2 3
10 0 3 1
1 1 2 1
6 2 1 2
8 3 2 3
8 1 2 1
14 1 0 1
1 1 2 1
6 1 2 2
5 2 3 0
8 3 1 1
8 2 3 2
15 2 1 1
1 1 1 1
1 1 1 1
6 1 0 0
5 0 0 3
8 3 1 2
8 3 3 1
8 2 0 0
11 0 2 1
1 1 2 1
6 1 3 3
8 1 2 0
1 3 0 1
9 1 1 1
1 0 2 1
1 1 3 1
1 1 2 1
6 3 1 3
8 2 0 0
8 1 3 1
14 1 0 1
1 1 3 1
6 3 1 3
5 3 1 1
8 1 2 0
8 2 1 2
8 3 3 3
5 0 2 3
1 3 1 3
6 3 1 1
8 1 2 3
8 2 0 0
8 3 0 2
11 0 2 2
1 2 1 2
6 2 1 1
5 1 0 0
8 3 3 1
8 0 0 3
8 3 1 2
7 3 2 2
1 2 2 2
6 2 0 0
5 0 3 3
8 1 3 1
8 1 1 0
8 2 0 2
5 0 2 2
1 2 3 2
6 2 3 3
5 3 3 1
8 3 1 2
1 0 0 3
9 3 0 3
8 2 0 0
7 3 2 2
1 2 3 2
1 2 1 2
6 2 1 1
8 2 3 3
1 1 0 2
9 2 0 2
10 0 3 3
1 3 2 3
6 1 3 1
1 0 0 2
9 2 1 2
8 2 2 3
10 0 3 3
1 3 1 3
6 3 1 1
8 0 0 3
8 1 1 0
8 3 3 2
7 3 2 3
1 3 3 3
6 1 3 1
5 1 1 2
1 0 0 3
9 3 1 3
1 0 0 0
9 0 0 0
8 1 2 1
6 3 3 3
1 3 3 3
6 2 3 2
5 2 2 1
1 2 0 0
9 0 1 0
8 2 2 3
8 0 0 2
14 0 3 0
1 0 3 0
6 0 1 1
5 1 2 2
8 1 0 3
8 0 3 0
1 1 0 1
9 1 0 1
9 3 1 0
1 0 3 0
1 0 3 0
6 0 2 2
5 2 1 0
1 1 0 1
9 1 3 1
8 3 0 3
8 0 3 2
3 1 2 3
1 3 3 3
6 3 0 0
5 0 3 2
1 3 0 1
9 1 2 1
8 1 2 0
1 1 0 3
9 3 2 3
14 0 3 1
1 1 3 1
6 1 2 2
5 2 2 3
8 3 0 1
1 3 0 2
9 2 2 2
8 2 1 0
2 1 0 1
1 1 2 1
1 1 3 1
6 3 1 3
5 3 0 0
8 0 2 3
8 3 0 2
8 2 0 1
7 3 2 2
1 2 2 2
6 0 2 0
8 2 0 3
8 0 0 2
1 2 0 1
9 1 0 1
7 2 3 3
1 3 3 3
6 0 3 0
5 0 3 3
8 1 1 0
8 2 2 1
1 0 2 1
1 1 1 1
1 1 1 1
6 1 3 3
8 2 1 1
8 3 0 2
12 1 2 1
1 1 3 1
6 3 1 3
5 3 1 0
8 2 3 2
8 1 2 1
8 0 3 3
4 3 2 1
1 1 2 1
6 1 0 0
5 0 2 3
8 3 3 2
1 2 0 1
9 1 3 1
8 2 1 0
2 1 0 2
1 2 1 2
1 2 2 2
6 3 2 3
5 3 2 0
8 3 3 2
8 1 1 1
8 3 0 3
1 1 2 1
1 1 1 1
1 1 1 1
6 1 0 0
5 0 3 3
8 2 3 1
8 3 0 0
1 2 0 2
9 2 2 2
12 1 0 0
1 0 2 0
6 0 3 3
5 3 2 2
8 2 1 0
8 2 1 3
1 1 0 1
9 1 0 1
10 0 3 1
1 1 1 1
1 1 1 1
6 1 2 2
5 2 1 1
8 3 2 2
10 0 3 2
1 2 2 2
1 2 2 2
6 2 1 1
5 1 2 2
1 2 0 3
9 3 0 3
8 0 2 1
0 0 3 0
1 0 3 0
6 0 2 2
8 0 0 0
1 2 0 1
9 1 1 1
1 2 0 3
9 3 1 3
6 1 3 3
1 3 2 3
1 3 1 3
6 2 3 2
5 2 1 0
8 3 1 3
8 3 1 2
3 3 2 1
1 1 2 1
1 1 3 1
6 1 0 0
5 0 3 2
8 1 3 0
8 0 3 1
9 0 1 0
1 0 1 0
6 0 2 2
5 2 0 1
1 2 0 3
9 3 1 3
8 0 1 2
1 0 0 0
9 0 1 0
6 3 3 3
1 3 2 3
6 3 1 1
5 1 2 3
8 0 1 1
8 3 2 2
1 0 2 1
1 1 1 1
1 1 2 1
6 1 3 3
5 3 2 0
8 3 0 1
8 0 1 2
8 1 0 3
8 2 1 2
1 2 1 2
1 2 3 2
6 0 2 0
5 0 2 2
8 2 3 0
8 2 3 3
8 1 0 1
10 0 3 3
1 3 1 3
6 3 2 2
5 2 3 1
8 0 0 2
8 1 3 3
13 0 3 3
1 3 2 3
6 1 3 1
1 2 0 2
9 2 2 2
8 0 2 3
4 3 2 2
1 2 1 2
6 2 1 1
5 1 2 3
8 2 3 1
8 2 0 2
8 1 3 0
5 0 2 1
1 1 1 1
6 1 3 3
5 3 3 0
8 2 1 3
8 3 0 2
8 1 1 1
14 1 3 2
1 2 3 2
6 2 0 0
5 0 2 3
8 2 3 2
1 3 0 0
9 0 1 0
8 2 2 1
5 0 2 0
1 0 1 0
1 0 1 0
6 0 3 3
8 3 0 1
1 1 0 2
9 2 3 2
8 2 2 0
15 0 1 1
1 1 2 1
1 1 1 1
6 1 3 3
5 3 1 0
8 0 3 1
8 0 3 2
1 2 0 3
9 3 0 3
8 2 3 1
1 1 1 1
6 1 0 0
8 2 3 2
8 1 1 1
4 3 2 2
1 2 1 2
6 2 0 0
5 0 0 1
8 0 3 2
8 1 0 3
8 2 3 0
14 3 0 2
1 2 1 2
6 1 2 1
5 1 3 0
8 0 3 2
8 3 0 3
8 3 3 1
3 3 2 3
1 3 3 3
6 3 0 0
5 0 3 2
8 3 0 3
8 2 2 1
8 3 3 0
2 0 1 3
1 3 2 3
1 3 1 3
6 3 2 2
5 2 3 1
8 2 3 3
1 0 0 2
9 2 3 2
8 2 0 0
10 0 3 3
1 3 3 3
6 1 3 1
5 1 3 3
8 1 1 1
14 1 0 2
1 2 2 2
1 2 2 2
6 2 3 3
5 3 1 2
1 2 0 3
9 3 2 3
8 3 1 1
10 0 3 1
1 1 1 1
6 1 2 2
5 2 2 0
8 2 2 1
8 3 0 2
1 0 0 3
9 3 3 3
12 1 2 2
1 2 2 2
6 0 2 0
5 0 0 1
8 2 0 0
8 3 1 2
2 3 0 0
1 0 3 0
6 1 0 1
5 1 1 3
8 2 0 2
8 3 0 1
8 2 0 0
15 2 1 0
1 0 2 0
6 3 0 3
5 3 2 0
8 2 3 1
8 3 0 2
8 3 1 3
12 1 2 3
1 3 3 3
6 3 0 0
5 0 1 1
8 1 1 0
8 2 1 2
8 0 1 3
5 0 2 0
1 0 1 0
1 0 3 0
6 1 0 1
5 1 2 2
8 3 2 1
8 2 1 3
1 1 0 0
9 0 1 0
9 0 1 0
1 0 3 0
6 0 2 2
5 2 0 0
8 1 2 1
8 0 0 2
8 1 3 3
1 1 2 1
1 1 1 1
6 0 1 0
5 0 3 1
8 2 2 3
1 3 0 0
9 0 1 0
8 2 0 2
5 0 2 3
1 3 1 3
1 3 3 3
6 1 3 1
5 1 1 2
8 0 2 3
8 2 0 0
8 3 3 1
0 0 3 3
1 3 1 3
1 3 2 3
6 2 3 2
5 2 3 3
8 2 0 1
8 3 3 2
8 1 3 0
1 0 2 0
1 0 2 0
1 0 3 0
6 0 3 3
8 0 2 0
8 3 0 1
8 1 0 2
3 1 2 1
1 1 3 1
1 1 2 1
6 1 3 3
8 1 1 0
1 0 0 1
9 1 3 1
1 3 0 2
9 2 0 2
9 0 1 2
1 2 2 2
1 2 2 2
6 2 3 3
5 3 2 2
8 2 2 0
1 3 0 3
9 3 1 3
14 3 0 3
1 3 2 3
1 3 3 3
6 2 3 2
5 2 2 1
8 1 2 2
8 3 0 3
3 3 2 0
1 0 1 0
6 0 1 1
8 0 3 2
8 2 2 3
1 2 0 0
9 0 3 0
11 2 0 3
1 3 1 3
1 3 2 3
6 1 3 1
5 1 0 3
8 1 3 0
8 1 0 1
8 2 2 2
5 0 2 1
1 1 2 1
1 1 2 1
6 1 3 3
1 3 0 1
9 1 2 1
8 3 1 0
8 3 3 2
12 1 0 2
1 2 1 2
6 2 3 3
5 3 2 1
8 1 0 2
1 0 0 0
9 0 2 0
8 2 0 3
10 0 3 0
1 0 3 0
1 0 3 0
6 1 0 1
8 3 3 0
8 0 3 2
8 0 0 3
11 2 0 0
1 0 2 0
6 0 1 1
8 1 3 3
8 3 2 2
8 1 1 0
6 3 3 3
1 3 1 3
1 3 2 3
6 3 1 1
5 1 3 0
8 3 3 1
1 2 0 3
9 3 0 3
7 3 2 3
1 3 1 3
1 3 2 3
6 0 3 0
5 0 2 2
1 2 0 1
9 1 2 1
1 1 0 3
9 3 2 3
8 2 3 0
10 0 3 3
1 3 3 3
1 3 3 3
6 2 3 2
5 2 2 1
8 2 1 3
8 3 1 0
8 3 2 2
2 0 3 3
1 3 1 3
6 1 3 1
1 1 0 2
9 2 2 2
8 3 1 3
1 0 0 0
9 0 1 0
5 0 2 0
1 0 1 0
6 1 0 1
5 1 3 0
8 2 2 3
8 2 3 1
0 2 3 2
1 2 1 2
6 0 2 0
5 0 3 3
8 3 2 1
8 0 2 0
8 3 0 2
3 1 2 1
1 1 2 1
6 1 3 3
8 0 0 1
8 0 1 2
8 1 2 0
9 0 1 0
1 0 3 0
6 3 0 3
5 3 0 2
8 2 3 1
1 3 0 0
9 0 3 0
8 0 0 3
12 1 0 1
1 1 3 1
1 1 3 1
6 1 2 2
5 2 3 1
8 2 0 0
8 3 3 2
7 3 2 0
1 0 3 0
6 1 0 1
5 1 3 2
8 2 3 1
8 1 2 0
8 1 1 3
6 0 0 1
1 1 2 1
1 1 3 1
6 2 1 2
8 0 0 1
8 3 1 3
9 0 1 3
1 3 1 3
6 2 3 2
5 2 3 0
8 3 1 1
8 2 2 2
8 3 0 3
15 2 1 2
1 2 2 2
6 2 0 0
5 0 3 3
1 1 0 2
9 2 0 2
8 1 0 0
3 1 2 0
1 0 1 0
6 0 3 3
5 3 1 0
8 2 1 3
8 2 3 2
15 2 1 1
1 1 1 1
6 1 0 0
5 0 3 1
1 0 0 2
9 2 0 2
1 3 0 0
9 0 2 0
7 2 3 3
1 3 1 3
6 3 1 1
5 1 3 0
8 0 1 1
8 3 2 3
3 3 2 3
1 3 3 3
6 3 0 0
5 0 1 1
8 2 3 3
8 1 0 0
1 1 0 2
9 2 3 2
1 0 2 3
1 3 3 3
6 3 1 1
5 1 1 2
8 1 1 3
8 1 1 1
1 3 0 0
9 0 2 0
13 0 3 3
1 3 1 3
6 2 3 2
5 2 1 1
8 3 1 0
8 0 0 2
8 1 3 3
11 2 0 3
1 3 1 3
6 1 3 1
5 1 0 3
8 3 0 1
1 2 0 2
9 2 1 2
8 1 2 0
3 1 2 2
1 2 2 2
6 2 3 3
5 3 0 1
8 2 1 2
1 3 0 3
9 3 1 3
8 2 2 0
13 0 3 0
1 0 3 0
6 1 0 1
8 1 1 0
1 0 0 3
9 3 0 3
4 3 2 0
1 0 3 0
6 1 0 1
5 1 2 3
8 0 0 2
8 0 1 1
1 1 0 0
9 0 3 0
11 2 0 2
1 2 1 2
6 3 2 3
5 3 3 0
8 1 1 3
1 3 0 2
9 2 3 2
8 1 3 1
1 3 2 2
1 2 2 2
6 0 2 0
5 0 3 3
1 2 0 1
9 1 0 1
8 2 2 2
8 3 2 0
15 2 0 2
1 2 2 2
1 2 2 2
6 3 2 3
5 3 3 0";
            /*  0: bori
                1: muli
                2: banr
                3: bani
                4: gtir
                5: setr
                6: addr
                7: eqir
                8: seti
                9: addi
                10: eqrr
                11: eqri
                12: borr
                13: gtrr
                14: mulr
                15: gtri*/
            string[] splits = input.Split('\n');
            int pc = 0;
            int[] reg = new int[4];
            reg[0] = 0;
            reg[1] = 0;
            reg[2] = 0;
            reg[3] = 0;
            while (pc < splits.Length)
            {
                
                int[] inst = new int[4];
                

                //parse out instructions
                string[] instNums = splits[pc].Split(' ');
                inst[0] = int.Parse(instNums[0].Trim());
                inst[1] = int.Parse(instNums[1].Trim());
                inst[2] = int.Parse(instNums[2].Trim());
                inst[3] = int.Parse(instNums[3].Trim());


                switch (inst[0])
                {
                    case 0:
                        reg = bori(reg, inst);
                        break;
                    case 1:
                        reg = muli(reg, inst);
                        break;
                    case 2:
                        reg = banr(reg, inst);
                        break;
                    case 3:
                        reg = bani(reg, inst);
                        break;
                    case 4:
                        reg = gtir(reg, inst);
                        break;
                    case 5:
                        reg = setr(reg, inst);
                        break;
                    case 6:
                        reg = addr(reg, inst);
                        break;
                    case 7:
                        reg = eqir(reg, inst);
                        break;
                    case 8:
                        reg = seti(reg, inst);
                        break;
                    case 9:
                        reg = addi(reg, inst);
                        break;
                    case 10:
                        reg = eqrr(reg, inst);
                        break;
                    case 11:
                        reg = eqri(reg, inst);
                        break;
                    case 12:
                        reg = borr(reg, inst);
                        break;
                    case 13:
                        reg = gtrr(reg, inst);
                        break;
                    case 14:
                        reg = mulr(reg, inst);
                        break;
                    case 15:
                        reg = gtri(reg, inst);
                        break;
                    default:
                        Console.WriteLine("Bad Code");
                        break;
                }
                pc++;
            }
            Console.Write(reg[0]);
            Console.ReadLine();
        }
        public static bool arrayEq(int[] a, int[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            for(int i=0; i<a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static int[] addr(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]] + before[inst[2]];
            return before;
        }

        public static int[] addi(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]] + inst[2];
            return before;
        }

        public static int[] mulr(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]] * before[inst[2]];
            return before;
        }

        public static int[] muli(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]] * inst[2];
            return before;
        }

        public static int[] banr(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]] & before[inst[2]];
            return before;
        }

        public static int[] bani(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]] & inst[2];
            return before;
        }

        public static int[] borr(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]] | before[inst[2]];
            return before;
        }

        public static int[] bori(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]] | inst[2];
            return before;
        }

        public static int[] gtir(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = inst[1] > before[inst[2]] ? 1 : 0;
            return before;
        }

        public static int[] gtri(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]] > inst[2] ? 1 : 0;
            return before;
        }

        public static int[] gtrr(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]] > before[inst[2]] ? 1 : 0;
            return before;
        }

        public static int[] eqir(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = inst[1] == before[inst[2]] ? 1 : 0;
            return before;
        }

        public static int[] eqri(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]] == inst[2] ? 1 : 0;
            return before;
        }

        public static int[] eqrr(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]] == before[inst[2]] ? 1 : 0;
            return before;
        }
        public static int[] setr(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = before[inst[1]];
            return before;
        }
        public static int[] seti(int[] bef, int[] inst)
        {
            int[] before = new int[4];
            Array.Copy(bef, before, 4);
            before[inst[3]] = inst[1];
            return before;
        }


    }
}
