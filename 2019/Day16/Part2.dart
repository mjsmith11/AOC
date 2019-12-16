void main() {
  var rawInput = "59762677844514231707968927042008409969419694517232887554478298452757853493727797530143429199414189647594938168529426160403829916419900898120019486915163598950118118387983556244981478390010010743564233546700525501778401179747909200321695327752871489034092824259484940223162317182126390835917821347817200000199661513570119976546997597685636902767647085231978254788567397815205001371476581059051537484714721063777591837624734411735276719972310946108792993253386343825492200871313132544437143522345753202438698221420628103468831032567529341170616724533679890049900700498413379538865945324121019550366835772552195421407346881595591791012185841146868209045";
  //input is 650
  //repeated is 6500000
  // want to start at 5976267
  // need 806 repetitions
  // 5976100 offset
    // this works on a pattern that a digit in a string is the sum of the digit in positions 
  // of equal or less significance in the previous string modulo 10
  var input = "";
  for(int i=0; i<806; i++) {
    input = input + rawInput;
   }
  var iterations = 100;
  var inputArr = new List(input.length);
  for(int i = 0; i<input.length; i++) {
    inputArr[i] = int.parse(input[i]);
  }

  var outputArr = new List(input.length);
  for(int i=0; i<iterations; i++) {
    // iterate over output positions
    var sum = 0;
    for(int pos = input.length - 1; pos>=0; pos-- ) {
      sum = sum + inputArr[pos];
      outputArr[pos] = sum % 10;
    }
    inputArr = outputArr;
  }
  for(int i=167; i<175; i++) // hard coded based on above comments and input
  {
    print(outputArr[i]);
  }
}
