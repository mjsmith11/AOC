// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>

using namespace std;

vector<string> getInput() {
    ifstream myfile ("Day03/input.txt");
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
    int score = 0;
    for(string s : getInput()) {
        if (strcmp(s.c_str(), "") == 0) { continue; }
        int length = s.length();
        string front = s.substr(0, length/2);
        string back = s.substr(length/2, length/2);
        for (char& c : front) {
            if (back.find(c) != -1) {
                if (c>=65 && c<=90) {
                    // uppers
                    score += (c-38);
                } else {
                    score += (c-96);
                }
                break;
            }
        }
    }
    return score;
}

int Part2() {
    int score = 0;
    vector<string> input = getInput();
    for (int i=0; i+2 < input.size(); i+=3){
        for (char& c : input[i]) {
            if (input[i+1].find(c) != -1 && input[i+2].find(c) != -1) {
                if (c>=65 && c<=90) {
                    // uppers
                    score += (c-38);
                } else {
                    score += (c-96);
                }
                break;
            }
        }
    }
    return score;
}
// Driver Code
int main()
{

    cout << "Part 1: " << Part1() << "\n";
    cout << "Part 2: " << Part2() << "\n";
    
    return 0;
}
