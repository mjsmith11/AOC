// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <math.h>
#include <cstring>

using namespace std;

vector<string> getInput() {
    ifstream myfile ("Day25/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}

int getVal(char c) {
    switch(c) {
        case '=': return -2;
        case '-': return -1;
        default: return c-'0';
    }
}

char getChar(int n) {
    switch(n) {
        case -2: return '=';
        case -1: return '-';
        default: return '0'+n;
    }
}

string add(string s1, string s2) {
    int min = s1.length() < s2.length()? s1.length() : s2.length();
    int c = 0;
    int s = 0;
    int place = 0;
    string res = "";
    // characters where both s1 and s2 have a value
    while (place<min) {
        s = getVal(s1[s1.length()-1-place]) + getVal(s2[s2.length() -1-place]) + c;
        c = 0;
        while (s>2) {
            c++;
            s-=5;
        }
        while (s<-2) {
            c--;
            s+=5;
        }
        res = getChar(s) + res;
        place++;
    }
    // extra places if s1 is longer
    while(place<s1.length()) {
        s = getVal(s1[s1.length()-1-place]) + c;
        c = 0;
        while (s>2) {
            c++;
            s-=5;
        }
        while (s<-2) {
            c--;
            s+=5;
        }
        res = getChar(s) + res;
        place++;
    }
    // extra places if s2 is longer
    while(place<s2.length()) {
        s = getVal(s2[s2.length()-1-place]) + c;
        c = 0;
        while (s>2) {
            c++;
            s-=5;
        }
        while (s<-2) {
            c--;
            s+=5;
        }
        res = getChar(s) + res;
        place++;
    }
    // if there's a carry out from the last place
    while (c!=0) {
        s = c;
        c = 0;
        while (s>2) {
            c++;
            s-=5;
        }
        while (s<-2) {
            c--;
            s+=5;
        }
        res = getChar(s) + res;
    }
    return res;
}

string Part1() {
    vector<string> inp = getInput();
    string sum = "0";
    for(string s : inp) {
        if (strcmp("",s.c_str()) == 0) { continue; }
        sum = add(s, sum);
    }

    return sum;
}



// Driver Code
int main()
{
    std::cout << "Part 1: " << Part1() << "\n";
    
    return 0;
}
