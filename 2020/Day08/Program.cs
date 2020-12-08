﻿using System;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1: " + part1());
            Console.WriteLine("Part 2: " + part2());
        }

        static int part1() {
            string[] instructions = getInput();
            int pc = 0;
            int acc = 0;
            while(true) {
                string[] currentInstruction = instructions[pc].Split(" ");
                instructions[pc] = "end";
                if (currentInstruction[0] == "acc") {
                    acc += int.Parse(currentInstruction[1]);
                    pc++;
                } else if (currentInstruction[0] == "jmp") {
                    pc += int.Parse(currentInstruction[1]);
                } else if (currentInstruction[0] == "nop") {
                    pc++;
                } else if (currentInstruction[0] == "end") {
                    break;
                } else {
                    Console.WriteLine("Something is Wrong");
                }
            }
            return acc;
        }
    
        static int part2() {
            string[] masterInput = getInput();
            int answer = 0;

            // loop over each line
            for(int i=0; i<masterInput.Length; i++) {
                // change instruction
                string[] instructions = getInput();
                string[] changeInstruction = instructions[i].Split(" ");
                if (changeInstruction[0] == "acc") { continue; }
                else if (changeInstruction[0] == "jmp") { instructions[i] = "nop " + changeInstruction[1]; }
                else if (changeInstruction[0] == "nop") { instructions[i] = "jmp " + changeInstruction[1]; }

                //try to run and see if we terminate
                bool terminated = true;
                int pc = 0;
                int acc = 0;
                while(pc<instructions.Length) {
                    string[] currentInstruction = instructions[pc].Split(" ");
                    instructions[pc] = "end";
                    if (currentInstruction[0] == "acc") {
                        acc += int.Parse(currentInstruction[1]);
                        pc++;
                    } else if (currentInstruction[0] == "jmp") {
                        pc += int.Parse(currentInstruction[1]);
                    } else if (currentInstruction[0] == "nop") {
                        pc++;
                    } else if (currentInstruction[0] == "end") {
                        terminated = false;
                        break;
                    } else {
                        Console.WriteLine("Something is Wrong");
                    }
                }
                if(terminated) {
                    answer = acc;
                    break;
                }
            }
            return answer;
        }

        static string[] getInput() {
            string input = @"acc +37
acc -4
nop +405
jmp +276
acc +39
acc +40
acc -3
jmp +231
acc +44
acc +12
jmp +505
acc +35
jmp +282
acc +23
jmp +598
nop +392
acc +18
acc +44
acc +18
jmp +297
nop +460
jmp +152
nop +541
acc +33
jmp -11
acc -5
acc +9
jmp +327
acc +30
acc -1
acc -3
jmp +50
acc +22
acc +18
acc +33
acc +37
jmp +57
acc -17
acc -6
acc -2
jmp +535
acc -15
jmp +279
acc +34
acc +44
acc +41
jmp +349
acc +2
acc +6
nop +351
nop +252
jmp +505
jmp +1
jmp +1
nop +61
jmp +524
nop +351
jmp +399
acc +1
nop +397
acc +39
nop +141
jmp +134
acc +46
acc +14
acc +26
jmp +236
acc +7
acc -6
acc +35
jmp +397
acc +15
jmp +140
acc +3
acc -4
acc +37
acc +12
jmp +86
jmp +416
jmp +1
jmp +55
acc -19
jmp +536
jmp +1
acc -11
acc +15
jmp -61
acc +25
jmp -25
acc +50
acc +43
jmp +1
jmp +140
acc +46
nop -53
acc +1
nop +440
jmp +488
jmp +396
nop +443
acc +41
jmp +168
acc +25
nop +383
acc +12
acc -19
jmp +21
acc +29
acc +30
jmp +497
jmp +502
jmp +417
nop +351
acc -15
jmp +243
acc +21
acc +16
jmp +332
acc +28
acc +22
acc +38
jmp +476
acc +8
acc -11
jmp +458
acc +9
jmp +246
acc +40
acc +31
acc +26
jmp +218
acc +27
acc +9
nop +347
jmp +478
nop +28
nop +106
acc +25
acc -15
jmp +397
acc +31
jmp +231
acc -4
nop +136
acc +14
jmp +181
jmp +361
acc +16
acc +11
jmp -108
nop +299
acc +21
acc -2
jmp -106
jmp +246
acc +31
jmp +407
jmp +377
acc +43
acc -12
nop +142
acc +8
jmp -91
jmp +1
acc +34
acc +5
acc +31
jmp +12
acc +34
acc +7
acc +34
acc +20
jmp -45
acc -11
acc +41
acc +10
jmp +310
nop -106
jmp -36
acc +23
acc +46
acc +46
jmp +112
acc +41
nop +179
acc +17
nop +356
jmp +147
acc +42
nop +49
jmp +119
acc +0
acc +7
acc -18
acc -8
jmp +11
acc +12
acc +38
acc +39
jmp +281
nop +186
jmp +162
acc +44
acc +20
jmp +153
jmp +395
acc +49
jmp +1
acc +2
jmp +1
jmp -31
jmp +301
nop +97
jmp -102
jmp +262
acc +28
acc -15
acc +44
acc -13
jmp +191
jmp +281
acc +36
acc +1
nop +15
jmp +211
acc +6
acc -4
jmp +42
acc +34
acc +0
jmp +104
jmp +311
jmp +84
acc +43
acc -8
acc -10
acc +38
jmp -90
acc +49
jmp +303
nop +132
jmp +301
nop +60
acc +37
nop +96
jmp +182
acc +16
acc +18
nop +152
acc +19
jmp +325
jmp -63
acc +28
jmp +56
acc +18
acc +29
acc +33
jmp -115
acc +47
acc +19
jmp +1
nop +41
jmp +1
jmp -207
nop -62
acc -9
acc +42
acc -12
jmp -56
acc +28
jmp -163
acc +25
acc +17
jmp -217
acc +7
jmp +272
acc +43
acc +22
jmp +70
acc -17
jmp -117
acc +24
acc +26
nop -275
jmp -46
nop +87
acc +19
acc +28
jmp -34
acc +4
acc +9
acc +6
jmp +1
jmp +28
acc -6
nop -67
acc -10
jmp +271
acc +40
acc +25
acc -4
jmp -63
acc +46
jmp +78
acc +41
nop -126
nop +70
jmp +1
jmp +172
nop +270
jmp +30
jmp +1
acc +38
nop +68
acc +29
jmp +253
acc -18
jmp -89
acc +18
acc +30
jmp +147
acc +24
acc +11
acc +50
jmp -225
jmp -210
acc -18
acc +1
acc +38
jmp +1
jmp -79
acc +45
acc +12
jmp +209
jmp -207
acc +32
acc +4
acc +32
acc +14
jmp +83
acc +13
acc +1
acc +46
acc +38
jmp +28
nop +153
acc -17
jmp -73
acc +11
jmp +248
acc +29
acc +45
acc +16
jmp +96
jmp -273
acc +34
jmp +87
nop +99
acc -3
jmp -74
acc +12
nop -119
jmp -141
acc -18
nop -79
acc +1
acc +6
jmp +9
acc +3
acc +44
acc +39
jmp -165
acc +6
jmp +44
acc +25
jmp -133
acc +0
jmp +14
jmp +1
acc +1
jmp -223
jmp +71
nop -1
acc +22
acc +11
jmp -274
jmp -330
acc +45
jmp +1
acc +15
jmp -158
jmp -128
acc +50
acc +26
jmp -73
nop +99
jmp +71
acc +35
acc +7
jmp +192
acc +13
jmp +190
acc +4
acc -1
acc +40
acc -15
jmp +50
acc +29
jmp -337
jmp -75
acc +41
jmp +1
jmp -387
acc +28
acc +18
acc +19
jmp -62
nop -196
jmp -410
jmp +1
acc -17
jmp -267
acc +22
jmp -301
nop -98
acc -15
jmp -124
acc +45
acc -18
acc +15
acc +42
jmp -296
nop -10
acc +29
jmp -371
acc +3
jmp +1
nop +61
acc +5
jmp -361
acc -5
nop -326
jmp -379
acc -10
jmp +1
acc +44
jmp -231
acc +3
jmp -94
acc +1
jmp +113
jmp -336
acc +4
jmp -299
acc -13
jmp +1
acc +13
jmp +143
acc -11
acc -19
acc +18
nop -390
jmp -27
acc +42
jmp -232
acc +15
jmp -228
acc +21
acc +39
acc +47
acc +6
jmp +57
acc +28
acc +27
acc +50
jmp -397
acc +12
jmp -445
acc +30
jmp -352
acc -4
acc +26
acc +48
jmp +1
jmp -205
jmp +22
nop -284
acc -1
nop -361
acc +0
jmp -368
acc -17
nop -223
jmp -41
acc +4
acc +46
jmp +79
jmp -370
jmp -260
acc +42
jmp -14
acc +30
acc +50
acc +13
jmp -61
acc +46
jmp -63
nop -55
nop -320
jmp -11
acc +10
jmp -424
jmp -11
acc +3
jmp -71
acc +42
acc -13
jmp +4
nop -155
nop -138
jmp +62
acc +11
acc +19
acc +15
acc +17
jmp -73
acc -11
jmp -273
acc +8
acc +6
acc -7
acc +41
jmp -311
jmp -111
jmp -260
jmp +50
jmp -60
jmp +1
nop -89
acc +36
acc +14
jmp -220
nop -415
acc +28
jmp -402
acc +41
jmp -165
acc +9
acc -13
acc -18
acc +18
jmp -504
acc -9
acc +29
acc +44
jmp -444
acc +5
acc +47
jmp -545
acc +23
acc +7
nop -240
jmp -320
jmp -141
jmp +1
acc +28
nop -287
jmp -118
acc +44
acc -7
jmp -550
acc +10
acc +20
acc -3
jmp -401
acc +45
acc +36
jmp -375
jmp -485
acc +9
jmp -338
jmp -510
jmp -196
acc -16
jmp -372
acc +0
jmp -380
acc -3
nop -473
nop -361
jmp -311
acc +0
nop +20
jmp -436
acc +9
jmp +1
jmp -215
acc +19
jmp -451
jmp -43
acc -13
acc -10
acc -5
jmp -208
acc -11
jmp -156
acc +11
acc -2
nop -357
jmp -73
acc +21
jmp -159
acc +28
acc -16
acc +12
acc +1
jmp -282
jmp -131
acc -11
acc +45
acc +0
acc +28
jmp +1";
            return input.Split('\n');
        }
    }
}
