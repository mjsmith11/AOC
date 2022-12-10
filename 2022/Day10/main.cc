// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>

#include "absl/strings/str_split.h"

using namespace std;

vector<string> getInput() {
    ifstream myfile ("Day10/input.txt");
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
    int x = 1;
    int cycle = 1;
    int sum = 0;
    for(string s : getInput()) {
        if (strcmp(s.c_str(), "") == 0) { continue; }
        vector<string> parts = absl::StrSplit(s, ' ');
        if (cycle>220) { break; }
        if ((cycle - 20) % 40 == 0) {
            sum += (cycle*x);
        }
        if (strcmp(parts[0].c_str(), "addx") == 0) {
            // cycle where it doesn't complete
            cycle++;
            if ((cycle - 20) % 40 == 0) {
                sum += (cycle*x);
            }
            cycle++;
            x += atoi(parts[1].c_str());
        } else {
            //noop
            cycle++;
        }
    }
    return sum;
}

void Part2() {
    int x = 1;
    int cycle = 1;
    int sum = 0;
    for(string s : getInput()) {
        if (strcmp(s.c_str(), "") == 0) { continue; }
        vector<string> parts = absl::StrSplit(s, ' ');
        if (abs(cycle%40 - 1 - x) <= 1) {
            cout << "#";
        } else {
            cout << ".";
        }
        if (cycle%40 == 0) {
            cout << "\n";
        }
        if (strcmp(parts[0].c_str(), "addx") == 0) {
            // cycle where it doesn't complete
            cycle++;
            if (abs(cycle%40 - 1 - x) <= 1) {
                cout << "#";
            } else {
                cout << ".";
            }
            if (cycle%40 == 0) {
                cout << "\n";
            }
            cycle++;
            x += atoi(parts[1].c_str());
        } else {
            //noop
            cycle++;
        }
    }
}
// Driver Code
int main()
{
    std::cout << "Part 1 " << Part1() << "\n";
    cout << "Part 2\n";
    Part2();
    
    return 0;
}
