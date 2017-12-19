using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2017
{
    class Day15
    {
        static ConcurrentQueue<ulong> queueA;
        static ConcurrentQueue<ulong> queueB;
        static ulong startingA;
        static ulong startingB;

        public static void genA()
        {
            ulong queued = 0;
            ulong A = startingA;
            while(queued<5000000)
            {
                A = (A * 16807) % 2147483647;
                if (A%4==0)
                {
                    queued++;
                    queueA.Enqueue(A);
                }
            }
        }
        public static void genB()
        {
            ulong queued = 0;
            ulong B = startingB;
            while (queued<5000000)
            {
                B = (B * 48271) % 2147483647;
                if (B % 8 == 0)
                {
                    queued++;
                    queueB.Enqueue(B);
                }
            }
        }
        public static int part1(ulong aStart, ulong bStart)
        {
            ulong A = aStart;
            ulong B = bStart;
            int count = 0;
            for(ulong i=0; i<40000000; i++)
            {
                A = (A * 16807) % 2147483647;
                B = (B * 48271) % 2147483647;
                if(compareLower16(A,B))
                {
                    count++;
                }
            }
            return count;
        }

        public static int part2(ulong aStart, ulong bStart)
        {
            startingA = aStart;
            startingB = bStart;
            queueA = new ConcurrentQueue<ulong>();
            queueB = new ConcurrentQueue<ulong>();
            ThreadStart refA = new ThreadStart(genA);
            Thread thA = new Thread(refA);
            ThreadStart refB = new ThreadStart(genB);
            Thread thB = new Thread(refB);
            thA.Start();
            thB.Start();

            ulong comps = 0;
            int count = 0;
            while(comps<5000000)
            {
                if(queueA.Count>0 && queueB.Count>0)
                {
                    ulong a, b;
                    queueA.TryDequeue(out a);
                    queueB.TryDequeue(out b);
                    if(compareLower16(a, b))
                    {
                        count++;
                    }
                    comps++;
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
            return count;
        }

        public static bool compareLower16(ulong a, ulong b)
        {
            ulong mask = 0xffff;
            return (a & mask) == (b & mask);
        }
    }
}
