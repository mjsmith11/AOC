using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"jio a, +18
inc a
tpl a
inc a
tpl a
tpl a
tpl a
inc a
tpl a
inc a
tpl a
inc a
inc a
tpl a
tpl a
tpl a
inc a
jmp +22
tpl a
inc a
tpl a
inc a
inc a
tpl a
inc a
tpl a
inc a
inc a
tpl a
tpl a
inc a
inc a
tpl a
inc a
inc a
tpl a
inc a
inc a
tpl a
jio a, +8
inc b
jie a, +4
tpl a
inc a
jmp +2
hlf a
jmp -7";
            string[] instructions = input.Split('\n');
            int a, b, pc;
            // a = 0; // Part 1
            a = 1; // Part 2
            b = 0;
            pc = 0;
            while(pc < instructions.Length)
            { 
                string inst = instructions[pc].Trim();
                string[] parts = inst.Split(' ');
                string command = parts[0];
                string arg = parts[1];

                if (command == "hlf")
                {
                    if (arg=="a")
                    {
                        a /= 2;
                    }
                    else if (arg == "b")
                    {
                        b /= 2;
                    } 
                }
                else if (command == "tpl")
                {
                    if (arg == "a")
                    {
                        a *= 3;
                    }
                    else if (arg == "b")
                    {
                        b *= 3;
                    }
                }
                else if (command == "inc")
                {
                    if (arg == "a")
                    {
                        a += 1;
                    }
                    else if (arg == "b")
                    {
                        b += 1;
                    }
                }
                else if (command == "jmp")
                {
                    pc += int.Parse(arg);
                    pc--; //off set the increment
                }
                else if (command == "jie")
                {
                    string[] argParts = arg.Split(',');
                    string reg = argParts[0];
                    int offset = int.Parse(parts[2].Trim());
                    int regVal = 0;
                    if (reg=="a")
                    {
                        regVal = a;
                    }
                    else if (reg == "b")
                    {
                        regVal = b;
                    }
                    if (regVal % 2 == 0)
                    {
                        pc += offset;
                        pc--;
                    }
                }
                else if (command == "jio")
                {
                    string[] argParts = arg.Split(',');
                    string reg = argParts[0];
                    int offset = int.Parse(parts[2].Trim());
                    int regVal = 0;
                    if (reg == "a")
                    {
                        regVal = a;
                    }
                    else if (reg == "b")
                    {
                        regVal = b;
                    }
                    if (regVal == 1)
                    {
                        pc += offset;
                        pc--;
                    }
                }
                pc++;
            }
            Console.WriteLine(b);
            Console.ReadLine();
        }
    }
}
