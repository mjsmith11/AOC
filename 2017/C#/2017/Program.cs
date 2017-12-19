using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Day17.part2(355));
            Console.Read();
        }
		
		public static int day1(string input)
        {
            int sum=0;
            for (int i = 0; i < input.Length; i++)
            {
                //int i2 = i + 1;
                int i2 = i + input.Length / 2;
                if (i2 >= input.Length)
                    i2 -= input.Length;
                if(input[i]==input[i2])
                {
                    sum += int.Parse(input[i].ToString());
                }
            }
            return sum;
        }

        public static int day2(string filename)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            int sum = 0;
            string line;
            while((line = file.ReadLine()) != null)
            {
                /*int min = int.MaxValue;
                int max = 0;
                string[] nums = line.Split('\t');
                foreach(string s in nums)
                {
                    int value = int.Parse(s);
                    if (value < min)
                        min = value;
                    if (value > max)
                        max = value;
                }
                sum += (max - min);*/
                string[] nums = line.Split('\t');
                for(int i=0; i<nums.Length; i++)
                {
                    for(int j=i+1; j<nums.Length; j++)
                    {
                        int num1 = int.Parse(nums[i]);
                        int num2 = int.Parse(nums[j]);
                        if (num1 % num2 == 0)
                            sum += (num1 / num2);
                        else if (num2 % num1 == 0)
                            sum += (num2 / num1);
                    }
                }
            }

            return sum;
        }
    }
}
