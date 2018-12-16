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
            string input = @"Before: [0, 3, 0, 3]
9 0 0 1
After:  [0, 0, 0, 3]

Before: [1, 3, 3, 1]
0 3 1 0
After:  [1, 3, 3, 1]

Before: [0, 0, 1, 2]
1 0 3 3
After:  [0, 0, 1, 0]

Before: [2, 1, 2, 1]
3 1 2 2
After:  [2, 1, 0, 1]

Before: [2, 1, 2, 0]
15 2 0 1
After:  [2, 1, 2, 0]

Before: [0, 3, 0, 3]
1 0 1 2
After:  [0, 3, 0, 3]

Before: [3, 1, 0, 3]
10 0 3 2
After:  [3, 1, 1, 3]

Before: [0, 1, 2, 3]
4 1 3 1
After:  [0, 0, 2, 3]

Before: [1, 1, 1, 2]
2 1 3 1
After:  [1, 0, 1, 2]

Before: [3, 1, 2, 1]
3 1 2 1
After:  [3, 0, 2, 1]

Before: [2, 1, 3, 2]
11 0 2 3
After:  [2, 1, 3, 1]

Before: [2, 0, 3, 3]
10 2 3 0
After:  [1, 0, 3, 3]

Before: [0, 1, 2, 1]
5 3 2 2
After:  [0, 1, 1, 1]

Before: [3, 0, 0, 3]
15 3 0 0
After:  [1, 0, 0, 3]

Before: [2, 1, 3, 0]
11 0 2 2
After:  [2, 1, 1, 0]

Before: [0, 0, 2, 0]
9 0 0 3
After:  [0, 0, 2, 0]

Before: [1, 1, 0, 3]
12 1 1 0
After:  [1, 1, 0, 3]

Before: [3, 1, 2, 0]
3 1 2 3
After:  [3, 1, 2, 0]

Before: [3, 3, 2, 1]
0 3 1 2
After:  [3, 3, 1, 1]

Before: [3, 2, 2, 1]
5 3 2 1
After:  [3, 1, 2, 1]

Before: [1, 1, 3, 2]
2 1 3 2
After:  [1, 1, 0, 2]

Before: [0, 3, 2, 3]
9 0 0 3
After:  [0, 3, 2, 0]

Before: [0, 0, 1, 1]
13 2 3 0
After:  [0, 0, 1, 1]

Before: [1, 2, 3, 1]
13 3 3 1
After:  [1, 0, 3, 1]

Before: [3, 0, 3, 3]
10 0 3 1
After:  [3, 1, 3, 3]

Before: [0, 2, 2, 3]
7 3 2 0
After:  [0, 2, 2, 3]

Before: [3, 0, 0, 3]
7 3 3 0
After:  [1, 0, 0, 3]

Before: [1, 2, 0, 1]
14 0 2 1
After:  [1, 0, 0, 1]

Before: [1, 3, 0, 2]
14 0 2 0
After:  [0, 3, 0, 2]

Before: [2, 1, 2, 0]
3 1 2 1
After:  [2, 0, 2, 0]

Before: [0, 1, 2, 1]
5 3 2 3
After:  [0, 1, 2, 1]

Before: [0, 3, 1, 2]
7 0 0 2
After:  [0, 3, 1, 2]

Before: [0, 1, 1, 2]
9 0 0 0
After:  [0, 1, 1, 2]

Before: [1, 3, 0, 2]
14 0 2 2
After:  [1, 3, 0, 2]

Before: [3, 1, 0, 2]
2 1 3 0
After:  [0, 1, 0, 2]

Before: [3, 1, 2, 3]
10 0 3 3
After:  [3, 1, 2, 1]

Before: [1, 2, 2, 1]
5 3 2 2
After:  [1, 2, 1, 1]

Before: [0, 3, 0, 1]
13 3 3 0
After:  [0, 3, 0, 1]

Before: [3, 1, 2, 2]
3 1 2 3
After:  [3, 1, 2, 0]

Before: [0, 1, 2, 0]
3 1 2 2
After:  [0, 1, 0, 0]

Before: [2, 2, 3, 1]
11 0 2 2
After:  [2, 2, 1, 1]

Before: [3, 3, 2, 1]
5 3 2 0
After:  [1, 3, 2, 1]

Before: [2, 3, 3, 3]
11 0 2 1
After:  [2, 1, 3, 3]

Before: [1, 1, 2, 3]
3 1 2 3
After:  [1, 1, 2, 0]

Before: [0, 3, 2, 3]
7 3 2 0
After:  [0, 3, 2, 3]

Before: [1, 0, 2, 3]
8 0 2 2
After:  [1, 0, 0, 3]

Before: [0, 1, 3, 2]
13 3 3 0
After:  [0, 1, 3, 2]

Before: [0, 0, 0, 1]
6 0 2 1
After:  [0, 0, 0, 1]

Before: [3, 3, 1, 3]
4 2 3 1
After:  [3, 0, 1, 3]

Before: [0, 3, 0, 2]
6 0 2 3
After:  [0, 3, 0, 0]

Before: [0, 2, 0, 0]
9 0 0 3
After:  [0, 2, 0, 0]

Before: [1, 0, 2, 1]
8 0 2 1
After:  [1, 0, 2, 1]

Before: [3, 2, 0, 2]
11 2 0 2
After:  [3, 2, 1, 2]

Before: [3, 1, 2, 3]
3 1 2 2
After:  [3, 1, 0, 3]

Before: [3, 0, 2, 0]
7 2 2 0
After:  [1, 0, 2, 0]

Before: [0, 0, 3, 1]
6 0 1 2
After:  [0, 0, 0, 1]

Before: [0, 1, 0, 2]
1 0 3 1
After:  [0, 0, 0, 2]

Before: [1, 0, 2, 0]
8 0 2 3
After:  [1, 0, 2, 0]

Before: [2, 0, 3, 3]
11 0 2 2
After:  [2, 0, 1, 3]

Before: [3, 1, 3, 3]
10 0 3 0
After:  [1, 1, 3, 3]

Before: [1, 1, 1, 3]
7 3 3 0
After:  [1, 1, 1, 3]

Before: [2, 3, 3, 3]
10 2 3 1
After:  [2, 1, 3, 3]

Before: [3, 1, 3, 3]
10 0 3 1
After:  [3, 1, 3, 3]

Before: [1, 0, 1, 2]
13 3 3 3
After:  [1, 0, 1, 0]

Before: [0, 2, 1, 2]
7 0 0 1
After:  [0, 1, 1, 2]

Before: [3, 3, 2, 1]
5 3 2 1
After:  [3, 1, 2, 1]

Before: [0, 3, 1, 2]
1 0 1 2
After:  [0, 3, 0, 2]

Before: [0, 0, 3, 3]
6 0 1 2
After:  [0, 0, 0, 3]

Before: [2, 3, 2, 3]
15 2 0 2
After:  [2, 3, 1, 3]

Before: [3, 3, 1, 1]
0 3 1 0
After:  [1, 3, 1, 1]

Before: [3, 3, 2, 1]
5 3 2 2
After:  [3, 3, 1, 1]

Before: [2, 1, 2, 3]
3 1 2 2
After:  [2, 1, 0, 3]

Before: [1, 1, 0, 1]
12 1 1 0
After:  [1, 1, 0, 1]

Before: [3, 1, 2, 3]
3 1 2 3
After:  [3, 1, 2, 0]

Before: [3, 0, 3, 3]
10 2 3 1
After:  [3, 1, 3, 3]

Before: [1, 1, 2, 2]
8 0 2 0
After:  [0, 1, 2, 2]

Before: [0, 0, 0, 2]
6 0 2 0
After:  [0, 0, 0, 2]

Before: [0, 1, 2, 2]
12 1 1 3
After:  [0, 1, 2, 1]

Before: [2, 1, 1, 2]
2 1 3 2
After:  [2, 1, 0, 2]

Before: [2, 3, 2, 0]
15 2 0 3
After:  [2, 3, 2, 1]

Before: [2, 2, 1, 1]
13 3 3 0
After:  [0, 2, 1, 1]

Before: [2, 1, 3, 2]
2 1 3 3
After:  [2, 1, 3, 0]

Before: [1, 0, 3, 3]
10 2 3 0
After:  [1, 0, 3, 3]

Before: [0, 0, 0, 2]
6 0 1 2
After:  [0, 0, 0, 2]

Before: [1, 3, 3, 3]
10 2 3 3
After:  [1, 3, 3, 1]

Before: [2, 1, 3, 0]
12 1 1 3
After:  [2, 1, 3, 1]

Before: [3, 2, 1, 3]
4 2 3 1
After:  [3, 0, 1, 3]

Before: [0, 1, 3, 1]
13 3 3 0
After:  [0, 1, 3, 1]

Before: [3, 1, 3, 1]
7 2 1 1
After:  [3, 0, 3, 1]

Before: [0, 1, 1, 2]
2 1 3 1
After:  [0, 0, 1, 2]

Before: [3, 0, 2, 3]
4 2 3 2
After:  [3, 0, 0, 3]

Before: [1, 1, 0, 2]
14 0 2 3
After:  [1, 1, 0, 0]

Before: [0, 1, 2, 3]
3 1 2 3
After:  [0, 1, 2, 0]

Before: [3, 1, 0, 1]
12 1 1 3
After:  [3, 1, 0, 1]

Before: [0, 1, 3, 0]
6 0 3 1
After:  [0, 0, 3, 0]

Before: [2, 3, 2, 1]
5 3 2 0
After:  [1, 3, 2, 1]

Before: [2, 1, 3, 3]
12 1 1 1
After:  [2, 1, 3, 3]

Before: [3, 0, 0, 3]
11 2 0 1
After:  [3, 1, 0, 3]

Before: [3, 1, 1, 3]
4 1 3 3
After:  [3, 1, 1, 0]

Before: [3, 2, 0, 1]
13 3 3 2
After:  [3, 2, 0, 1]

Before: [0, 3, 0, 0]
6 0 3 3
After:  [0, 3, 0, 0]

Before: [0, 2, 2, 1]
7 0 0 3
After:  [0, 2, 2, 1]

Before: [3, 3, 3, 1]
0 3 1 3
After:  [3, 3, 3, 1]

Before: [1, 3, 1, 1]
0 3 1 0
After:  [1, 3, 1, 1]

Before: [1, 0, 0, 3]
14 0 2 0
After:  [0, 0, 0, 3]

Before: [1, 1, 3, 3]
15 3 2 2
After:  [1, 1, 1, 3]

Before: [2, 1, 2, 2]
2 1 3 2
After:  [2, 1, 0, 2]

Before: [2, 3, 1, 3]
4 2 3 0
After:  [0, 3, 1, 3]

Before: [0, 1, 1, 0]
6 0 3 2
After:  [0, 1, 0, 0]

Before: [1, 1, 2, 2]
2 1 3 0
After:  [0, 1, 2, 2]

Before: [0, 0, 2, 2]
6 0 1 1
After:  [0, 0, 2, 2]

Before: [1, 2, 2, 1]
8 0 2 3
After:  [1, 2, 2, 0]

Before: [3, 3, 2, 1]
5 3 2 3
After:  [3, 3, 2, 1]

Before: [1, 0, 0, 1]
14 0 2 3
After:  [1, 0, 0, 0]

Before: [2, 1, 2, 2]
2 1 3 0
After:  [0, 1, 2, 2]

Before: [0, 3, 0, 1]
0 3 1 1
After:  [0, 1, 0, 1]

Before: [1, 1, 0, 0]
14 0 2 3
After:  [1, 1, 0, 0]

Before: [0, 0, 3, 1]
15 2 3 3
After:  [0, 0, 3, 0]

Before: [2, 2, 1, 1]
13 3 3 1
After:  [2, 0, 1, 1]

Before: [0, 0, 3, 3]
1 0 3 3
After:  [0, 0, 3, 0]

Before: [0, 1, 1, 1]
1 0 2 0
After:  [0, 1, 1, 1]

Before: [1, 1, 0, 3]
7 3 1 2
After:  [1, 1, 0, 3]

Before: [0, 1, 2, 1]
5 3 2 1
After:  [0, 1, 2, 1]

Before: [2, 1, 1, 2]
2 1 3 0
After:  [0, 1, 1, 2]

Before: [3, 1, 3, 1]
15 2 3 3
After:  [3, 1, 3, 0]

Before: [0, 2, 0, 2]
9 0 0 0
After:  [0, 2, 0, 2]

Before: [0, 1, 2, 3]
3 1 2 2
After:  [0, 1, 0, 3]

Before: [0, 0, 0, 0]
6 0 3 3
After:  [0, 0, 0, 0]

Before: [0, 3, 2, 1]
1 0 2 0
After:  [0, 3, 2, 1]

Before: [3, 1, 3, 3]
10 2 3 2
After:  [3, 1, 1, 3]

Before: [3, 1, 3, 2]
12 1 1 3
After:  [3, 1, 3, 1]

Before: [2, 3, 2, 1]
5 3 2 3
After:  [2, 3, 2, 1]

Before: [0, 1, 1, 2]
2 1 3 3
After:  [0, 1, 1, 0]

Before: [0, 3, 1, 1]
0 3 1 3
After:  [0, 3, 1, 1]

Before: [0, 1, 0, 1]
6 0 2 0
After:  [0, 1, 0, 1]

Before: [1, 0, 0, 2]
13 3 3 3
After:  [1, 0, 0, 0]

Before: [1, 2, 2, 3]
8 0 2 3
After:  [1, 2, 2, 0]

Before: [3, 2, 0, 3]
10 0 3 2
After:  [3, 2, 1, 3]

Before: [1, 1, 2, 1]
5 3 2 2
After:  [1, 1, 1, 1]

Before: [2, 3, 3, 1]
15 2 3 3
After:  [2, 3, 3, 0]

Before: [0, 3, 0, 1]
0 3 1 0
After:  [1, 3, 0, 1]

Before: [3, 1, 3, 1]
12 1 1 2
After:  [3, 1, 1, 1]

Before: [2, 0, 3, 2]
11 0 2 1
After:  [2, 1, 3, 2]

Before: [2, 3, 2, 1]
0 3 1 1
After:  [2, 1, 2, 1]

Before: [1, 3, 2, 2]
8 0 2 0
After:  [0, 3, 2, 2]

Before: [2, 3, 3, 3]
11 0 2 0
After:  [1, 3, 3, 3]

Before: [2, 2, 2, 1]
15 2 0 2
After:  [2, 2, 1, 1]

Before: [2, 3, 3, 1]
11 0 2 1
After:  [2, 1, 3, 1]

Before: [0, 1, 0, 0]
9 0 0 2
After:  [0, 1, 0, 0]

Before: [1, 0, 0, 1]
14 0 2 0
After:  [0, 0, 0, 1]

Before: [2, 1, 2, 3]
3 1 2 1
After:  [2, 0, 2, 3]

Before: [3, 0, 0, 2]
11 2 0 3
After:  [3, 0, 0, 1]

Before: [3, 3, 2, 3]
10 0 3 1
After:  [3, 1, 2, 3]

Before: [3, 3, 0, 2]
11 2 0 3
After:  [3, 3, 0, 1]

Before: [3, 2, 2, 3]
15 3 0 0
After:  [1, 2, 2, 3]

Before: [0, 0, 2, 1]
5 3 2 2
After:  [0, 0, 1, 1]

Before: [3, 1, 0, 3]
10 0 3 0
After:  [1, 1, 0, 3]

Before: [0, 2, 3, 3]
7 3 1 1
After:  [0, 0, 3, 3]

Before: [2, 1, 2, 3]
15 2 0 2
After:  [2, 1, 1, 3]

Before: [3, 1, 2, 3]
4 1 3 3
After:  [3, 1, 2, 0]

Before: [3, 0, 2, 1]
5 3 2 2
After:  [3, 0, 1, 1]

Before: [1, 3, 0, 3]
14 0 2 1
After:  [1, 0, 0, 3]

Before: [1, 2, 0, 2]
14 0 2 3
After:  [1, 2, 0, 0]

Before: [0, 0, 3, 3]
10 2 3 2
After:  [0, 0, 1, 3]

Before: [0, 0, 2, 2]
1 0 3 3
After:  [0, 0, 2, 0]

Before: [0, 1, 3, 0]
12 1 1 0
After:  [1, 1, 3, 0]

Before: [0, 3, 3, 3]
15 3 2 3
After:  [0, 3, 3, 1]

Before: [3, 1, 0, 1]
11 2 0 0
After:  [1, 1, 0, 1]

Before: [1, 0, 0, 2]
14 0 2 0
After:  [0, 0, 0, 2]

Before: [2, 0, 2, 1]
10 0 2 1
After:  [2, 1, 2, 1]

Before: [2, 3, 3, 2]
13 3 3 3
After:  [2, 3, 3, 0]

Before: [0, 0, 2, 1]
5 3 2 0
After:  [1, 0, 2, 1]

Before: [0, 1, 2, 0]
1 0 2 0
After:  [0, 1, 2, 0]

Before: [0, 0, 2, 0]
6 0 1 0
After:  [0, 0, 2, 0]

Before: [3, 1, 2, 0]
12 1 1 0
After:  [1, 1, 2, 0]

Before: [1, 1, 0, 3]
14 0 2 0
After:  [0, 1, 0, 3]

Before: [0, 0, 3, 0]
6 0 3 2
After:  [0, 0, 0, 0]

Before: [2, 0, 2, 0]
10 0 2 1
After:  [2, 1, 2, 0]

Before: [1, 3, 3, 1]
0 3 1 3
After:  [1, 3, 3, 1]

Before: [3, 0, 0, 3]
10 0 3 3
After:  [3, 0, 0, 1]

Before: [3, 3, 1, 3]
7 3 3 3
After:  [3, 3, 1, 1]

Before: [3, 0, 3, 3]
15 3 0 2
After:  [3, 0, 1, 3]

Before: [0, 1, 2, 2]
3 1 2 2
After:  [0, 1, 0, 2]

Before: [1, 2, 0, 2]
14 0 2 1
After:  [1, 0, 0, 2]

Before: [2, 2, 1, 1]
13 2 3 1
After:  [2, 0, 1, 1]

Before: [1, 0, 2, 2]
8 0 2 1
After:  [1, 0, 2, 2]

Before: [3, 2, 0, 3]
11 2 0 2
After:  [3, 2, 1, 3]

Before: [0, 0, 3, 2]
6 0 1 2
After:  [0, 0, 0, 2]

Before: [1, 0, 2, 1]
8 0 2 3
After:  [1, 0, 2, 0]

Before: [2, 0, 3, 2]
11 0 2 2
After:  [2, 0, 1, 2]

Before: [1, 2, 0, 1]
13 3 3 3
After:  [1, 2, 0, 0]

Before: [2, 1, 3, 2]
2 1 3 1
After:  [2, 0, 3, 2]

Before: [2, 0, 2, 1]
5 3 2 3
After:  [2, 0, 2, 1]

Before: [1, 3, 3, 1]
13 3 3 3
After:  [1, 3, 3, 0]

Before: [1, 0, 2, 3]
8 0 2 0
After:  [0, 0, 2, 3]

Before: [3, 2, 2, 2]
7 2 2 0
After:  [1, 2, 2, 2]

Before: [1, 1, 2, 3]
8 0 2 2
After:  [1, 1, 0, 3]

Before: [3, 3, 1, 1]
0 3 1 2
After:  [3, 3, 1, 1]

Before: [3, 1, 1, 2]
12 1 1 1
After:  [3, 1, 1, 2]

Before: [0, 3, 3, 2]
13 3 3 1
After:  [0, 0, 3, 2]

Before: [3, 1, 0, 1]
12 1 1 0
After:  [1, 1, 0, 1]

Before: [0, 1, 2, 2]
2 1 3 0
After:  [0, 1, 2, 2]

Before: [1, 3, 0, 0]
14 0 2 3
After:  [1, 3, 0, 0]

Before: [1, 2, 0, 3]
14 0 2 0
After:  [0, 2, 0, 3]

Before: [1, 3, 0, 2]
14 0 2 3
After:  [1, 3, 0, 0]

Before: [0, 1, 0, 1]
6 0 2 2
After:  [0, 1, 0, 1]

Before: [2, 0, 2, 1]
10 0 2 3
After:  [2, 0, 2, 1]

Before: [0, 1, 3, 1]
15 2 3 2
After:  [0, 1, 0, 1]

Before: [1, 3, 0, 1]
14 0 2 1
After:  [1, 0, 0, 1]

Before: [2, 1, 3, 3]
4 1 3 3
After:  [2, 1, 3, 0]

Before: [3, 3, 3, 3]
15 3 0 1
After:  [3, 1, 3, 3]

Before: [1, 3, 0, 0]
14 0 2 0
After:  [0, 3, 0, 0]

Before: [1, 1, 0, 2]
2 1 3 2
After:  [1, 1, 0, 2]

Before: [0, 1, 2, 2]
2 1 3 3
After:  [0, 1, 2, 0]

Before: [3, 0, 0, 0]
11 2 0 3
After:  [3, 0, 0, 1]

Before: [2, 3, 0, 1]
0 3 1 2
After:  [2, 3, 1, 1]

Before: [1, 1, 2, 1]
3 1 2 3
After:  [1, 1, 2, 0]

Before: [3, 1, 3, 2]
12 1 1 2
After:  [3, 1, 1, 2]

Before: [0, 3, 1, 2]
1 0 1 3
After:  [0, 3, 1, 0]

Before: [0, 2, 1, 2]
13 3 3 2
After:  [0, 2, 0, 2]

Before: [3, 1, 3, 3]
15 3 2 0
After:  [1, 1, 3, 3]

Before: [3, 1, 0, 0]
11 2 0 1
After:  [3, 1, 0, 0]

Before: [3, 1, 2, 1]
13 3 3 1
After:  [3, 0, 2, 1]

Before: [1, 0, 2, 2]
8 0 2 2
After:  [1, 0, 0, 2]

Before: [0, 3, 0, 0]
1 0 1 2
After:  [0, 3, 0, 0]

Before: [1, 1, 3, 2]
2 1 3 1
After:  [1, 0, 3, 2]

Before: [0, 1, 3, 1]
1 0 2 2
After:  [0, 1, 0, 1]

Before: [2, 1, 2, 2]
3 1 2 0
After:  [0, 1, 2, 2]

Before: [3, 3, 3, 3]
10 2 3 0
After:  [1, 3, 3, 3]

Before: [0, 0, 1, 3]
6 0 1 2
After:  [0, 0, 0, 3]

Before: [0, 1, 2, 3]
7 3 2 2
After:  [0, 1, 0, 3]

Before: [0, 0, 3, 3]
1 0 2 2
After:  [0, 0, 0, 3]

Before: [2, 1, 2, 0]
3 1 2 3
After:  [2, 1, 2, 0]

Before: [0, 1, 0, 2]
2 1 3 1
After:  [0, 0, 0, 2]

Before: [3, 0, 0, 3]
11 2 0 0
After:  [1, 0, 0, 3]

Before: [1, 3, 2, 1]
8 0 2 3
After:  [1, 3, 2, 0]

Before: [2, 2, 2, 1]
5 3 2 0
After:  [1, 2, 2, 1]

Before: [2, 2, 2, 2]
15 2 1 3
After:  [2, 2, 2, 1]

Before: [0, 0, 3, 1]
6 0 1 1
After:  [0, 0, 3, 1]

Before: [0, 2, 0, 1]
6 0 2 2
After:  [0, 2, 0, 1]

Before: [3, 1, 0, 2]
2 1 3 1
After:  [3, 0, 0, 2]

Before: [1, 3, 0, 3]
14 0 2 3
After:  [1, 3, 0, 0]

Before: [0, 2, 1, 0]
6 0 3 0
After:  [0, 2, 1, 0]

Before: [1, 3, 2, 1]
13 3 3 0
After:  [0, 3, 2, 1]

Before: [1, 2, 0, 3]
14 0 2 1
After:  [1, 0, 0, 3]

Before: [0, 3, 3, 2]
9 0 0 2
After:  [0, 3, 0, 2]

Before: [3, 3, 0, 0]
11 2 0 3
After:  [3, 3, 0, 1]

Before: [2, 1, 2, 3]
12 1 1 2
After:  [2, 1, 1, 3]

Before: [0, 2, 0, 2]
6 0 2 3
After:  [0, 2, 0, 0]

Before: [0, 0, 3, 0]
1 0 2 2
After:  [0, 0, 0, 0]

Before: [2, 3, 3, 1]
0 3 1 3
After:  [2, 3, 3, 1]

Before: [0, 1, 0, 2]
2 1 3 3
After:  [0, 1, 0, 0]

Before: [1, 2, 3, 3]
7 3 3 3
After:  [1, 2, 3, 1]

Before: [3, 3, 1, 1]
0 3 1 3
After:  [3, 3, 1, 1]

Before: [3, 1, 0, 3]
11 2 0 2
After:  [3, 1, 1, 3]

Before: [1, 1, 2, 1]
5 3 2 1
After:  [1, 1, 2, 1]

Before: [0, 3, 0, 1]
0 3 1 2
After:  [0, 3, 1, 1]

Before: [2, 1, 3, 1]
15 2 3 1
After:  [2, 0, 3, 1]

Before: [3, 0, 1, 3]
4 2 3 1
After:  [3, 0, 1, 3]

Before: [3, 0, 2, 1]
5 3 2 0
After:  [1, 0, 2, 1]

Before: [2, 2, 2, 1]
5 3 2 1
After:  [2, 1, 2, 1]

Before: [2, 3, 2, 0]
10 0 2 1
After:  [2, 1, 2, 0]

Before: [0, 1, 1, 2]
1 0 3 0
After:  [0, 1, 1, 2]

Before: [3, 0, 3, 3]
7 3 3 3
After:  [3, 0, 3, 1]

Before: [0, 1, 0, 0]
12 1 1 0
After:  [1, 1, 0, 0]

Before: [0, 3, 2, 1]
13 3 3 0
After:  [0, 3, 2, 1]

Before: [2, 1, 2, 1]
13 3 3 2
After:  [2, 1, 0, 1]

Before: [0, 1, 1, 2]
12 1 1 3
After:  [0, 1, 1, 1]

Before: [1, 1, 0, 1]
12 1 1 1
After:  [1, 1, 0, 1]

Before: [0, 1, 3, 1]
12 1 1 3
After:  [0, 1, 3, 1]

Before: [1, 1, 0, 0]
12 1 1 2
After:  [1, 1, 1, 0]

Before: [1, 1, 1, 1]
13 2 3 1
After:  [1, 0, 1, 1]

Before: [0, 3, 3, 3]
1 0 1 0
After:  [0, 3, 3, 3]

Before: [3, 1, 0, 0]
11 2 0 2
After:  [3, 1, 1, 0]

Before: [1, 1, 2, 1]
3 1 2 0
After:  [0, 1, 2, 1]

Before: [0, 0, 0, 2]
6 0 1 3
After:  [0, 0, 0, 0]

Before: [1, 1, 0, 3]
4 1 3 0
After:  [0, 1, 0, 3]

Before: [0, 2, 0, 1]
13 3 3 3
After:  [0, 2, 0, 0]

Before: [0, 3, 0, 3]
6 0 2 1
After:  [0, 0, 0, 3]

Before: [0, 1, 0, 1]
9 0 0 2
After:  [0, 1, 0, 1]

Before: [1, 2, 3, 3]
7 3 3 1
After:  [1, 1, 3, 3]

Before: [3, 1, 1, 3]
10 0 3 2
After:  [3, 1, 1, 3]

Before: [1, 2, 2, 0]
8 0 2 1
After:  [1, 0, 2, 0]

Before: [0, 2, 0, 3]
9 0 0 0
After:  [0, 2, 0, 3]

Before: [2, 1, 2, 3]
4 1 3 1
After:  [2, 0, 2, 3]

Before: [1, 1, 0, 2]
2 1 3 3
After:  [1, 1, 0, 0]

Before: [1, 1, 2, 0]
8 0 2 1
After:  [1, 0, 2, 0]

Before: [0, 3, 3, 1]
9 0 0 1
After:  [0, 0, 3, 1]

Before: [1, 1, 2, 3]
3 1 2 2
After:  [1, 1, 0, 3]

Before: [0, 0, 1, 2]
9 0 0 2
After:  [0, 0, 0, 2]

Before: [3, 3, 0, 1]
0 3 1 1
After:  [3, 1, 0, 1]

Before: [0, 1, 1, 2]
2 1 3 2
After:  [0, 1, 0, 2]

Before: [0, 0, 0, 0]
9 0 0 3
After:  [0, 0, 0, 0]

Before: [2, 2, 2, 1]
5 3 2 2
After:  [2, 2, 1, 1]

Before: [0, 1, 3, 3]
10 2 3 2
After:  [0, 1, 1, 3]

Before: [3, 0, 2, 2]
13 3 3 2
After:  [3, 0, 0, 2]

Before: [2, 1, 2, 2]
2 1 3 1
After:  [2, 0, 2, 2]

Before: [3, 1, 1, 3]
12 1 1 3
After:  [3, 1, 1, 1]

Before: [0, 1, 1, 1]
9 0 0 1
After:  [0, 0, 1, 1]

Before: [1, 1, 2, 3]
3 1 2 0
After:  [0, 1, 2, 3]

Before: [3, 2, 2, 1]
5 3 2 2
After:  [3, 2, 1, 1]

Before: [3, 0, 2, 1]
5 3 2 3
After:  [3, 0, 2, 1]

Before: [2, 3, 1, 1]
0 3 1 1
After:  [2, 1, 1, 1]

Before: [0, 3, 0, 1]
9 0 0 2
After:  [0, 3, 0, 1]

Before: [2, 1, 2, 3]
7 2 2 0
After:  [1, 1, 2, 3]

Before: [1, 1, 2, 0]
8 0 2 3
After:  [1, 1, 2, 0]

Before: [3, 1, 2, 2]
3 1 2 1
After:  [3, 0, 2, 2]

Before: [1, 2, 2, 3]
8 0 2 2
After:  [1, 2, 0, 3]

Before: [2, 1, 1, 2]
2 1 3 1
After:  [2, 0, 1, 2]

Before: [0, 1, 2, 1]
3 1 2 3
After:  [0, 1, 2, 0]

Before: [1, 0, 0, 3]
14 0 2 2
After:  [1, 0, 0, 3]

Before: [1, 0, 0, 1]
14 0 2 1
After:  [1, 0, 0, 1]

Before: [3, 1, 0, 1]
11 2 0 1
After:  [3, 1, 0, 1]

Before: [3, 3, 2, 3]
4 2 3 2
After:  [3, 3, 0, 3]

Before: [0, 1, 2, 1]
1 0 3 2
After:  [0, 1, 0, 1]

Before: [0, 2, 2, 1]
5 3 2 1
After:  [0, 1, 2, 1]

Before: [3, 1, 2, 1]
5 3 2 0
After:  [1, 1, 2, 1]

Before: [1, 1, 2, 0]
3 1 2 2
After:  [1, 1, 0, 0]

Before: [1, 1, 2, 2]
7 2 2 3
After:  [1, 1, 2, 1]

Before: [1, 3, 2, 2]
7 2 2 0
After:  [1, 3, 2, 2]

Before: [0, 1, 2, 2]
2 1 3 2
After:  [0, 1, 0, 2]

Before: [0, 0, 2, 3]
6 0 1 3
After:  [0, 0, 2, 0]

Before: [0, 3, 3, 3]
7 0 0 2
After:  [0, 3, 1, 3]

Before: [0, 0, 2, 1]
5 3 2 1
After:  [0, 1, 2, 1]

Before: [1, 3, 0, 1]
14 0 2 0
After:  [0, 3, 0, 1]

Before: [3, 1, 0, 2]
12 1 1 1
After:  [3, 1, 0, 2]

Before: [2, 3, 1, 1]
0 3 1 2
After:  [2, 3, 1, 1]

Before: [0, 0, 2, 0]
6 0 3 0
After:  [0, 0, 2, 0]

Before: [0, 2, 1, 3]
7 3 2 3
After:  [0, 2, 1, 0]

Before: [0, 1, 2, 3]
3 1 2 1
After:  [0, 0, 2, 3]

Before: [0, 3, 3, 1]
0 3 1 0
After:  [1, 3, 3, 1]

Before: [1, 1, 0, 0]
14 0 2 1
After:  [1, 0, 0, 0]

Before: [3, 3, 3, 1]
0 3 1 1
After:  [3, 1, 3, 1]

Before: [1, 1, 1, 2]
2 1 3 2
After:  [1, 1, 0, 2]

Before: [0, 3, 2, 1]
5 3 2 2
After:  [0, 3, 1, 1]

Before: [2, 1, 1, 0]
12 1 1 1
After:  [2, 1, 1, 0]

Before: [2, 3, 1, 3]
4 2 3 3
After:  [2, 3, 1, 0]

Before: [0, 1, 0, 0]
6 0 3 1
After:  [0, 0, 0, 0]

Before: [2, 0, 2, 2]
10 0 2 0
After:  [1, 0, 2, 2]

Before: [1, 3, 2, 1]
0 3 1 3
After:  [1, 3, 2, 1]

Before: [1, 3, 2, 0]
8 0 2 1
After:  [1, 0, 2, 0]

Before: [2, 3, 2, 1]
10 0 2 0
After:  [1, 3, 2, 1]

Before: [1, 3, 2, 1]
0 3 1 0
After:  [1, 3, 2, 1]

Before: [1, 0, 2, 1]
5 3 2 3
After:  [1, 0, 2, 1]

Before: [2, 1, 2, 2]
10 0 2 2
After:  [2, 1, 1, 2]

Before: [3, 1, 0, 3]
7 3 3 3
After:  [3, 1, 0, 1]

Before: [1, 3, 3, 1]
0 3 1 1
After:  [1, 1, 3, 1]

Before: [2, 3, 3, 3]
10 2 3 2
After:  [2, 3, 1, 3]

Before: [3, 2, 0, 1]
11 2 0 2
After:  [3, 2, 1, 1]

Before: [0, 0, 2, 1]
7 0 0 0
After:  [1, 0, 2, 1]

Before: [1, 2, 2, 0]
15 2 1 2
After:  [1, 2, 1, 0]

Before: [0, 2, 1, 1]
1 0 3 0
After:  [0, 2, 1, 1]

Before: [0, 1, 3, 1]
9 0 0 3
After:  [0, 1, 3, 0]

Before: [0, 0, 3, 1]
1 0 2 3
After:  [0, 0, 3, 0]

Before: [0, 3, 3, 0]
1 0 2 3
After:  [0, 3, 3, 0]

Before: [2, 2, 2, 0]
7 2 2 3
After:  [2, 2, 2, 1]

Before: [1, 2, 2, 2]
8 0 2 1
After:  [1, 0, 2, 2]

Before: [1, 3, 2, 2]
8 0 2 3
After:  [1, 3, 2, 0]

Before: [0, 2, 1, 1]
13 3 3 3
After:  [0, 2, 1, 0]

Before: [3, 0, 3, 1]
15 2 3 2
After:  [3, 0, 0, 1]

Before: [1, 3, 2, 1]
8 0 2 2
After:  [1, 3, 0, 1]

Before: [3, 3, 2, 3]
4 2 3 0
After:  [0, 3, 2, 3]

Before: [2, 1, 3, 3]
10 2 3 0
After:  [1, 1, 3, 3]

Before: [0, 3, 0, 2]
9 0 0 2
After:  [0, 3, 0, 2]

Before: [3, 1, 1, 1]
12 1 1 2
After:  [3, 1, 1, 1]

Before: [0, 0, 0, 0]
9 0 0 0
After:  [0, 0, 0, 0]

Before: [3, 3, 0, 0]
11 2 0 1
After:  [3, 1, 0, 0]

Before: [1, 2, 0, 3]
4 1 3 0
After:  [0, 2, 0, 3]

Before: [3, 1, 2, 3]
3 1 2 0
After:  [0, 1, 2, 3]

Before: [1, 1, 0, 3]
4 1 3 2
After:  [1, 1, 0, 3]

Before: [1, 2, 2, 3]
8 0 2 1
After:  [1, 0, 2, 3]

Before: [0, 0, 3, 0]
6 0 1 0
After:  [0, 0, 3, 0]

Before: [0, 1, 1, 2]
2 1 3 0
After:  [0, 1, 1, 2]

Before: [0, 2, 0, 3]
7 3 1 0
After:  [0, 2, 0, 3]

Before: [2, 1, 3, 2]
2 1 3 0
After:  [0, 1, 3, 2]

Before: [1, 1, 0, 2]
14 0 2 2
After:  [1, 1, 0, 2]

Before: [1, 3, 0, 2]
14 0 2 1
After:  [1, 0, 0, 2]

Before: [0, 1, 0, 1]
6 0 2 3
After:  [0, 1, 0, 0]

Before: [1, 0, 1, 3]
4 2 3 3
After:  [1, 0, 1, 0]

Before: [2, 2, 2, 3]
7 3 2 3
After:  [2, 2, 2, 0]

Before: [0, 1, 1, 2]
13 3 3 1
After:  [0, 0, 1, 2]

Before: [0, 3, 1, 1]
0 3 1 2
After:  [0, 3, 1, 1]

Before: [0, 3, 1, 3]
4 2 3 3
After:  [0, 3, 1, 0]

Before: [3, 0, 2, 3]
10 0 3 0
After:  [1, 0, 2, 3]

Before: [2, 1, 2, 1]
5 3 2 0
After:  [1, 1, 2, 1]

Before: [1, 3, 0, 0]
14 0 2 2
After:  [1, 3, 0, 0]

Before: [0, 0, 0, 0]
6 0 3 1
After:  [0, 0, 0, 0]

Before: [1, 2, 0, 3]
14 0 2 2
After:  [1, 2, 0, 3]

Before: [1, 2, 2, 1]
8 0 2 0
After:  [0, 2, 2, 1]

Before: [2, 3, 2, 3]
4 2 3 1
After:  [2, 0, 2, 3]

Before: [1, 3, 2, 1]
5 3 2 0
After:  [1, 3, 2, 1]

Before: [1, 3, 2, 3]
8 0 2 1
After:  [1, 0, 2, 3]

Before: [3, 3, 2, 1]
13 3 3 3
After:  [3, 3, 2, 0]

Before: [0, 1, 1, 3]
9 0 0 2
After:  [0, 1, 0, 3]

Before: [0, 1, 3, 2]
2 1 3 2
After:  [0, 1, 0, 2]

Before: [2, 3, 0, 1]
0 3 1 1
After:  [2, 1, 0, 1]

Before: [3, 1, 2, 0]
7 2 2 3
After:  [3, 1, 2, 1]

Before: [1, 1, 2, 3]
12 1 1 0
After:  [1, 1, 2, 3]

Before: [1, 1, 2, 1]
3 1 2 2
After:  [1, 1, 0, 1]

Before: [0, 0, 3, 0]
6 0 3 1
After:  [0, 0, 3, 0]

Before: [2, 3, 2, 3]
7 3 3 0
After:  [1, 3, 2, 3]

Before: [2, 1, 0, 2]
13 3 3 3
After:  [2, 1, 0, 0]

Before: [2, 2, 0, 3]
7 3 3 2
After:  [2, 2, 1, 3]

Before: [0, 1, 2, 0]
7 2 2 2
After:  [0, 1, 1, 0]

Before: [3, 3, 3, 1]
0 3 1 0
After:  [1, 3, 3, 1]

Before: [2, 1, 3, 1]
11 0 2 2
After:  [2, 1, 1, 1]

Before: [0, 3, 1, 1]
0 3 1 0
After:  [1, 3, 1, 1]

Before: [0, 0, 0, 1]
6 0 2 2
After:  [0, 0, 0, 1]

Before: [2, 0, 3, 3]
11 0 2 0
After:  [1, 0, 3, 3]

Before: [1, 3, 0, 0]
14 0 2 1
After:  [1, 0, 0, 0]

Before: [2, 0, 1, 3]
4 2 3 1
After:  [2, 0, 1, 3]

Before: [3, 1, 2, 0]
3 1 2 2
After:  [3, 1, 0, 0]

Before: [0, 1, 1, 3]
1 0 3 0
After:  [0, 1, 1, 3]

Before: [1, 2, 0, 1]
14 0 2 2
After:  [1, 2, 0, 1]

Before: [2, 1, 3, 3]
15 3 2 0
After:  [1, 1, 3, 3]

Before: [1, 2, 1, 3]
7 3 2 1
After:  [1, 0, 1, 3]

Before: [1, 1, 0, 0]
14 0 2 0
After:  [0, 1, 0, 0]

Before: [2, 2, 3, 3]
10 2 3 3
After:  [2, 2, 3, 1]

Before: [0, 3, 2, 0]
9 0 0 1
After:  [0, 0, 2, 0]

Before: [2, 3, 1, 1]
0 3 1 0
After:  [1, 3, 1, 1]

Before: [2, 3, 1, 1]
13 2 3 1
After:  [2, 0, 1, 1]

Before: [1, 0, 1, 3]
4 2 3 0
After:  [0, 0, 1, 3]

Before: [3, 2, 2, 1]
15 2 1 0
After:  [1, 2, 2, 1]

Before: [1, 3, 3, 3]
10 2 3 1
After:  [1, 1, 3, 3]

Before: [2, 3, 3, 3]
11 0 2 3
After:  [2, 3, 3, 1]

Before: [0, 3, 3, 3]
1 0 3 1
After:  [0, 0, 3, 3]

Before: [1, 1, 0, 2]
14 0 2 1
After:  [1, 0, 0, 2]

Before: [3, 2, 2, 1]
5 3 2 3
After:  [3, 2, 2, 1]

Before: [1, 1, 0, 2]
14 0 2 0
After:  [0, 1, 0, 2]

Before: [0, 0, 1, 0]
6 0 3 0
After:  [0, 0, 1, 0]

Before: [3, 3, 1, 2]
13 3 3 0
After:  [0, 3, 1, 2]

Before: [1, 1, 0, 1]
14 0 2 1
After:  [1, 0, 0, 1]

Before: [0, 1, 3, 3]
10 2 3 3
After:  [0, 1, 3, 1]

Before: [0, 2, 1, 3]
7 0 0 1
After:  [0, 1, 1, 3]

Before: [0, 2, 2, 1]
9 0 0 0
After:  [0, 2, 2, 1]

Before: [0, 2, 3, 1]
1 0 2 3
After:  [0, 2, 3, 0]

Before: [1, 2, 0, 3]
7 3 1 1
After:  [1, 0, 0, 3]

Before: [1, 0, 2, 0]
8 0 2 2
After:  [1, 0, 0, 0]

Before: [3, 3, 0, 3]
11 2 0 3
After:  [3, 3, 0, 1]

Before: [0, 1, 0, 3]
4 1 3 2
After:  [0, 1, 0, 3]

Before: [3, 2, 0, 3]
15 3 0 1
After:  [3, 1, 0, 3]

Before: [2, 3, 0, 1]
0 3 1 0
After:  [1, 3, 0, 1]

Before: [0, 0, 0, 0]
6 0 1 1
After:  [0, 0, 0, 0]

Before: [3, 2, 2, 3]
15 3 0 2
After:  [3, 2, 1, 3]

Before: [0, 3, 0, 0]
9 0 0 0
After:  [0, 3, 0, 0]

Before: [0, 1, 2, 1]
12 1 1 2
After:  [0, 1, 1, 1]

Before: [3, 1, 2, 3]
4 1 3 0
After:  [0, 1, 2, 3]

Before: [2, 1, 3, 3]
12 1 1 3
After:  [2, 1, 3, 1]

Before: [1, 2, 3, 2]
13 3 3 3
After:  [1, 2, 3, 0]

Before: [2, 2, 2, 3]
4 1 3 1
After:  [2, 0, 2, 3]

Before: [3, 1, 1, 3]
4 1 3 2
After:  [3, 1, 0, 3]

Before: [3, 2, 0, 3]
11 2 0 3
After:  [3, 2, 0, 1]

Before: [2, 3, 3, 3]
11 0 2 2
After:  [2, 3, 1, 3]

Before: [3, 2, 2, 1]
5 3 2 0
After:  [1, 2, 2, 1]

Before: [3, 2, 0, 0]
11 2 0 2
After:  [3, 2, 1, 0]

Before: [0, 0, 1, 1]
6 0 1 2
After:  [0, 0, 0, 1]

Before: [1, 1, 2, 2]
2 1 3 2
After:  [1, 1, 0, 2]

Before: [0, 0, 2, 2]
7 0 0 3
After:  [0, 0, 2, 1]

Before: [3, 1, 0, 3]
4 1 3 1
After:  [3, 0, 0, 3]

Before: [2, 1, 1, 0]
12 1 1 2
After:  [2, 1, 1, 0]

Before: [1, 1, 1, 3]
12 1 1 0
After:  [1, 1, 1, 3]

Before: [2, 1, 0, 3]
12 1 1 3
After:  [2, 1, 0, 1]

Before: [3, 1, 2, 2]
2 1 3 2
After:  [3, 1, 0, 2]

Before: [0, 0, 3, 2]
9 0 0 0
After:  [0, 0, 3, 2]

Before: [1, 1, 0, 1]
12 1 1 2
After:  [1, 1, 1, 1]

Before: [2, 1, 3, 2]
11 0 2 1
After:  [2, 1, 3, 2]

Before: [1, 0, 2, 2]
13 3 3 3
After:  [1, 0, 2, 0]

Before: [1, 1, 3, 2]
13 3 3 1
After:  [1, 0, 3, 2]

Before: [3, 2, 0, 2]
11 2 0 1
After:  [3, 1, 0, 2]

Before: [3, 3, 0, 3]
10 0 3 1
After:  [3, 1, 0, 3]

Before: [0, 2, 2, 3]
7 3 3 2
After:  [0, 2, 1, 3]

Before: [1, 1, 2, 3]
7 3 2 2
After:  [1, 1, 0, 3]

Before: [0, 1, 2, 1]
3 1 2 2
After:  [0, 1, 0, 1]

Before: [0, 1, 2, 1]
3 1 2 1
After:  [0, 0, 2, 1]

Before: [0, 2, 2, 0]
15 2 1 1
After:  [0, 1, 2, 0]

Before: [1, 1, 3, 3]
10 2 3 0
After:  [1, 1, 3, 3]

Before: [2, 3, 2, 1]
0 3 1 2
After:  [2, 3, 1, 1]

Before: [0, 0, 3, 0]
9 0 0 0
After:  [0, 0, 3, 0]

Before: [3, 1, 2, 3]
10 0 3 1
After:  [3, 1, 2, 3]

Before: [3, 1, 2, 0]
12 1 1 2
After:  [3, 1, 1, 0]

Before: [1, 0, 3, 3]
15 3 2 2
After:  [1, 0, 1, 3]

Before: [3, 0, 1, 3]
4 2 3 2
After:  [3, 0, 0, 3]

Before: [1, 2, 0, 0]
14 0 2 0
After:  [0, 2, 0, 0]

Before: [3, 1, 2, 1]
5 3 2 3
After:  [3, 1, 2, 1]

Before: [2, 3, 2, 1]
15 2 0 3
After:  [2, 3, 2, 1]

Before: [3, 1, 3, 3]
4 1 3 3
After:  [3, 1, 3, 0]

Before: [1, 1, 2, 1]
5 3 2 3
After:  [1, 1, 2, 1]

Before: [0, 3, 0, 0]
6 0 3 2
After:  [0, 3, 0, 0]

Before: [0, 0, 3, 1]
1 0 2 0
After:  [0, 0, 3, 1]

Before: [0, 2, 0, 3]
4 1 3 1
After:  [0, 0, 0, 3]

Before: [3, 1, 0, 2]
11 2 0 1
After:  [3, 1, 0, 2]

Before: [0, 0, 2, 1]
5 3 2 3
After:  [0, 0, 2, 1]

Before: [1, 3, 2, 1]
8 0 2 0
After:  [0, 3, 2, 1]

Before: [0, 1, 2, 2]
2 1 3 1
After:  [0, 0, 2, 2]

Before: [1, 1, 2, 1]
12 1 1 2
After:  [1, 1, 1, 1]

Before: [0, 3, 0, 1]
6 0 2 3
After:  [0, 3, 0, 0]

Before: [1, 3, 3, 3]
10 2 3 2
After:  [1, 3, 1, 3]

Before: [3, 1, 3, 3]
15 3 0 0
After:  [1, 1, 3, 3]

Before: [2, 1, 2, 3]
4 1 3 2
After:  [2, 1, 0, 3]

Before: [0, 3, 2, 2]
13 3 3 3
After:  [0, 3, 2, 0]

Before: [1, 2, 2, 2]
8 0 2 2
After:  [1, 2, 0, 2]

Before: [1, 2, 0, 0]
14 0 2 1
After:  [1, 0, 0, 0]

Before: [1, 3, 3, 2]
13 3 3 1
After:  [1, 0, 3, 2]

Before: [1, 1, 3, 2]
2 1 3 3
After:  [1, 1, 3, 0]

Before: [0, 3, 2, 1]
0 3 1 1
After:  [0, 1, 2, 1]

Before: [3, 3, 0, 1]
11 2 0 2
After:  [3, 3, 1, 1]

Before: [0, 1, 0, 3]
6 0 2 0
After:  [0, 1, 0, 3]

Before: [0, 3, 3, 1]
15 2 3 1
After:  [0, 0, 3, 1]

Before: [0, 1, 3, 1]
13 3 3 2
After:  [0, 1, 0, 1]

Before: [1, 2, 2, 1]
5 3 2 3
After:  [1, 2, 2, 1]

Before: [2, 0, 2, 1]
13 3 3 1
After:  [2, 0, 2, 1]

Before: [1, 1, 3, 3]
15 3 2 3
After:  [1, 1, 3, 1]

Before: [3, 1, 2, 2]
3 1 2 2
After:  [3, 1, 0, 2]

Before: [2, 0, 2, 2]
10 0 2 3
After:  [2, 0, 2, 1]

Before: [0, 0, 2, 3]
9 0 0 2
After:  [0, 0, 0, 3]

Before: [0, 2, 2, 2]
9 0 0 3
After:  [0, 2, 2, 0]

Before: [0, 1, 2, 0]
9 0 0 3
After:  [0, 1, 2, 0]

Before: [1, 2, 2, 0]
8 0 2 0
After:  [0, 2, 2, 0]

Before: [2, 3, 2, 3]
4 2 3 0
After:  [0, 3, 2, 3]

Before: [0, 3, 2, 1]
0 3 1 3
After:  [0, 3, 2, 1]

Before: [0, 1, 1, 0]
1 0 2 2
After:  [0, 1, 0, 0]

Before: [1, 2, 2, 3]
4 1 3 1
After:  [1, 0, 2, 3]

Before: [0, 1, 2, 3]
3 1 2 0
After:  [0, 1, 2, 3]

Before: [0, 3, 0, 0]
9 0 0 1
After:  [0, 0, 0, 0]

Before: [3, 1, 1, 1]
13 3 3 2
After:  [3, 1, 0, 1]

Before: [1, 1, 2, 3]
3 1 2 1
After:  [1, 0, 2, 3]

Before: [2, 0, 2, 1]
5 3 2 0
After:  [1, 0, 2, 1]

Before: [0, 0, 1, 1]
1 0 3 3
After:  [0, 0, 1, 0]

Before: [0, 3, 2, 2]
7 0 0 2
After:  [0, 3, 1, 2]

Before: [1, 1, 2, 0]
8 0 2 2
After:  [1, 1, 0, 0]

Before: [1, 1, 2, 1]
8 0 2 0
After:  [0, 1, 2, 1]

Before: [0, 0, 3, 3]
6 0 1 3
After:  [0, 0, 3, 0]

Before: [2, 0, 2, 2]
15 2 0 2
After:  [2, 0, 1, 2]

Before: [2, 3, 3, 2]
13 3 3 2
After:  [2, 3, 0, 2]

Before: [2, 2, 2, 3]
4 2 3 1
After:  [2, 0, 2, 3]

Before: [1, 3, 0, 1]
0 3 1 3
After:  [1, 3, 0, 1]

Before: [0, 3, 1, 3]
1 0 1 0
After:  [0, 3, 1, 3]

Before: [2, 2, 2, 0]
10 0 2 3
After:  [2, 2, 2, 1]

Before: [0, 0, 1, 1]
9 0 0 0
After:  [0, 0, 1, 1]

Before: [0, 1, 0, 1]
6 0 2 1
After:  [0, 0, 0, 1]

Before: [2, 1, 2, 2]
3 1 2 3
After:  [2, 1, 2, 0]

Before: [0, 1, 2, 3]
9 0 0 0
After:  [0, 1, 2, 3]

Before: [3, 1, 2, 3]
15 3 0 0
After:  [1, 1, 2, 3]

Before: [0, 2, 0, 1]
1 0 1 3
After:  [0, 2, 0, 0]

Before: [1, 2, 0, 0]
14 0 2 3
After:  [1, 2, 0, 0]

Before: [2, 1, 2, 3]
3 1 2 3
After:  [2, 1, 2, 0]

Before: [0, 2, 3, 0]
6 0 3 3
After:  [0, 2, 3, 0]

Before: [1, 2, 2, 0]
8 0 2 3
After:  [1, 2, 2, 0]

Before: [3, 1, 2, 3]
12 1 1 2
After:  [3, 1, 1, 3]

Before: [3, 0, 1, 2]
13 3 3 0
After:  [0, 0, 1, 2]

Before: [0, 2, 2, 1]
5 3 2 2
After:  [0, 2, 1, 1]

Before: [3, 1, 2, 1]
5 3 2 2
After:  [3, 1, 1, 1]

Before: [2, 3, 3, 1]
0 3 1 1
After:  [2, 1, 3, 1]

Before: [1, 3, 2, 3]
8 0 2 2
After:  [1, 3, 0, 3]

Before: [0, 2, 2, 0]
1 0 2 1
After:  [0, 0, 2, 0]

Before: [2, 3, 2, 1]
0 3 1 3
After:  [2, 3, 2, 1]

Before: [2, 1, 0, 2]
2 1 3 1
After:  [2, 0, 0, 2]

Before: [0, 0, 3, 3]
7 0 0 0
After:  [1, 0, 3, 3]

Before: [0, 0, 3, 1]
9 0 0 0
After:  [0, 0, 3, 1]

Before: [2, 2, 3, 2]
11 0 2 3
After:  [2, 2, 3, 1]

Before: [2, 0, 1, 3]
7 3 2 1
After:  [2, 0, 1, 3]

Before: [3, 2, 2, 1]
15 2 1 1
After:  [3, 1, 2, 1]

Before: [0, 1, 3, 1]
9 0 0 1
After:  [0, 0, 3, 1]

Before: [0, 3, 3, 1]
0 3 1 2
After:  [0, 3, 1, 1]

Before: [0, 3, 2, 1]
9 0 0 3
After:  [0, 3, 2, 0]

Before: [3, 2, 0, 1]
13 3 3 1
After:  [3, 0, 0, 1]

Before: [1, 1, 0, 2]
2 1 3 1
After:  [1, 0, 0, 2]

Before: [0, 1, 0, 2]
12 1 1 3
After:  [0, 1, 0, 1]

Before: [3, 1, 3, 3]
15 3 0 1
After:  [3, 1, 3, 3]

Before: [0, 2, 1, 3]
9 0 0 0
After:  [0, 2, 1, 3]

Before: [0, 2, 1, 0]
6 0 3 1
After:  [0, 0, 1, 0]

Before: [1, 1, 2, 2]
3 1 2 1
After:  [1, 0, 2, 2]

Before: [3, 1, 0, 2]
11 2 0 3
After:  [3, 1, 0, 1]

Before: [3, 2, 2, 2]
13 3 3 0
After:  [0, 2, 2, 2]

Before: [2, 2, 3, 2]
11 0 2 1
After:  [2, 1, 3, 2]

Before: [3, 3, 0, 2]
11 2 0 2
After:  [3, 3, 1, 2]

Before: [1, 3, 0, 1]
0 3 1 1
After:  [1, 1, 0, 1]

Before: [3, 1, 2, 2]
2 1 3 1
After:  [3, 0, 2, 2]

Before: [3, 1, 2, 1]
3 1 2 3
After:  [3, 1, 2, 0]

Before: [3, 1, 2, 1]
5 3 2 1
After:  [3, 1, 2, 1]

Before: [0, 2, 0, 2]
1 0 1 2
After:  [0, 2, 0, 2]

Before: [2, 3, 2, 1]
7 2 2 1
After:  [2, 1, 2, 1]

Before: [1, 0, 0, 0]
14 0 2 3
After:  [1, 0, 0, 0]

Before: [0, 3, 1, 1]
7 0 0 3
After:  [0, 3, 1, 1]

Before: [0, 2, 1, 0]
6 0 3 2
After:  [0, 2, 0, 0]

Before: [1, 2, 1, 3]
4 2 3 2
After:  [1, 2, 0, 3]

Before: [1, 3, 3, 1]
0 3 1 2
After:  [1, 3, 1, 1]

Before: [3, 2, 2, 2]
15 2 1 2
After:  [3, 2, 1, 2]

Before: [1, 3, 1, 1]
0 3 1 2
After:  [1, 3, 1, 1]

Before: [3, 2, 2, 3]
4 1 3 1
After:  [3, 0, 2, 3]

Before: [0, 2, 2, 2]
7 0 0 0
After:  [1, 2, 2, 2]

Before: [0, 2, 2, 3]
4 1 3 0
After:  [0, 2, 2, 3]

Before: [1, 1, 0, 0]
12 1 1 3
After:  [1, 1, 0, 1]

Before: [0, 2, 3, 1]
13 3 3 1
After:  [0, 0, 3, 1]

Before: [0, 2, 2, 0]
6 0 3 2
After:  [0, 2, 0, 0]

Before: [0, 2, 3, 2]
9 0 0 1
After:  [0, 0, 3, 2]

Before: [2, 1, 1, 2]
13 3 3 0
After:  [0, 1, 1, 2]

Before: [0, 1, 3, 2]
1 0 3 1
After:  [0, 0, 3, 2]

Before: [0, 0, 2, 0]
9 0 0 2
After:  [0, 0, 0, 0]

Before: [1, 3, 2, 2]
8 0 2 1
After:  [1, 0, 2, 2]

Before: [0, 2, 2, 2]
15 2 1 1
After:  [0, 1, 2, 2]

Before: [1, 2, 1, 3]
4 2 3 3
After:  [1, 2, 1, 0]

Before: [1, 0, 2, 1]
5 3 2 1
After:  [1, 1, 2, 1]

Before: [2, 2, 2, 2]
15 2 1 0
After:  [1, 2, 2, 2]

Before: [2, 0, 3, 2]
13 3 3 3
After:  [2, 0, 3, 0]

Before: [2, 2, 2, 2]
10 0 2 0
After:  [1, 2, 2, 2]

Before: [1, 3, 2, 3]
8 0 2 3
After:  [1, 3, 2, 0]

Before: [0, 3, 2, 1]
5 3 2 0
After:  [1, 3, 2, 1]

Before: [0, 0, 1, 3]
6 0 1 0
After:  [0, 0, 1, 3]

Before: [0, 2, 2, 0]
7 0 0 2
After:  [0, 2, 1, 0]

Before: [1, 1, 1, 3]
4 2 3 0
After:  [0, 1, 1, 3]

Before: [3, 2, 1, 1]
13 2 3 0
After:  [0, 2, 1, 1]

Before: [2, 1, 2, 0]
3 1 2 2
After:  [2, 1, 0, 0]

Before: [1, 3, 1, 3]
4 2 3 0
After:  [0, 3, 1, 3]

Before: [2, 0, 3, 0]
11 0 2 3
After:  [2, 0, 3, 1]

Before: [1, 1, 2, 1]
8 0 2 2
After:  [1, 1, 0, 1]

Before: [0, 0, 3, 1]
9 0 0 2
After:  [0, 0, 0, 1]

Before: [2, 3, 2, 1]
0 3 1 0
After:  [1, 3, 2, 1]

Before: [1, 3, 0, 1]
0 3 1 0
After:  [1, 3, 0, 1]

Before: [1, 3, 1, 1]
13 2 3 2
After:  [1, 3, 0, 1]

Before: [2, 1, 3, 1]
11 0 2 1
After:  [2, 1, 3, 1]

Before: [1, 1, 0, 3]
14 0 2 1
After:  [1, 0, 0, 3]

Before: [0, 0, 0, 1]
9 0 0 1
After:  [0, 0, 0, 1]

Before: [1, 1, 2, 3]
8 0 2 3
After:  [1, 1, 2, 0]

Before: [3, 1, 0, 1]
11 2 0 2
After:  [3, 1, 1, 1]

Before: [2, 1, 2, 0]
10 0 2 3
After:  [2, 1, 2, 1]

Before: [3, 0, 1, 3]
10 0 3 1
After:  [3, 1, 1, 3]

Before: [0, 3, 1, 3]
1 0 3 2
After:  [0, 3, 0, 3]

Before: [1, 1, 2, 0]
8 0 2 0
After:  [0, 1, 2, 0]

Before: [1, 1, 2, 1]
8 0 2 1
After:  [1, 0, 2, 1]

Before: [2, 1, 2, 2]
15 2 0 1
After:  [2, 1, 2, 2]

Before: [0, 0, 2, 0]
7 2 2 0
After:  [1, 0, 2, 0]

Before: [3, 3, 2, 3]
15 3 0 2
After:  [3, 3, 1, 3]

Before: [0, 2, 2, 3]
1 0 2 3
After:  [0, 2, 2, 0]

Before: [1, 2, 0, 3]
14 0 2 3
After:  [1, 2, 0, 0]

Before: [3, 0, 3, 2]
13 3 3 1
After:  [3, 0, 3, 2]

Before: [0, 0, 2, 1]
6 0 1 2
After:  [0, 0, 0, 1]

Before: [2, 0, 3, 1]
11 0 2 2
After:  [2, 0, 1, 1]

Before: [1, 1, 0, 1]
14 0 2 0
After:  [0, 1, 0, 1]

Before: [2, 2, 3, 0]
11 0 2 1
After:  [2, 1, 3, 0]

Before: [3, 1, 0, 3]
7 3 1 2
After:  [3, 1, 0, 3]

Before: [0, 2, 1, 2]
1 0 2 0
After:  [0, 2, 1, 2]

Before: [0, 3, 1, 3]
4 2 3 1
After:  [0, 0, 1, 3]

Before: [1, 2, 0, 2]
14 0 2 2
After:  [1, 2, 0, 2]

Before: [1, 1, 2, 2]
2 1 3 3
After:  [1, 1, 2, 0]

Before: [3, 1, 2, 0]
3 1 2 1
After:  [3, 0, 2, 0]

Before: [0, 3, 3, 1]
7 0 0 0
After:  [1, 3, 3, 1]

Before: [0, 3, 0, 0]
6 0 3 1
After:  [0, 0, 0, 0]

Before: [3, 3, 0, 1]
11 2 0 1
After:  [3, 1, 0, 1]

Before: [3, 2, 0, 3]
11 2 0 1
After:  [3, 1, 0, 3]

Before: [2, 1, 2, 2]
7 2 2 2
After:  [2, 1, 1, 2]

Before: [3, 3, 1, 1]
13 3 3 2
After:  [3, 3, 0, 1]

Before: [3, 1, 0, 2]
11 2 0 2
After:  [3, 1, 1, 2]

Before: [0, 3, 1, 0]
1 0 1 2
After:  [0, 3, 0, 0]

Before: [1, 1, 3, 1]
13 3 3 2
After:  [1, 1, 0, 1]

Before: [2, 1, 2, 2]
3 1 2 2
After:  [2, 1, 0, 2]

Before: [0, 0, 1, 3]
9 0 0 3
After:  [0, 0, 1, 0]

Before: [3, 3, 0, 1]
0 3 1 0
After:  [1, 3, 0, 1]

Before: [1, 0, 0, 0]
14 0 2 2
After:  [1, 0, 0, 0]

Before: [0, 0, 0, 1]
6 0 2 0
After:  [0, 0, 0, 1]

Before: [2, 3, 3, 1]
11 0 2 2
After:  [2, 3, 1, 1]

Before: [3, 1, 3, 2]
2 1 3 1
After:  [3, 0, 3, 2]

Before: [1, 1, 2, 2]
13 3 3 1
After:  [1, 0, 2, 2]

Before: [3, 1, 0, 3]
10 0 3 1
After:  [3, 1, 0, 3]

Before: [1, 0, 0, 2]
14 0 2 1
After:  [1, 0, 0, 2]

Before: [0, 1, 2, 1]
5 3 2 0
After:  [1, 1, 2, 1]

Before: [2, 3, 1, 2]
13 3 3 0
After:  [0, 3, 1, 2]

Before: [3, 1, 1, 2]
2 1 3 0
After:  [0, 1, 1, 2]

Before: [1, 1, 2, 1]
5 3 2 0
After:  [1, 1, 2, 1]

Before: [0, 3, 3, 3]
10 2 3 3
After:  [0, 3, 3, 1]

Before: [3, 3, 0, 1]
0 3 1 3
After:  [3, 3, 0, 1]

Before: [3, 1, 0, 2]
12 1 1 0
After:  [1, 1, 0, 2]

Before: [3, 2, 2, 3]
10 0 3 1
After:  [3, 1, 2, 3]

Before: [0, 0, 1, 1]
6 0 1 0
After:  [0, 0, 1, 1]

Before: [1, 1, 0, 3]
14 0 2 3
After:  [1, 1, 0, 0]

Before: [0, 0, 3, 3]
6 0 1 0
After:  [0, 0, 3, 3]

Before: [3, 1, 2, 2]
3 1 2 0
After:  [0, 1, 2, 2]

Before: [0, 2, 3, 0]
6 0 3 2
After:  [0, 2, 0, 0]

Before: [3, 2, 0, 1]
11 2 0 3
After:  [3, 2, 0, 1]

Before: [0, 3, 2, 0]
1 0 1 3
After:  [0, 3, 2, 0]

Before: [1, 1, 2, 2]
3 1 2 0
After:  [0, 1, 2, 2]

Before: [1, 1, 3, 2]
2 1 3 0
After:  [0, 1, 3, 2]

Before: [2, 3, 3, 3]
10 2 3 3
After:  [2, 3, 3, 1]

Before: [3, 1, 1, 3]
4 1 3 1
After:  [3, 0, 1, 3]

Before: [2, 3, 3, 1]
11 0 2 0
After:  [1, 3, 3, 1]

Before: [0, 0, 0, 3]
6 0 1 2
After:  [0, 0, 0, 3]

Before: [2, 3, 2, 1]
5 3 2 1
After:  [2, 1, 2, 1]

Before: [1, 2, 2, 3]
4 2 3 2
After:  [1, 2, 0, 3]

Before: [3, 1, 3, 3]
15 3 0 2
After:  [3, 1, 1, 3]

Before: [0, 2, 2, 2]
9 0 0 2
After:  [0, 2, 0, 2]

Before: [0, 0, 2, 1]
1 0 2 0
After:  [0, 0, 2, 1]

Before: [2, 3, 3, 1]
0 3 1 0
After:  [1, 3, 3, 1]

Before: [3, 1, 3, 2]
2 1 3 3
After:  [3, 1, 3, 0]

Before: [0, 1, 2, 2]
1 0 3 1
After:  [0, 0, 2, 2]

Before: [1, 0, 0, 0]
14 0 2 0
After:  [0, 0, 0, 0]

Before: [1, 3, 0, 3]
14 0 2 2
After:  [1, 3, 0, 3]

Before: [3, 1, 3, 1]
13 3 3 3
After:  [3, 1, 3, 0]

Before: [0, 0, 2, 1]
6 0 1 0
After:  [0, 0, 2, 1]

Before: [2, 2, 2, 3]
10 0 2 2
After:  [2, 2, 1, 3]

Before: [1, 1, 2, 0]
3 1 2 0
After:  [0, 1, 2, 0]

Before: [1, 0, 3, 1]
15 2 3 0
After:  [0, 0, 3, 1]

Before: [3, 0, 0, 3]
10 0 3 0
After:  [1, 0, 0, 3]

Before: [2, 2, 0, 3]
7 3 3 1
After:  [2, 1, 0, 3]

Before: [3, 1, 3, 2]
2 1 3 2
After:  [3, 1, 0, 2]

Before: [3, 1, 1, 3]
15 3 0 0
After:  [1, 1, 1, 3]

Before: [0, 1, 3, 3]
1 0 1 1
After:  [0, 0, 3, 3]

Before: [3, 0, 2, 3]
4 2 3 1
After:  [3, 0, 2, 3]

Before: [2, 1, 1, 2]
2 1 3 3
After:  [2, 1, 1, 0]

Before: [1, 1, 2, 1]
3 1 2 1
After:  [1, 0, 2, 1]

Before: [1, 3, 2, 3]
4 2 3 0
After:  [0, 3, 2, 3]

Before: [0, 3, 0, 2]
6 0 2 1
After:  [0, 0, 0, 2]

Before: [3, 1, 2, 2]
13 3 3 1
After:  [3, 0, 2, 2]

Before: [0, 3, 3, 1]
0 3 1 1
After:  [0, 1, 3, 1]

Before: [2, 2, 1, 3]
4 1 3 1
After:  [2, 0, 1, 3]

Before: [1, 2, 2, 1]
5 3 2 1
After:  [1, 1, 2, 1]

Before: [2, 2, 3, 0]
11 0 2 3
After:  [2, 2, 3, 1]

Before: [0, 1, 3, 3]
4 1 3 2
After:  [0, 1, 0, 3]

Before: [2, 1, 3, 3]
15 3 2 2
After:  [2, 1, 1, 3]

Before: [3, 1, 2, 0]
3 1 2 0
After:  [0, 1, 2, 0]

Before: [0, 1, 3, 2]
2 1 3 0
After:  [0, 1, 3, 2]

Before: [3, 1, 0, 2]
2 1 3 3
After:  [3, 1, 0, 0]

Before: [0, 1, 0, 0]
12 1 1 1
After:  [0, 1, 0, 0]

Before: [0, 1, 0, 0]
6 0 2 0
After:  [0, 1, 0, 0]

Before: [0, 1, 1, 1]
12 1 1 0
After:  [1, 1, 1, 1]

Before: [2, 2, 0, 3]
4 1 3 0
After:  [0, 2, 0, 3]

Before: [0, 1, 3, 3]
7 2 1 2
After:  [0, 1, 0, 3]

Before: [2, 1, 0, 2]
2 1 3 2
After:  [2, 1, 0, 2]

Before: [2, 1, 2, 3]
10 0 2 0
After:  [1, 1, 2, 3]

Before: [0, 0, 0, 2]
6 0 1 1
After:  [0, 0, 0, 2]

Before: [1, 1, 2, 3]
8 0 2 1
After:  [1, 0, 2, 3]

Before: [2, 2, 2, 3]
7 3 3 3
After:  [2, 2, 2, 1]

Before: [2, 2, 2, 1]
15 2 1 1
After:  [2, 1, 2, 1]

Before: [2, 0, 2, 1]
5 3 2 2
After:  [2, 0, 1, 1]

Before: [0, 3, 1, 3]
1 0 3 3
After:  [0, 3, 1, 0]

Before: [2, 1, 2, 0]
3 1 2 0
After:  [0, 1, 2, 0]

Before: [0, 0, 0, 0]
6 0 2 3
After:  [0, 0, 0, 0]

Before: [0, 2, 2, 0]
9 0 0 0
After:  [0, 2, 2, 0]

Before: [1, 1, 2, 2]
2 1 3 1
After:  [1, 0, 2, 2]

Before: [2, 2, 3, 3]
11 0 2 2
After:  [2, 2, 1, 3]

Before: [1, 1, 0, 3]
14 0 2 2
After:  [1, 1, 0, 3]

Before: [2, 1, 1, 2]
12 1 1 3
After:  [2, 1, 1, 1]

Before: [3, 1, 2, 2]
2 1 3 3
After:  [3, 1, 2, 0]

Before: [1, 2, 2, 3]
4 1 3 3
After:  [1, 2, 2, 0]

Before: [0, 1, 2, 3]
1 0 3 2
After:  [0, 1, 0, 3]

Before: [3, 2, 2, 0]
7 2 2 3
After:  [3, 2, 2, 1]

Before: [1, 1, 2, 1]
8 0 2 3
After:  [1, 1, 2, 0]

Before: [1, 1, 1, 2]
2 1 3 3
After:  [1, 1, 1, 0]

Before: [2, 1, 0, 2]
2 1 3 3
After:  [2, 1, 0, 0]

Before: [3, 3, 2, 1]
0 3 1 3
After:  [3, 3, 2, 1]

Before: [1, 1, 0, 2]
2 1 3 0
After:  [0, 1, 0, 2]

Before: [3, 3, 0, 0]
11 2 0 0
After:  [1, 3, 0, 0]

Before: [2, 1, 3, 3]
11 0 2 2
After:  [2, 1, 1, 3]

Before: [0, 2, 0, 2]
6 0 2 0
After:  [0, 2, 0, 2]

Before: [3, 3, 1, 1]
0 3 1 1
After:  [3, 1, 1, 1]

Before: [0, 3, 2, 1]
5 3 2 1
After:  [0, 1, 2, 1]

Before: [1, 0, 0, 1]
14 0 2 2
After:  [1, 0, 0, 1]

Before: [2, 1, 0, 1]
13 3 3 1
After:  [2, 0, 0, 1]

Before: [0, 1, 2, 2]
12 1 1 2
After:  [0, 1, 1, 2]

Before: [0, 1, 2, 0]
3 1 2 0
After:  [0, 1, 2, 0]

Before: [1, 2, 0, 3]
7 3 1 2
After:  [1, 2, 0, 3]

Before: [0, 1, 0, 2]
6 0 2 3
After:  [0, 1, 0, 0]

Before: [2, 0, 2, 3]
15 2 0 1
After:  [2, 1, 2, 3]

Before: [1, 1, 0, 1]
14 0 2 3
After:  [1, 1, 0, 0]

Before: [0, 3, 2, 1]
0 3 1 0
After:  [1, 3, 2, 1]

Before: [0, 1, 2, 1]
1 0 2 2
After:  [0, 1, 0, 1]

Before: [3, 0, 2, 1]
5 3 2 1
After:  [3, 1, 2, 1]

Before: [3, 3, 0, 3]
15 3 0 1
After:  [3, 1, 0, 3]

Before: [0, 3, 2, 1]
0 3 1 2
After:  [0, 3, 1, 1]

Before: [1, 0, 2, 0]
7 2 2 1
After:  [1, 1, 2, 0]

Before: [1, 3, 0, 1]
14 0 2 3
After:  [1, 3, 0, 0]

Before: [2, 3, 3, 2]
11 0 2 3
After:  [2, 3, 3, 1]

Before: [0, 1, 3, 2]
12 1 1 0
After:  [1, 1, 3, 2]

Before: [3, 3, 0, 1]
11 2 0 3
After:  [3, 3, 0, 1]

Before: [0, 0, 0, 3]
7 3 3 1
After:  [0, 1, 0, 3]

Before: [1, 1, 0, 0]
14 0 2 2
After:  [1, 1, 0, 0]

Before: [2, 1, 3, 1]
13 3 3 3
After:  [2, 1, 3, 0]

Before: [1, 3, 2, 1]
5 3 2 3
After:  [1, 3, 2, 1]

Before: [3, 1, 2, 1]
3 1 2 2
After:  [3, 1, 0, 1]

Before: [0, 1, 2, 3]
4 1 3 3
After:  [0, 1, 2, 0]

Before: [0, 3, 3, 0]
1 0 2 0
After:  [0, 3, 3, 0]

Before: [3, 1, 2, 1]
12 1 1 0
After:  [1, 1, 2, 1]

Before: [1, 0, 3, 3]
10 2 3 2
After:  [1, 0, 1, 3]

Before: [1, 0, 3, 1]
13 3 3 3
After:  [1, 0, 3, 0]

Before: [3, 2, 2, 3]
4 2 3 2
After:  [3, 2, 0, 3]

Before: [2, 1, 2, 2]
10 0 2 1
After:  [2, 1, 2, 2]

Before: [0, 3, 1, 2]
1 0 2 0
After:  [0, 3, 1, 2]

Before: [3, 1, 3, 0]
7 2 1 1
After:  [3, 0, 3, 0]

Before: [0, 1, 0, 3]
4 1 3 0
After:  [0, 1, 0, 3]

Before: [2, 3, 0, 1]
0 3 1 3
After:  [2, 3, 0, 1]

Before: [1, 3, 0, 3]
14 0 2 0
After:  [0, 3, 0, 3]

Before: [1, 1, 1, 2]
2 1 3 0
After:  [0, 1, 1, 2]

Before: [2, 1, 2, 1]
5 3 2 1
After:  [2, 1, 2, 1]

Before: [2, 0, 3, 1]
11 0 2 3
After:  [2, 0, 3, 1]

Before: [2, 2, 3, 1]
11 0 2 3
After:  [2, 2, 3, 1]

Before: [1, 3, 1, 1]
13 3 3 3
After:  [1, 3, 1, 0]

Before: [0, 2, 1, 1]
9 0 0 1
After:  [0, 0, 1, 1]

Before: [1, 2, 3, 3]
4 1 3 3
After:  [1, 2, 3, 0]

Before: [0, 0, 2, 1]
1 0 3 1
After:  [0, 0, 2, 1]

Before: [0, 1, 0, 0]
9 0 0 1
After:  [0, 0, 0, 0]

Before: [3, 0, 1, 3]
10 0 3 0
After:  [1, 0, 1, 3]

Before: [3, 2, 0, 0]
11 2 0 0
After:  [1, 2, 0, 0]

Before: [2, 3, 2, 2]
15 2 0 1
After:  [2, 1, 2, 2]

Before: [3, 1, 0, 1]
12 1 1 2
After:  [3, 1, 1, 1]

Before: [1, 0, 2, 1]
5 3 2 0
After:  [1, 0, 2, 1]

Before: [2, 3, 3, 1]
0 3 1 2
After:  [2, 3, 1, 1]

Before: [0, 2, 2, 1]
5 3 2 3
After:  [0, 2, 2, 1]

Before: [2, 1, 1, 1]
13 2 3 3
After:  [2, 1, 1, 0]

Before: [1, 0, 0, 3]
14 0 2 3
After:  [1, 0, 0, 0]

Before: [2, 2, 3, 1]
13 3 3 3
After:  [2, 2, 3, 0]

Before: [3, 1, 2, 2]
2 1 3 0
After:  [0, 1, 2, 2]

Before: [3, 0, 3, 1]
15 2 3 3
After:  [3, 0, 3, 0]

Before: [2, 0, 2, 3]
10 0 2 0
After:  [1, 0, 2, 3]

Before: [3, 2, 3, 3]
15 3 2 3
After:  [3, 2, 3, 1]

Before: [0, 1, 1, 3]
4 2 3 3
After:  [0, 1, 1, 0]

Before: [1, 3, 2, 1]
0 3 1 2
After:  [1, 3, 1, 1]
";
            string[] splits = input.Split('\n');
            int line = 0;
            int threeOrMore = 0;
            while (line < splits.Length)
            {
                
                int[] before = new int[4];
                int[] inst = new int[4];
                int[] after = new int[4];
                // parse out before
                string[] befParts1 = splits[line].Split('[');
                string befNums = befParts1[1].Split(']')[0];
                string[] befNumSplits = befNums.Split(',');
                before[0] = int.Parse(befNumSplits[0].Trim());
                before[1] = int.Parse(befNumSplits[1].Trim());
                before[2] = int.Parse(befNumSplits[2].Trim());
                before[3] = int.Parse(befNumSplits[3].Trim());

                line++;

                //parse out instructions
                string[] instNums = splits[line].Split(' ');
                inst[0] = int.Parse(instNums[0].Trim());
                inst[1] = int.Parse(instNums[1].Trim());
                inst[2] = int.Parse(instNums[2].Trim());
                inst[3] = int.Parse(instNums[3].Trim());

                line++;

                // parse out after
                string[] aftParts1 = splits[line].Split('[');
                string aftNums = aftParts1[1].Split(']')[0];
                string[] aftNumSplits = aftNums.Split(',');
                after[0] = int.Parse(aftNumSplits[0].Trim());
                after[1] = int.Parse(aftNumSplits[1].Trim());
                after[2] = int.Parse(aftNumSplits[2].Trim());
                after[3] = int.Parse(aftNumSplits[3].Trim());

                //skip over blank
                line += 2;

                int match = 0;
                if (arrayEq(addr(before, inst), after)) { match++; }
                if (arrayEq(addi(before, inst), after)) { match++; }
                if (arrayEq(mulr(before, inst), after)) { match++; }
                if (arrayEq(muli(before, inst), after)) { match++; }
                if (arrayEq(banr(before, inst), after)) { match++; }
                if (arrayEq(bani(before, inst), after)) { match++; }
                if (arrayEq(borr(before, inst), after)) { match++; }
                if (arrayEq(bori(before, inst), after)) { match++; }
                if (arrayEq(setr(before, inst), after)) { match++; }
                if (arrayEq(seti(before, inst), after)) { match++; }
                if (arrayEq(gtir(before, inst), after)) { match++; }
                if (arrayEq(gtri(before, inst), after)) { match++; }
                if (arrayEq(gtrr(before, inst), after)) { match++; }
                if (arrayEq(eqir(before, inst), after)) { match++; }
                if (arrayEq(eqri(before, inst), after)) { match++; }
                if (arrayEq(eqrr(before, inst), after)) { match++; }
                if(match>=3) { threeOrMore++; }
            }
            Console.WriteLine(threeOrMore);
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
