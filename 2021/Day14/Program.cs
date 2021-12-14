// See https://aka.ms/new-console-template for more information
Console.WriteLine("Part 1 : " + solve(10));
Console.WriteLine("Part 2 : " + solve(40));


static long solve(int rounds) {
    string polymerstr = getTemplate();
    string[] ruleStrings = getRules();
    Dictionary<string,string> rules = new Dictionary<string,string>();
    foreach (string r in ruleStrings) {
        string[] splits = r.Trim().Split(" -> ");
        rules[splits[0]] = splits[1];
    }
    Dictionary<string,long> components = new Dictionary<string,long>();
    for(int i=0; i<polymerstr.Length-1; i++) {
        string comp = polymerstr.Substring(i,2);
        if(components.ContainsKey(comp)) {
            components[comp]++;
        } else {
            components[comp] = 1;
        }
    }
    
    // do all the insertions for all the rounds. Each Pair becomes 2 pairs
    for(int i=0; i<rounds; i++) {
        Dictionary<string,long> newComponents = new Dictionary<string,long>();
        foreach(string k in components.Keys) {
            string insertion = rules[k];
            if (newComponents.ContainsKey(k.Substring(0,1) + insertion)) {
                newComponents[k.Substring(0,1) + insertion] += components[k];
            } else {
                newComponents[k.Substring(0,1) + insertion] = components[k];
            }
            if (newComponents.ContainsKey(insertion + k.Substring(1,1))) {
                newComponents[insertion + k.Substring(1,1)] += components[k];
            } else {
                newComponents[insertion + k.Substring(1,1)] = components[k];
            }
            
        }
        components = newComponents;
    }

    // count all the elements
    Dictionary<string,long> counts = new Dictionary<string,long>();
    foreach(string k in components.Keys) {
        if(counts.ContainsKey(k.Substring(0,1))) {
            counts[k.Substring(0,1)] += components[k];
        } else {
            counts[k.Substring(0,1)] = components[k];
        }

        if(counts.ContainsKey(k.Substring(1,1))) {
            counts[k.Substring(1,1)] += components[k];
        } else {
            counts[k.Substring(1,1)] = components[k];
        }
    }

    // because of the overlapping pairs, everything is counted twice except the very first and very last elements
    // Divide by 2 and add one for odd numbers
    foreach(string s in counts.Keys) {
        if (counts[s] % 2 == 1) {
            counts[s]++;
        }
        counts[s] /=2; 
    }
    return counts.Values.Max() - counts.Values.Min();
}

static string getTemplate() {
    return "NBOKHVHOSVKSSBSVVBCS";
}

static string[] getRules() {
    string rules = @"SN -> H
KP -> O
CP -> V
FN -> P
FV -> S
HO -> S
NS -> N
OP -> C
HC -> S
NP -> B
CF -> V
NN -> O
OS -> F
VO -> V
HK -> N
SV -> V
VC -> V
PH -> K
NH -> O
SB -> N
KS -> V
CB -> H
SS -> P
SP -> H
VN -> K
VP -> O
SK -> V
VF -> C
VV -> B
SF -> K
HH -> K
PV -> V
SO -> H
NK -> P
NO -> C
ON -> S
PB -> K
VS -> H
SC -> P
HS -> P
BS -> P
CS -> P
VB -> V
BP -> K
FH -> O
OF -> F
HF -> F
FS -> C
BN -> O
NC -> F
FC -> B
CV -> V
HN -> C
KF -> K
OO -> P
CC -> S
FF -> C
BC -> P
PP -> F
KO -> V
PC -> B
HB -> H
OB -> N
OV -> S
KH -> B
BO -> B
HV -> P
BV -> K
PS -> F
CH -> C
SH -> H
OK -> V
NB -> K
BF -> S
CO -> O
NV -> H
FB -> K
FO -> C
CK -> P
BH -> B
OH -> F
KB -> N
OC -> K
KK -> O
CN -> H
FP -> K
VH -> K
VK -> P
HP -> S
FK -> F
BK -> H
KV -> V
BB -> O
KC -> F
KN -> C
PO -> P
NF -> P
PN -> S
PF -> S
PK -> O";
    return rules.Split("\n");
}