// See https://aka.ms/new-console-template for more information
Console.WriteLine("Very specific to my unique input.");
Console.WriteLine("Part 1 : " + part1());
Console.WriteLine("Part 2 : " + part2());


static long part1() {
    ALU a = new ALU();
    long max = 0;
    // iterate over the first 7 numbers and then apply the rules from notes to generate the rest
    for(long i = 9999999; i>1000000; i--) {
        string num = i.ToString();
        if(num.Contains("0")) { continue; } // zeros aren't allowed
        if(Int32.Parse(num[4].ToString()) != Int32.Parse(num[3].ToString()) - 5) { continue; } // constraint between spots 3 and 4
        
        // num is now indexes 0 to 6 apply rules to create the rest.
        num += (Int32.Parse(num[6].ToString()) -4); //7
        // 8 and 8 depend on each other so we have to loop over all values.
        for(int j=1; j<=7; j++) { // j stops at 7 since we have to add 2 for spot 9;
            string jnum = num;
            jnum += j; //8
            jnum += (j+2); //9;
            jnum += (Int32.Parse(num[5].ToString()) +8); //10
            jnum += (Int32.Parse(num[2].ToString()) +5); //11
            jnum += (Int32.Parse(num[1].ToString()) -2); //12
            jnum += (Int32.Parse(num[0].ToString()) + 6); //13
            if(jnum.Contains("0")) { continue; } // zeros aren't allowed
            if(jnum.Length != 14) { continue; } // check for things that aren't 0-9

            // shouldn't need to check against the ALU, but just for fun
            a.reset();
            a.input = jnum;
            a.execute2();
            if (a.z==0) { 
                if (Int64.Parse(jnum) > max) {
                    max = Int64.Parse(jnum);
                }    
            }
        }
    }
    return max;

}

static long part2() {
    ALU a = new ALU();
    long min = Int64.MaxValue;
    // iterate over the first 7 numbers and then apply the rules from notes to generate the rest
    for(long i = 9999999; i>1000000; i--) {
        string num = i.ToString();
        if(num.Contains("0")) { continue; } // zeros aren't allowed
        if(Int32.Parse(num[4].ToString()) != Int32.Parse(num[3].ToString()) - 5) { continue; } // constraint between spots 3 and 4
        
        // num is now indexes 0 to 6 apply rules to create the rest.
        num += (Int32.Parse(num[6].ToString()) -4); //7
        // 8 and 8 depend on each other so we have to loop over all values.
        for(int j=1; j<=7; j++) { // j stops at 7 since we have to add 2 for spot 9;
            string jnum = num;
            jnum += j; //8
            jnum += (j+2); //9;
            jnum += (Int32.Parse(num[5].ToString()) +8); //10
            jnum += (Int32.Parse(num[2].ToString()) +5); //11
            jnum += (Int32.Parse(num[1].ToString()) -2); //12
            jnum += (Int32.Parse(num[0].ToString()) + 6); //13
            if(jnum.Contains("0")) { continue; } // zeros aren't allowed
            if(jnum.Length != 14) { continue; } // check for things that aren't 0-9

            // shouldn't need to check against the ALU, but just for fun
            a.reset();
            a.input = jnum;
            a.execute2();
            if (a.z==0) { 
                if (Int64.Parse(jnum) < min) {
                    min = Int64.Parse(jnum);
                }    
            }
        }
    }
    return min;

}


static void convertToCode() {
    foreach(string line in getInstructions()) {
        string[] pieces = line.Trim().Split(" ");
        switch(pieces[0]) {
            case "inp":
                Console.WriteLine($"{pieces[1]} = getNextInput();");
                break;
            case "add":
                Console.WriteLine($"{pieces[1]} += {pieces[2]};");
                break;
            case "mul":
                Console.WriteLine($"{pieces[1]} *= {pieces[2]};");
                break;
            case "div":
                Console.WriteLine($"{pieces[1]} /= {pieces[2]};");
                break;
            case "mod":
                Console.WriteLine($"{pieces[1]} %= {pieces[2]};");
                break;
            case "eql":
                Console.WriteLine($"{pieces[1]} = {pieces[1]}=={pieces[2]}?1:0;");
                break;
        }
    }
}




static string[] getInstructions() {
    string input = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 13
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 6
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 15
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 7
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 15
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 10
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -7
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 10
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 8
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 10
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 1
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -5
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 10
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 15
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 5
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -3
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 3
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x 0
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 5
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -5
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 11
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x 0
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 10
mul y x
add z y";
    return input.Split("\n");
}