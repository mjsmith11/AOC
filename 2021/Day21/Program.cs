// See https://aka.ms/new-console-template for more information
Console.WriteLine("Part 1 : " + part1());
Console.WriteLine("Part 2 : " + part2());

static int part1() {
    Player one = new Player(7);
    Player two = new Player(4);
    int nextDieNum = 1;
    while(one.points<1000 && two.points<1000) {
        int amtToMove = (nextDieNum%100) + ((nextDieNum+1)%100) + ((nextDieNum+2)%100);
        nextDieNum += 3;
        one.move(amtToMove);
    
        // make sure player 1 didn't just win
        if (one.points <1000) {
            amtToMove = (nextDieNum%100) + ((nextDieNum+1)%100) + ((nextDieNum+2)%100);
            nextDieNum += 3;
            two.move(amtToMove);
        }
    }
    if (one.points>=1000) {
        return two.points * (nextDieNum - 1);
    } else {
        return one.points * (nextDieNum - 1);
    }
}

static long part2() {
    
    long p1Wins = 0;
    long p2Wins = 0;
    Dictionary<int, long> gameStates = new Dictionary<int,long>();

    Player one = new Player(7);
    Player two = new Player(4);
    int gameId = gameToInt(one, two);
    gameStates[gameId] = 1;

    List<int> rollPossibilites = new List<int>();
    for(int i=1; i<=3; i++) {
        for(int j=1; j<=3; j++) {
            for(int k=1; k<=3; k++) {
                rollPossibilites.Add(i+j+k);
            }
        }
    }
    while(gameStates.Count() > 0) {
        Dictionary<int, long> newGameStates = new Dictionary<int,long>();
        foreach(KeyValuePair<int,long> entry in gameStates) 
        {
            one = getOne(entry.Key);
            two = getTwo(entry.Key);
            foreach(int r1 in rollPossibilites) {
                Player newOne = one.newPlayerMove(r1);
                if(newOne.points>=21) {
                    // p1 won.  It doesn't matter what p2 does
                    p1Wins += entry.Value;
                } else {
                    // p1 did not win.  It does matter what p2 does
                    foreach(int r2 in rollPossibilites) {
                        Player newTwo = two.newPlayerMove(r2);
                        if (newTwo.points>=21) {
                            //p2 wins
                            p2Wins += entry.Value;
                        } else {
                            // need to go another round.
                            int id = gameToInt(newOne,newTwo);
                            if (newGameStates.ContainsKey(id)) {
                                newGameStates[id] += entry.Value;
                            } else {
                                newGameStates[id] = entry.Value;
                            }
                        }
                    }
                }
            }

        }
        gameStates = newGameStates;
    }


    return p1Wins>p2Wins?p1Wins:p2Wins;

}

static int gameToInt(Player one, Player two) {
    return one.space + one.points*100 + two.space*10000 + two.points * 1000000;
}

static Player getOne(int state) {
    int space = state % 100;
    int points = (state/100)%100;
    return new Player(space,points);
}

static Player getTwo(int state) {
    int space = (state/10000) % 100;
    int points = (state/1000000)%100;
    return new Player(space,points);
}

