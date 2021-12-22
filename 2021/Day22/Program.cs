using System;
using System.Text.RegularExpressions;

namespace Day22
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1 : " + part1());
            Console.WriteLine("Part 2 : " + part2());
        }

        static int part1() {
            int offset = 50;
            int size = 101;
            string[] lines = getInput();
            bool[,,] grid = new bool[size,size,size];
            foreach(string line in lines) {
                string regex = @"(?<inst>(on|off)) x=(?<x1>(-)?\d+)\.\.(?<x2>(-)?\d+),y=(?<y1>(-)?\d+)\.\.(?<y2>(-)?\d+),z=(?<z1>(-)?\d+)\.\.(?<z2>(-)?\d+)";
                Match m = Regex.Match(line,regex);
                string instruction = m.Groups["inst"].Value;
                int x1 = Int32.Parse(m.Groups["x1"].Value);
                int x2 = Int32.Parse(m.Groups["x2"].Value);
                int y1 = Int32.Parse(m.Groups["y1"].Value);
                int y2 = Int32.Parse(m.Groups["y2"].Value);
                int z1 = Int32.Parse(m.Groups["z1"].Value);
                int z2 = Int32.Parse(m.Groups["z2"].Value);
            
                if (x1>50 && x2>50) { continue; }
                if (y1>50 && y2>50) { continue; }
                if (z1>50 && z2>50) { continue; }
                if (x1<-50 && x2<-50) {continue; }
                if (y1<-50 && y2<-50) {continue; }
                if (z1<-50 && z2<-50) {continue; }

                int xmin,xmax,ymin,ymax,zmin,zmax;
                xmin = getMin(x1,x2);
                xmax = getMax(x1,x2);
                ymin = getMin(y1,y2);
                ymax = getMax(y1,y2);
                zmin = getMin(z1,z2);
                zmax = getMax(z1,z2);
                for(int x=xmin; x<=xmax; x++) {
                    for(int y=ymin; y<=ymax; y++) {
                        for(int z=zmin; z<=zmax; z++) {
                            if (instruction=="on") {grid[x+offset,y+offset,z+offset] = true; }
                            else {grid[x+offset,y+offset,z+offset] = false; }
                        }
                    }
                }
                
            }
            int count = 0;
            for(int i=0; i<size; i++) {
                for(int j=0; j<size; j++) {
                    for(int k=0; k<size; k++) {
                        if(grid[i,j,k]) {count++; }
                    }
                }
            }

            return count;
        }

        static long part2() {
            int offset = 100000;
            int size = 200001;
            string[] lines = getInput();
            bool[,,] grid = new bool[size,size,size];
            foreach(string line in lines) {
                string regex = @"(?<inst>(on|off)) x=(?<x1>(-)?\d+)\.\.(?<x2>(-)?\d+),y=(?<y1>(-)?\d+)\.\.(?<y2>(-)?\d+),z=(?<z1>(-)?\d+)\.\.(?<z2>(-)?\d+)";
                Match m = Regex.Match(line,regex);
                string instruction = m.Groups["inst"].Value;
                int x1 = Int32.Parse(m.Groups["x1"].Value);
                int x2 = Int32.Parse(m.Groups["x2"].Value);
                int y1 = Int32.Parse(m.Groups["y1"].Value);
                int y2 = Int32.Parse(m.Groups["y2"].Value);
                int z1 = Int32.Parse(m.Groups["z1"].Value);
                int z2 = Int32.Parse(m.Groups["z2"].Value);

                int xmin,xmax,ymin,ymax,zmin,zmax;
                xmin = x1<x2?x1:x2;
                xmax = x1>x2?x1:x2;
                ymin = y1<y2?y1:y2;
                ymax = y1>y2?y1:y2;
                zmin = z1<z2?z1:z2;
                zmax = z1>z2?z1:z2;
                for(int x=xmin; x<=xmax; x++) {
                    for(int y=ymin; y<=ymax; y++) {
                        for(int z=zmin; z<=zmax; z++) {
                            if (instruction=="on") {grid[x+offset,y+offset,z+offset] = true; }
                            else {grid[x+offset,y+offset,z+offset] = false; }
                        }
                    }
                }
                
            }
            Console.WriteLine("steps complete");
            long count = 0;
            for(int i=0; i<size; i++) {
                Console.WriteLine($"Counting i="+i);
                for(int j=0; j<size; j++) {
                    for(int k=0; k<size; k++) {
                        if(grid[i,j,k]) {count++; }
                    }
                }
            }

            return count;
        }

        static int getMax(int n1, int n2) {
            int max = n1>n2?n1:n2;
            if(max>50) { return 50; }
            if (max<-50) { return -50; }
            return max;
        }
        static int getMin(int n1, int n2) {
            int min = n1<n2?n1:n2;
            if(min>50) { return 50; }
            if (min<-50) { return -50; }
            return min;
        }
        static string[] getInput() {
            string data = @"on x=-5..47,y=-31..22,z=-19..33
on x=-44..5,y=-27..21,z=-14..35
on x=-49..-1,y=-11..42,z=-10..38
on x=-20..34,y=-40..6,z=-44..1
off x=26..39,y=40..50,z=-2..11
on x=-41..5,y=-41..6,z=-36..8
off x=-43..-33,y=-45..-28,z=7..25
on x=-33..15,y=-32..19,z=-34..11
off x=35..47,y=-46..-34,z=-11..5
on x=-14..36,y=-6..44,z=-16..29
on x=-57795..-6158,y=29564..72030,z=20435..90618
on x=36731..105352,y=-21140..28532,z=16094..90401
on x=30999..107136,y=-53464..15513,z=8553..71215
on x=13528..83982,y=-99403..-27377,z=-24141..23996
on x=-72682..-12347,y=18159..111354,z=7391..80950
on x=-1060..80757,y=-65301..-20884,z=-103788..-16709
on x=-83015..-9461,y=-72160..-8347,z=-81239..-26856
on x=-52752..22273,y=-49450..9096,z=54442..119054
on x=-29982..40483,y=-108474..-28371,z=-24328..38471
on x=-4958..62750,y=40422..118853,z=-7672..65583
on x=55694..108686,y=-43367..46958,z=-26781..48729
on x=-98497..-18186,y=-63569..3412,z=1232..88485
on x=-726..56291,y=-62629..13224,z=18033..85226
on x=-110886..-34664,y=-81338..-8658,z=8914..63723
on x=-55829..24974,y=-16897..54165,z=-121762..-28058
on x=-65152..-11147,y=22489..91432,z=-58782..1780
on x=-120100..-32970,y=-46592..27473,z=-11695..61039
on x=-18631..37533,y=-124565..-50804,z=-35667..28308
on x=-57817..18248,y=49321..117703,z=5745..55881
on x=14781..98692,y=-1341..70827,z=15753..70151
on x=-34419..55919,y=-19626..40991,z=39015..114138
on x=-60785..11593,y=-56135..2999,z=-95368..-26915
on x=-32178..58085,y=17647..101866,z=-91405..-8878
on x=-53655..12091,y=50097..105568,z=-75335..-4862
on x=-111166..-40997,y=-71714..2688,z=5609..50954
on x=-16602..70118,y=-98693..-44401,z=5197..76897
on x=16383..101554,y=4615..83635,z=-44907..18747
off x=-95822..-15171,y=-19987..48940,z=10804..104439
on x=-89813..-14614,y=16069..88491,z=-3297..45228
on x=41075..99376,y=-20427..49978,z=-52012..13762
on x=-21330..50085,y=-17944..62733,z=-112280..-30197
on x=-16478..35915,y=36008..118594,z=-7885..47086
off x=-98156..-27851,y=-49952..43171,z=-99005..-8456
off x=2032..69770,y=-71013..4824,z=7471..94418
on x=43670..120875,y=-42068..12382,z=-24787..38892
off x=37514..111226,y=-45862..25743,z=-16714..54663
off x=25699..97951,y=-30668..59918,z=-15349..69697
off x=-44271..17935,y=-9516..60759,z=49131..112598
on x=-61695..-5813,y=40978..94975,z=8655..80240
off x=-101086..-9439,y=-7088..67543,z=33935..83858
off x=18020..114017,y=-48931..32606,z=21474..89843
off x=-77139..10506,y=-89994..-18797,z=-80..59318
off x=8476..79288,y=-75520..11602,z=-96624..-24783
on x=-47488..-1262,y=24338..100707,z=16292..72967
off x=-84341..13987,y=2429..92914,z=-90671..-1318
off x=-37810..49457,y=-71013..-7894,z=-105357..-13188
off x=-27365..46395,y=31009..98017,z=15428..76570
off x=-70369..-16548,y=22648..78696,z=-1892..86821
on x=-53470..21291,y=-120233..-33476,z=-44150..38147
off x=-93533..-4276,y=-16170..68771,z=-104985..-24507";
            return data.Split("\n");
        }
    }
}
