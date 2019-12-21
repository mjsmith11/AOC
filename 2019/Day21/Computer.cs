using System;
namespace Day21 {
    public class Computer {
        private Int64[] positions;
        private Int64 pc;
        public bool halted;
        private Int64 lastOutput;
        private Int64 relativeBase; 
        private int outputLength = 10000;
        
        public Computer(string program) {
            string[] instructions = program.Split(',');
            positions =new Int64[10*instructions.Length];
            for(Int64 i=0; i<instructions.Length; i++) {
                positions[i] = Int64.Parse(instructions[i]);
            }
            pc = 0;
            halted = false;
            relativeBase = 0;
        }
        
        public void testOutput() {
            for (int i=0; i<50; i++){
                Console.WriteLine(i + " : " + positions[i]);
            }
        }
        
        public Int64[] execute(long[] inputs) {
            if(halted) {
                Console.WriteLine("Tried to run halted program");
                return new Int64[outputLength];
            }
            Int64[] outputs = new Int64[outputLength];
            int nextOutput = 0;
            int nextInput = 0;
            Int64 instruction = positions[pc];
            Int64 opcode = getOpcode(instruction);
            while (opcode != 99) {
                Int64 loc1 = positions[pc + 1];
                Int64 loc2 = positions[pc + 2];
                Int64 loc3 = positions[pc + 3];
                
                if (opcode==1) {
                    positions[loc3 + getRelativeBase(getMode3(instruction))] = getValue(loc1, getMode1(instruction)) + getValue(loc2, getMode2(instruction));
                    pc = pc + 4;
                } else if (opcode==2) {
                    positions[loc3  + getRelativeBase(getMode3(instruction))] = getValue(loc1, getMode1(instruction)) * getValue(loc2, getMode2(instruction));
                    pc = pc + 4;
                } else if (opcode == 3) {
                    //Console.WriteLine("inputting " + (char)inputs[nextInput]);
                    positions[loc1  + getRelativeBase(getMode1(instruction))] = inputs[nextInput]; 
                    nextInput++;
                     pc = pc + 2;
                } else if (opcode == 4) { 
                    lastOutput = getValue(loc1, getMode1(instruction));
                    outputs[nextOutput]= lastOutput;
                    nextOutput++;
                    pc = pc + 2;
                    if (nextOutput==outputLength) { return outputs; }
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
                        positions[loc3 + getRelativeBase(getMode3(instruction))] = 1;
                    else 
                        positions[loc3  + getRelativeBase(getMode3(instruction))] = 0;
                    pc = pc + 4;
                } else if (opcode == 8) {
                    if (getValue(loc1, getMode1(instruction)) == getValue(loc2, getMode2(instruction)))
                        positions[loc3  + getRelativeBase(getMode3(instruction))] = 1;
                    else 
                        positions[loc3  + getRelativeBase(getMode3(instruction))] = 0;
                    pc = pc + 4;
                } else if (opcode == 9) {
                    relativeBase += getValue(loc1, getMode1(instruction));
                    pc = pc + 2;
                } else { 
                    Console.WriteLine("Bad Opcode");
                    return new Int64[outputLength]; 
                }
            instruction = positions[pc];
            opcode = getOpcode(instruction);
            }
            halted = true;
            Console.WriteLine("Halt");
            return outputs;
            
        }
        
        public void reset(){
            halted = false;
            pc = 0;
            relativeBase = 0;
        }
        
        private Int64 getOpcode(Int64 instruction) {
            return instruction % 100;
        }
        private Int64 getMode1(Int64 instruction) {
            return (instruction / 100) % 10;
        }
        private Int64 getMode2(Int64 instruction) {
            return (instruction / 1000) % 10;
        }
        private Int64 getMode3(Int64 instruction) {
            return (instruction / 10000) % 10;
        }
        private Int64 getValue(Int64 param, Int64 mode) {
            if (mode == 1) {
                return param;
            }
            else if (mode == 2) {
                return positions[param + relativeBase];
            }
            else {
                return positions[param];
            }
        }
        private Int64 getRelativeBase(Int64 mode)
        {
            if (mode==2) 
            {
                return relativeBase;
            }
            else 
            {
                return 0;
            }
        }
    }
}