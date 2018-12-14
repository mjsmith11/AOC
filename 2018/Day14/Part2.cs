     
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
			while (recipes.Count() < 100000000)
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
			int num1 = 5;
			int num2 = 1;
			int num3 = 3;
			int num4 = 4;
			int num5 = 0;
			int num6 = 1;
			for (int i = 0; i < recipes.Count()-6; i++)
			{
				if (recipes[i] == num1)
				{
					if (recipes[i + 1] == num2)
					{
						if (recipes[i + 2] == num3)
						{
							if (recipes[i + 3] == num4)
							{
								if (recipes[i + 4] == num5)
								{
									if (recipes[i + 5] == num6)
									{
										Console.Write(i);
										break;
									}									
								}
							}
						}
					}
				}
			}
			Console.Write("not found");
				Console.ReadLine();
		}
	}
}
