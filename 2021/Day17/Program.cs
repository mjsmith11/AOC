// See https://aka.ms/new-console-template for more information
Console.WriteLine("Part 1 : " + part1());
Console.WriteLine("Part 2 : " + part2());

static int part1() {
    string input = getInput();
    string[] splits = input.Split(",");
    int minx=Int32.Parse(splits[0]);
    int maxx=Int32.Parse(splits[1]);
    int miny=Int32.Parse(splits[2]);
    int maxy=Int32.Parse(splits[3]);

    int maxHeight = 0;

    for(int vx=1; vx<=maxx; vx++) {
        for(int vy=miny; vy<=500; vy++) { // 500 is a guess that happened to be enough :-)
            int px = 0;
            int py = 0;
            int curvx=vx;
            int curvy=vy;
            bool hitTarget = false;
            int peak = Int32.MinValue;
            while(px<maxx && py>miny ) {
                px += curvx;
                py += curvy;
                if (curvx>0) { curvx--; }
                curvy--;
                if (py>peak) { peak = py; }
                if (px>=minx && px<=maxx && py>=miny && py<=maxy) {
                    hitTarget = true;
                    break;
                }
            }
            if (peak>maxHeight && hitTarget) {
                maxHeight = peak;
            }
        }
    }

    return maxHeight;
}

static int part2() {
    string input = getInput();
    string[] splits = input.Split(",");
    int minx=Int32.Parse(splits[0]);
    int maxx=Int32.Parse(splits[1]);
    int miny=Int32.Parse(splits[2]);
    int maxy=Int32.Parse(splits[3]);

    int count = 0;

    for(int vx=1; vx<=maxx; vx++) {
        for(int vy=miny; vy<=500; vy++) { // 500 is a guess that happened to be enough :-)
            int px = 0;
            int py = 0;
            int curvx=vx;
            int curvy=vy;
            while(px<maxx && py>miny ) {
                px += curvx;
                py += curvy;
                if (curvx>0) { curvx--; }
                curvy--;
                if (px>=minx && px<=maxx && py>=miny && py<=maxy) {
                    count++;
                    break;
                }
            }
        }
    }

    return count;
}



static string getInput() {
    return "150,193,-136,-86";
    //return "20,30,-10,-5";
}