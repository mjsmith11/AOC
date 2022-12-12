// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <map>

using namespace std;

vector<string> getInput() {
    ifstream myfile ("Day12/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}
int manhatten(int x1, int y1, int x2, int y2) {
    return 0;
    return abs(x1-x2) + abs(y1-y2);
}

int solve(int startX, int startY) {
    vector<vector<char>> map;
    for(string s : getInput()) {
        vector<char> line;
        for(char c : s) {
            line.push_back(c);
        }
        map.push_back(line);
    }
    int xSize = 81;
    int ySize = 41;
    int goalX = 58;
    int goalY = 20;

    vector<pair<int,int>> openSet;
    openSet.push_back(pair<int,int>(startX,startY));

    std::map<pair<int,int>, pair<int,int>> cameFrom;

    std::map<pair<int,int>, int> gScore;
    gScore[pair<int,int>(startX,startY)] = 0;

    std::map<pair<int,int>, int> fScore;
    gScore[pair<int,int>(startX,startY)] = manhatten(startX, startY, goalX, goalY);

    while (openSet.size() > 0) {
        int currentI = 0;
        pair<int,int> current = openSet[0];
        for(int i=1; i<openSet.size(); i++) {
            if (auto score = fScore.find(openSet[i]); score != fScore.end()) {
                if (fScore[openSet[i]] < fScore[openSet[currentI]]) {
                    currentI = i;
                    current = openSet[currentI];
                }
            }
        }
        openSet.erase(openSet.begin() + currentI);
        if (current == pair<int,int>(goalX, goalY)) { break; }

        // left
        if (current.first > 0 && map[current.second][current.first - 1] - map[current.second][current.first] <= 1) {
            int tentativeG = gScore[current] + 1;
            if (auto score = gScore.find(pair<int,int>(current.first-1, current.second)); score == gScore.end() || tentativeG < gScore[pair<int,int>(current.first-1, current.second)]) {
                cameFrom[pair<int,int>(current.first-1, current.second)] = current;
                gScore[pair<int,int>(current.first-1, current.second)] = tentativeG;
                fScore[pair<int,int>(current.first-1, current.second)] = tentativeG + manhatten(goalX, goalY, current.first-1, current.second);
                bool contains = false;
                for (pair<int,int> p : openSet) {
                    if (p == pair<int,int>(current.first - 1, current.second)) {
                        contains = true;
                        break;
                    }
                }
                if (!contains) {
                    openSet.push_back(pair<int,int>(current.first - 1, current.second));
                }
            }
        }
         // right
        if (current.first+1 < xSize && map[current.second][current.first + 1] - map[current.second][current.first] <= 1) {
            int tentativeG = gScore[current] + 1;
            if (auto score = gScore.find(pair<int,int>(current.first+1, current.second)); score == gScore.end() || tentativeG < gScore[pair<int,int>(current.first+1, current.second)]) {
                cameFrom[pair<int,int>(current.first+1, current.second)] = current;
                gScore[pair<int,int>(current.first+1, current.second)] = tentativeG;
                fScore[pair<int,int>(current.first+1, current.second)] = tentativeG + manhatten(goalX, goalY, current.first+1, current.second);
                bool contains = false;
                for (pair<int,int> p : openSet) {
                    if (p == pair<int,int>(current.first + 1, current.second)) {
                        contains = true;
                        break;
                    }
                }
                if (!contains) {
                    openSet.push_back(pair<int,int>(current.first + 1, current.second));
                }
            }
        }

         // up
        if (current.second > 0 && map[current.second-1][current.first] -map[current.second][current.first] <= 1) {
            int tentativeG = gScore[current] + 1;
            if (auto score = gScore.find(pair<int,int>(current.first, current.second-1)); score == gScore.end() || tentativeG < gScore[pair<int,int>(current.first, current.second-1)]) {
                cameFrom[pair<int,int>(current.first, current.second-1)] = current;
                gScore[pair<int,int>(current.first, current.second-1)] = tentativeG;
                fScore[pair<int,int>(current.first, current.second-1)] = tentativeG + manhatten(goalX, goalY, current.first, current.second-1);
                bool contains = false;
                for (pair<int,int> p : openSet) {
                    if (p == pair<int,int>(current.first, current.second-1)) {
                        contains = true;
                        break;
                    }
                }
                if (!contains) {
                    openSet.push_back(pair<int,int>(current.first, current.second-1));
                }
            }
        }
         // down
        if (current.second+1 < ySize && map[current.second+1][current.first] - map[current.second][current.first] <= 1) {
            int tentativeG = gScore[current] + 1;
            if (auto score = gScore.find(pair<int,int>(current.first, current.second+1)); score == gScore.end() || tentativeG < gScore[pair<int,int>(current.first, current.second+1)]) {
                cameFrom[pair<int,int>(current.first, current.second+1)] = current;
                gScore[pair<int,int>(current.first, current.second+1)] = tentativeG;
                fScore[pair<int,int>(current.first, current.second+1)] = tentativeG + manhatten(goalX, goalY, current.first, current.second+1);
                bool contains = false;
                for (pair<int,int> p : openSet) {
                    if (p == pair<int,int>(current.first, current.second+1)) {
                        contains = true;
                        break;
                    }
                }
                if (!contains) {
                    openSet.push_back(pair<int,int>(current.first, current.second+1));
                }
            }
        }

    }

    return fScore[pair<int,int>(goalX,goalY)];
}
int Part1() {
    return solve(0,20);
}

int16_t Part2() {
    vector<vector<char>> map;
    for(string s : getInput()) {
        vector<char> line;
        for(char c : s) {
            line.push_back(c);
        }
        map.push_back(line);
    }
    int minSteps = 1000;
    for(int y=0; y<map.size(); y++) {
        for (int x=0; x<map[y].size(); x++) {
            if (map[y][x] == 'a') {
                int steps = solve(x,y);
                minSteps = steps<minSteps && steps>0 ? steps : minSteps;
            }
        }
    }
    return minSteps;
}
// Driver Code
int main()
{
    std::cout << "Part 1 " << Part1() << "\n";
    std::cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
