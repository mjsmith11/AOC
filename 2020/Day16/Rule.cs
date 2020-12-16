using System;
using System.Text.RegularExpressions;

namespace Day16
{
    public class Rule
    {
        private int min1;
        private int max1;
        private int min2;
        private int max2;

        public Rule(string str) {
            string regex = @"(?<min1>\d+)-(?<max1>\d+) or (?<min2>\d+)-(?<max2>\d+)";
            Match m = Regex.Match(str,regex);
            this.min1 = int.Parse(m.Groups["min1"].Value);
            this.max1 = int.Parse(m.Groups["max1"].Value);
            this.min2 = int.Parse(m.Groups["min2"].Value);
            this.max2 = int.Parse(m.Groups["max2"].Value);
        }

        public bool isValid(int num) {
            return ((num>=min1) && (num<=max1)) || ((num>=min2) && (num<=max2));
        }
    }
}