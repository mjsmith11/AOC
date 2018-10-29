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
			int frosting, candy, butterscotch, sugar;
			int tbsp;
			int max = 0;
			for (frosting = 0; frosting < 100; frosting++)
			{
				tbsp = frosting;
				for (candy = 0; candy < 100; candy++)
				{
					for (butterscotch = 0; butterscotch < 100; butterscotch++)
					{
						for (sugar = 0; sugar < 100; sugar++)
						{
							tbsp = frosting + candy + butterscotch + sugar;
							if (tbsp == 100)
							{
								int val = calculate(frosting, candy, butterscotch, sugar);
								if ((val > max) && (countCalories(frosting, candy, butterscotch, sugar) == 500))
								{
									max = val;
								}
							}
						}
					}
				}
			}
			Console.WriteLine(max);
			Console.Read();
		}
		public static int calculate(int frosting, int candy, int butterscotch, int sugar)
		{
			int capacity = (frosting * 4) - butterscotch;
			int durability = (-2 * frosting) + (5 * candy);
			int flavor = (-1 * candy) + (5 * butterscotch) - (2 * sugar);
			int texture = 2 * sugar;
			if (capacity <= 0) { return 0; }
			if (durability <= 0) { return 0; }
			if (flavor <= 0) { return 0; }
			if (texture <= 0) { return 0; }
			return capacity * durability * flavor * texture;
		}
		public static int countCalories(int frosting, int candy, int butterscotch, int sugar)
		{
			return (5 * frosting) + (8 * candy) + (6 * butterscotch) + sugar;
		}
	}
}
