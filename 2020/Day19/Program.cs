using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace Day19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1: " + part1(0, false));
            Console.WriteLine("Part 2");
            // part 2 is a bit of a mess today.
            // Rule 0 is 8 11.
            // Since we are changing 8 from 42 to 42 | 42 8, that's 1 or more occurences of whatever rule 42 is
            // so we can identify the regex for 42 and add a + to the part 1 regex after the first occurence of the 42 regex.
            // Since rule 11 changes from 42 31 to 42 31 | 42 11 31, this turns out to be 1 or more matches of rule 42 followed
            // by one or more matches for rule 31.  Regexes don't natively support this, so we add {x} after the 2nd occurence
            // of the rule 42 regex in the part 1 regex and the same {x} after the regex for rule 31.
            Console.WriteLine("Full Part 1 Regex");
            part1(0,true);
            Console.WriteLine("Rule 42");
            part1(42, true);
            Console.WriteLine("Rule 31");
            part1(31, true);

            Console.WriteLine("Answer: " + checker());
        }

        // builds the described regex in the main method and counts the number of messages that match for
        // values of x from 1 to 10
        static int checker() {
            int grandTotal = 0;
            for (int i = 1; i< 10; i++) {
                string regex = @"^(((a(b(b(b((ba|ab)a|(b(b|a)|aa)b)|a((a(b|a)|bb)b|(bb|ba)a))|a(((b(b|a)|aa)b|(ab)a)b|((aa|bb)b|(ab|(b|a)a)a)a))|a(a(a(a((b|a)b|ba)|b(a(b|a)|bb))|b((bb)a|(ab|aa)b))|b(a(b((b|a)(b|a))|a(ab|aa))|b(b(ab)|a(a(b|a)|bb)))))|b((a(b(a(ba|ab)|b(aa))|a((a(b|a)|bb)b|((b|a)b|ba)a))|b(b((aa)b)|a(b(aa)|a(aa))))b|(a((b(aa|bb)|a(bb))a|(b(aa)|a(aa))b)|b(a((a(b|a)|bb)a|((b|a)(b|a))b)|b(b(bb|ba)|a(a(b|a)|bb))))a))a|(a(a(a(b((bb)b)|a(b(ab|aa)))|b((a(aa|bb)|b((b|a)b|ba))a|((ba|ab)b|(ab|(b|a)a)a)b))|b(a(b(b(ab|aa))|a(b(ab|(b|a)a)))|b((b(bb)|a(bb|ba))b|((bb)b|(a(b|a)|bb)a)a)))|b(b((((ab)a)b|(a(aa)|b(ab|(b|a)a))a)a|((a(b(b|a)|aa)|b(ab|(b|a)a))b|(b((b|a)(b|a))|a(ab|aa))a)b)|a((b((aa|bb)a|((b|a)(b|a))b)|a(b((b|a)(b|a))|a(ab|aa)))b|((a(bb|ba)|b(aa))a|((b|a)(ba|ab))b)a)))b)+)(((a(b(b(b((ba|ab)a|(b(b|a)|aa)b)|a((a(b|a)|bb)b|(bb|ba)a))|a(((b(b|a)|aa)b|(ab)a)b|((aa|bb)b|(ab|(b|a)a)a)a))|a(a(a(a((b|a)b|ba)|b(a(b|a)|bb))|b((bb)a|(ab|aa)b))|b(a(b((b|a)(b|a))|a(ab|aa))|b(b(ab)|a(a(b|a)|bb)))))|b((a(b(a(ba|ab)|b(aa))|a((a(b|a)|bb)b|((b|a)b|ba)a))|b(b((aa)b)|a(b(aa)|a(aa))))b|(a((b(aa|bb)|a(bb))a|(b(aa)|a(aa))b)|b(a((a(b|a)|bb)a|((b|a)(b|a))b)|b(b(bb|ba)|a(a(b|a)|bb))))a))a|(a(a(a(b((bb)b)|a(b(ab|aa)))|b((a(aa|bb)|b((b|a)b|ba))a|((ba|ab)b|(ab|(b|a)a)a)b))|b(a(b(b(ab|aa))|a(b(ab|(b|a)a)))|b((b(bb)|a(bb|ba))b|((bb)b|(a(b|a)|bb)a)a)))|b(b((((ab)a)b|(a(aa)|b(ab|(b|a)a))a)a|((a(b(b|a)|aa)|b(ab|(b|a)a))b|(b((b|a)(b|a))|a(ab|aa))a)b)|a((b((aa|bb)a|((b|a)(b|a))b)|a(b((b|a)(b|a))|a(ab|aa)))b|((a(bb|ba)|b(aa))a|((b|a)(ba|ab))b)a)))b){";
                regex = regex + i;
                regex = regex + @"}(a(a(a((((b(b|a)|aa)a|((b|a)(b|a))b)a|(b(ab|(b|a)a)|a(a(b|a)|bb))b)b|(((bb)a|(bb)b)b|((ba|ab)b|(b(b|a)|aa)a)a)a)|b(b(((aa)a|(bb|ba)b)b|(((b|a)b|ba)a|(bb)b)a)|a(((ab)a|(ab)b)a|(a(bb|ba)|b(aa))b)))|b((((a(ba|aa)|b(ba))a|(a(b(b|a)|aa)|b(ab|(b|a)a))b)a|(b((ba|aa)b|(b(b|a)|aa)a)|a(((b|a)(b|a))b|(ba|aa)a))b)b|(a(((bb)a|(ba|ab)b)a|((b(b|a)|aa)a|(ab)b)b)|b(a((ba)b|(ab|aa)a)|b(b(ba)|a(aa|bb))))a))|b((((a(b((b|a)b|ba)|a(ba))|b((a(b|a)|bb)a|((b|a)(b|a))b))b|(((bb)b|(a(b|a)|bb)a)a|(a(bb)|b((b|a)(b|a)))b)a)b|(((a(ba|aa)|b(ba))b|(((b|a)(b|a))b|(aa)a)a)a|(b(b(ba))|a((b|a)((b|a)b|ba)))b)a)a|(b(a(b((ba|aa)b|(b(b|a)|aa)a)|a(((b|a)b|ba)a|(bb)b))|b(b(((b|a)b|ba)a|(bb)b)|a(b(ba)|a(ba))))|a(a(a((bb|ba)b|(ab|(b|a)a)a)|b(b(ba)))|b((b(aa)|a(ba))b|(a(ba|ab)|b(b(b|a)|aa))a)))b)){"; //8})$
                regex = regex + i;
                regex = regex + @"})$";
                int numMatches = 0;
                foreach(string s in getMessages()) {
                    Match m = Regex.Match(s.Trim(), regex);
                    if (m.Success) {numMatches++;}
                }
                grandTotal += numMatches;
            }
            return grandTotal;
        }

        static int part1(int rule, bool printRegex) {
            Dictionary<int,string> rules = new Dictionary<int,string>();
            foreach(string s in getInput()) {
                string[] splits = s.Split(':');
                rules[int.Parse(splits[0])] = splits[1] + " "; // make sure numbers are surrounded by spaces so we don't replace something like 48 when trying to replace 4
            }

            string myRule = rules[rule];
            string regex = @"\d+";
            MatchCollection matches = Regex.Matches(myRule, regex);

            while(matches.Count > 0) {
                foreach(Match m in matches) {
                    myRule = myRule.Replace(" " + m.Value + " ", " ("+rules[int.Parse(m.Value)]+") "); // make sure numbers are surrounded by spaces so we don't replace something like 48 when trying to replace 4
                }
                matches = Regex.Matches(myRule,regex);
            }
            // boil it down to a regex
            myRule = myRule.Replace(" ","");
            myRule = myRule.Replace("(\"a\")", "a");
            myRule = myRule.Replace("(\"b\")", "b");
            myRule = "^"+myRule+"$";
            if (printRegex) {
                Console.WriteLine(myRule);
            }

            int count = 0;
            foreach(string s in getMessages()) {
                Match m = Regex.Match(s.Trim(),myRule);
                if (m.Success) {count++; }
            }
            return count;
            
        }


        static string[] getInput() {
            string input = System.IO.File.ReadAllText(@"input.txt");
            return input.Split('\n');
        }

        static string[] getMessages() {
            return @"bbabbbbbbbbaabbaaaaaabaaaabbaaaa
aaaabaaaabbabbaaabbabbabbbaaaaaaaababbabababbbaababababbbabaabbbbaaababbaaaaaaaaabbbbabb
aaaaaabaaaabaabaabbaaababaabbabb
baabbbbaabaaabbbbbaabbbabbbbbbabbabbaabb
ababbabbbbaaabbbaabbbbababbbbbbbaaababababbaaaaaabbbabbb
aababaaaabbaaaabbabbbbaa
bbaabbaababaaabbaabaabbb
abbabbbaabbbaaabbbabaaaabbbbbbbaaabbbbaabbaabbba
bbbabbbbbaabbaaaaaaaaaaa
abaabaababbaaaabbabbaababbbbbbbaabaabbba
babaaaaabaabbabbbbbbabbbbbabbbaabbbabbba
bbaaaaabbbbbabbabbaaababaaaaaaaabbabaaabbabbbbab
bbbbaaabaaabbbbbbaaabbaa
aaaababbbbbabbaababbabab
abbaaaabababaaaabbaabaaaaaababbaaabbabaabaaababb
bbababbbabbbbaaabbbaaaba
bbaabbaaaaabbabbbbbbbbabbbabaabababababbaaabaaabaaabaabbbbaabbaaababbbbbabbaaaab
ababbabbbbabbabbbbaababbabaabaaabababbbbbabbbaabbabbbababbabbaaa
babbabaaabababaababaaaaabbbbbbbb
aaababbabaaabababbaabbab
babaaaaabababbabbabababb
bbbaabaaabbbbbbbbabaabbbabbabbbbbbbbbaba
bbbaaaababbbbabababaabbabbabaabaaaaaaaaa
aababbabbabbbaaaaaaabbbabaabaabbabbabaaabaabaaaaababbbabbabbabaa
baaaabbaaabbababbaabaaabbbaaabab
aaaaaababaaabbabaabbababbbaababb
bbaabaaaababaabbababbbbb
abbbbababbbabababbaaabba
aaabbabaaabababbbaabbbaaabaabaabbabbbbaababbbbababbbaaaaabaaaabbbabababbaaaabaaaabaaabaa
bbbbaaabababbbaaabaaabab
babaabbbabbbaaaaabaaabababbaabbaabbbbbbbbbababaaabbbabaabbbbbbaa
aabbbbabbbabbbbbababbbbabbbbbaabbabaabab
aabbabbabbbbbbaabbaaabbb
ababbbaabbbabbaaabbabbbbaaaaaaaa
bbbbbabbabbabaaaabbbabbaaabbababbbbabaabbaababaabbaaababbaaaaaab
bbaaabbbbabaabbabbaababbaaaabaaabaaaaaabaababaab
abbbbaabaaabaababbbbbaba
bbababbbabbbababbaaabbaa
bbabaababbaabaaabbbabaababaaabbb
bbbbbaaabbaabbaababaaaabbbbbbbaabbaabbababaabbaabaaabaaabaaababbbbabbbabbbaabbba
aababababbbaabaabababbbbaabbabbaabaabbaa
baaaabaabbbbbabbaabbbabb
bbbbaaabaabbababbbbaaaabbbabbbab
aaabbbaaabbababbabaaaabb
babaaaaabbaaabbbaaabaabb
babbbabbabbbbbababbaabab
aabaaaaabaabaabbaabaabaa
aababbaabaabbbbaaababbbbbabababbabbbbbaaaaaaaababbabbaba
abaaabaababbababbbbbaabbabbabaabbaaaababbababaab
baabbabaaabbaabaabbbaabb
bbbbbaaabaaaabbabbaaaabbaababbabbbbbaabaaaabaaabbbbbbaab
bbbbaabbbaababbbbbabbbab
aaaababbaabbbabababbabbbbbaabbbaabbbabbabbaabbbaabbbaabbbaaaaaab
baabaabaababbbbbbaaabaabbbabaaaaaaabaabb
bbbbbaaabaababababaabaaaabbaaaabaaaaaabb
abbaaaabbbaababbbabbbbba
abaababababbaabaababbbbb
abaaaaaaaaaaabbabbababbaabbaabaaabababaaaaabbbba
babbbaaabbabbaaaabbaabab
babaabbbabbababbbbbbabba
baaaabaabaaaabaabbabbbab
babbaababbaaaaabbaababaa
abbabaabbabaaaaababbabbbbbbbbbba
aabaabbabbaabbabbbbabbba
aababbaabbababaabaaaaabbbabbaabbbababaaa
babbbabbabaaabbaabababbaababaaab
aababaabbbbaaabbaaababbaabbbbababbabaabaaaababbaaaababaa
bbaabbbababaaabababbaaabaabbbbaa
aaaabbbaababbbbaaabaaabababbaabb
abbaaababaaaaaaababbbbba
aababbabaababbabbbbbbabbaaaaabbaaabbabbaaaabbaba
bbababaaababbbbbbbaabbbaaabbbaabbbaabbaabbaabbaa
bbbaaabbbabbbaaabbbababa
bbabbbaabababbbbaaaabbbabababbba
bbabbaaaabbbbaabbaaaaaaaabaabbaa
bbbbbaaaabbabbbaabbbabba
bbbababbbabaaaabbbbaaaabbbabaabb
ababbbbaaabbabbabbaababbbbbabbaaabababab
ababbaaabaaaaabababbbaaabbaababbabbbabbbababbababbbbbbaababaabba
baabbaaabbaaaaabaaaabbab
bbaaabbbbbabbbaabbabababbaaabbab
aababbabbbabbaaabbabbbab
aabbbabaabbabbbaabbaabab
baaabbbaabbbbaaaaabbaaaaabaababbaabababbbaabbbab
bbaaaabbbaaaabbbbbbabbba
abbbaababaabbaaaaababbbbabaabbba
baaaabaabaabaaabbabaabbaababaaaabbbbaababbbbabab
babaabaaaabaaaabbbbababbbababbba
bbabbaaabbaaabaaabaaabbb
baabaabaabbbbababababbbaabbaabbbbabbbababbaabaabbbbaaaba
ababbabbbbbaaabbaaaababaabbabbbbbabaababbbbbaaaa
baaaabaababaabaaaaabbabb
ababaaaaabbabababaababaa
babbbabbaaaaaabaabbbabbb
baaabbbaabaaaaaabbabbbaabbaaabbbbaaaaaab
abbbabababbaaaaababbaabbaaabbbab
baaaabbaabaababaabbababbbabbbabbabbbabba
bbabababaabbbabaaaaaaabaaabbbbaa
bbbabbaaabaabaabaabaaaaabbaababa
baaaabbaabbbaabaaabbaaaaabababab
bbbbabbbbabbbaaabababbbbbaababba
aaaabaaabbaababbbbaabbbb
bbbaabbabbbbbbbbabbabbbbbaabbabbaaababaabbabababaaaaabbbbbaaaaab
baabbbbbbababbabbbabbbba
abbababbbbabbaaababaaabaababbaaaaabaabbbbaabbbaaaabbbbbb
baabbbaabbbbaababbabbbbaababbaaaababaaabbaaabbabbaabbaaaabaababbabbbbabbbbaabbaaaababbbb
abbbbaaaabbaabbaabbbaabb
babaaaababababaaaaabbabbbabbbaabaabaabbabaabbbaabbbbbbaaabaaaabbbaaabbaaaabaabbabaaabbba
aababbbbbaaabbbaaaaabaaaaabaaaabbbbbabba
baabbaaaabbbaabaabbabbbb
aaaaabaababaababbabbbabaaaaabbaaaabbbbaaaabaaabbababaababbaaabbb
bbabbbbbaabbaaaaaabbbabb
bbbbbabbbabbbabbbbbababbbabaababaaaaaaaa
baaaaaaabbabbbbaabababab
abaabaabbaabaaabaaaaaabb
abbaaabaaabaaabbbbabbbab
abaabaabbaaaaabbaaaaabaabbaaabab
bbbaabaabaabaabbbbbababbaaabbbbbbbbabbab
baabbbbbbababbabbbbababbbbbbbaba
abaaabbabbbaaabbbababaab
abbabaaaaabbaabbabbbaaaa
ababbabababbbabaaababbbbbbbabaaaabaaaaabaabababb
aaaabbbababbbbbbaaaabbaabbaabbaabbbbabbb
abbbbababaaaabaaaaaaabab
aababbaabbababaaaaaabaab
baabbbaabbabaababbaaabbbaaaaaaaaabbbbbabababababaaabababaabbbbbaabbbbbabbaaaabba
abaababaabaababaaaaabbaa
bbbbbbaaabbbbaaabaaaabaaabaaaaaaaaaaaabb
baaabbababababbaabbbbabb
abaaaaaabbaaaabbaabaabaaabbbabbbababaabb
babbabbbbabaabaaabbbabaabbaaaaaaabbbbbabbbababab
bbbbaabbaaabbbaabbbbbbab
abaabaabbaabaaabababaaba
bababbbbaababaaabbbbbbab
aaaaabbbababababbabbaaaa
baabbbbbababbbbabbaaabab
abaaababbbbaaaabbbabbbababbbabbbabbbbabbabaaababaaabbbabababaaabaababbaa
babaabbbaaabbbaabbbabbaababababbbbbaaaaaabbbbaabaaaabaabbbaaaaaaababaaabbabbabaa
baabbaaabbabbaaaaabaaaaaabaaabab
abaabaabaabaaabbaaaaabaa
bbbbbbbbbbaabbbaabbabbab
bbbabaababbababbaabbbabaabaabbba
babbbbbbbbbaabbbbbbaabab
bbbbbbababbbabbbabbbabbaaaababaaabababbbbabaabab
baabbbbaaabbbbababbbbbbabaaabbbaababaaababbaabaaababaabb
baabababbabaaaabaabbabbbbbbabbababbbbaaaababbaaaaaaaaaaabababaababaabbba
abbbbaaabbbaabbbbbbbabbaabababbababbbbaabababbababbbabbbbbabaabbbabbbbbb
babbbaaabababbaaaaabbbba
baaabaabbabbbbabbbbbaaaabbbbabbabaaaaabbaaaaaababbabbababbbbbabababbbbabbbaabaabbbaababb
abaabbabaabbaabbaabaabab
abbbbbbbababbabbbbbabbab
abaabaaabbabababbbbabbba
abababbaabbbbbbbbaababbbbbbbaaaabababababaaabbbbabbabaababaabaabbabbabaaababbabaaaaabbab
bbbbaaabaaaababaabbabbab
baabaabbbabaabbbaaaababbbabbaaabaabbbabb
babaababbbabbaabbababaabbaaababa
babbbabbaaabaabaabbabbaaaabaabab
aabbbbabbabaaaaabaabbbaa
bbaaaaaabbbbbabbbbaaaaabaaababaabbabaabb
abababbaababbaabbaaabaab
abababbaabbbbbabbbbaabaabaaaaaababbaaabb
aabbbaabaabbabababbbaaaa
aababbabaaababbaaabbbbabbabbbbbababbababbbabbbaa
bbbabbaaabaaabaaaababaab
baabbabaabbaabbaaaabaaaa
baabaabbaabaaabaabbabbaaaaaabbbbaabaabbb
bbbaabaaaababbbbbbbbabaa
baabaabbaababaaaabbaabbbaaabbbbabbbbabab
babbbaaabbabababbbaaaababbbbaaaa
bbabbaaaaababaabbbaaaababbbaaaababaaabbaaaabbaabbbbbbbaabaabaaabbabbabbbbabbbbbbabaabaaa
abaaababbbbabbbabbaabbbaababaaabaaabbaaa
aabbababababbaabaabaaabababaabababaaaabb
bbbbabbbaabbaaaaaabbbbba
baabaababbbbbaaaaababbabbbaaabbbbaababba
aababaaaabbbaababbbabbba
baabaabababbbbbbbabbaaaa
bbaaaabbbababbbabbababbabaaaaaaaaaabaaabbbbbaabaabaaabab
baaaabbbaabbabbaabbbbaaa
baabbabaaabaaabbababbbaaaabbbbabababbabbabbaabaa
aababbaaaaabaababababaab
aaaabbbaaabaaabbbaaabbaa
aaaabaababaababaaabaaaabbabbabaa
bbbabaabaabbbabbbaaabaababbbaaab
bbabaaabababaaabbaaabaababaabbba
abbbaabaababaaaaabbbabab
abbbbbabbbbabaabaabbbbabbbbaaababbabbaba
aaaabbbaabbaabbabaaabbaaabaaaabb
baabbabbaabbaabbbbaaabbbabbaabababbabbbbabbbbaabaaaaabaa
bbbaaaabaaaabbabaaababab
aabbabbbbaabaaabbabababb
aabbbbabaabbaaaabbabaaab
aabaaabaaaabbaaaabaababbbaababbaabbbabbaabbabaaaaabababbabbabbbbbbaaaabbbbbabbab
bbbbabbbbbbbbbaaabbabaaabbaaaabbabbbbabbbbbbbbababbaaaabaaaaabbabbabaabbabaabaaa
ababbaabaaaabababbbbabaa
aabbaaaabaaaaabbabbaaaabbababbbbabababbaabbbaaaa
bbaababbaaaabaabbaaaabaaabbababbaaaababaaaaaabbb
abbabbaaaabaaaaabbbabbabaaabbaaabaaabaaaaabaaabbaabbaabbbbbbabbbaabaaaababbabbab
abbbbababbaaababbbbbbbbbbbbabbbabbbaabbbaaaabaaaabbaaaabbabbbabb
bbbbbaaabaaababaabbbabab
bbbabaabbbbabbbbbbbbbbbaaaaaaabbbaabaabaababaaab
aababaaaababbaabbbabbbab
abbabbbbbaabbbbaaabbbbabbabbbbabbaaaaaab
baabbaaaabaaabababbbbbaa
aababbaababbbabbbbbbaaabbbbbabaa
bababbabaaaabaaabaabbabbaabaaabbabbaabbababbbbaabbbbbaba
bbaaaaabaababaaabbbabbab
bbbaaaabbababbabaababbabaaabaaaa
babbbbbabaabaaababaabbaa
abababbbbbbbaabababbaaab
baabababaaaabbbabaabaaaa
aaababbabaaaabaaaabbabbbbaabaaababbabbbbabbabababbabbbbabaaabaaa
bbbababbabbbaaabbaaabaababbaabaabbbaaabaabaaaabb
bbaaaaaabbbabbbbbbbbaabbbbaabaaaaaaaabbbbbbabbba
abaaabaababaaaabaaaaabab
ababbbaabbabbabaabababaa
baaaaaabbaaabaabbbbaaaba
bbbaaaabbbaababaabababbb
baabaaabaaaaaabaaaaaabaaaabaaabbaabababaaaaaaabb
abaaabbabaaabbabbbbbabab
bbbabaabbbbbabbbaabaaabbbbbabaaabbabaabb
bbaaabaaabababbaaabbabaa
bbaabaaababaaaabaabbabbbabbabbbbababaabbbbaabbbbbaabbbab
aababbabbbabbbababaaaabaaaababbb
aababbbbabbabbbaaaaabaabababaabb
abababbabaaabbabbbaaaaaa
aababababbbaabaaaababbbababaabbabbabaaab
aababbbaaaaabaabbbaababbbbabaabababaababababbaba
baaaabbabbbabbaaaabbabbaabbaabaa
babaabbaababbabbaababaaabaaababaababbbbb
abaabaaaabaaabbabaabbbaa
aabaaabbabbbbababbbabbaabbbabaaabaaaaaaabbbbbaabbabbbaba
aababaaababbababaababbabaaaabbaaababbbab
ababbabaaabaabbbbbabbabbbbbbbaab
babaaabbabaababbbbaaaabbaaabbbba
baababbbbbbbabababaaaaababaabbbbbaabaaab
bbbabaabbbaaaaaabbbbabba
babbaabbbbbaabbabaabbbbaabbaabaaaaabbaaaaabbabbbbabbbaaabbaaabbaaaaabababababbab
bbabababaababbaaaabaaaabbaaababb
aabbaabaaaaabbbababaabaabbababab
aababbbbbabbbaaaaaababbb
bbaabbbabbaaabbaaaaaababbaababba
aabaaaabaabbaabbaababaab
abbaaababbababababbbaabaaabbababaaabbbaaaaababbb
babbaababbababaabaababaa
abbabbbabbabbbbaabbbaaab
baabbbabbbabaabbaaabbbabaaabaaaabbabbaab
bbaaaababaabbbbaaabbabbbaaabbbba
bbababaaabbabbaabbababababbabaabbaaabbababaaaabb
bbbbabbbbbbbbbaabaaaabbababbbbab
baaaaaabbabbbbabaaababaaaaabbabb
aababbaaabbabbbabaaabbbabababbba
bbabaababbbababbbabbabba
babaaaabbbaaabbbabbabbbbbabbaabaabbbabbb
baaaaabbababaaaabbbbbaab
babbbaaababaaaabbbaababa
aabbabbaabaababababbbbab
bbbbbbaaabbbbbbbaaababaa
abbaaabaabbabaaabbaabbba
abaabbabbbaaaaaababbabbbbabbbaaababbbbbbbaaababbbabbbaba
abbaaabaaabbaabbabaaabaaabbbbabb
babaabbbbaabaaabbbbababa
aaaababbbabbbaabbababababbbababbbbabaaabaaabaabaabababaaababaabb
bbaaaabaaaabbbbbaabbaaab
babbbbbbabbabbbaabbabbab
abaabbbababbbaababbabaaaabaaaababbbbabaaaabaaabaaabbbbabbbababababbaaaba
aabbaababbaaabbbababbbaababbbaab
bbbababbbaaaabbaabbaabaa
abaabababbaabbbabaaabbabbababbaaabbbababaaaabbba
bababbabaabbbbababbaaaabaaabaaaababbbaba
babaaaabaaabbbaabababbbbbababbaa
aaabbbbbbaaabbabbaaaaaaa
bbbaaaaabbaaaabbbabaaaaabbababaababaaababbabbaabbbbbbbbb
aaaaaabaaabbaabbababaabb
aabaaaaaaaaaaababbababbbabbaabbb
abbaababaabbbbbbabaabbababbabaaaaaaaabba
abaabaababbabbbaabababab
aabaaabbaaaaaababbaabaaabbaababa
abaabbabbaabaaabbaabbbbbaabbaaabaaabaabb
babbbabbabbbbaababaababaabbaabbb
aaabbbbbabbbbaaabaaaabaababaaabbbaababababbbaabbbbbbbaabbabaabab
bbbababbbabbbabbbabaaaab
bbaabaaaababaaabaabbbbbabaabbbbbabbbbabbbaabbbbbbabbbaba
bababaabbbaaaabbabaaaaaaaaaababbaaabbaababbaabbbabbaaaaa
bbbababbabbabbbaabaabbaa
bbbabbaababaabbbbaabbbbabbaababbbabbbbaa
aababbaaabaaabaaaabbababbbabaababaaaabaaabbabbaaababaabb
bbbaabbabbabbaaabbababbbaaabbbbbbbbbaaaa
bababbbaaaabaaabaababbbabaabaabb
aabbaabbaabababbbabbbaab
bbaaabbbbaabbaaaaabbbabb
abbababbabbaaaabbabaaaba
babbbbbbabbaabbaaabaaaaaaabbbaababababab
aabababaaaaababaabababbb
aaabaabaaaaaaabababaaaba
abbaabbaabaababaabbaabaa
aaababbaababaabbbbbbbbaabaabaabaabbaabbbbbabaaabaabbbaabbaabaaba
baabbabbbaabaababaaaabab
abbabaabaabaaaabaaababbb
aababbbabbababaabbaaaababbaaababbababaaabbbbbaaabaabbbbabbbaaaaaaabababbabaaaaab
bababbbbaabbabbbbaaabbbabbaaabaababbbabb
abbbbaaabaabbabbbbaaaabbbbbbbaab
bbbaabbbbbbbbaaababbbbab
abbaaababaabbabbbbbaabbabbbabbaababaaaababbbaabb
baabbabbbbbaaaababaaabbababbabababbababa
babbbaabbbbabababaaaaaaaababbbab
abbabbbbbbbbbaaabaaaaaaa
abbbbbabbbbaaabbabbabaaaabbabbbbaaabbaabbabbbaba
aabbaaaaaaaababbbbbaaaaabaabbbbabbabbbab
aababbbbbabaabaaababaabb
bbaaabaaabbabbbaaaaaaababbbabaaa
aaaababaabaaaaaaabbabbbaabaabbabbbaababb
baabbaaaaaabbbabbbbaabaaabaaaabaabbbaabaaaaabaaaabbbbabb
bbbabaabbaabaabbbbbbbbaaaaaaabbabbbabbbabaabbbab
aabbabababbababbababbbbaaabbbabb
ababbaabababbbbabaaabbbb
bbababaabaabbaabbbbabaabbabbbababaabbbaa
aaaaaabaaababaaaabbaabbababaabababbbabab
aaabaababbbaabbbbbbaaabbaabaabab
baababbbbbbaaaaabbaaaababbbbabbabababbba
abbabbaaabbbbbbababababb
abbabbbaababbabbbababbaa
babaaaabbbaaabaabbabbbbbabbabaabbaaabbaaaaabbaba
aaaabaaabbbbaaabbaabbbbabbbbbbaababbbbabbababbaa
aaaaaabaaaabbaabbbabbbbaaaababab
baaaaabaababbababaaaabaabaabbabbbaaaaaaa
bbbaaaababaabbabaaababab
abbbbaabbabbbabbbabbababbbbbaaabbbabbaabbabbabba
abbabbaabbababaababaabaaaaaaaaaa
abbbbaabbbbbbaaababbabba
aaaabaabbbabbbaaaabbbabb
babaabbaabbbabaaababaaaabaabbababbaaaaabaababaaaabaaaabbbaaaaaaa
bbababbaaabbbaaaabbbabaaaaaabbbabaaaaaaa
bababbbbabbaaababaaabaab
aabbbbaaabaabbbbaaabbaaabbbabbba
aabbaababaaabababbbaabbbaabbabaa
aabababbbabbbabbbaaabaaa
abaabaababaabbabaaabbbaabaaabababbababbabaaaaaba
bbbaaabbbbabababaaabbbbbabbbbababbaaaaabaabaabbaabbbabbaaabbbabb
aaaaaabbbbabbbababaaaabbbbaaabaabbbbbbaaaaaabababbbaabaa
baaabbaaabababaabbaabaabbabbbbaaabbaabbaabbaabaaabbabaaaabaaaaab
bbaaaaabbababbababbabaaaaaaabbaa
bbbabababbabbabbbabbababaabababaabbbaaabaabaabaa
abababbaabbaabbaababaaab
aaaabaabbaaaabbaaabbabbb
babbbabbbbbbabbbaaabaabaabbbbbbbabbabaabbbabbbab
baabbaabbabaaaabaababbabababaabb
bbabbbaaababbabbbbababaaaaabbbabbabbabbbbaaaaabbaaabbaababbabbbbabaaabab
baabbaaaaabbaababbbaaabbbabababaabbbabaabaaaaaaabbbbbbbbababbaaa
abbababbaaaaabbabbbbbbaaaabaaaaaabbbbabaabaabbaababbaabbbbbbbabaaabaabbb
bbbbaaabbbbabaababbabbbbbabbaaaabbbaaaba
bbbbabbbbbbaaabbaaaababaaaababbbabaabbbb
aabaaabbbbabbaaaabaaaaab
bbbbaabbaaaababababbaaaa
aaabbbbbaaabbaabbabaabababababbb
babbaababbaababbaabbababbbbbbaaaabaabbba
aabbabaabbabaaabaabbbbaaabbbabbaabbbabbbababbababaababaaababaabaabbabaaaababbbbb
aabbabbbabaaabaababbbabbbabbaabb
bbbbbbaaaaaabaabbbabbabbbabbaaaabaabbbbabaaaabbbaabababbbabaababbbbbbabb
bbbaaaaaaabbabbaabbbbbaa
babbaababaabbbbabaaaabbbabbaaababbbaabaabbbbabaa
abaaabbabbaaaaaaabbaaaaa
aabbaabbababbaabbababababaabaaaaabbaabab
ababbbaaabaaabbabababbaa
babbaaaababbabbbaaaabbbbbbbbbaabbbbbaabaabbbbbab
babaaabaaaaaaabbbaaabaababaaabaa
aaabbbaaabbabaaaabaabaabaaabaaab
babaabbbbbbbaaabbaababaa".Split('\n');
        }
    }
}
