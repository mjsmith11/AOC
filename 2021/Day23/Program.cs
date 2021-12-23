
using System.Collections.Generic;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Part 1 : " + solve(getInput1(), getGoal1()));
Console.WriteLine("Part 2 : " + solve(getInput2(), getGoal2()));



static int solve(string input, string goal) {
    Node goalNode = new Node(goal,0);
    PriorityQueue<Node,int> queue= new PriorityQueue<Node,int>();
    queue.Enqueue(new Node(input,0),0);
    List<string> sptSet = new List<string>();
    while(queue.Count > 0) {
        Node n = queue.Dequeue();
        if (sptSet.Contains(n.getGridString())) {
            continue;
        }
        if(Node.gridsEqual(n,goalNode,input.Split("\n").Length)) {
            return n.energy;
        }
        sptSet.Add(n.getGridString());
        foreach(Node neighbor in n.findNeighbors()) {
            queue.Enqueue(neighbor,neighbor.energy);
        }
    }
    return 0;

}


static string getInput1() {
    return @"#############
#...........#
###C#A#B#D###
  #B#A#D#C#  
  #########  ";
}

static string getGoal1() {
    return @"#############
#...........#
###A#B#C#D###
  #A#B#C#D#  
  #########  ";
}

static string getInput2() {
    return @"#############
#...........#
###C#A#B#D###
  #D#C#B#A#  
  #D#B#A#C#  
  #B#A#D#C#  
  #########  ";
}

static string getGoal2() {
    return @"#############
#...........#
###A#B#C#D###
  #A#B#C#D#  
  #A#B#C#D#  
  #A#B#C#D#  
  #########  ";
}