// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <unordered_set>
#include <algorithm>
#include <queue>
#include <unordered_set>

#include "absl/strings/str_split.h"

using namespace std;

class OrderedTriple {
    public:
        int x;
        int y;
        int z;

        OrderedTriple(int x1, int y1, int z1) {
            x=x1;
            y=y1;
            z=z1;
        }
        void print() {
            cout << "("<<x<<","<<y<<","<<z<<")\n";
        }
        string getString() {
            return "("+to_string(x)+","+to_string(y)+","+to_string(z)+")";
        }
};

vector<string> getInput() {
    ifstream myfile ("Day18/input.txt");
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
    vector<OrderedTriple> cubes;
    for (string s : getInput()) {
        if (strcmp("",s.c_str()) == 0) { continue; }
        vector<string> coords = absl::StrSplit(s, ',');
        OrderedTriple t = OrderedTriple(atoi(coords[0].c_str()),atoi(coords[1].c_str()),atoi(coords[2].c_str()));
        cubes.push_back(t);
    }
    int surface = 0;
    int last = cubes.size() - 1;
    // sort by xy look at zs
    sort(cubes.begin(), cubes.end(), [](const OrderedTriple& lhs, const OrderedTriple& rhs) {
      if (lhs.x != rhs.x) {
        return lhs.x < rhs.x;
      } else if (lhs.y != rhs.y) {
        return lhs.y < rhs.y;
      }
      return lhs.z < rhs.z;
   });

   // process first
    // nothing before
    surface++;
    // check after
    if(cubes[0].x != cubes[1].x || cubes[0].y != cubes[1].y || cubes[1].z != cubes[0].z + 1) {
        surface++;
    }
    for(int i=1; i<cubes.size()-1; i++) {
        // look before
        if (cubes[i-1].x != cubes[i].x || cubes[i-1].y != cubes[i].y || cubes[i-1].z != cubes[i].z-1 ) {
            surface++;
        }
        // look after
        if (cubes[i+1].x != cubes[i].x || cubes[i+1].y != cubes[i].y || cubes[i+1].z != cubes[i].z+1 ) {
            surface++;
        }
    }
    // process last
    // check before
    // look before
    if (cubes[last-1].x != cubes[last].x || cubes[last-1].y != cubes[last].y || cubes[last-1].z != cubes[last].z-1 ) {
        surface++;
    }
    // nothing after
    surface++;

    // sort by yz look at zxs
    sort(cubes.begin(), cubes.end(), [](const OrderedTriple& lhs, const OrderedTriple& rhs) {
      if (lhs.y != rhs.y) {
        return lhs.y < rhs.y;
      } else if (lhs.z != rhs.z) {
        return lhs.z < rhs.z;
      }
      return lhs.x < rhs.x;
   });

   // process first
    // nothing before
    surface++;
    // check after
    if(cubes[0].y != cubes[1].y || cubes[0].z != cubes[1].z || cubes[1].x != cubes[0].x + 1) {
        surface++;
    }
    for(int i=1; i<cubes.size()-1; i++) {
        // look before
        if (cubes[i-1].y != cubes[i].y || cubes[i-1].z != cubes[i].z || cubes[i-1].x != cubes[i].x-1 ) {
            surface++;
        }
        // look after
        if (cubes[i+1].y != cubes[i].y || cubes[i+1].z != cubes[i].z || cubes[i+1].x != cubes[i].x+1 ) {
            surface++;
        }
    }
    // process last
    // check before
    // look before
    if (cubes[last-1].y != cubes[last].y || cubes[last-1].z != cubes[last].z || cubes[last-1].x != cubes[last].x-1) {
        surface++;
    }
    // nothing after
    surface++;

    // sort by xz look at ys
    sort(cubes.begin(), cubes.end(), [](const OrderedTriple& lhs, const OrderedTriple& rhs) {
      if (lhs.x != rhs.x) {
        return lhs.x < rhs.x;
      } else if (lhs.z != rhs.z) {
        return lhs.z < rhs.z;
      }
      return lhs.y < rhs.y;
   });

   // process first
    // nothing before
    surface++;
    // check after
    if(cubes[0].x != cubes[1].x || cubes[0].z != cubes[1].z || cubes[1].y != cubes[0].y + 1) {
        surface++;
    }
    for(int i=1; i<cubes.size()-1; i++) {
        // look before
        if (cubes[i-1].x != cubes[i].x || cubes[i-1].z != cubes[i].z || cubes[i-1].y != cubes[i].y-1 ) {
            surface++;
        }
        // look after
        if (cubes[i+1].x != cubes[i].x || cubes[i+1].z != cubes[i].z || cubes[i+1].y != cubes[i].y+1 ) {
            surface++;
        }
    }
    // process last
    // check before
    // look before
    if (cubes[last-1].x != cubes[last].x || cubes[last-1].z != cubes[last].z || cubes[last-1].y != cubes[last].y-1 ) {
        surface++;
    }
    // nothing after
    surface++;

    

    return surface;
}

int Part2() {
    vector<vector<vector<bool>>> space;
    for(int x=0; x<25; x++) {
        vector<vector<bool>> xLoop;
        for (int y=0; y<25; y++) {
            vector<bool> yloop;
            for (int z=0; z<25; z++) {
                yloop.push_back(false);
            }
            xLoop.push_back(yloop);
        }
        space.push_back(xLoop);
    }
    for (string s : getInput()) {
        if (strcmp("",s.c_str()) == 0) { continue; }
        vector<string> coords = absl::StrSplit(s, ',');
        int x = atoi(coords[0].c_str())+1; // move it 1 so 0's aren't on the edge
        int y = atoi(coords[1].c_str())+1;
        int z = atoi(coords[2].c_str())+1; 
        space[x][y][z] = true;
    }
    queue<OrderedTriple> q;
    q.push(OrderedTriple(0,0,0));
    unordered_set<string> visited;

    int surface = 0;
    while(q.size() > 0) {
        OrderedTriple c = q.front();
        q.pop();

        
        if (auto f = visited.find(c.getString()); f!=visited.end()) {
            continue;
        }
        visited.insert(c.getString());

        if (c.x < 24) {
            if (space[c.x+1][c.y][c.z]) {
                surface++;
            } else {
                OrderedTriple ot = OrderedTriple(c.x+1,c.y,c.z);
                if (auto f = visited.find(ot.getString()); f==visited.end()) {
                    q.push(ot);
                }
            }
        }

        if (c.y < 24) {
            if (space[c.x][c.y+1][c.z]) {
                surface++;
            } else {
                OrderedTriple ot = OrderedTriple(c.x,c.y+1,c.z);
                if (auto f = visited.find(ot.getString()); f==visited.end()) {
                    q.push(ot);
                }
            }
        }

        if (c.z < 24) {
            if (space[c.x][c.y][c.z+1]) {
                surface++;
            } else {
                OrderedTriple ot = OrderedTriple(c.x,c.y,c.z+1);
                if (auto f = visited.find(ot.getString()); f==visited.end()) {
                    q.push(ot);
                }
            }
        }

        if (c.x >0) {
            if (space[c.x-1][c.y][c.z]) {
                surface++;
            } else {
                OrderedTriple ot = OrderedTriple(c.x-1,c.y,c.z);
                if (auto f = visited.find(ot.getString()); f==visited.end()) {
                    q.push(ot);
                }
            }
        }
        if (c.y >0) {
            if (space[c.x][c.y-1][c.z]) {
                surface++;
            } else {
                OrderedTriple ot = OrderedTriple(c.x,c.y-1,c.z);
                if (auto f = visited.find(ot.getString()); f==visited.end()) {
                    q.push(ot);
                }
            }
        }
        if (c.z >0) {
            if (space[c.x][c.y][c.z-1]) {
                surface++;
            } else {
                OrderedTriple ot = OrderedTriple(c.x,c.y,c.z-1);
                if (auto f = visited.find(ot.getString()); f==visited.end()) {
                    q.push(ot);
                }
            }
        }
    }
    return surface;
}

// Driver Code
int main()
{
    std::cout << "Part 1 " << Part1() << "\n";
    std::cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
