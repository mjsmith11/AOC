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
			bool part1 = true;
			long r2 = 0;
			long r3 = 0;
			long r4 = 0;
			long r5 = 0;

			List<long> values = new List<long>();
			long last = -1;

			r2 = 123;
			do
			{
				r2 = r2 & 456;
			} while (r2 != 72);

			r2 = 0;
			while (true)
			{
				r5 = r2 | 65536;
				r2 = 4843319;
				while (true)
				{
					r4 = r5 & 255;
					r2 = r2 + r4;
					r2 = r2 & 16777215;
					r2 = r2 * 65899;
					r2 = r2 & 16777215;
					if (256 > r5)
					{
						if (part1)
						{
							Console.WriteLine(r2);
							Console.ReadLine();
							System.Environment.Exit(0);
						}
						else
						{
							if (values.Contains(r2))
							{
								Console.WriteLine(last);
								Console.ReadLine();
								System.Environment.Exit(0);
							}
							else
							{
								values.Add(r2);
								last = r2;
								break;
							}
						}
					}
					r4 = 0;
					do
					{
						r3 = r4 + 1;
						r3 = r3 * 256;
						if (r3 <= r5)
						{
							r4++;
						}
					} while (r3 <= r5);
					r5 = r4;
				}
			}
		}
	}
}
