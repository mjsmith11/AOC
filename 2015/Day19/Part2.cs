using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
	// This is a bad solution.  It relies on a random number generation.  It won't always get to the answer and assumes there is only one path between 'e' and the molecule
	class Part2
	{
		static void Main(string[] args)
		{
			// go backward from the molecule trying to find 'e'
			string[] replacements = getReplacements().Split('\n');
			string molecule = getMolecule();
			int steps = 0;
			Random rnd = new Random();
			while (molecule != "e")
			{
				// choose a replacements
				int r = rnd.Next(replacements.Length);
				string rTrim = replacements[r].Trim();
				string[] splits = rTrim.Split(new string[] { " => " }, StringSplitOptions.None);
				string from = splits[0];
				string to = splits[1];
				int foundLoc = molecule.IndexOf(to);
				if (foundLoc != -1)
				{
					molecule = replace(molecule, from, foundLoc, to.Length);
					Console.WriteLine(molecule);
					steps++;
				}

			}

			Console.WriteLine(steps);
			Console.Read();
		}

		public static string replace(string src, string replacement, int origLocation, int origSize)
		{
			string result  = src.Substring(0, origLocation);
			result = result + replacement;
			int endingStart = origLocation + origSize;
			result = result + src.Substring(endingStart, src.Length - endingStart);
			return result;
		}

		public static string getMolecule()
		{
			return "ORnPBPMgArCaCaCaSiThCaCaSiThCaCaPBSiRnFArRnFArCaCaSiThCaCaSiThCaCaCaCaCaCaSiRnFYFArSiRnMgArCaSiRnPTiTiBFYPBFArSiRnCaSiRnTiRnFArSiAlArPTiBPTiRnCaSiAlArCaPTiTiBPMgYFArPTiRnFArSiRnCaCaFArRnCaFArCaSiRnSiRnMgArFYCaSiRnMgArCaCaSiThPRnFArPBCaSiRnMgArCaCaSiThCaSiRnTiMgArFArSiThSiThCaCaSiRnMgArCaCaSiRnFArTiBPTiRnCaSiAlArCaPTiRnFArPBPBCaCaSiThCaPBSiThPRnFArSiThCaSiThCaSiThCaPTiBSiRnFYFArCaCaPRnFArPBCaCaPBSiRnTiRnFArCaPRnFArSiRnCaCaCaSiThCaRnCaFArYCaSiRnFArBCaCaCaSiThFArPBFArCaSiRnFArRnCaCaCaFArSiRnFArTiRnPMgArF";
		}
		public static string getReplacements()
		{
			return @"Al => ThF
Al => ThRnFAr
B => BCa
B => TiB
B => TiRnFAr
Ca => CaCa
Ca => PB
Ca => PRnFAr
Ca => SiRnFYFAr
Ca => SiRnMgAr
Ca => SiTh
F => CaF
F => PMg
F => SiAl
H => CRnAlAr
H => CRnFYFYFAr
H => CRnFYMgAr
H => CRnMgYFAr
H => HCa
H => NRnFYFAr
H => NRnMgAr
H => NTh
H => OB
H => ORnFAr
Mg => BF
Mg => TiMg
N => CRnFAr
N => HSi
O => CRnFYFAr
O => CRnMgAr
O => HP
O => NRnFAr
O => OTi
P => CaP
P => PTi
P => SiRnFAr
Si => CaSi
Th => ThCa
Ti => BP
Ti => TiTi
e => HF
e => NAl
e => OMg";
		}
	}
}
