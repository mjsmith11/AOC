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
            string input = @"Step G must be finished before step L can begin.
Step X must be finished before step U can begin.
Step W must be finished before step H can begin.
Step M must be finished before step S can begin.
Step Z must be finished before step N can begin.
Step K must be finished before step U can begin.
Step V must be finished before step B can begin.
Step L must be finished before step P can begin.
Step U must be finished before step S can begin.
Step D must be finished before step Q can begin.
Step C must be finished before step Q can begin.
Step O must be finished before step N can begin.
Step E must be finished before step P can begin.
Step J must be finished before step Q can begin.
Step R must be finished before step A can begin.
Step P must be finished before step Q can begin.
Step H must be finished before step F can begin.
Step I must be finished before step Y can begin.
Step F must be finished before step T can begin.
Step T must be finished before step Q can begin.
Step S must be finished before step B can begin.
Step A must be finished before step N can begin.
Step B must be finished before step N can begin.
Step Q must be finished before step Y can begin.
Step N must be finished before step Y can begin.
Step G must be finished before step S can begin.
Step S must be finished before step Q can begin.
Step A must be finished before step Y can begin.
Step Q must be finished before step N can begin.
Step Z must be finished before step K can begin.
Step F must be finished before step A can begin.
Step F must be finished before step Q can begin.
Step M must be finished before step V can begin.
Step B must be finished before step Y can begin.
Step A must be finished before step Q can begin.
Step F must be finished before step B can begin.
Step S must be finished before step N can begin.
Step G must be finished before step B can begin.
Step C must be finished before step T can begin.
Step Z must be finished before step D can begin.
Step P must be finished before step N can begin.
Step Z must be finished before step P can begin.
Step K must be finished before step O can begin.
Step R must be finished before step P can begin.
Step J must be finished before step R can begin.
Step W must be finished before step B can begin.
Step T must be finished before step S can begin.
Step M must be finished before step B can begin.
Step K must be finished before step B can begin.
Step I must be finished before step S can begin.
Step H must be finished before step A can begin.
Step O must be finished before step J can begin.
Step H must be finished before step I can begin.
Step I must be finished before step N can begin.
Step D must be finished before step J can begin.
Step P must be finished before step B can begin.
Step T must be finished before step N can begin.
Step D must be finished before step A can begin.
Step M must be finished before step D can begin.
Step R must be finished before step I can begin.
Step U must be finished before step Y can begin.
Step P must be finished before step S can begin.
Step R must be finished before step B can begin.
Step G must be finished before step C can begin.
Step U must be finished before step C can begin.
Step O must be finished before step F can begin.
Step Z must be finished before step E can begin.
Step B must be finished before step Q can begin.
Step E must be finished before step J can begin.
Step X must be finished before step B can begin.
Step O must be finished before step A can begin.
Step H must be finished before step Y can begin.
Step T must be finished before step Y can begin.
Step U must be finished before step H can begin.
Step A must be finished before step B can begin.
Step D must be finished before step Y can begin.
Step X must be finished before step D can begin.
Step V must be finished before step U can begin.
Step L must be finished before step J can begin.
Step G must be finished before step X can begin.
Step Z must be finished before step J can begin.
Step L must be finished before step R can begin.
Step U must be finished before step F can begin.
Step O must be finished before step S can begin.
Step F must be finished before step S can begin.
Step C must be finished before step F can begin.
Step L must be finished before step I can begin.
Step C must be finished before step I can begin.
Step P must be finished before step Y can begin.
Step R must be finished before step H can begin.
Step P must be finished before step I can begin.
Step J must be finished before step B can begin.
Step D must be finished before step S can begin.
Step C must be finished before step E can begin.
Step W must be finished before step J can begin.
Step D must be finished before step T can begin.
Step G must be finished before step D can begin.
Step Z must be finished before step A can begin.
Step U must be finished before step R can begin.
Step P must be finished before step T can begin.
Step C must be finished before step Y can begin.";

            string[] parts = input.Split('\n');
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            foreach(string s in parts)
            {
                string step = s.Trim();
                string[] words = step.Split(' ');
                string first = words[1];
                string second = words[7];

                if (!graph.ContainsKey(second))
                {
                    graph[second] = new List<string>();
                }

                if (!graph.ContainsKey(first))
                {
                    graph[first] = new List<string>();
                }
                graph[second].Add(first);
            }

            List<string> candidates = new List<string>();
            foreach(KeyValuePair<string, List<string>> kv in graph)
            {
                candidates.Add(kv.Key);
            }
            candidates = candidates.OrderBy(q => q).ToList();
            List<string> done = new List<string>();


            Dictionary<int, int> timeLeft = new Dictionary<int, int>();
            Dictionary<int, string> task = new Dictionary<int, string>();
            for(int i=0; i<5; i++)
            {
                timeLeft[i] = 0;
                task[i] = ".";
            }

            int time = 0;
            while(done.Count() != 26)
            {
                // update workers
                for(int i = 0; i<5; i++)
                {
                    if (timeLeft[i] == 1)
                    {
                        timeLeft[i] = 0;
                        done.Add(task[i]);
                        task[i] = ".";
                    }
                    else if (timeLeft[i] > 1)
                    {
                        timeLeft[i]--;
                    }
                }
                // are we done?
                if(done.Count() == 26)
                {
                    Console.WriteLine("Finished After Second " + time);
                    break;
                }
                time++;
                // try to assign new tasks
                for (int i = 0; i < 5; i++)
                {
                    if (task[i] == ".") { 
                        foreach (string candidate in candidates)
                        {
                            bool ok2do = true;
                            foreach (string prereq in graph[candidate])
                            {
                                if (!done.Contains(prereq))
                                {
                                    ok2do = false;
                                    break;
                                }
                            }
                            if (ok2do)
                            {
                                candidates.Remove(candidate);
                                task[i] = candidate;
                                timeLeft[i] = 60 + candidate[0] - 'A' + 1;
                                break;
                            }
                        }
                    }
                }
            }



            Console.ReadLine();
        }


    }
}
