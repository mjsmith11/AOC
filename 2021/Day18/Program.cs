using System;
using System.Text;

namespace Day18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1 : " + part1());
            Console.WriteLine("Part 2 : " + part2());
            
        }

        static int part1() {
            string[] data = getInput();
            string total = data[0].Trim();
            for(int i=1; i<data.Length; i++) {
                total = addition(total,data[i]);
                total = reduce(total);
            }
            return magnitude(total);
        }

        static int part2() {
            string[] data = getInput();
            int max = 0;
            for(int i=0; i<data.Length; i++) {
                for(int j=0; j<data.Length; j++) {
                    if (i!=j) {
                        string sum = addition(data[i],data[j]);
                        string reduced = reduce(sum);
                        int mag = magnitude(reduced);
                        if (mag>max) { 
                            max=mag;
                        }
                    }
                }
            }
            return max;
        }

        static string reduce(string s) {
            bool reduced;
            do {
                reduced = false;
                string result = tryExplode(s);
                if (result != "") {
                    reduced = true;
                    s = result;
                } else {
                    result = trySplit(s);
                    if (result != "" ) {
                        reduced = true;
                        s=result;
                    }
                }
            } while (reduced);
            return s;
        }

        static string addition(string a, string b) {
            return $"[{a.Trim()},{b.Trim()}]";
        }

        static int magnitude(string s) {
            int level =0;
            int separatingCommaIndex = 0;
            for(int i=0;i<s.Length;i++) {
                if (s[i] == '[') {
                    level++;
                } else if (s[i] == ']') {
                    level--;
                } else if (s[i] == ',') {
                    if (level==1) {
                        separatingCommaIndex = i;
                    }
                }
            }
            string left = s.Substring(1,separatingCommaIndex-1);
            string right = s.Substring(separatingCommaIndex+1);
            right = right.Substring(0,right.Length-1); // strip the trailing ]
            int leftValue;
            int rightValue;
            if (left.Contains("[")) {
                leftValue = magnitude(left);
            } else {
                leftValue = Int32.Parse(left);
            }

            if (right.Contains("[")) {
                rightValue = magnitude(right);
            } else {
                rightValue = Int32.Parse(right);
            }
            return 3*leftValue + 2*rightValue;
        }

        static string tryExplode(string s) {
            int level=0;
            for(int i=0; i<s.Length; i++) {
                if (s[i] == '[') {
                    if(level<4) { 
                        level++;
                    } else {
                        // explode
                        int explodeIndex = i;
                        int explodeSize = s.IndexOf("]",explodeIndex)-i+1;
                        int rightIndex = 0;
                        int rightSize=0;
                        for(int j=explodeIndex+explodeSize; j<s.Length && rightIndex==0; j++) {
                            if(Char.IsNumber(s[j])) {
                                rightIndex = j;
                                while(Char.IsNumber(s[j])) {
                                    rightSize++;
                                    j++;
                                }
                            }
                        }
                        int leftIndex = 0;
                        int leftSize = 0;
                        for(int k=explodeIndex-1; k>0 && leftIndex==0; k--) {
                            if(Char.IsNumber(s[k])) {
                                leftIndex = k;
                                leftSize = 1;
                                k--;
                                while(Char.IsNumber(s[k])) {
                                    leftIndex--;
                                    leftSize++;
                                    k--;
                                }
                            }
                        }
                        string[] explodePair = s.Substring(explodeIndex+1,explodeSize-2).Split(",");
                        if(rightIndex!=0) {
                            int rightNum = Int32.Parse(s.Substring(rightIndex,rightSize));
                            int rightPairNum = Int32.Parse(explodePair[1]);
                            int replacement = rightNum + rightPairNum;
                            s = Replace(s,rightIndex,rightSize,replacement.ToString());
                        }
                        s = Replace(s,explodeIndex,explodeSize,"0");
                        if(leftIndex!=0) {
                            int leftNum = Int32.Parse(s.Substring(leftIndex,leftSize));
                            int leftPairNum = Int32.Parse(explodePair[0]);
                            int replacement = leftNum + leftPairNum;
                            s = Replace(s,leftIndex,leftSize,replacement.ToString());
                        }
                        return s;
                    }
                } else if (s[i] ==']') {
                    level--;
                }
            }
            return "";
        }

        static string trySplit(string s) {
            for(int i = 0; i<s.Length; i++) {
                if(Char.IsNumber(s[i])) {
                    if (Char.IsNumber(s[i+1])) {
                        // next two are numbers.  That's >= 10 so split
                        int numIndex = i;
                        int numLength =2;
                        i +=2;
                        while (Char.IsNumber(s[i])) {
                            numLength++;
                            i++;
                        }
                        int number = Int32.Parse(s.Substring(numIndex,numLength));
                        int left = number/2;
                        int right = (int)((double)number/2.0 + 0.5);
                        string replacement = $"[{left},{right}]";
                        return Replace(s,numIndex,numLength,replacement);
                    }
                }
            }
            return "";
        }

        static string Replace(string s, int start, int length, string newStr) {
            return s.Remove(start,length).Insert(start,newStr);
        }

        static string[] getInput() {
            string data = @"[[[7,[9,4]],[5,8]],7]
[[[[9,3],[9,0]],[[1,9],2]],4]
[2,[[[0,6],3],[7,6]]]
[4,[[[8,9],[4,2]],[[6,8],[2,7]]]]
[[6,[6,[6,8]]],[[[8,7],8],8]]
[[5,[[2,7],3]],[[[4,6],9],9]]
[[8,1],[9,7]]
[[[[9,3],[8,1]],[[6,6],[7,4]]],[[9,[9,8]],[6,3]]]
[[[6,0],[1,[1,6]]],[2,[[9,4],7]]]
[[[9,7],3],[[[8,4],[4,1]],[7,3]]]
[[[3,7],[[0,0],[3,1]]],[6,[[2,4],6]]]
[[[[3,0],3],[[9,2],[8,3]]],[[[5,3],[5,1]],[6,[4,6]]]]
[[7,[[7,6],[4,5]]],[[5,[0,0]],[[9,7],3]]]
[[[[0,0],8],[7,[6,0]]],[[[0,8],[7,5]],[[2,2],4]]]
[[[[5,6],[7,9]],1],[[[0,2],[7,9]],[[6,2],6]]]
[7,[0,5]]
[[2,[7,8]],[[[3,0],0],[0,8]]]
[[[[9,2],[4,8]],[1,[8,3]]],[[6,1],[[1,5],[7,3]]]]
[[[[7,1],6],[3,5]],[[8,[3,8]],[7,3]]]
[[[[1,7],8],0],[2,[[4,1],9]]]
[[[[9,2],0],0],[[1,[9,5]],3]]
[[1,[3,5]],7]
[[[[7,5],[4,1]],[[6,9],1]],[[0,8],[1,[4,2]]]]
[[6,[0,[5,4]]],[[4,[6,1]],3]]
[[[[5,8],4],[0,[1,5]]],[[[0,1],9],[[2,1],6]]]
[[[[9,5],3],[[1,6],6]],[9,[[1,4],[6,1]]]]
[[8,[[7,8],[6,1]]],[1,8]]
[[3,[[6,1],[2,7]]],[0,[3,[1,7]]]]
[[[[3,3],0],[[6,5],8]],[[[8,3],3],[5,[3,9]]]]
[[[1,6],9],[[9,4],1]]
[[[[5,3],[4,3]],[3,5]],[[4,[9,8]],[2,[8,5]]]]
[[[[7,3],6],7],[[[1,4],9],[3,[7,0]]]]
[[0,5],[[[4,3],7],[8,[0,3]]]]
[6,[[[9,4],2],[[8,4],[5,7]]]]
[[9,[2,[1,7]]],[4,[[7,2],3]]]
[9,[5,[[9,7],[0,5]]]]
[[[[1,6],1],[[2,3],[3,3]]],[[5,[8,6]],[[1,3],[8,9]]]]
[[3,0],[[4,1],[6,[5,7]]]]
[[[[3,3],[9,0]],[1,[0,0]]],[0,[[6,6],[1,1]]]]
[[[4,6],[[9,2],[0,5]]],0]
[9,[[5,5],[8,[4,1]]]]
[[[[9,2],[9,9]],[[8,7],3]],0]
[[2,5],[4,8]]
[[[[9,1],8],[1,2]],[7,[[7,2],5]]]
[2,7]
[[[[0,3],0],0],[[1,8],[[5,3],1]]]
[[[9,8],5],[[0,2],[4,[2,4]]]]
[[3,[9,[9,4]]],[3,[[3,0],7]]]
[[6,[5,1]],[4,7]]
[[5,[8,[4,1]]],[8,[[1,8],[1,7]]]]
[2,[[7,5],[[9,1],6]]]
[0,[4,[2,2]]]
[7,[[[9,5],[7,4]],[[5,0],[5,0]]]]
[8,[[[5,3],3],[5,[2,0]]]]
[[[[3,7],7],[[6,0],3]],[[[5,4],8],[[9,3],[2,9]]]]
[[[[8,1],3],[[8,4],[3,0]]],[2,6]]
[7,[9,7]]
[[[[4,9],9],0],[[[3,8],[6,9]],0]]
[[[[6,1],0],[[5,2],9]],4]
[[[4,1],[[8,5],8]],[[7,[9,4]],[[7,8],[0,9]]]]
[[0,2],5]
[[[5,[7,5]],[6,[7,3]]],[[[7,2],[7,5]],[[3,1],6]]]
[[[[5,1],[9,1]],[[3,2],[6,7]]],[8,[[3,5],8]]]
[[[4,[3,9]],[5,1]],[5,[[2,4],[9,0]]]]
[5,[[[8,5],5],1]]
[[[7,7],[[8,7],7]],[[9,2],[[3,5],[8,0]]]]
[[[[2,0],0],[[8,5],7]],[[[3,4],[8,1]],1]]
[[6,[[0,7],[1,9]]],[[[5,0],5],[7,[1,5]]]]
[[[0,[6,9]],[6,[9,4]]],[3,1]]
[[8,[2,9]],[5,[6,9]]]
[[[[9,4],[7,8]],8],[[[0,3],[8,8]],[[1,7],[8,2]]]]
[[[[9,5],[0,6]],[6,[3,5]]],5]
[[[[3,0],[4,9]],[5,4]],[5,[[1,2],[0,3]]]]
[[[[9,3],8],8],[2,9]]
[5,[[[8,4],[8,0]],[[9,2],[7,6]]]]
[[[[4,8],2],[4,0]],[[1,[2,1]],[0,[0,7]]]]
[3,[[[8,5],[8,6]],2]]
[[[3,[1,2]],9],[7,[2,[0,6]]]]
[[[[8,3],1],9],6]
[[2,[6,8]],[[6,9],[1,[4,9]]]]
[[[[5,9],3],[9,6]],[[[9,9],6],6]]
[[[[1,6],1],[2,[8,7]]],[4,[[7,6],3]]]
[[3,[8,[8,6]]],[[[2,0],3],6]]
[[[1,[6,5]],6],[7,[3,6]]]
[[2,[[8,3],3]],[[0,[3,4]],[5,[2,9]]]]
[[[9,4],[4,[0,1]]],[4,[3,5]]]
[[[5,[7,3]],[[7,5],[8,9]]],5]
[[[1,4],[4,5]],[[[4,8],4],0]]
[[[[9,2],2],[3,0]],[[[4,6],3],[0,7]]]
[[[[2,2],[0,4]],6],3]
[[[4,[6,2]],[3,[3,4]]],[[[1,1],0],[0,9]]]
[[[[8,2],[5,4]],[[4,4],8]],[4,[5,[6,4]]]]
[[[7,[2,4]],[6,[2,6]]],[[7,6],8]]
[[[[2,6],3],[6,[2,8]]],2]
[[[2,[2,9]],[4,[9,0]]],[[8,0],[[4,1],4]]]
[2,[3,[1,8]]]
[[[5,9],[[3,4],[1,9]]],[[6,[9,2]],6]]
[[[[1,5],[2,8]],[[4,1],3]],[[1,[6,3]],[[9,7],8]]]
[[[[7,8],9],4],2]
[[[0,[6,8]],6],5]";
            return data.Split("\n");
        }
    }
}
