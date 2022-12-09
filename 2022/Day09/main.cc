// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <unordered_set>

#include "absl/strings/str_split.h"

using namespace std;

vector<string> getInput() {
    ifstream myfile ("Day09/input.txt");
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
    pair<int,int> head;
    pair<int,int> tail;
    head.first = 0;
    head.second = 0;
    tail.first = 0;
    tail.second = 0;
    unordered_set<int> visited;
    visited.insert(0);
    for(string s : getInput()) {
         if (strcmp(s.c_str(), "") == 0) { continue; }
        vector<string> parts = absl::StrSplit(s, ' ');
        char dir = parts[0][0];
        int amt = atoi(parts[1].c_str());
        for(int i=0; i<amt; i++) {
            // move head
            if (dir=='U') {
                head.second--;
            } else if (dir=='D') {
                head.second++;
            } else if (dir=='L') {
                head.first--;
            } else {
                head.first++;
            }

            // is tail close enough
            if (abs(head.first - tail.first) <= 1 && abs(head.second - tail.second) <= 1) {
                continue;
            }

            // move tail if they are in the same column
            if (head.second == tail.second) {
                if(head.first > tail.first) {
                    tail.first++;
                } else {
                    tail.first--;
                }
            } else if (head.first == tail.first) { // move tail if they are in the same row
                if (head.second > tail.second) {
                    tail.second++;
                } else {
                    tail.second--;
                }
            } else { // need to move diagonally
                if(head.first > tail.first) {
                    tail.first++;
                } else {
                    tail.first--;
                }
                if (head.second > tail.second) {
                    tail.second++;
                } else {
                    tail.second--;
                }
            }
            visited.insert(tail.first*1000+tail.second);
        }
    }
   

    return visited.size();
}

int Part2() {
    vector<pair<int,int>> knots;
    for(int i=0; i<10; i++) {
        pair<int,int> k;
        k.first = 0;
        k.second = 0;
        knots.push_back(k);
    }
    unordered_set<int> visited;
    visited.insert(0);
    for(string s : getInput()) {
         if (strcmp(s.c_str(), "") == 0) { continue; }
        vector<string> parts = absl::StrSplit(s, ' ');
        char dir = parts[0][0];
        int amt = atoi(parts[1].c_str());
        for(int i=0; i<amt; i++) {
            // move head
            if (dir=='U') {
                knots[0].second--;
            } else if (dir=='D') {
                knots[0].second++;
            } else if (dir=='L') {
                knots[0].first--;
            } else {
                knots[0].first++;
            }

            for (int i=1; i<10; i++) {
                pair<int,int>& head = knots[i-1];
                pair<int, int>& tail = knots[i];
                // is tail close enough
                if (abs(head.first - tail.first) <= 1 && abs(head.second - tail.second) <= 1) {
                    continue;
                }

                // move tail if they are in the same column
                if (head.second == tail.second) {
                    if(head.first > tail.first) {
                        tail.first++;
                    } else {
                        tail.first--;
                    }
                } else if (head.first == tail.first) { // move tail if they are in the same row
                    if (head.second > tail.second) {
                        tail.second++;
                    } else {
                        tail.second--;
                    }
                } else { // need to move diagonally
                    if(head.first > tail.first) {
                        tail.first++;
                    } else {
                        tail.first--;
                    }
                    if (head.second > tail.second) {
                        tail.second++;
                    } else {
                        tail.second--;
                    }
                }
            }
            visited.insert(knots[9].first*10000+knots[9].second);
        }
    }
    return visited.size();
}
// Driver Code
int main()
{
    std::cout << "Part 1 " << Part1() << "\n";
    std::cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
