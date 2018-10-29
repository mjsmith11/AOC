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
		private static Dictionary<string, Dictionary<string, int>> happyness;
		private static int max;
		private static void Swap(ref char a, ref char b)
		{
			if (a == b) return;

			a ^= b;
			b ^= a;
			a ^= b;
		}

		public static void GetPer(char[] list)
		{
			int x = list.Length - 1;
			GetPer(list, 0, x);
		}

		private static void GetPer(char[] list, int k, int m)
		{
			if (k == m)
			{
				int val = getHappynessChange(list);
				if (val > max)
				{
					max = val;
				}
			}
			else
				for (int i = k; i <= m; i++)
				{
					Swap(ref list[k], ref list[i]);
					GetPer(list, k + 1, m);
					Swap(ref list[k], ref list[i]);
				}
		}

		static void Main(string[] args)
		{
			happyness = new Dictionary<string, Dictionary<string, int>>();
			happyness["Alice"] = new Dictionary<string,int>();
			happyness["Alice"]["Bob"] = 2;
			happyness["Alice"]["Carol"] = 26;
			happyness["Alice"]["David"] = -82;
			happyness["Alice"]["Eric"] = -75;
			happyness["Alice"]["Frank"] = 42;
			happyness["Alice"]["George"] = 38;
			happyness["Alice"]["Mallory"] = 39;
			happyness["Alice"]["Self"] = 0;

			happyness["Bob"] = new Dictionary<string, int>();
			happyness["Bob"]["Alice"] = 40;
			happyness["Bob"]["Carol"] = -61;
			happyness["Bob"]["David"] = -15;
			happyness["Bob"]["Eric"] = 63;
			happyness["Bob"]["Frank"] = 41;
			happyness["Bob"]["George"] = 30;
			happyness["Bob"]["Mallory"] = 87;
			happyness["Bob"]["Self"] = 0;

			happyness["Carol"] = new Dictionary<string, int>();
			happyness["Carol"]["Alice"] = -35;
			happyness["Carol"]["Bob"] = -99;
			happyness["Carol"]["David"] = -51;
			happyness["Carol"]["Eric"] = 95;
			happyness["Carol"]["Frank"] = 90;
			happyness["Carol"]["George"] = -16;
			happyness["Carol"]["Mallory"] = 94;
			happyness["Carol"]["Self"] = 0;

			happyness["David"] = new Dictionary<string, int>();
			happyness["David"]["Alice"] = 36;
			happyness["David"]["Bob"] = -18;
			happyness["David"]["Carol"] = -65;
			happyness["David"]["Eric"] = -18;
			happyness["David"]["Frank"] = -22;
			happyness["David"]["George"] = 2;
			happyness["David"]["Mallory"] = 42;
			happyness["David"]["Self"] = 0;

			happyness["Eric"] = new Dictionary<string, int>();
			happyness["Eric"]["Alice"] = -65;
			happyness["Eric"]["Bob"] = 24;
			happyness["Eric"]["Carol"] = 100;
			happyness["Eric"]["David"] = 51;
			happyness["Eric"]["Frank"] = 21;
			happyness["Eric"]["George"] = 55;
			happyness["Eric"]["Mallory"] = -44;
			happyness["Eric"]["Self"] = 0;

			happyness["Frank"] = new Dictionary<string, int>();
			happyness["Frank"]["Alice"] = -48;
			happyness["Frank"]["Bob"] = 91;
			happyness["Frank"]["Carol"] = 8;
			happyness["Frank"]["David"] = -66;
			happyness["Frank"]["Eric"] = 97;
			happyness["Frank"]["George"] = -9;
			happyness["Frank"]["Mallory"] = -92;
			happyness["Frank"]["Self"] = 0;

			happyness["George"] = new Dictionary<string, int>();
			happyness["George"]["Alice"] = -44;
			happyness["George"]["Bob"] = -25;
			happyness["George"]["Carol"] = 17;
			happyness["George"]["David"] = 92;
			happyness["George"]["Eric"] = -92;
			happyness["George"]["Frank"] = 18;
			happyness["George"]["Mallory"] = 97;
			happyness["George"]["Self"] = 0;

			happyness["Mallory"] = new Dictionary<string, int>();
			happyness["Mallory"]["Alice"] = 92;
			happyness["Mallory"]["Bob"] = -96;
			happyness["Mallory"]["Carol"] = -51;
			happyness["Mallory"]["David"] = -81;
			happyness["Mallory"]["Eric"] = 31;
			happyness["Mallory"]["Frank"] = -73;
			happyness["Mallory"]["George"] = -89;
			happyness["Mallory"]["Self"] = 0;

			happyness["Self"] = new Dictionary<string, int>();
			happyness["Self"]["Alice"] = 0;
			happyness["Self"]["Bob"] = 0;
			happyness["Self"]["Carol"] = 0;
			happyness["Self"]["David"] = 0;
			happyness["Self"]["Eric"] = 0;
			happyness["Self"]["Frank"] = 0;
			happyness["Self"]["George"] = 0;
			happyness["Self"]["Mallory"] = 0;

			max = 0;
			GetPer("012345678".ToCharArray());
			Console.WriteLine(max);
			Console.Read();
		}

		public static int getHappynessChange(char[] seats)
		{
			int happynessVal = 0;

			//seat 0 is special
			string seat0Name = getName(seats[0]);
			string seat8Name = getName(seats[8]);
			string seat1Name = getName(seats[1]);
			happynessVal += happyness[seat0Name][seat8Name];
			happynessVal += happyness[seat0Name][seat1Name];

			// seat 8 is special
			string seat7Name = getName(seats[7]);
			happynessVal += happyness[seat8Name][seat7Name];
			happynessVal += happyness[seat8Name][seat0Name];

			for (int i = 1; i <= 7; i++)
			{
				string seatName = getName(seats[i]);
				string leftName = getName(seats[i - 1]);
				string rightName = getName(seats[i + 1]);
				happynessVal += happyness[seatName][leftName];
				happynessVal += happyness[seatName][rightName];
			}
			return happynessVal;
		}

		public static string getName(char num)
		{
			switch (num)
			{
				case '0': return "Alice";
				case '1': return "Bob";
				case '2': return "Carol";
				case '3': return "David";
				case '4': return "Eric";
				case '5': return "Frank";
				case '6': return "George";
				case '7': return "Mallory";
				case '8': return "Self";
				default: return "";
			}
		}

	}


}
