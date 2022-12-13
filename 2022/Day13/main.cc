// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <map>
#include <queue>

#include "absl/strings/str_split.h"

using namespace std;

vector<string> getInput() {
    ifstream myfile ("Day13/input.txt");
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
    private:
        bool isSingle;
        int num;
        vector<Node> elements;

    public:
        Node(int n) {
            isSingle = true;
            num = n;
        }
        Node(int n, bool asList) {
            isSingle = false;
            elements.push_back(Node(n));
        }
        Node(string s) {
            if (s[0] == '[') {
                isSingle = false;
                string noSquareBrackets = s.substr(1,s.length() - 2);
                int start = 0;
                int current = 0;
                int levels = 0;
                while (current < noSquareBrackets.length()) {
                    if (noSquareBrackets[current] == ',' && levels == 0) {
                        elements.push_back(Node(noSquareBrackets.substr(start, current-start)));
                        start = current+1;
                    } else {
                        if (noSquareBrackets[current] == '[') {
                            levels++;
                        }
                        if (noSquareBrackets[current] == ']') {
                            levels--;
                        }
                    }
                    current++;
                }
                if (start<noSquareBrackets.length()) {
                    elements.push_back(Node(noSquareBrackets.substr(start, current-start)));
                }

            } else {
                isSingle = true;
                num = atoi(s.c_str());
            }
        }

        void output() {
            output(0);
        }
        void output(int indent) {
            for (Node n : elements) {
                if (n.isSingle) {
                    for(int i=0; i<indent; i++) {
                        cout << " ";
                    }
                    cout << n.num << "\n";
                } else {
                    n.output(indent+2);
                }
            }
        }

        // negative if this is less
        // 0 if equal
        // positive if this is more
        int compareTo(const Node* other) const {
            if (this->isSingle && other->isSingle) {
                return this->num - other->num;
            } else if (!this->isSingle && !other->isSingle) {
                int min = this->elements.size() < other->elements.size()? this->elements.size() : other->elements.size();
                for (int i=0; i<min; i++) {
                    int comp = this->elements[i].compareTo(&other->elements[i]);
                    if (comp != 0) { return comp; }
                }
                if (this->elements.size() == other->elements.size()) {
                    return 0;
                }
                if (this->elements.size() == min) {
                    return -1;
                }
                return 1;
            } else {
                if (this->isSingle) {
                    return Node(this->num, true).compareTo(other);
                } else {
                    Node* newOther = new Node(other->num, true);
                    return this->compareTo(newOther);
                }
            }

        }
};

struct CustomCompare
{
    bool operator()(const Node& lhs, const Node& rhs)
    {
        return lhs.compareTo(&rhs) >= 0;
    }
};

int Part1() {
    vector<string> strs = getInput();
    int total = 0;
    for(int i=0; i<strs.size(); i+=3) {
        Node n1 = Node(strs[i]);
        Node n2 = Node(strs[i+1]);
        if (n1.compareTo(&n2) < 0) {
            total += i/3+1;
        }
    }
    return total;
}

int16_t Part2() {
    priority_queue<Node,vector<Node>, CustomCompare > pq;
    Node d1 = Node("[[2]]");
    Node d2 = Node("[[6]]");
    pq.push(d1);
    pq.push(d2);
    vector<string> strs = getInput();
    for(int i=0; i<strs.size(); i+=3) {
        Node n1 = Node(strs[i]);
        Node n2 = Node(strs[i+1]);
        pq.push(n1);
        pq.push(n2);
    }
    int d1i;
    int d2i;
    int i = 1;
    while(!pq.empty()) {
        Node n = pq.top();
        if(n.compareTo(&d1) == 0) {
            d1i = i;
        }
        if(n.compareTo(&d2) == 0) {
            d2i = i;
        }
        i++;
        pq.pop();
    }
    return d1i*d2i;
}
// Driver Code
int main()
{
    std::cout << "Part 1 " << Part1() << "\n";
    std::cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
