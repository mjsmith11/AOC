using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// The results of disassembling the program in the input.

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			long r0 = 1;
			long r1 = 0;
			long r2 = 0;
			long r3 = 0;
			long r4 = 0;
			long r5 = 0;

			r3 += 2;
			r3 = r3 * r3;
			r3 = 19 * r3;
			r3 *= 11;
			r5 += 7;
			r5 *= 22;
			r5 += 18;
			r3 += r5;
			r5 = 27;
			r5 = r5 * 28;
			r5 += 29;
			r5 *= 30;
			r5 *= 14;
			r5 *= 32;
			r3 += r5;
			r0 = 0;

			r4 = 1;
			do
			{
				r2 = 1;
				do
				{
					r5 = r4 * r2;
					if (r5 == r3)
					{
						r0 = r0 + r4;
					}
					r2++;
				} while (r2 <= r3);
				r4++;
			} while (r4 <= r3);
			Console.WriteLine(r0);
			Console.WriteLine(r1);
			Console.WriteLine(r2);
			Console.WriteLine(r3);
			Console.WriteLine(r4);
			Console.WriteLine(r5);
			Console.ReadLine();
		}

	}
}
