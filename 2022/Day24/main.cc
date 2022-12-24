// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <unordered_set>
#include <map>

using namespace std;

vector<string> getInput() {
    ifstream myfile ("Day24/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}

struct pair_hash {
    inline std::size_t operator()(const std::pair<int,int> & v) const {
        return v.first*31+v.second;
    }
};


struct Blizzard {
    pair<int,int> location;
    int xdir;
    int ydir;
};

int Part1() {
    unordered_set<pair<int,int>,pair_hash> blizzardLocations;
    vector<Blizzard> blizzards;
    vector<string> inp = getInput();
    for(int y=0; y<inp.size(); y++) {
        for(int x=0; x<inp[y].length(); x++) {
            if(inp[y][x] == '<') {
                Blizzard b;
                pair<int,int> p(x,y);
                b.location = p;
                b.xdir = -1;
                b.ydir = 0;
                blizzards.push_back(b);
                blizzardLocations.insert(p);
            } else if(inp[y][x] == '>') {
                Blizzard b;
                pair<int,int> p(x,y);
                b.location = p;
                b.xdir = 1;
                b.ydir = 0;
                blizzards.push_back(b);
                blizzardLocations.insert(p);
            } else if(inp[y][x] == '^') {
                Blizzard b;
                pair<int,int> p(x,y);
                b.location = p;
                b.xdir = 0;
                b.ydir = -1;
                blizzards.push_back(b);
                blizzardLocations.insert(p);
            } else if(inp[y][x] == 'v') {
                Blizzard b;
                pair<int,int> p(x,y);
                b.location = p;
                b.xdir = 0;
                b.ydir = 1;
                blizzards.push_back(b);
                blizzardLocations.insert(p);
            }
        }
    }
    int topWall = 0;
    int bottomWall = 36;
    // int bottomWall = 5;
    int leftWall = 0;
    int rightWall = 101; // 7
    int startX = 1;
    int goalX = 100; // 6
    unordered_set<pair<int,int>, pair_hash> expeditionLocations;
    expeditionLocations.insert(pair<int,int>(startX,0));
    for(int i=1; i<1000; i++) {
        // move blizzards
        blizzardLocations.clear();
        for(Blizzard& b : blizzards) {
            b.location.first += b.xdir;
            b.location.second += b.ydir;
            if (b.location.first == leftWall) {
                b.location.first = rightWall - 1;
            }
            if (b.location.first == rightWall) {
                b.location.first = leftWall + 1;
            }
            if (b.location.second == topWall) {
                b.location.second = bottomWall - 1;
            }
            if (b.location.second == bottomWall) {
                b.location.second = topWall + 1;
            }
            blizzardLocations.insert(b.location);
        }

        // move expedition
        unordered_set<pair<int,int>, pair_hash> newExpeditionLocations;
        for(pair<int,int> e : expeditionLocations) {
            // stay
            if (blizzardLocations.find(e) == blizzardLocations.end()) {
                newExpeditionLocations.insert(e);
            }
            // down
            if (e.second<bottomWall-1 || (e.first == goalX && e.second==bottomWall-1)) {
                pair<int,int> e1(e.first, e.second + 1);
                if (blizzardLocations.find(e1) == blizzardLocations.end()) {
                    newExpeditionLocations.insert(e1);
                }
            }
            // up
            if (e.second>topWall+1 || (e.first == goalX && e.second==topWall+1)) {
                pair<int,int> e1(e.first, e.second - 1);
                if (blizzardLocations.find(e1) == blizzardLocations.end()) {
                    newExpeditionLocations.insert(e1);
                }
            }
            // left
            if (e.first>leftWall+1 && e.second != topWall && e.second != bottomWall) {
                pair<int,int> e1(e.first-1, e.second);
                if (blizzardLocations.find(e1) == blizzardLocations.end()) {
                    newExpeditionLocations.insert(e1);
                }
            }
            // right
            if (e.first<rightWall-1 && e.second != topWall && e.second != bottomWall) {
                pair<int,int> e1(e.first+1, e.second);
                if (blizzardLocations.find(e1) == blizzardLocations.end()) {
                    newExpeditionLocations.insert(e1);
                }
            }
        }
        expeditionLocations = newExpeditionLocations;
        pair<int,int>pGoal(goalX,bottomWall);
        if(expeditionLocations.find(pGoal) != expeditionLocations.end()) {
            return i;
        }
    }
    return 1;
}

struct ExpeditionState {
    pair<int,int> location;
    bool reachedGoal;
    bool returnedToStart;

    int toInt() {
        int r = location.second;
        r += location.first * 1000;
        int w = 3;
        if (reachedGoal) {
            w--;
        }
        if (returnedToStart) {
            w--;
        }
        r += w*1000000;
        return r;
    }

};
struct state_hash {
    inline std::size_t operator()(const ExpeditionState & v) const {
        size_t s = v.location.first*31+v.location.second;
        s = s*2+v.reachedGoal?1:0;
        s = s*2+v.returnedToStart?1:0;
    }
};
int Part2() {
    unordered_set<pair<int,int>,pair_hash> blizzardLocations;
    vector<Blizzard> blizzards;
    vector<string> inp = getInput();
    for(int y=0; y<inp.size(); y++) {
        for(int x=0; x<inp[y].length(); x++) {
            if(inp[y][x] == '<') {
                Blizzard b;
                pair<int,int> p(x,y);
                b.location = p;
                b.xdir = -1;
                b.ydir = 0;
                blizzards.push_back(b);
                blizzardLocations.insert(p);
            } else if(inp[y][x] == '>') {
                Blizzard b;
                pair<int,int> p(x,y);
                b.location = p;
                b.xdir = 1;
                b.ydir = 0;
                blizzards.push_back(b);
                blizzardLocations.insert(p);
            } else if(inp[y][x] == '^') {
                Blizzard b;
                pair<int,int> p(x,y);
                b.location = p;
                b.xdir = 0;
                b.ydir = -1;
                blizzards.push_back(b);
                blizzardLocations.insert(p);
            } else if(inp[y][x] == 'v') {
                Blizzard b;
                pair<int,int> p(x,y);
                b.location = p;
                b.xdir = 0;
                b.ydir = 1;
                blizzards.push_back(b);
                blizzardLocations.insert(p);
            }
        }
    }
    int topWall = 0;
    int bottomWall = 36;
    // int bottomWall = 5;
    int leftWall = 0;
    int rightWall = 101; // 7
    int startX = 1;
    int goalX = 100; // 6
    vector<ExpeditionState> expeditionLocations;
    ExpeditionState start;
    start.location = pair<int,int>(startX,0);
    start.reachedGoal = false;
    start.returnedToStart = false;
    expeditionLocations.push_back(start);
    bool gotToEnd = false;
    bool returned = false;
    for(int i=1; i<1000; i++) {
        // move blizzards
        blizzardLocations.clear();
        for(Blizzard& b : blizzards) {
            b.location.first += b.xdir;
            b.location.second += b.ydir;
            if (b.location.first == leftWall) {
                b.location.first = rightWall - 1;
            }
            if (b.location.first == rightWall) {
                b.location.first = leftWall + 1;
            }
            if (b.location.second == topWall) {
                b.location.second = bottomWall - 1;
            }
            if (b.location.second == bottomWall) {
                b.location.second = topWall + 1;
            }
            blizzardLocations.insert(b.location);
        }
        unordered_set<int> visited;
        // move expedition
        vector<ExpeditionState> newExpeditionLocations;
        for(ExpeditionState es : expeditionLocations) {
            // don't need to see the same state twice
            int num = es.toInt();
            if(visited.find(num) != visited.end()) {
                continue;
            }
            visited.insert(num);
            pair<int,int> e = es.location;
            // stay
            if (blizzardLocations.find(e) == blizzardLocations.end()) {
                // don't need to check the state bools if we didn't move
                newExpeditionLocations.push_back(es);
            }
            // down
            if (e.second<bottomWall-1 || (e.first == goalX && e.second==bottomWall-1)) {
                pair<int,int> e1(e.first, e.second + 1);
                if (blizzardLocations.find(e1) == blizzardLocations.end()) {
                    ExpeditionState es1;
                    es1.location = e1;
                    es1.reachedGoal = (es.reachedGoal || (e1.first == goalX && e1.second==bottomWall));
                    es1.returnedToStart = (es.returnedToStart || (es.reachedGoal && e1.first == startX && e1.second==topWall)); 
                    newExpeditionLocations.push_back(es1);
                }
            }
            // up
            if (e.second>topWall+1 || (e.first == startX && e.second==topWall+1)) {
                pair<int,int> e1(e.first, e.second - 1);
                if (blizzardLocations.find(e1) == blizzardLocations.end()) {
                    ExpeditionState es1;
                    es1.location = e1;
                    es1.reachedGoal = (es.reachedGoal || (e1.first == goalX && e1.second==bottomWall));
                    es1.returnedToStart = (es.returnedToStart || (es.reachedGoal && e1.first == startX && e1.second==topWall)); 
                    newExpeditionLocations.push_back(es1);
                }
            }
            // left
            if (e.first>leftWall+1 && e.second != topWall && e.second != bottomWall) {
                pair<int,int> e1(e.first-1, e.second);
                if (blizzardLocations.find(e1) == blizzardLocations.end()) {
                    ExpeditionState es1;
                    es1.location = e1;
                    es1.reachedGoal = (es.reachedGoal || (e1.first == goalX && e1.second==bottomWall));
                    es1.returnedToStart = (es.returnedToStart || (es.reachedGoal && e1.first == startX && e1.second==topWall)); 
                    newExpeditionLocations.push_back(es1);
                }
            }
            // right
            if (e.first<rightWall-1 && e.second != topWall && e.second != bottomWall) {
                pair<int,int> e1(e.first+1, e.second);
                if (blizzardLocations.find(e1) == blizzardLocations.end()) {
                    ExpeditionState es1;
                    es1.location = e1;
                    es1.reachedGoal = (es.reachedGoal || (e1.first == goalX && e1.second==bottomWall));
                    es1.returnedToStart = (es.returnedToStart || (es.reachedGoal && e1.first == startX && e1.second==topWall)); 
                    newExpeditionLocations.push_back(es1);
                }
            }
        }
        expeditionLocations = newExpeditionLocations;
        
        // if an expedition reached a waypoint, we aren't going to get a better result from an expedition that reached later
        if (!gotToEnd) {
            vector<ExpeditionState> atEnd;
            for(ExpeditionState es : expeditionLocations) {
                if (es.reachedGoal) {
                    atEnd.push_back(es);
                    gotToEnd = true;
                }
            }
            if (gotToEnd) {
                expeditionLocations = atEnd;
            }
        } else {
            if (!returned) {
                vector<ExpeditionState> returnedStates;
                for(ExpeditionState es : expeditionLocations) {
                    if (es.returnedToStart) {
                        returnedStates.push_back(es);
                        returned = true;
                    }
                }
                if (returned) {
                    expeditionLocations = returnedStates;
                }
            }
        }
        
        // see if an expedition has hit all the waypoints and reached the goal
        for(ExpeditionState es : expeditionLocations) {
            if(es.returnedToStart && es.reachedGoal) {
                if (es.location.first ==goalX && es.location.second==bottomWall) {
                    return i;
                }
            }
        }
    }
    return 2;
}


// Driver Code
int main()
{
    std::cout << "Part 1: " << Part1() << "\n";
    std::cout << "Part 2: " << Part2() << "\n";
    
    return 0;
}
