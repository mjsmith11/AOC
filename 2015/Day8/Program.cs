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
			countMem("\"aaa\\\"aaa\"");
			string input = System.IO.File.ReadAllText(@"C:\temp\input.txt");
			string[] strings = input.Split('\n');
			int code = 0;
			int mem = 0;
			int enc = 0;
			foreach (string s in strings)
			{
				string trimmed = s.Trim();
				code += trimmed.Length;
				mem += countMem(trimmed);
				enc += countEncoded(trimmed);
			}
			Console.WriteLine(code - mem);
			Console.WriteLine(enc - code);
			Console.Read();
		}

		static int countMem(string s)
		{
			bool inStr = false;
			bool inEscape = false;
			int count = 0;
			for (int i = 0; i < s.Length; i++)
			{
				if (inStr)
				{
					if (inEscape)
					{
						inEscape = false;
						if (s[i] == '"' || s[i] == '\\')
						{
							continue;
						}
						else if (s[i] == 'x')
						{
							i += 2;
							continue;
						}
					}
					else
					{
						if (s[i] == '"')
						{
							inStr = false;
							continue;
						}
						else if (s[i] == '\\')
						{
							inEscape = true;
							count++;
							continue;
						}
						else
						{
							count++;
							continue;
						}
					}
				}
				else
				{
					if (s[i] == '"')
					{
						inStr = true;
						continue;
					}
					throw new Exception("idk what's happening");
				}
			}
			return count;
		}

		static int countEncoded(string s)
		{
			bool inStr = false;
			bool inEscape = false;
			int count = 6; 
			for (int i = 0; i < s.Length; i++)
			{
				if (inStr)
				{
					if (inEscape)
					{
						inEscape = false;
						if (s[i] == '"' || s[i] == '\\')
						{
							count += 3;
							continue;
						}
						else if (s[i] == 'x')
						{
							i += 2;
							count+=4;
							continue;
						}
					}
					else
					{
						if (s[i] == '"')
						{
							inStr = false;
							continue;
						}
						else if (s[i] == '\\')
						{
							inEscape = true;
							count++;
							continue;
						}
						else
						{
							count++;
							continue;
						}
					}
				}
				else
				{
					if (s[i] == '"')
					{
						inStr = true;
						continue;
					}
					throw new Exception("idk what's happening");
				}
			}
			return count;
		}
	}
}
