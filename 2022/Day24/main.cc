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
    // int bottomWall = 36;
    int bottomWall = 5;
    int leftWall = 0;
    int rightWall = 7;// 101;
    int startX = 1;
    int goalX = 6;// 100;
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
    // int bottomWall = 36;
    int bottomWall = 5;
    int leftWall = 0;
    int rightWall = 7;// 101;
    int startX = 1;
    int goalX = 6;// 100;
    unordered_set<ExpeditionState, state_hash> expeditionLocations;
    ExpeditionState start;
    start.location = pair<int,int>(startX,0);
    start.reachedGoal = false;
    start.returnedToStart = false;
    expeditionLocations.insert(start);
    for(int i=1; i<1000; i++) {
        cout << i << "\n";
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
        unordered_set<ExpeditionState, state_hash> newExpeditionLocations;
        for(ExpeditionState es : expeditionLocations) {
            pair<int,int> e = es.location;
            // stay
            if (blizzardLocations.find(e) == blizzardLocations.end()) {
                // don't need to check the state bools if we didn't move
                newExpeditionLocations.insert(es);
            }
            // down
            if (e.second<bottomWall-1 || (e.first == goalX && e.second==bottomWall-1)) {
                pair<int,int> e1(e.first, e.second + 1);
                if (blizzardLocations.find(e1) == blizzardLocations.end()) {
                    ExpeditionState es1;
                    es1.location = e1;
                    es1.reachedGoal = (es.reachedGoal || (e1.first == goalX && e1.second==bottomWall));
                    es1.returnedToStart = (es.returnedToStart || (es.reachedGoal && e1.first == startX && e1.second==topWall)); 
                    newExpeditionLocations.insert(es1);
                }
            }
            // up
            if (e.second>topWall+1 || (e.first == goalX && e.second==topWall+1)) {
                pair<int,int> e1(e.first, e.second - 1);
                if (blizzardLocations.find(e1) == blizzardLocations.end()) {
                    ExpeditionState es1;
                    es1.location = e1;
                    es1.reachedGoal = (es.reachedGoal || (e1.first == goalX && e1.second==bottomWall));
                    es1.returnedToStart = (es.returnedToStart || (es.reachedGoal && e1.first == startX && e1.second==topWall)); 
                    newExpeditionLocations.insert(es1);
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
                    newExpeditionLocations.insert(es1);
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
                    newExpeditionLocations.insert(es1);
                }
            }
        }
        expeditionLocations = newExpeditionLocations;
        pair<int,int>pGoal(goalX,bottomWall);
        ExpeditionState esGoal;
        esGoal.location = pGoal;
        esGoal.reachedGoal = true;
        esGoal.returnedToStart = true;
        if(expeditionLocations.find(esGoal) != expeditionLocations.end()) {
            return i;
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
