using System;
namespace Part2 {
    public class Computer {
        private int[] positions;
        private int pc;
        public bool halted;
        private int lastOutput;
        
        public Computer(string program) {
            string[] instructions = program.Split(',');
            positions =new int[instructions.Length];
            for(int i=0; i<instructions.Length; i++) {
                positions[i] = Int32.Parse(instructions[i]);
            }
            pc = 0;
            halted = false;
        }
        
        public int execute(int input1, int input2) {
            if(halted) {
                Console.WriteLine("Tried to run halted program");
                return lastOutput;
            }
            int nextInput = input1;
            int instruction = positions[pc];
            int opcode = getOpcode(instruction);
            while (opcode != 99) {
                int loc1 = positions[pc + 1];
                int loc2 = positions[pc + 2];
                int loc3 = positions[pc + 3];
                
                if (opcode==1) {
                    positions[loc3] = getValue(loc1, getMode1(instruction)) + getValue(loc2, getMode2(instruction));
                    pc = pc + 4;
                } else if (opcode==2) {
                    positions[loc3] = getValue(loc1, getMode1(instruction)) * getValue(loc2, getMode2(instruction));
                    pc = pc + 4;
                } else if (opcode == 3) {
                    positions[loc1] = nextInput; 
                    nextInput = input2;
                     pc = pc + 2;
                } else if (opcode == 4) { 
                    lastOutput = getValue(loc1, getMode1(instruction));
                    pc = pc + 2;
                    return lastOutput;
                } else if (opcode == 5) {
                    if (getValue(loc1, getMode1(instruction)) != 0)
                        pc = getValue(loc2, getMode2(instruction));
                    else
                        pc = pc + 3;
                } else if (opcode == 6) {
                    if (getValue(loc1, getMode1(instruction)) == 0)
                        pc = getValue( loc2, getMode2(instruction));
                    else
                        pc = pc + 3;
                } else if (opcode == 7) {
                    if (getValue(loc1, getMode1(instruction)) < getValue(loc2, getMode2(instruction)))
                        positions[loc3] = 1;
                    else 
                        positions[loc3] = 0;
                    pc = pc + 4;
                } else if (opcode == 8) {
                    if (getValue(loc1, getMode1(instruction)) == getValue(loc2, getMode2(instruction)))
                        positions[loc3] = 1;
                    else 
                        positions[loc3] = 0;
                    pc = pc + 4;
                } else { 
                    return -instruction; 
                }
            instruction = positions[pc];
            opcode = getOpcode(instruction);
            }
            halted = true;
            return lastOutput;
            
        }
        
        public void reset(){
            halted = false;
            pc = 0;
        }
        
        private int getOpcode(int instruction) {
            return instruction % 100;
        }
        private int getMode1(int instruction) {
            return (instruction / 100) % 10;
        }
        private int getMode2(int instruction) {
            return (instruction / 1000) % 10;
        }
        private int getMode3(int instruction) {
            return (instruction / 10000) % 10;
        }
        private int getValue(int param, int mode) {
            if (mode == 1) {
                return param;
            }
            else {
                return positions[param];
            }
        }
    }
}