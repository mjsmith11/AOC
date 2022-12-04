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
    ifstream myfile ("Day02/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
} 
int getScore1(string me, string opp) {
    int myPoints;
    int resultPoints;
    if (strcmp(me.c_str(), "X") == 0) {
        myPoints = 1;
        if (strcmp(opp.c_str(), "A") == 0) {
            resultPoints = 3;
        } else if (strcmp(opp.c_str(), "B") == 0) {
            resultPoints = 0;
        } else {
            resultPoints = 6;
        }
    } else if (strcmp(me.c_str(), "Y") == 0) {
        myPoints = 2;
        if (strcmp(opp.c_str(), "A") == 0) {
            resultPoints = 6;
        } else if (strcmp(opp.c_str(), "B") == 0) {
            resultPoints = 3;
        } else {
            resultPoints = 0;
        }
    } else {
        myPoints = 3;
        if (strcmp(opp.c_str(), "A") == 0) {
            resultPoints = 0;
        } else if (strcmp(opp.c_str(), "B") == 0) {
            resultPoints = 6;
        } else {
            resultPoints = 3;
        }
    }
    return myPoints + resultPoints;
}

int getScore2(string me, string opp) {
    int myPoints;
    int resultPoints;
    if (strcmp(me.c_str(), "X") == 0) { // lose
        resultPoints = 0;
        if (strcmp(opp.c_str(), "A") == 0) { // they played rock
            myPoints = 3; // scissors
        } else if (strcmp(opp.c_str(), "B") == 0) { // they played paper
            myPoints = 1; // rock
        } else { // they played scissors
            myPoints = 2; // paper
        }
    } else if (strcmp(me.c_str(), "Y") == 0) {
        resultPoints = 3;
        if (strcmp(opp.c_str(), "A") == 0) {
            myPoints = 1;
        } else if (strcmp(opp.c_str(), "B") == 0) {
            myPoints = 2;
        } else {
            myPoints = 3;
        }
    } else {
        resultPoints = 6;
        if (strcmp(opp.c_str(), "A") == 0) {
            myPoints = 2;
        } else if (strcmp(opp.c_str(), "B") == 0) {
            myPoints = 3;
        } else {
            myPoints = 1;
        }
    }
    return myPoints + resultPoints;
}
// Driver Code
int main()
{
    int score1 = 0;
    int score2 = 0;
    for(string s : getInput()) {
        if (strcmp(s.c_str(), "") == 0) { continue; }
        std::vector<std::string> v = absl::StrSplit(s, ' ');
        score1 += getScore1(v[1], v[0]);
        score2 += getScore2(v[1], v[0]);
    }
    cout << "Part 1: " << score1 << "\n";
    cout << "Part 2: " << score2 << "\n";
    
    return 0;
}
