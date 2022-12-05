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
    ifstream myfile ("Day05/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
} 
/*[D]                     [N] [F]    
  [H] [F]             [L] [J] [H]    
  [R] [H]             [F] [V] [G] [H]
  [Z] [Q]         [Z] [W] [L] [J] [B]
  [S] [W] [H]     [B] [H] [D] [C] [M]
  [P] [R] [S] [G] [J] [J] [W] [Z] [V]
  [W] [B] [V] [F] [G] [T] [T] [T] [P]
  [Q] [V] [C] [H] [P] [Q] [Z] [D] [W]
   1   2   3   4   5   6   7   8   9 */
vector<stack<char>> getStacks() {
    vector<stack<char>> stacks;
    stack<char> s;
    stacks.push_back(s); // don't use 0;
    // 1
    s = stack<char>();
    s.push('Q');
    s.push('W');
    s.push('P');
    s.push('S');
    s.push('Z');
    s.push('R');
    s.push('H');
    s.push('D');
    stacks.push_back(s);
    // 2
    s = stack<char>();
    s.push('V');
    s.push('B');
    s.push('R');
    s.push('W');
    s.push('Q');
    s.push('H');
    s.push('F');
    stacks.push_back(s);
    // 3
    s = stack<char>();
    s.push('C');
    s.push('V');
    s.push('S');
    s.push('H');
    stacks.push_back(s);
    // 4
    s = stack<char>();
    s.push('H');
    s.push('F');
    s.push('G');
    stacks.push_back(s);
    // 5
    s = stack<char>();
    s.push('P');
    s.push('G');
    s.push('J');
    s.push('B');
    s.push('Z');
    stacks.push_back(s);
    // 6
    s = stack<char>();
    s.push('Q');
    s.push('T');
    s.push('J');
    s.push('H');
    s.push('W');
    s.push('F');
    s.push('L');
    stacks.push_back(s);
    // 7
    s = stack<char>();
    s.push('Z');
    s.push('T');
    s.push('W');
    s.push('D');
    s.push('L');
    s.push('V');
    s.push('J');
    s.push('N');
    stacks.push_back(s);
    // 8
    s = stack<char>();
    s.push('D');
    s.push('T');
    s.push('Z');
    s.push('C');
    s.push('J');
    s.push('G');
    s.push('H');
    s.push('F');
    stacks.push_back(s);
    // 9
    s = stack<char>();
    s.push('W');
    s.push('P');
    s.push('V');
    s.push('M');
    s.push('B');
    s.push('H');
    stacks.push_back(s);
    
    return stacks;
}

void Part1() {
    vector<stack<char>> myStacks = getStacks();
    for(string s : getInput()) {
        if (strcmp(s.c_str(), "") == 0) { continue; }
        vector<string> words = absl::StrSplit(s, ' ');
        int numToMove = atoi(words[1].c_str());
        int from = atoi(words[3].c_str());
        int to = atoi(words[5].c_str());
        for (int i=0; i<numToMove; i++) {
            myStacks[to].push(myStacks[from].top());
            myStacks[from].pop();
        }
    }
    cout << "Part 1: ";
    for(int i=1; i<myStacks.size(); i++) {
        cout << myStacks[i].top();
    }
    cout << "\n";
}

int Part2() {
    vector<stack<char>> myStacks = getStacks();
    for(string s : getInput()) {
        if (strcmp(s.c_str(), "") == 0) { continue; }
        vector<string> words = absl::StrSplit(s, ' ');
        int numToMove = atoi(words[1].c_str());
        int from = atoi(words[3].c_str());
        int to = atoi(words[5].c_str());
        stack<char> tmp;
        for (int i=0; i<numToMove; i++) {
            tmp.push(myStacks[from].top());
            myStacks[from].pop();
        }
        for (int i=0; i<numToMove; i++) {
            myStacks[to].push(tmp.top());
            tmp.pop();
        }
    }
    cout << "Part 2: ";
    for(int i=1; i<myStacks.size(); i++) {
        cout << myStacks[i].top();
    }
    cout << "\n";
}
// Driver Code
int main()
{
    Part1();
    Part2();
    
    return 0;
}
