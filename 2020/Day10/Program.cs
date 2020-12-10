using System;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1: " + part1());
            Console.WriteLine("Part 2: " + part2());
        }

        static int part1() {
            int[] adapters = getInput();
            // the adapters will have to be used in increasing order
            Array.Sort(adapters,0,adapters.Length);
            
            // see what the first adapter is and add 1 to diff3 for the device's adapter
            int diff1 = adapters[0]==1?1:0;
            int diff3 = adapters[0]==3?1:0 + 1;
            
            // start at one and compare adapters i and i-1
            for(int i=1; i<adapters.Length; i++){
                if (adapters[i] - adapters[i-1] == 1) {
                    diff1++;
                }
                if (adapters[i] - adapters[i-1] == 3) {
                    diff3++;
                }
            }
            return diff1 * diff3;
        }

        static long part2() {
            int[] adapters = getInput();
            Array.Sort(adapters,0,adapters.Length);
            int[] allAdapters = new int[adapters.Length + 2];
            allAdapters[0] = 0;
            int max =  adapters[adapters.Length - 1] + 3;
            allAdapters[allAdapters.Length - 1] = max;
            for(int i=0; i<adapters.Length; i++) {
                allAdapters[i+1] = adapters[i];
            }
            long[] cache = new long[max + 3];
            return walk(allAdapters,cache,0,max);
        }


        static long walk(int[] adapters, long[] cache, int i, int max) {
            // check the cache for this
            if (cache[i] > 0) {
                return cache[i];
            }

            if(arrayContains(adapters, i) && i==max) {
                // we're at the end and only one way to do it
                cache[i] = 1;
                return 1;
            }

            //now we have to check for stuff from 1 to 3 jolts away from i
            long result = 0;
            for(int k = 1; k<=3; k++){
                if(arrayContains(adapters, i + k)) {
                    result += walk(adapters, cache, i+k, max);
                }
            }
            cache[i] = result;
            return result;
        }

        static bool arrayContains(int[] arr, int num) {
            return Array.Exists(arr, element => element == num);
        }
        
        static int[] getInput() {
            string input = @"99
104
120
108
67
136
80
44
129
113
158
157
89
60
138
63
35
57
61
153
116
54
7
22
133
130
5
72
2
28
131
123
55
145
151
42
98
34
140
146
100
79
117
154
9
83
132
45
43
107
91
163
86
115
39
76
36
82
162
6
27
101
150
30
110
139
109
1
64
56
161
92
62
69
144
21
147
12
114
18
137
75
164
33
152
23
68
51
8
95
90
48
29
26
165
81
13
126
14
143
15";
            string[] strArr = input.Split('\n');
            int[] ints = new int[strArr.Length];
            for(int i=0; i<strArr.Length; i++) {
                ints[i] = int.Parse(strArr[i]);
            }
            return ints;
        }
    }
}
