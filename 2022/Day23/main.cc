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
    ifstream myfile ("Day23/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}

struct Elf {
    pair<int,int> location;
    pair<int,int> proposedLocation;
    bool willMove;
};
struct pair_hash {
    inline std::size_t operator()(const std::pair<int,int> & v) const {
        return v.first*31+v.second;
    }
};

int Part1() {
    vector<Elf> elves;
    unordered_set<pair<int,int>, pair_hash> occupiedLocations;
    vector<string> inp = getInput();
    for(int y=0; y<inp.size(); y++) {
        for(int x=0; x<inp[y].length(); x++) {
            if(inp[y][x] == '#') {
                Elf e;
                e.location = pair<int,int>(x,y);
                e.willMove = false;
                elves.push_back(e);
                occupiedLocations.insert(e.location);
            }
        }
    }
    map<pair<int,int>, int> numProposals;
    vector<char> order;
    order.push_back('N');
    order.push_back('S');
    order.push_back('W');
    order.push_back('E');
    for(int i=0; i<10; i++) {
        // propose locations
        for (Elf& e : elves) {
            bool clear = true;
            for(int x=-1; x<=1; x++) {
                for(int y=-1; y<=1; y++) {
                    if (x==0 && y==0) {
                        continue;
                    }
                    if (occupiedLocations.find(pair<int,int>(e.location.first + x, e.location.second+y)) != occupiedLocations.end()) {
                        clear = false;
                    }
                }
            }
            if (clear) {
                e.willMove = false;
                continue;
            } else {
                e.willMove = true;
            }
            bool madeProposal = false;
            for(char o : order) {
                pair<int,int> c1;
                pair<int,int> c2;
                pair<int,int> c3;
                if (o=='N') {
                    c1 = pair<int,int>(e.location.first-1, e.location.second-1);
                    c2 = pair<int,int>(e.location.first, e.location.second-1);
                    c3 = pair<int,int>(e.location.first+1, e.location.second-1);
                }
                if (o=='S') {
                    c1 = pair<int,int>(e.location.first-1, e.location.second+1);
                    c2 = pair<int,int>(e.location.first, e.location.second+1);
                    c3 = pair<int,int>(e.location.first+1, e.location.second+1);
                }
                if (o=='W') {
                    c1 = pair<int,int>(e.location.first-1, e.location.second-1);
                    c2 = pair<int,int>(e.location.first-1, e.location.second);
                    c3 = pair<int,int>(e.location.first-1, e.location.second+1);
                }
                if (o=='E') {
                    c1 = pair<int,int>(e.location.first+1, e.location.second-1);
                    c2 = pair<int,int>(e.location.first+1, e.location.second);
                    c3 = pair<int,int>(e.location.first+1, e.location.second+1);
                }
                if (occupiedLocations.find(c1) == occupiedLocations.end()) {
                    if (occupiedLocations.find(c2) == occupiedLocations.end()) {
                        if (occupiedLocations.find(c3) == occupiedLocations.end()) {
                            e.proposedLocation = c2;
                            madeProposal = true;
                            if (numProposals.find(c2) == numProposals.end()) {
                                numProposals[c2] = 1;
                            } else {
                                numProposals[c2]++;
                            }
                            break;
                        }
                    }
                }
            }
            if (!madeProposal) {
                e.willMove = false;
            }
        }
        // move the elves
        occupiedLocations.clear();
        for (Elf& e : elves) {
            if (e.willMove && numProposals[e.proposedLocation] == 1) {
                e.location = e.proposedLocation;
            }
            occupiedLocations.insert(e.location);
        }

        //reset
        numProposals.clear();
        vector<char> newOrder;
        newOrder.push_back(order[1]);
        newOrder.push_back(order[2]);
        newOrder.push_back(order[3]);
        newOrder.push_back(order[0]);
        order = newOrder;
    }
    // calculate result
    int minX = elves[0].location.first;
    int maxX = elves[0].location.first;
    int minY = elves[0].location.second;
    int maxY = elves[0].location.second;
    for(Elf e : elves) {
        minX = minX<e.location.first?minX:e.location.first;
        minY = minY<e.location.second?minY:e.location.second;
        maxX = maxX>e.location.first?maxX:e.location.first;
        maxY = maxY>e.location.second?maxY:e.location.second;
    }

    return (maxX-minX+1)*(maxY-minY+1)-elves.size();
}


int Part2() {
    vector<Elf> elves;
    unordered_set<pair<int,int>, pair_hash> occupiedLocations;
    vector<string> inp = getInput();
    for(int y=0; y<inp.size(); y++) {
        for(int x=0; x<inp[y].length(); x++) {
            if(inp[y][x] == '#') {
                Elf e;
                e.location = pair<int,int>(x,y);
                e.willMove = false;
                elves.push_back(e);
                occupiedLocations.insert(e.location);
            }
        }
    }
    map<pair<int,int>, int> numProposals;
    vector<char> order;
    order.push_back('N');
    order.push_back('S');
    order.push_back('W');
    order.push_back('E');
    for(int i=0; i<1000; i++) {
        // propose locations
        for (Elf& e : elves) {
            bool clear = true;
            for(int x=-1; x<=1; x++) {
                for(int y=-1; y<=1; y++) {
                    if (x==0 && y==0) {
                        continue;
                    }
                    if (occupiedLocations.find(pair<int,int>(e.location.first + x, e.location.second+y)) != occupiedLocations.end()) {
                        clear = false;
                    }
                }
            }
            if (clear) {
                e.willMove = false;
                continue;
            } else {
                e.willMove = true;
            }
            bool addedProposal = false;
            for(char o : order) {
                pair<int,int> c1;
                pair<int,int> c2;
                pair<int,int> c3;
                if (o=='N') {
                    c1 = pair<int,int>(e.location.first-1, e.location.second-1);
                    c2 = pair<int,int>(e.location.first, e.location.second-1);
                    c3 = pair<int,int>(e.location.first+1, e.location.second-1);
                }
                else if (o=='S') {
                    c1 = pair<int,int>(e.location.first-1, e.location.second+1);
                    c2 = pair<int,int>(e.location.first, e.location.second+1);
                    c3 = pair<int,int>(e.location.first+1, e.location.second+1);
                }
                else if (o=='W') {
                    c1 = pair<int,int>(e.location.first-1, e.location.second-1);
                    c2 = pair<int,int>(e.location.first-1, e.location.second);
                    c3 = pair<int,int>(e.location.first-1, e.location.second+1);
                }
                else if (o=='E') {
                    c1 = pair<int,int>(e.location.first+1, e.location.second-1);
                    c2 = pair<int,int>(e.location.first+1, e.location.second);
                    c3 = pair<int,int>(e.location.first+1, e.location.second+1);
                }
                if (occupiedLocations.find(c1) == occupiedLocations.end()) {
                    if (occupiedLocations.find(c2) == occupiedLocations.end()) {
                        if (occupiedLocations.find(c3) == occupiedLocations.end()) {
                            e.proposedLocation = c2;
                            if (numProposals.find(c2) == numProposals.end()) {
                                numProposals[c2] = 1;
                            } else {
                                numProposals[c2]++;
                            }
                            addedProposal  = true;
                            break;
                        }
                    }
                }
            }
            if (!addedProposal) {e.willMove = false;}
        }
        // move the elves
        occupiedLocations.clear();
        bool anyMoved = false;
        for (Elf& e : elves) {
            if (e.willMove && numProposals[e.proposedLocation] == 1) {
                anyMoved = true;
                e.location = e.proposedLocation;
            }
            occupiedLocations.insert(e.location);
        }
        if (!anyMoved) {
            return i+1;
        }

        //reset
        numProposals.clear();
        vector<char> newOrder;
        newOrder.push_back(order[1]);
        newOrder.push_back(order[2]);
        newOrder.push_back(order[3]);
        newOrder.push_back(order[0]);
        order = newOrder;
    }

    return -1;
}


// Driver Code
int main()
{
    std::cout << "Part 1: " << Part1() << "\n";
    std::cout << "Part 2: " << Part2() << "\n";
    
    return 0;
}
