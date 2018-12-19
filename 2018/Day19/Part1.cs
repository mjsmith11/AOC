using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// This runs part 2. For part 1, remove comment on line 1667
// It's not perfect, I had to output the final map
// to a file and count up the water areas I missed and add it to the result.

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			int ipReg = 1;
			string input = @"addi 1 16 1
seti 1 4 4
seti 1 1 2
mulr 4 2 5
eqrr 5 3 5
addr 5 1 1
addi 1 1 1
addr 4 0 0
addi 2 1 2
gtrr 2 3 5
addr 1 5 1
seti 2 4 1
addi 4 1 4
gtrr 4 3 5
addr 5 1 1
seti 1 1 1
mulr 1 1 1
addi 3 2 3
mulr 3 3 3
mulr 1 3 3
muli 3 11 3
addi 5 7 5
mulr 5 1 5
addi 5 18 5
addr 3 5 3
addr 1 0 1
seti 0 7 1
setr 1 3 5
mulr 5 1 5
addr 1 5 5
mulr 1 5 5
muli 5 14 5
mulr 5 1 5
addr 3 5 3
seti 0 7 0
seti 0 6 1";
			string[] splits = input.Split('\n');
			int pc = 0;
			int[] reg = new int[6];
			reg[0] = 0;
			reg[1] = 0;
			reg[2] = 0;
			reg[3] = 0;
			reg[4] = 0;
			reg[5] = 0;
			while (pc < splits.Length)
			{

				int[] inst = new int[4];
				reg[ipReg] = pc;

				//parse out instructions
				string[] instNums = splits[pc].Split(' ');
				string opcode = instNums[0];
				inst[1] = int.Parse(instNums[1].Trim());
				inst[2] = int.Parse(instNums[2].Trim());
				inst[3] = int.Parse(instNums[3].Trim());


				switch (opcode)
				{
					case "bori":
						reg = bori(reg, inst);
						break;
					case "muli":
						reg = muli(reg, inst);
						break;
					case "banr":
						reg = banr(reg, inst);
						break;
					case "bani":
						reg = bani(reg, inst);
						break;
					case "gtir":
						reg = gtir(reg, inst);
						break;
					case "setr":
						reg = setr(reg, inst);
						break;
					case "addr":
						reg = addr(reg, inst);
						break;
					case "eqir":
						reg = eqir(reg, inst);
						break;
					case "seti":
						reg = seti(reg, inst);
						break;
					case "addi":
						reg = addi(reg, inst);
						break;
					case "eqrr":
						reg = eqrr(reg, inst);
						break;
					case "eqri":
						reg = eqri(reg, inst);
						break;
					case "borr":
						reg = borr(reg, inst);
						break;
					case "gtrr":
						reg = gtrr(reg, inst);
						break;
					case "mulr":
						reg = mulr(reg, inst);
						break;
					case "gtri":
						reg = gtri(reg, inst);
						break;
					default:
						Console.WriteLine("Bad Code");
						break;
				}
				pc = reg[ipReg];
				pc++;
			}
			Console.Write(reg[0]);
			Console.ReadLine();
		}
		public static bool arrayEq(int[] a, int[] b)
		{
			if (a.Length != b.Length)
			{
				return false;
			}
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] != b[i])
				{
					return false;
				}
			}
			return true;
		}
		public static int[] addr(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]] + before[inst[2]];
			return before;
		}

		public static int[] addi(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]] + inst[2];
			return before;
		}

		public static int[] mulr(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]] * before[inst[2]];
			return before;
		}

		public static int[] muli(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]] * inst[2];
			return before;
		}

		public static int[] banr(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]] & before[inst[2]];
			return before;
		}

		public static int[] bani(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]] & inst[2];
			return before;
		}

		public static int[] borr(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]] | before[inst[2]];
			return before;
		}

		public static int[] bori(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]] | inst[2];
			return before;
		}

		public static int[] gtir(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = inst[1] > before[inst[2]] ? 1 : 0;
			return before;
		}

		public static int[] gtri(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]] > inst[2] ? 1 : 0;
			return before;
		}

		public static int[] gtrr(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]] > before[inst[2]] ? 1 : 0;
			return before;
		}

		public static int[] eqir(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = inst[1] == before[inst[2]] ? 1 : 0;
			return before;
		}

		public static int[] eqri(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]] == inst[2] ? 1 : 0;
			return before;
		}

		public static int[] eqrr(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]] == before[inst[2]] ? 1 : 0;
			return before;
		}
		public static int[] setr(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = before[inst[1]];
			return before;
		}
		public static int[] seti(int[] bef, int[] inst)
		{
			int[] before = new int[6];
			Array.Copy(bef, before, 6);
			before[inst[3]] = inst[1];
			return before;
		}


	}
}
