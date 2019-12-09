#import <Foundation/Foundation.h>
int main(void){
    NSAutoreleasePool* pool = [[NSAutoreleasePool alloc] init];
    // Your code here!
   
    int j;
    int counter = 0;
    int maxOutput = 0;
    int maxPhase = 0;
    for (j=1234; j<=43210; j++)
    {
        int validation = validatePhase(j);
        if (validation == 0) { continue; }
        int output = runAmps(j);
        if (output > maxOutput) {
            maxOutput = output;
            maxPhase = j;
        }
    }

    
    NSString *s = [NSString stringWithFormat:@"%d %d", maxOutput, maxPhase];
    [[NSFileHandle fileHandleWithStandardOutput] writeData: [s dataUsingEncoding: NSUTF8StringEncoding]];
    [pool release];
    return 0;
}

int runAmps(int phase) {
    int input = 0;
    int i;
     for (i = 0; i < 5; i++) {
         input = evaluate(getPhase(i, phase),input);
     }
    return input;
}

int validatePhase(int phase) {
    int myPhase = phase;
    int* used[5];
    used[0] = 0;
    used[1] = 0;
    used[2] = 0;
    used[3] = 0;
    used[4] = 0;
    int i;
    for(i=0; i<5; i++) {
        int digit = myPhase % 10;
        if (digit > 4) { return 0; }
        if (used[digit] == 1) { return 0; }
        else { used[digit] = 1; }
        myPhase = myPhase / 10;
    }
    return 1;
 }

int getPhase(int ampNum, int phase) {
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

int evaluate(int input1, int input2) {
    NSString *input = @"3,8,1001,8,10,8,105,1,0,0,21,38,55,64,89,114,195,276,357,438,99999,3,9,101,3,9,9,102,3,9,9,1001,9,5,9,4,9,99,3,9,101,2,9,9,1002,9,3,9,101,5,9,9,4,9,99,3,9,101,3,9,9,4,9,99,3,9,1002,9,4,9,101,5,9,9,1002,9,5,9,101,5,9,9,102,3,9,9,4,9,99,3,9,101,3,9,9,1002,9,4,9,101,5,9,9,102,5,9,9,1001,9,5,9,4,9,99,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,99,3,9,101,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,99";
    NSArray *array = [input componentsSeparatedByString:@","];
    int *positions[[array count]];
    int counter = 0;
    for(id i in array) {
        positions[counter] = [i integerValue];
        counter = counter + 1;
    }
    int nextInput = input1;
    int pc = 0;
    int instruction = positions[0];
    int opcode = getOpcode(instruction);
    while(opcode != 99) {
        int loc1 = positions[pc + 1];
        int loc2 = positions[pc + 2];
        int loc3 = positions[pc + 3];
        
        if (opcode==1) {
            int value1 = getValue(positions[loc1], loc1, getMode1(instruction));
            int value2 = getValue(positions[loc2], loc2, getMode2(instruction));
            positions[loc3] = value1 + value2;
            //positions[loc3] = getValue(positions, loc1, getMode1(instruction)) + getValue(positions, loc2, getMode2(instruction));
            pc = pc + 4;
        } else if (opcode==2) {
            positions[loc3] = getValue(positions[loc1], loc1, getMode1(instruction)) * getValue(positions[loc2], loc2, getMode2(instruction));
            pc = pc + 4;
        } else if (opcode == 3) {
            positions[loc1] = nextInput; 
            nextInput = input2;
             pc = pc + 2;
        } else if (opcode == 4) { 
            int output = getValue(positions[loc1], loc1, getMode1(instruction));
            if (output != 0) { return output; }
            pc = pc + 2;
        } else if (opcode == 5) {
            if (getValue(positions[loc1], loc1, getMode1(instruction)) != 0)
                pc = getValue(positions[loc2], loc2, getMode2(instruction));
            else
                pc = pc + 3;
        } else if (opcode == 6) {
            if (getValue(positions[loc1], loc1, getMode1(instruction)) == 0)
                pc = getValue(positions[loc2], loc2, getMode2(instruction));
            else
                pc = pc + 3;
        } else if (opcode == 7) {
            if (getValue(positions[loc1], loc1, getMode1(instruction)) < getValue(positions[loc2], loc2, getMode2(instruction)))
                positions[loc3] = 1;
            else 
                positions[loc3] = 0;
            pc = pc + 4;
        } else if (opcode == 8) {
            if (getValue(positions[loc1], loc1, getMode1(instruction)) == getValue(positions[loc2], loc2, getMode2(instruction)))
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
    
}

int getOpcode(int instruction) {
    return instruction % 100;
}

int getMode1(int instruction) {
    return (instruction / 100) % 10;
}

int getMode2(int instruction) {
    return (instruction / 1000) % 10;
}

int getMode3(int instruction) {
    return (instruction / 10000) % 10;
}

int getValue(int arrayval, int param, int mode) {
    if (mode == 1) {
        return param;
    } else {
        return arrayval;
    }
}