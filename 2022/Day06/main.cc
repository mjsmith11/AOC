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
    ifstream myfile ("Day06/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}

int solve(int k) {
    map<char, int> m;
    string s = getInput()[0];
    int i=0;
    int minAnswer = 0;
    while(i<s.length()) {
        if (auto search = m.find(s[i]); search==m.end()) {
            // char not in seen before
            // found a window
            if (i>=minAnswer && i>=k-1) { return i+1; }
        } else {
            // char seen before
            if (i-m[s[i]] < k) {
                // too recent
                minAnswer = (m[s[i]] + k) > minAnswer ? m[s[i]] + k : minAnswer;
            } else {
                //could be the answer
                if (i>=minAnswer && i>=k-1) {return i+1;}
            }
        }
        m[s[i]] = i;
        i++;
    }
    return -1;
}

int Part1() {
    return solve(4);
}

int Part2() {
    return solve(14);
}
// Driver Code
int main()
{
    cout << "Part 1 " << Part1() << "\n";
    cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
