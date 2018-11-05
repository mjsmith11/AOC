using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
	class Part1
	{
		static void Main(string[] args)
		{
			Dictionary<string, string> results = new Dictionary<string, string>();
			string[] replacements = getReplacements().Split('\n');
			string molecule = getMolecule();
			foreach (string r in replacements)
			{
				string rTrim = r.Trim();
				string[] splits = rTrim.Split(new string[] { " => " }, StringSplitOptions.None);
				string from = splits[0];
				string to = splits[1];

				int startLoc = 0;
				int foundLoc = molecule.IndexOf(from, startLoc);
				while (foundLoc != -1)
				{
					results[replace(molecule, to, foundLoc, from.Length)] = "";

					startLoc = foundLoc + 1;
					foundLoc = molecule.IndexOf(from, startLoc);
				}

			}
			Console.WriteLine(results.Count());
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
