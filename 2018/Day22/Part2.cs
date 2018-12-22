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
			long targetX = 9;
			long targetY = 731;
			long depth = 11109;

			Square[,] cave = new Square[depth,depth];
			List<Vertex> Q = new List<Vertex>();

			// These bounds are an educated guess (that worked) based on the input
			for (int x = 0; x < 27; x++)
			{
				for (int y = 0; y < 1462; y++)
				{
					long gIndex;
					if (x == 0 && y == 0)
					{
						gIndex = 0;
					}
					else if(x==targetX && y==targetY)
					{
						gIndex = 0;
					}
					else if (x == 0)
					{
						gIndex = y * 48271;
					}
					else if (y == 0)
					{
						gIndex = x * 16807;
					}
					else
					{
						gIndex = cave[x - 1, y].erosion * cave[x, y - 1].erosion;
					}
					long erosion = (gIndex + depth) % 20183;
					cave[x, y] = new Square(gIndex, erosion);
					if(erosion%3==0){
						Q.Add(new Vertex(cave[x, y], x, y, 'C'));
						Q.Add(new Vertex(cave[x, y], x, y, 'T'));
					}
					else if (erosion % 3 == 1)
					{
						Q.Add(new Vertex(cave[x, y], x, y, 'C'));
						Q.Add(new Vertex(cave[x, y], x, y, 'N'));
					}
					else if (erosion % 3 == 2)
					{
						Q.Add(new Vertex(cave[x, y], x, y, 'N'));
						Q.Add(new Vertex(cave[x, y], x, y, 'T'));
					}
				}
			}
			Dictionary<int, int> dist = new Dictionary<int, int>();
			Dictionary<int, int> prev = new Dictionary<int, int>();
			List<Vertex> Done = new List<Vertex>();
			for (int i = 0; i < Vertex.nextId; i++)
			{
				dist[i] = int.MaxValue;
				prev[i] = -1;
			}
			Vertex src = Q.Where(o => o.x == 0 && o.y == 0 && o.tool == 'T').Single();
			dist[src.id] = 0;

			while (Q.Count() > 0)
			{
				Vertex u = Q[0];
				int uDist = dist[u.id];
				foreach (Vertex xyz in Q)
				{
					if (dist[xyz.id] < uDist)
					{
						u = xyz;
						uDist = dist[xyz.id];
					}
				}

				Q.Remove(u);
				Done.Add(u);
				List<Vertex> neighbors = getNeighbors(u, Q.Concat(Done).ToList());

				foreach (Vertex v in neighbors)
				{
					int alt = dist[u.id] + getWeight(u, v);
					if (alt < dist[v.id])
					{
						dist[v.id] = alt;
						prev[v.id] = u.id;
					}
				}
			}

			Vertex target = Done.Where(o => o.x == targetX && o.y == targetY && o.tool == 'T').Single();
			Console.WriteLine(dist[target.id]);
			Console.ReadLine();
		}
		public static int getWeight(Vertex v1, Vertex v2)
		{
			int dist = Math.Abs(v1.x - v2.x) + Math.Abs(v1.y - v2.y);
			if (dist == 1)
			{
				if (v1.tool == v2.tool)
				{
					return 1;
				}
				else
				{
					return -1;
				}
			}
			else if (dist == 0)
			{
				if (v1.tool == v2.tool)
				{
					return 0;
				}
				else
				{
					return 7;
				}
			}
			else
			{
				return -2;
			}
		}

		public static List<Vertex> getNeighbors(Vertex u, List<Vertex> vertices)
		{
			List<Vertex> neighbors = new List<Vertex>();

			// check for tool change
			neighbors = neighbors.Concat(vertices.Where(o => o.x == u.x && o.y == u.y && o.tool != u.tool)).ToList();
			// check up
			neighbors = neighbors.Concat(vertices.Where(o => o.x == u.x && o.y == u.y + 1 && o.tool == u.tool)).ToList();
			// check down
			neighbors = neighbors.Concat(vertices.Where(o => o.x == u.x && o.y == u.y - 1 && o.tool == u.tool)).ToList();
			// check left
			neighbors = neighbors.Concat(vertices.Where(o => o.x == u.x - 1 && o.y == u.y && o.tool == u.tool)).ToList();
			// check right
			neighbors = neighbors.Concat(vertices.Where(o => o.x == u.x + 1 && o.y == u.y && o.tool == u.tool)).ToList();

			return neighbors;
		}
	}
	public class Square
	{
		public long gIndex;
		public long erosion;
		public Square(long g, long e)
		{
			erosion = e;
			gIndex = g;
		}
	}
	public class Vertex
	{
		public static int nextId = 0;
		public Square sq;
		public int x;
		public int y;
		public int id;
		public char tool;

		public Vertex(Square sq, int x, int y, char tool){
			this.sq = sq;
			this.x = x;
			this.y = y;
			this.tool = tool;
			this.id = nextId;
			nextId++;
		}
	}
};
