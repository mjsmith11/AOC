using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1 : " + part1());
            Console.WriteLine("Part 2 : " + part2());
        }

        static int part1() {
            Dictionary<string,List<string>> graph = getGraph();
            Queue<string> toExplore = new Queue<string>();
            List<string> smallExplored = new List<string>();
            toExplore.Enqueue("start");
            int paths = 0;
            List<string> path = new List<string>();
            path.Add("start");
            paths = step(path,0,graph,"start");
            return paths;
        }

        static int part2() {
            Dictionary<string,List<string>> graph = getGraph();
            Queue<string> toExplore = new Queue<string>();
            List<string> smallExplored = new List<string>();
            toExplore.Enqueue("start");
            int paths = 0;
            List<string> path = new List<string>();
            path.Add("start");
            paths = step2(path,0,graph,"start");
            return paths;
        }

        static int step(List<string> path, int pathsFound, Dictionary<string,List<string>> graph, string node) {
            if (node =="end") {
                return pathsFound + 1;
            }
            foreach (string n in graph[node]) {
                if (n.Any(char.IsUpper) || !path.Contains(n)) {
                    path.Add(n);
                    pathsFound = step(path,pathsFound,graph,n);
                    path.RemoveAt(path.Count() - 1);
                }
            }
            return pathsFound;
        }

        static int step2(List<string> path, int pathsFound, Dictionary<string,List<string>> graph, string node) {
            if (node =="end") {
                return pathsFound + 1;
            }
            foreach (string n in graph[node]) {
                if (canStep2(path,n)) {
                    path.Add(n);
                    pathsFound = step2(path,pathsFound,graph,n);
                    path.RemoveAt(path.Count() - 1);
                }
            }
            return pathsFound;
        }

        static bool canStep2(List<string> path, string node) {
            if (node.Any(char.IsUpper)) { return true; }
            if (!path.Contains(node)) { return true; }
            if (node=="start") {return false; }
            // at this point, node is lower case and we've visited it
            // To make this step, the path must not already contain any duplicate smalls
            List<string> seenSmalls = new List<string>();
            foreach(string n in path) {
                if (!n.Any(char.IsUpper)) {
                    if (seenSmalls.Contains(n)) {
                        // found a duplicate small cave.
                        return false;
                    }
                    seenSmalls.Add(n);
                }
            }
            return true;
        }

        static Dictionary<string,List<string>> getGraph() {

            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            string input = @"RT-start
bp-sq
em-bp
end-em
to-MW
to-VK
RT-bp
start-MW
to-hr
sq-AR
RT-hr
bp-to
hr-VK
st-VK
sq-end
MW-sq
to-RT
em-er
bp-hr
MW-em
st-bp
to-start
em-st
st-end
VK-sq
hr-st";
            string[] lines = input.Split('\n');
            foreach(string l in lines){
                string[] pieces = l.Trim().Split("-");
                if (!graph.ContainsKey(pieces[0])) {
                    graph[pieces[0]] = new List<string>();
                }
                if (!graph.ContainsKey(pieces[1])) {
                    graph[pieces[1]] = new List<string>();
                }
                graph[pieces[0]].Add(pieces[1]);
                graph[pieces[1]].Add(pieces[0]);
            }
            return graph;
        }
    }
}
