// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <list>

using namespace std;

vector<string> getInput() {
    ifstream myfile ("Day20/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}

class Node {
    public:
        long value;
        bool mixed;
        int mixOrder;
    
        Node(long value) {
            this->value = value;
            this->mixed = false;
            this->mixOrder = 0;
        }
};


int Part1() {
    vector<string> inp = getInput();
    list<Node> l;
    for(string s : getInput()) {
        if (strcmp("",s.c_str()) == 0) { continue; }
        l.push_back(Node(atoi(s.c_str())));
    }
    int mixed = 0;
    while (mixed<l.size()) {
        list<Node>::iterator it = l.begin();
        while (it->mixed) { it++; }
        it->mixed = true;
        mixed++;
        int amt = it->value;
        // this is probably actualy a mod operation
        while (amt<0) {
            int mult = -1*amt/(l.size() -1) + 1;
            amt = amt + (l.size()-1)*mult;
        }
        while (amt>(l.size() -1)) {
            amt %= (l.size() - 1);
        }
        list<Node>::iterator newPos = it;
        for (int i=0; i<=amt; i++) {
            newPos++;
            if (newPos==l.end()) {
                newPos = l.begin();
            }
        }
        
        l.insert(newPos, *it);
        l.erase(it);
    }
    list<Node>::iterator zero = l.begin();
    while(true) {
        if (zero->value == 0) {
            break;
        }
        zero++;
    }
    int sum = 0;
    for (int i=1; i<=3000; i++) {
        zero++;
        if (zero==l.end()) {
            zero = l.begin();
        }
        if (i%1000 == 0) {
            sum += zero->value;
        }
    }
    return sum;
}

long Part2() {
    vector<string> inp = getInput();
    list<Node> l;
    for(string s : getInput()) {
        if (strcmp("",s.c_str()) == 0) { continue; }
        l.push_back(Node(atol(s.c_str())*811589153L));
    }

    cout << "Mix #" << 1 << "\n";
    for (Node& n : l) {
        n.mixed = false;
    }
    int mixed = 0;
    while (mixed<l.size()) {
        list<Node>::iterator it = l.begin();
        while (it->mixed) { it++; }
        it->mixed = true;
        it->mixOrder = mixed;
        mixed++;
        long amt = it->value;
        // this is probably actualy a mod operation
        while (amt<0) {
            long mult = -1L*amt/(l.size() -1) + 1L;
            amt = amt + (l.size()-1)*mult;
        }
        while (amt>(l.size() -1)) {
            amt %= (l.size() - 1);
        }
        list<Node>::iterator newPos = it;
        for (int i=0; i<=amt; i++) {
            newPos++;
            if (newPos==l.end()) {
                newPos = l.begin();
            }
        }
        
        l.insert(newPos, *it);
        l.erase(it);
    }

    for(int i=1; i<10; i++) {
        cout << "Mix #" << i << "\n";
        for (Node& n : l) {
            n.mixed = false;
        }
        int mixed = 0;
        while (mixed<l.size()) {
            list<Node>::iterator it = l.begin();
            while (it->mixOrder != mixed) { it++; }
            it->mixed = true;
            mixed++;
            long amt = it->value;
            // this is probably actualy a mod operation
            while (amt<0) {
                long mult = -1L*amt/(l.size() -1) + 1L;
                amt = amt + (l.size()-1)*mult;
            }
            while (amt>(l.size() -1)) {
                amt %= (l.size() - 1);
            }
            list<Node>::iterator newPos = it;
            for (int i=0; i<=amt; i++) {
                newPos++;
                if (newPos==l.end()) {
                    newPos = l.begin();
                }
            }
            
            l.insert(newPos, *it);
            l.erase(it);
        }

    }


    list<Node>::iterator zero = l.begin();
    while(true) {
        if (zero->value == 0) {
            break;
        }
        zero++;
    }
    long sum = 0;
    for (int i=1; i<=3000; i++) {
        zero++;
        if (zero==l.end()) {
            zero = l.begin();
        }
        if (i%1000 == 0) {
            sum += zero->value;
        }
    }
    return sum;
}

// Driver Code
int main()
{
    int p1 = Part1();
    std::cout << "Part 1 " << p1 << "\n";
    std::cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
