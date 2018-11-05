using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
	class Part1
	{
		static void Main(string[] args)
		{
			for (int i = 1; true; i++)
			{
				Console.WriteLine("House " + i);
				if (calculatePresents(i) >= 33100000)
				{
					Console.WriteLine(i);
					break;
				}
			}
			Console.Read();
		}

		public static int calculatePresents(int house)
		{
			int presents = 0;
			for (int elfNum = (int)Math.Sqrt(house); elfNum > 0; elfNum--)
			{
				if (house % elfNum == 0)
				{
					presents += (elfNum * 10);
					presents += (house / elfNum * 10);
				}
			}
			return presents;
		}
	}
}
