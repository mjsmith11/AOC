using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017
{
    class Day10
    {
        public static int part1()
        {
            byte[] input = new byte[16];
            input[0] = 165;
            input[1] = 1;
            input[2] = 255;
            input[3] = 31;
            input[4] = 87;
            input[5] = 52;
            input[6] = 24;
            input[7] = 113;
            input[8] = 0;
            input[9] = 91;
            input[10] = 148;
            input[11] = 254;
            input[12] = 158;
            input[13] = 2;
            input[14] = 73;
            input[15] = 153;

            int zero1 = 0;
            int zero2 = 0;
            int[] myHash = hash(getNewList(), input, ref zero1, ref zero2);

            return myHash[0] * myHash[1];
        }

        public static string part2(string input)
        {
            //string input = "165,1,255,31,87,52,24,113,0,91,148,254,158,2,73,153";
            byte[] inpBytes = Encoding.ASCII.GetBytes(input);
            byte[] appendedInp = new byte[inpBytes.Length + 5]; 
            for (int i = 0; i < inpBytes.Length; i++)
                appendedInp[i] = inpBytes[i];
            appendedInp[inpBytes.Length] = 17;
            appendedInp[inpBytes.Length + 1] = 31;
            appendedInp[inpBytes.Length + 2] = 73;
            appendedInp[inpBytes.Length + 3] = 47;
            appendedInp[inpBytes.Length + 4] = 23;

            int[] list = getNewList();
            int currentPos = 0;
            int skip = 0;

            for (int i = 0; i<64; i++)
            {
                list = hash(list, appendedInp, ref currentPos, ref skip);
            }
            int[] denseHash = getDenseHash(list);

            StringBuilder hex = new StringBuilder(32);
            foreach(int i in denseHash)
            {
                hex.AppendFormat("{0:x2}", i);
            }
            return hex.ToString();

        }

        private static int[] getDenseHash(int[] sparse)
        {
            int[] dense = new int[16];
            for(int i=0; i<16; i++)
            {
                int val = sparse[16 * i];
                for (int j=16*i+1; j<16*(i+1); j++)
                {
                    val = val ^ sparse[j];
                }
                dense[i] = val;
            }
            return dense;
        }
        private static int[] getNewList()
        {
            int[] list = new int[256];
            for(int i=0; i<256; i++)
            {
                list[i] = i;
            }
            return list;
        }

        private static int[] hash(int[] list, byte[] lengths, ref int currentPos, ref int skip)
        {
            foreach(int length in lengths)
            {
                list = reverse(list, currentPos, currentPos + length - 1);
                currentPos = (currentPos + length + skip) % 256;
                skip++;
            }
            return list;
        }

        private static int[] reverse(int[] list, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                int swapIndex1 = startIndex % 256;
                int swapIndex2 = endIndex % 256;
                int temp = list[swapIndex1];
                list[swapIndex1] = list[swapIndex2];
                list[swapIndex2] = temp;
                endIndex--;
                startIndex++;
            }
            return list;
        }


    }
}
