public class Player {
    public int points;
    public int space;

    public Player(int startingSpace) {
        space = startingSpace;
        points = 0;
    }

    public Player(int space, int points) {
        this.space = space;
        this.points = points;
    }

    public void move(int spaces) {
        for(int i=0; i<spaces; i++) {
            space++;
            if (space==11) { space = 1;}
        }
        points += space;
    }

    public Player newPlayerMove(int spaces) {
        int mySpace = space;
        for(int i=0; i<spaces; i++) {
            mySpace++;
            if(mySpace==11) { mySpace = 1; }
        }
        
        int myPoints = points+mySpace;
        return new Player(mySpace, myPoints);
    } 

    public string ToString() {
        return $"{points} {space}";
    }
}