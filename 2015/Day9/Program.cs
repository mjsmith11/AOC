using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
	class Program
	{
		public static Graph g;
		public static int min;
		public static int max;
		private static void Swap(ref char a, ref char b)
		{
			if (a == b) return;

			a ^= b;
			b ^= a;
			a ^= b;
		}

		public static void GetPer(char[] list)
		{
			int x = list.Length - 1;
			GetPer(list, 0, x);
		}

		private static void GetPer(char[] list, int k, int m)
		{
			if (k == m)
			{
				int val = g.findWeight(list);
				if (val < min)
				{
					min = val;
				}
				if (val > max)
				{
					max = val;
				}
			}
			else
				for (int i = k; i <= m; i++)
				{
					Swap(ref list[k], ref list[i]);
					GetPer(list, k + 1, m);
					Swap(ref list[k], ref list[i]);
				}
		}

		static void Main(string[] args)
		{
			
			g = new Graph();
			string input = System.IO.File.ReadAllText(@"C:\temp\input.txt");
			string[] strings = input.Split('\n');

			foreach (string s in strings)
			{
				string trimmed = s.Trim();
				string[] splits = trimmed.Split(' ');
				g.addEdge(new Edge(splits[0].Trim(), splits[2].Trim(), int.Parse(splits[4])));
			}
			min = 1000000000;
			max = 0;
			string nums = "01234567";
			GetPer(nums.ToCharArray());
			Console.Write(min);
			Console.Write(max);
			Console.Read();
		}

	}
	class Graph
	{
		private List<string> nodes;
		private List<Edge> edges;

		public Graph()
		{
			nodes = new List<string>();
			edges = new List<Edge>();
		}


		public int findWeight(char[] order)
		{
			int count = 0;
			for (int i = 0; i < order.Length - 1; i++)
			{
				count += findEdge(nodes[int.Parse(order[i].ToString())], nodes[int.Parse(order[i+1].ToString())]).weight;
			}
			return count;
		}
		public void addEdge(Edge e) {
			if (!nodes.Contains(e.n1))
			{
				nodes.Add(e.n1);
			}
			if (!nodes.Contains(e.n2))
			{
				nodes.Add(e.n2);
			}
			edges.Add(e);
		}

		public Edge findEdge(string n1, string n2)
		{
			foreach (Edge e in edges)
			{
				if (e.n1 == n1 && e.n2 == n2)
				{
					return e;
				}
				if (e.n1 == n2 && e.n2 == n1)
				{
					return e;
				}
			}
			return null;
		}
	}

	class Edge
	{
		public string n1;
		public string n2;
		public int weight;

		public Edge(string n1, string n2, int weight)
		{
			this.n1 = n1;
			this.n2 = n2;
			this.weight = weight;
		}
	}
}
