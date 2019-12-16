void main() {
  var input = "59762677844514231707968927042008409969419694517232887554478298452757853493727797530143429199414189647594938168529426160403829916419900898120019486915163598950118118387983556244981478390010010743564233546700525501778401179747909200321695327752871489034092824259484940223162317182126390835917821347817200000199661513570119976546997597685636902767647085231978254788567397815205001371476581059051537484714721063777591837624734411735276719972310946108792993253386343825492200871313132544437143522345753202438698221420628103468831032567529341170616724533679890049900700498413379538865945324121019550366835772552195421407346881595591791012185841146868209045";
  var iterations = 100;
  var inputArr = new List(input.length);
  for(int i = 0; i<input.length; i++) {
    inputArr[i] = int.parse(input[i]);
  }
  var outputArr = new List(input.length);
  for(int i=0; i<iterations; i++) {
    // iterate over output positions
    for(int pos = 0; pos<input.length; pos++ ) {
      // prep the pattern for this positon
      var pattern = new List(4*(pos+1));
      for(int j=0; j<(pos+1); j++) { pattern[j] = 0;}
      for(int j=(pos+1); j<2*(pos+1); j++) { pattern[j] = 1;}
      for(int j=2*(pos+1); j<3*(pos+1); j++) { pattern[j] = 0;}
      for(int j=3*(pos+1); j<4*(pos+1); j++) { pattern[j] = -1;}
      var nextPattern = 1;
      var value = 0;
      for(int j=0; j<input.length; j++) {
        var inputVal = inputArr[j];
        var patternVal = pattern[nextPattern];
        value = value + (inputArr[j]*pattern[nextPattern]);
        nextPattern = nextPattern + 1;
        if (nextPattern >= pattern.length) { nextPattern = 0;}
      }
      outputArr[pos] = (value.abs() % 10);
    }
    inputArr = outputArr;
  }
  for(int i=0; i<8; i++)
  {
    print(outputArr[i]);
  }
}
