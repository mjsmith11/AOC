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

		static void Main(string[] args)
		{
			List<int> containers = new List<int>();
			containers.Add(11);
			containers.Add(30);
			containers.Add(47);
			containers.Add(31);
			containers.Add(32);
			containers.Add(36);
			containers.Add(3);
			containers.Add(1);
			containers.Add(5);
			containers.Add(3);
			containers.Add(32);
			containers.Add(36);
			containers.Add(15);
			containers.Add(11);
			containers.Add(46);
			containers.Add(26);
			containers.Add(28);
			containers.Add(1);
			containers.Add(19);
			containers.Add(3);

			int ways = 0;
			int minContainers = containers.Count();
			for (int i = 0; i < Math.Pow(2, containers.Count()); i++ )
			{
				int amount = 0;
				int numContainers = 0;
				for (int j = 0; j < containers.Count(); j++)
				{
					if ((i & (1 << j)) > 0)
					{
						amount += containers[j];
						numContainers++;
					}
				}
				if (amount == 150)
				{
					ways++;
					if (numContainers<minContainers)
					{
						minContainers = numContainers;
					}
				}
			}


			Console.WriteLine(ways);
			Console.WriteLine(minContainers);
			Console.Read();
		}
	}
}
