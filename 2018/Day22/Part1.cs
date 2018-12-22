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

			Square[,] cave = new Square[targetX + 1,targetY + 1];

			long risk = 0;

			for (int x = 0; x <= targetX; x++)
			{
				for (int y = 0; y <= targetY; y++)
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
					risk += (erosion % 3);
				}
			}
			Console.WriteLine(risk);
			Console.ReadLine();
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
}
