using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _2017
{
    class Day13
    {
        public static bool caughtAtZero;
        public static int part1()
        {
            return calculateSeverity(0);
        }
        public static int part2()
        {
            /*int delay = -1;
            int severity;
            do
            {
                delay++;
                if (delay % 10000 == 0)
                    Console.WriteLine(delay);
                severity = calculateSeverity(delay);
            } while (severity != 0 || caughtAtZero);
            return delay;*/
            Hashtable firewall = getInput();
            int start = 0;
            while (!safe(start, firewall)) start++;
            return start;
        }

        public static bool safe(int time, Hashtable firewall)
        {
            for(int i=0; i<100; i++)
            {
                int ind = i + time;
                if(firewall.Contains(i))
                {
                    int size = ((FirewallLayer)firewall[i]).range;
                    if (!isOpen(ind, size))
                        return false;
                }
            }
            return true;
        }

        private static bool isOpen(int time, int size)
        {
            return !(time % ((size - 1) * 2) == 0);
        }
        private static int calculateSeverity(int delay)
        {
            int totalSeverity = 0;
            int packetLocation = 0;
            Hashtable firewall = getInput();
            for(int i=0; i<delay; i++)
            {
                moveScanners(firewall);
            }
            while (packetLocation<100)
            {
                if(firewall.Contains(packetLocation))
                {
                    FirewallLayer layer = (FirewallLayer)firewall[packetLocation];
                    if (layer.isAtTop())
                    {
                        //got caught
                        totalSeverity += layer.getSeverity();
                    }
                }

                moveScanners(firewall);
                packetLocation++;
            }

            return totalSeverity;
        }

        public static void moveScanners(Hashtable firewall)
        {
            for (int i = 0; i < 100; i++)
            {
                if (firewall.Contains(i))
                {
                    FirewallLayer layer = (FirewallLayer)firewall[i];
                    layer.moveScanner();
                }
            }
        }
        public static Hashtable getInput()
        {
            Hashtable h = new Hashtable();
            h.Add(0, new FirewallLayer(0, 3));
            h.Add(1, new FirewallLayer(1, 2));
            h.Add(2, new FirewallLayer(2, 9));
            h.Add(4, new FirewallLayer(4, 4));
            h.Add(6, new FirewallLayer(6, 4));
            h.Add(8, new FirewallLayer(8, 6));
            h.Add(10, new FirewallLayer(10, 6));
            h.Add(12, new FirewallLayer(12, 8));
            h.Add(14, new FirewallLayer(14, 5));
            h.Add(16, new FirewallLayer(16, 6));
            h.Add(18, new FirewallLayer(18, 8));
            h.Add(20, new FirewallLayer(20, 8));
            h.Add(22, new FirewallLayer(22, 8));
            h.Add(24, new FirewallLayer(24, 6));
            h.Add(26, new FirewallLayer(26, 12));
            h.Add(28, new FirewallLayer(28, 12));
            h.Add(30, new FirewallLayer(30, 8));
            h.Add(32, new FirewallLayer(32, 10));
            h.Add(34, new FirewallLayer(34, 12));
            h.Add(36, new FirewallLayer(36, 12));
            h.Add(38, new FirewallLayer(38, 10));
            h.Add(40, new FirewallLayer(40, 12));
            h.Add(42, new FirewallLayer(42, 12));
            h.Add(44, new FirewallLayer(44, 12));
            h.Add(46, new FirewallLayer(46, 12));
            h.Add(48, new FirewallLayer(48, 14));
            h.Add(50, new FirewallLayer(50, 14));
            h.Add(52, new FirewallLayer(52, 8));
            h.Add(54, new FirewallLayer(54, 12));
            h.Add(56, new FirewallLayer(56, 14));
            h.Add(58, new FirewallLayer(58, 14));
            h.Add(60, new FirewallLayer(60, 14));
            h.Add(64, new FirewallLayer(64, 14));
            h.Add(66, new FirewallLayer(66, 14));
            h.Add(68, new FirewallLayer(68, 14));
            h.Add(70, new FirewallLayer(70, 14));
            h.Add(72, new FirewallLayer(72, 14));
            h.Add(74, new FirewallLayer(74, 12));
            h.Add(76, new FirewallLayer(76, 18));
            h.Add(78, new FirewallLayer(78, 14));
            h.Add(80, new FirewallLayer(80, 14));
            h.Add(86, new FirewallLayer(86, 18));
            h.Add(88, new FirewallLayer(88, 18));
            h.Add(94, new FirewallLayer(94, 20));
            h.Add(98, new FirewallLayer(98, 18));
            return h;
        }
    }
}
