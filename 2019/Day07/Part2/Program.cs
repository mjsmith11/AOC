using System;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
        string input = "3,8,1001,8,10,8,105,1,0,0,21,38,55,64,89,114,195,276,357,438,99999,3,9,101,3,9,9,102,3,9,9,1001,9,5,9,4,9,99,3,9,101,2,9,9,1002,9,3,9,101,5,9,9,4,9,99,3,9,101,3,9,9,4,9,99,3,9,1002,9,4,9,101,5,9,9,1002,9,5,9,101,5,9,9,102,3,9,9,4,9,99,3,9,101,3,9,9,1002,9,4,9,101,5,9,9,102,5,9,9,1001,9,5,9,4,9,99,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,99,3,9,101,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,99,0,0";
            //string input = "3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10";
            int maxOutput = 0;
            int maxPhase = 0;
            for(int i=56789; i<=98765; i++) {
                if(validatePhase(i)) {
                    int output = runAmps(i, input);
                    if (output>maxOutput) {
                        maxOutput = output;
                        maxPhase = i;
                    }
                }
            }
            Console.WriteLine(maxOutput);
        }
        /*static int runAmps(int phase, string program) {
            int input = 0;
            for(int i = 0; i<5; i++) {
                Computer amp = new Computer(program);
                input = amp.execute(getPhase(i, phase), input);
            }
            return input;
        }*/
        static int runAmps(int phase, string program) {
            int input = 0;
            bool init = true;
            Computer ampA = new Computer(program);
            Computer ampB = new Computer(program);
            Computer ampC = new Computer(program);
            Computer ampD = new Computer(program);
            Computer ampE = new Computer(program);
            while (!ampE.halted) {
                if(init) {
                    input = ampA.execute(getPhase(0,phase),input);
                    input = ampB.execute(getPhase(1,phase),input);
                    input = ampC.execute(getPhase(2,phase),input);
                    input = ampD.execute(getPhase(3,phase),input);
                    input = ampE.execute(getPhase(4,phase),input);
                    init = false;
                } else {
                    input = ampA.execute(input,input);
                    input = ampB.execute(input,input);
                    input = ampC.execute(input,input);
                    input = ampD.execute(input,input);
                    input = ampE.execute(input,input);
                }
            }
            return input;
        }
        static int getPhase(int ampNum, int phase) {
            /*4 => 0
            3 => 1
            2 => 2
            1 => 3
            0 => 4*/
            int targetNum = (-1*ampNum) + 4;
            int i;
            for (i=0; i<targetNum; i++) {
                phase = phase / 10;
            }
            return phase % 10;
        }
        /*static bool validatePhase(int phase) {
            int myPhase = phase;
            bool[] used = new bool[10];
            int i;
            for(i=0; i<5; i++) {
                int digit = myPhase % 10;
                if (digit < 5) { return false; }
                if (used[digit]) { return false; }
                else { used[digit] = true; }
                myPhase = myPhase / 10;
            }
            return true;
        }*/
        static bool validatePhase(int phase) {
            int myPhase = phase;
            bool[] used = new bool[10];
            int i;
            for(i=0; i<5; i++) {
                int digit = myPhase % 10;
                if (digit < 5) { return false; }
                if (used[digit]) { return false; }
                else { used[digit] = true; }
                myPhase = myPhase / 10;
            }
            return true;
        }
    }
}
