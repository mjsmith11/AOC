// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <stdlib.h> 

#include "absl/strings/str_split.h"

using namespace std;

vector<string> getInput() {
    ifstream myfile ("Day04/input.txt");
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
    int count = 0;
    for(string s : getInput()) {
        if (strcmp(s.c_str(), "") == 0) { continue; }
        vector<string> ranges = absl::StrSplit(s, ',');
        vector<string> firstNums = absl::StrSplit(ranges[0], '-');
        vector<string> secondNums = absl::StrSplit(ranges[1], '-');
        int s1 = atoi(firstNums[0].c_str());
        int e1 = atoi(firstNums[1].c_str());
        int s2 = atoi(secondNums[0].c_str());
        int e2 = atoi(secondNums[1].c_str());
        if (s1>=s2 && e1<=e2) {
            count++;
            continue;
        }
        if (s2>=s1 && e2<=e1) {
            count++;
            continue;
        }
    }
    return count;
}

int Part2() {
    int count = 0;
    for(string s : getInput()) {
        if (strcmp(s.c_str(), "") == 0) { continue; }
        vector<string> ranges = absl::StrSplit(s, ',');
        vector<string> firstNums = absl::StrSplit(ranges[0], '-');
        vector<string> secondNums = absl::StrSplit(ranges[1], '-');
        int s1 = atoi(firstNums[0].c_str());
        int e1 = atoi(firstNums[1].c_str());
        int s2 = atoi(secondNums[0].c_str());
        int e2 = atoi(secondNums[1].c_str());
        if (s1>=s2 && s1<=e2) {
            count++;
            continue;
        }
        if (s2>=s1 && s2<=e1) {
            count++;
            continue;
        }
    }
    return count;
}
// Driver Code
int main()
{

    cout << "Part 1: " << Part1() << "\n";
    cout << "Part 2: " << Part2() << "\n";
    
    return 0;
}
