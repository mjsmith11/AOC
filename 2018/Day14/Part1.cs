     
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
			List<int> recipes = new List<int>();
			recipes.Add(3);
			recipes.Add(7);
			int elf1 = 0;
			int elf2 = 1;
			while (recipes.Count() < 513411)
			{
				int sum = recipes[elf1] + recipes[elf2];
				if (sum < 10)
				{
					recipes.Add(sum);
				}
				else
				{
					recipes.Add(sum / 10);
					recipes.Add(sum % 10);
				}
				elf1 = (elf1 + recipes[elf1] + 1) % recipes.Count();
				elf2 = (elf2 + recipes[elf2] + 1) % recipes.Count();
			}
			for (int i = 513401; i < 513411; i++)
			{
				Console.Write(recipes[i] + " ");
			}
				Console.ReadLine();
		}
	}
}
