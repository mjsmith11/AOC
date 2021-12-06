// See https://aka.ms/new-console-template for more information
Console.WriteLine("Part 1: " + altSolve(80));
Console.WriteLine("Part 2: " + altSolve(256));

static int solve(int days) {
    List<int> fish = getInput();
    for(int i = 0; i<days; i++) {
        List<int> newFish = new List<int>();
        foreach(int f in fish) {
            if (f==0) {
                newFish.Add(8);
                newFish.Add(6);
            } else {
                newFish.Add(f-1);
            }
        }
        fish=newFish;
    }
    return fish.Count();
}

static long altSolve(int days) {
    List<int> fish = getInput();
    Dictionary<int,long> list = new Dictionary<int,long>();
    list[0]=0;
    list[1]=0;
    list[2]=0;
    list[3]=0;
    list[4]=0;
    list[5]=0;
    list[6]=0;
    list[7]=0;
    list[8]=0;
    foreach (int f in fish) {
        list[f]++;
    }
    for(int i = 0; i<days; i++) {
        Dictionary<int,long> newList = new Dictionary<int,long>();
        newList[0] = list[1];
        newList[1] = list[2];
        newList[2] = list[3];
        newList[3] = list[4];
        newList[4] = list[5];
        newList[5] = list[6];
        newList[6] = list[7] + list[0];
        newList[7] = list[8];
        newList[8] = list[0];

        list=newList;
    }
    long sum = 0;
    for(int i=0; i<=8; i++) {
        sum += list[i];
    }
    return sum;

}



static List<int> getInput() {
    string input = "4,3,4,5,2,1,1,5,5,3,3,1,5,1,4,2,2,3,1,5,1,4,1,2,3,4,1,4,1,5,2,1,1,3,3,5,1,1,1,1,4,5,1,2,1,2,1,1,1,5,3,3,1,1,1,1,2,4,2,1,2,3,2,5,3,5,3,1,5,4,5,4,4,4,1,1,2,1,3,1,1,4,2,1,2,1,2,5,4,2,4,2,2,4,2,2,5,1,2,1,2,1,4,4,4,3,2,1,2,4,3,5,1,1,3,4,2,3,3,5,3,1,4,1,1,1,1,2,3,2,1,1,5,5,1,5,2,1,4,4,4,3,2,2,1,2,1,5,1,4,4,1,1,4,1,4,2,4,3,1,4,1,4,2,1,5,1,1,1,3,2,4,1,1,4,1,4,3,1,5,3,3,3,4,1,1,3,1,3,4,1,4,5,1,4,1,2,2,1,3,3,5,3,2,5,1,1,5,1,5,1,4,4,3,1,5,5,2,2,4,1,1,2,1,2,1,4,3,5,5,2,3,4,1,4,2,4,4,1,4,1,1,4,2,4,1,2,1,1,1,1,1,1,3,1,3,3,1,1,1,1,3,2,3,5,4,2,4,3,1,5,3,1,1,1,2,1,4,4,5,1,5,1,1,1,2,2,4,1,4,5,2,4,5,2,2,2,5,4,4";
    string[] splitInput = input.Split(",");
    List<int> nums = new List<int>();
    foreach(string num in splitInput) {
        nums.Add(Int32.Parse(num));
    }
    return nums;
}