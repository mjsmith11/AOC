// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>

#include "absl/strings/str_split.h"

using namespace std;

vector<string> getInput() {
    ifstream myfile ("Day14/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}


int Part1() {
    vector<string> strs = getInput();
    vector<vector<char>> map;
    for(int y=0; y<1000; y++) {
        vector<char> row;
        for(int x=0; x<1000; x++) {
            row.push_back('.');
        }
        map.push_back(row);
    }
    for(int i=0; i<strs.size(); i++) {
        if (strcmp("",strs[i].c_str()) == 0) { continue; }
        vector<string> pairs = absl::StrSplit(strs[i],"->");
        for(int j=0; j<pairs.size() - 1; j++) {
            vector<string> p1 = absl::StrSplit(pairs[j], ',');
            vector<string> p2 = absl::StrSplit(pairs[j+1], ',');
            int minX = atoi(p1[0].c_str());
            int minY = atoi(p1[1].c_str());
            int maxX = atoi(p2[0].c_str());
            int maxY = atoi(p2[1].c_str());
            if(minX>maxX) {
                int temp = minX;
                minX = maxX;
                maxX = temp;
            }
            if(minY>maxY) {
                int temp = minY;
                minY = maxY;
                maxY = temp;
            }
            for (int x=minX; x<=maxX; x++) {
                for (int y=minY; y<=maxY; y++) {
                    map[y][x] = '#';
                }
            }
        }
    }
    bool done = false;
    while (!done) {
        int sandX = 500;
        int sandY = 0;
        bool canMove = true;
        while (canMove && sandY<200) {
            if (map[sandY+1][sandX] == '.') {
                sandY++;
            } else if(map[sandY+1][sandX-1] == '.') {
                sandY++;
                sandX--;
            } else if (map[sandY+1][sandX+1] == '.') {
                sandY++;
                sandX++;
            } else {
                canMove = false;
            }
        }
        if (sandY>=200) {
            done = true;
        } else {
            map[sandY][sandX] = 'o';
        }
    }
    int sand = 0;
    for(int y=0; y<1000; y++) {
        for(int x=0; x<1000; x++) {
            if (map[y][x] == 'o') {
                sand++;
            }
        }
    }
    return sand;
}

int Part2() {
        vector<string> strs = getInput();
    vector<vector<char>> map;
    for(int y=0; y<1000; y++) {
        vector<char> row;
        for(int x=0; x<1000; x++) {
            row.push_back('.');
        }
        map.push_back(row);
    }
    int biggestY = 0;
    for(int i=0; i<strs.size(); i++) {
        if (strcmp("",strs[i].c_str()) == 0) { continue; }
        vector<string> pairs = absl::StrSplit(strs[i],"->");
        for(int j=0; j<pairs.size() - 1; j++) {
            vector<string> p1 = absl::StrSplit(pairs[j], ',');
            vector<string> p2 = absl::StrSplit(pairs[j+1], ',');
            int minX = atoi(p1[0].c_str());
            int minY = atoi(p1[1].c_str());
            int maxX = atoi(p2[0].c_str());
            int maxY = atoi(p2[1].c_str());
            if(minX>maxX) {
                int temp = minX;
                minX = maxX;
                maxX = temp;
            }
            if(minY>maxY) {
                int temp = minY;
                minY = maxY;
                maxY = temp;
            }
            biggestY = maxY>biggestY?maxY:biggestY;
            for (int x=minX; x<=maxX; x++) {
                for (int y=minY; y<=maxY; y++) {
                    map[y][x] = '#';
                }
            }
        }
    }
    for(int x=0; x<1000; x++) {
        map[biggestY+2][x] = '#';
    }
    bool done = false;
    while (!done) {
        int sandX = 500;
        int sandY = 0;
        bool canMove = true;
        while (canMove && sandY<200) {
            if (map[sandY+1][sandX] == '.') {
                sandY++;
            } else if(map[sandY+1][sandX-1] == '.') {
                sandY++;
                sandX--;
            } else if (map[sandY+1][sandX+1] == '.') {
                sandY++;
                sandX++;
            } else {
                canMove = false;
            }
        }
        map[sandY][sandX] = 'o';
        if(sandX==500 && sandY==0) {
            done = true;
        }
    }
    int sand = 0;
    for(int y=0; y<1000; y++) {
        for(int x=0; x<1000; x++) {
            if (map[y][x] == 'o') {
                sand++;
            }
        }
    }
    return sand;
}
// Driver Code
int main()
{
    std::cout << "Part 1 " << Part1() << "\n";
    std::cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
