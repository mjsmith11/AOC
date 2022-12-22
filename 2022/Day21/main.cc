// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <map>

#include "absl/strings/str_split.h"

using namespace std;
bool usedHuman;
vector<string> getInput() {
    ifstream myfile ("Day21/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}



long Part1() {
    string find = "root";
    vector<string> inp = getInput();
    map<string,string> opMonkeys;
    map<string,long> valueMonkeys;

    for(string s : getInput()) {
        if (strcmp("",s.c_str()) == 0) { continue; }
        vector<string> parts = absl::StrSplit(s,": ");
        if (parts[1].find('+') != -1) {
            opMonkeys[parts[0]] = parts[1];
        }
        else if (parts[1].find('-') != -1) {
            opMonkeys[parts[0]] = parts[1];
        }
        else if (parts[1].find('*') != -1) {
            opMonkeys[parts[0]] = parts[1];
        }
        else if (parts[1].find('/') != -1) {
            opMonkeys[parts[0]] = parts[1];
        }
        else {
            valueMonkeys[parts[0]] = atol(parts[1].c_str());
        }
    }
    auto a = valueMonkeys.find(find);
    while(a==valueMonkeys.end()) {
        vector<string> deleteKeys;
        for (map<string,string>::iterator it = opMonkeys.begin(); it!=opMonkeys.end(); it++) {
            vector<string> pieces = absl::StrSplit(it->second,' ');
            if (auto l = valueMonkeys.find(pieces[0]); l!=valueMonkeys.end()) {
                if (auto r = valueMonkeys.find(pieces[2]); r!=valueMonkeys.end()) {
                    long result;
                    if (pieces[1][0] == '+') {
                        result = l->second + r->second; 
                    }
                    if (pieces[1][0] == '-') {
                        result = l->second - r->second; 
                    }
                    if (pieces[1][0] == '*') {
                        result = l->second * r->second; 
                    }
                    if (pieces[1][0] == '/') {
                        result = l->second / r->second; 
                    }
                    valueMonkeys[it->first] = result;
                    deleteKeys.push_back(it->first);
                }
            }
        }
        for(string s : deleteKeys) {
            opMonkeys.erase(s);
        }

        a = valueMonkeys.find(find);
    }
    return valueMonkeys[find];
}



long valueFind(string find, map<string,string> opMonkeys, map<string,long> valueMonkeys, int layers) {
    if (strcmp(find.c_str(),"humn")==0) {
        usedHuman = true;
    }
    if (auto f = valueMonkeys.find(find); f!=valueMonkeys.end()) {
        return f->second;
    }
    vector<string> pieces = absl::StrSplit(opMonkeys[find],' ');
    if (pieces[1][0] == '+') {
        return valueFind(pieces[0], opMonkeys, valueMonkeys, layers+1) + valueFind(pieces[2], opMonkeys, valueMonkeys, layers+1);
    }
    if (pieces[1][0] == '-') {
        return valueFind(pieces[0], opMonkeys, valueMonkeys, layers+1) - valueFind(pieces[2], opMonkeys, valueMonkeys, layers+1);
    }
    if (pieces[1][0] == '*') {
        return valueFind(pieces[0], opMonkeys, valueMonkeys, layers+1) * valueFind(pieces[2], opMonkeys, valueMonkeys, layers+1);
    }
    if (pieces[1][0] == '/') {
        return valueFind(pieces[0], opMonkeys, valueMonkeys, layers+1) / valueFind(pieces[2], opMonkeys, valueMonkeys, layers+1);
    }
}
long findHuman(long target, string expression, map<string,string> opMonkeys, map<string,long> valueMonkeys) {
    vector<string> expPieces = absl::StrSplit(expression, ' ');
    usedHuman = false;
    long leftOp = valueFind(expPieces[0], opMonkeys, valueMonkeys, 0);
    bool leftHuman = usedHuman;

    usedHuman = false;
    long rightOp = valueFind(expPieces[2], opMonkeys, valueMonkeys, 0);
    bool rightHuman = usedHuman;

    if (leftHuman) {
        long newTarget = 0;
        if (expPieces[1][0]=='+') {
            newTarget = target-rightOp;
        } else if (expPieces[1][0]=='-') {
            newTarget = target+rightOp;
        } else if (expPieces[1][0]=='*') {
            newTarget = target/rightOp;
        } else if (expPieces[1][0]=='/') {
            newTarget = target*rightOp;
        }
        if (strcmp(expPieces[0].c_str(), "humn")==0) {
            return newTarget;
        }
        return findHuman(newTarget, opMonkeys[expPieces[0]], opMonkeys, valueMonkeys);
    }
    if (rightHuman) {
        long newTarget = 0;
        if (expPieces[1][0]=='+') {
            newTarget = target-leftOp;
        } else if (expPieces[1][0]=='-') {
            newTarget = -1*(target-leftOp);
        } else if (expPieces[1][0]=='*') {
            newTarget = target/leftOp;
        } else if (expPieces[1][0]=='/') {
            cout << "I hope this doesn't happen\n";
        }
        if (strcmp(expPieces[2].c_str(), "humn")==0) {
            return newTarget;
        }
        return findHuman(newTarget, opMonkeys[expPieces[2]], opMonkeys, valueMonkeys);
    }
    cout << "I hope this doesn't happen either\n";
}

long Part2() {
    vector<string> inp = getInput();
    map<string,string> opMonkeys;
    map<string,long> valueMonkeys;

    for(string s : getInput()) {
        if (strcmp("",s.c_str()) == 0) { continue; }
        vector<string> parts = absl::StrSplit(s,": ");
        if (parts[1].find('+') != -1) {
            opMonkeys[parts[0]] = parts[1];
        }
        else if (parts[1].find('-') != -1) {
            opMonkeys[parts[0]] = parts[1];
        }
        else if (parts[1].find('*') != -1) {
            opMonkeys[parts[0]] = parts[1];
        }
        else if (parts[1].find('/') != -1) {
            opMonkeys[parts[0]] = parts[1];
        }
        else {
            valueMonkeys[parts[0]] = atol(parts[1].c_str());
        }
    }
    // a little hard coding here for 1 less thing to calculate
    long target = valueFind("ptvl", opMonkeys, valueMonkeys, 0);
    return findHuman(target, opMonkeys["jsrw"], opMonkeys, valueMonkeys);
}


// Driver Code
int main()
{
    std::cout << "Part 1 " << Part1() << "\n";
    std::cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
