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
/*struct pair_hash {
    inline std::size_t operator()(const std::pair<int,int> & v) const {
        return v.first*31+v.second;
    }
};*/
struct pair_hash
{
    template <class T1, class T2>
    std::size_t operator() (const std::pair<T1, T2> &pair) const {
        return std::hash<T1>()(pair.first) ^ std::hash<T2>()(pair.second);
    }
};
void output(unordered_set<pair<int,int>, pair_hash> occupiedLocations) {
    for(int y=-5; y<15; y++) {
        for(int x=-5; x<15;x++) {
            if (occupiedLocations.find(pair<int,int>(x,y)) == occupiedLocations.end()) {
                cout << ".";
            } else {
                cout << "#";
            }
        }
        cout << "\n";
    }
    cout << "\n";
}
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
    // output(occupiedLocations);
    map<pair<int,int>, int> numProposals;
    vector<char> order;
    order.push_back('N');
    order.push_back('S');
    order.push_back('W');
    order.push_back('E');
    for(int i=0; i<2; i++) {
        // propose locations
        for (Elf& e : elves) {
            pair<int, int> ch1(e.location.first-1, e.location.second-1);
            pair<int, int> ch2(e.location.first, e.location.second-1);
            pair<int, int> ch3(e.location.first+1, e.location.second-1);
            pair<int, int> ch4(e.location.first-1, e.location.second);
            pair<int, int> ch5(e.location.first+1, e.location.second);
            pair<int, int> ch6(e.location.first-1, e.location.second+1);
            pair<int, int> ch7(e.location.first, e.location.second+1);
            pair<int, int> ch8(e.location.first+1, e.location.second+1);
            bool clear = (occupiedLocations.find(ch1) == occupiedLocations.end());
            clear &= (occupiedLocations.find(ch2) == occupiedLocations.end());
            clear &= (occupiedLocations.find(ch3) == occupiedLocations.end());
            clear &= (occupiedLocations.find(ch4) == occupiedLocations.end());
            clear &= (occupiedLocations.find(ch5) == occupiedLocations.end());
            clear &= (occupiedLocations.find(ch6) == occupiedLocations.end());
            clear &= (occupiedLocations.find(ch7) == occupiedLocations.end());
            clear &= (occupiedLocations.find(ch8) == occupiedLocations.end());
            if (clear) {
                e.willMove = false;
                continue;
            } else {
                e.willMove = true;
            }
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
        }
        // move the elves
        occupiedLocations.clear();
        for (Elf& e : elves) {
            if (e.willMove && numProposals[e.proposedLocation] == 1) {
                e.location = e.proposedLocation;
            }
            occupiedLocations.insert(e.location);
        }
        output(occupiedLocations);

        //reset
        numProposals.clear();
        vector<char> newOrder;
        newOrder.push_back(order[1]);
        newOrder.push_back(order[2]);
        newOrder.push_back(order[3]);
        newOrder.push_back(order[0]);
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
    cout << minX << "\n";
    cout << maxX << "\n";
    cout << minY << "\n";
    cout << maxY << "\n";
    return (maxX-minX+1)*(maxY-minY+1)-elves.size();
}

int Part2() {
    return 2;
}


// Driver Code
int main()
{
    std::cout << "Part 1: " << Part1() << "\n";
    std::cout << "Part 2: " << Part2() << "\n";
    
    return 0;
}
