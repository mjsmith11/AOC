using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
	class Part2
	{
		static void Main(string[] args)
		{
			for (int i = 1; true; i++)
			{
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
				int div = house / elfNum;
				if ((house % elfNum == 0))
				{
					if (div <= 50)
					{
						presents += (elfNum * 11);
					}
					if ((div != elfNum) && (house/div<=50))
					{
						presents += (div * 11);
					}
				}
			}
			return presents;
		}
	}
}
