public class Node {
    private char[,] grid;
    private int depth;
    private static int width = 13;
    private static int hallwayY=1;
    public int energy;

    public Node (string s, int energy) {
        this.energy = energy;
        string[] lines = s.Split("\n");
        this.depth = lines.Length;
        grid = new char[width,depth];
        for(int y=0; y<depth; y++) {
            for(int x=0; x<width; x++) {
                grid[x,y] = lines[y][x];
            }
        }
    }

    public Node(char[,] grid, int energy) {
        this.energy = energy;
        this.depth = grid.GetLength(1);
        this.grid = grid;
    }

    public string getGridString() {
        return getGridString(this.grid);
    }

    public string getGridString(char[,] gridArray) {
        string s = "";
        for(int y=0; y<depth; y++) {
            for(int x=0; x<width; x++) {
                s += gridArray[x,y];
            }
            s += '\n';
        }
        return s;
    }

    public List<Node> findNeighbors() {
        List<Node> neighbors = new List<Node>();

        // check the hallway
        for(int hallwayX=1; hallwayX<width-1; hallwayX++) {
            int targetCol = getTargetCol(grid[hallwayX,hallwayY]);
            if(targetCol==0) {continue; }
            OrderedPair dest = canMoveToRoom(targetCol, hallwayX);
            if (dest != null){
                char[,] newGrid = grid.Clone() as char[,];
                char amphipodType = grid[hallwayX,hallwayY];
                newGrid[hallwayX,hallwayY] = '.';
                newGrid[dest.x,dest.y] = amphipodType;
                int dist = Math.Abs(hallwayX-dest.x) + Math.Abs(hallwayY-dest.y);
                int newEnergy = energy + dist*getMultiplier(amphipodType);
                neighbors.Add(new Node(newGrid, newEnergy));
            }
        }

        // check the rooms
        int[] roomCols = {3,5,7,9};
        int[] hallwayCols = {1,2,4,6,8,10,11};
        foreach(int roomx in roomCols) {
            for(int roomy = hallwayY+1; roomy<depth - 1; roomy++) {
                if (grid[roomx,roomy]!='.') {
                    if (canLeaveRoom(roomx,roomy)) {
                        foreach(int hallwayX in hallwayCols) {
                            int start;
                            int stop;
                            if(roomx<hallwayX) {
                                start = roomx;
                                stop = hallwayX;
                            } else {
                                start = hallwayX;
                                stop = roomx;
                            }
                            bool hallwayClear = true;
                            for(int i=start; i<=stop; i++) {
                                if(grid[i,hallwayY]!='.') {hallwayClear = false; } // something is in the way
                            }
                            if (hallwayClear) {
                                char[,] newGrid = grid.Clone() as char[,];
                                char amphipodType = grid[roomx,roomy];
                                newGrid[roomx,roomy] = '.';
                                newGrid[hallwayX,hallwayY] = amphipodType;
                                int dist = Math.Abs(hallwayX-roomx) + Math.Abs(hallwayY-roomy);
                                int newEnergy = energy + dist*getMultiplier(amphipodType);
                                neighbors.Add(new Node(newGrid, newEnergy));
                            }
                        }
                    }
                    break; //we don't want to move something that is covered up
                }
            }
        }


        return neighbors;
    }

    private bool canLeaveRoom(int roomx, int roomy) {
        char type = grid[roomx,roomy];
        int targetCol = getTargetCol(type);
        if (targetCol != roomx) { return true; } // in the wrong column
        for(int y=roomy+1; y<depth-1; y++) {
            if (grid[roomx,y]!=type) { return true; }// something needs let out
        }
        return false;
    }
    private OrderedPair canMoveToRoom(int targetCol, int hallwayX) {
        // check the hallway
        int start;
        int stop;
        if(targetCol<hallwayX) {
            start = targetCol;
            stop = hallwayX-1;
        } else {
            start = hallwayX+1;
            stop = targetCol;
        }
        for(int i=start; i<=stop; i++) {
            if(grid[i,hallwayY]!='.') {return null; } // something is in the way
        }
        // check the target column
        char thisChar = grid[hallwayX,hallwayY];
        for(int y=depth - 2; y>hallwayY; y--) { // subtracting 1 from y for 0 based and 1 for the row of #
            char c = grid[targetCol,y];
            if (grid[targetCol,y]=='.') { 
                return new OrderedPair(targetCol,y); 
            } // there's an opening
            if (grid[targetCol,y] != thisChar) {return null; } // something is here but it's not it's destination
            // else nothing because its not available but the thing will stay
        }
        return null;

    }

    private int getTargetCol(char c) {
        switch(c) {
            case 'A': return 3;
            case 'B': return 5;
            case 'C': return 7;
            case 'D': return 9;
            default: return 0;
        }
    }
    private int getMultiplier(char c) {
        switch(c) {
            case 'A': return 1;
            case 'B': return 10;
            case 'C': return 100;
            case 'D': return 1000;
            default: return 0;
        }
    }

    public static bool gridsEqual(Node a, Node b, int ymax) {
        for(int x=0; x<width; x++) {
            for(int y=0; y<ymax; y++) {
                if(a.grid[x,y]==' ') { continue; }
                if (a.grid[x,y]!=b.grid[x,y]) {return false; }
            }
        }
        return true;
    }
}