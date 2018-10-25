// Something is up here.  It takes way too long.

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
		static string lookAndSay(string input)
		{
			char current = ' ';
			int count = 0;
			string output = "";
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == current) {
					count++;
				} else {
					if (current != ' ') {
						output = output + count;
						output = output + current;
					}
					current = input[i];
					count = 1;
				}
			}
			output = output + count;
			output = output + current;
			return output;
		}
		static void Main(string[] args)
		{
			string value = "1321131112";
			for (int i = 0; i < 50; i++)
			{
				Console.WriteLine(i);
				value = lookAndSay(value);
			}
			Console.WriteLine("Result " + value.Length);
			Console.Read();
		}

	}

}
