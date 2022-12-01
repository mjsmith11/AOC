// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <stdlib.h> 
#include <queue>

using namespace std;

vector<string> getInput() {
    ifstream myfile ("input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
} 
// Driver Code
int main()
{
    int total = 0;
    priority_queue<int> maxHeap;
    for(string s : getInput()) {
        if(s.compare("") == 0) {
            // blank
            maxHeap.push(total);
            total = 0;
        } else {
            total += atoi(s.c_str());
        }
    }
    cout << "Part 1 " << maxHeap.top() << "\n";

    int top3 = maxHeap.top();
    maxHeap.pop();
    top3 += maxHeap.top();
    maxHeap.pop();
    top3 += maxHeap.top();
    cout << "Part 2 " << top3 << "\n";


    return 0;
}
