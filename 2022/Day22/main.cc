// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>

using namespace std;

vector<string> getBoardInput() {
    ifstream myfile ("Day22/input1.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}

string getInstInput() {
    ifstream myfile ("Day22/input2.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp[0];
}

vector<vector<vector<char>>> parseForPart2() {
    ifstream myfile ("Day22/input3.txt");
    // each face
    vector<vector<vector<char>>> cube;
    for(int i=0; i<6; i++) {
        vector<vector<char>> face;
        // each row of face
        for(int j=0; j<50; j++) {
            vector<char> row;
            string s;
            getline(myfile,s);
            for(char c : s) {
                row.push_back(c);
            }
            face.push_back(row);
        }

        cube.push_back(face);
    }
    myfile.close();
    return cube;
}

void output(vector<vector<char>> map, int xPos, int yPos) {
    for(int y=0; y<map.size(); y++) {
        for(int x=0; x<map[y].size(); x++) {
            if (x==xPos && y==yPos) {
                cout << "X";
            } else {
                cout << map[y][x];
            }
        }
        cout << "\n";
    }
    cout << "\n";
}

int Part1() {
    vector<vector<char>> map;
    for(string s : getBoardInput()) {
        if (strcmp("",s.c_str()) == 0) { continue; }
        vector<char> row;
        for(char c: s) {
            row.push_back(c);
        }
        if(!map.empty()) {
            while(row.size() < map[0].size()) {
                row.push_back(' ');
            }
        }
        map.push_back(row);
    }
    string instructions = getInstInput();
    int ySize = map.size();
    int xSize = map[0].size();
    // find starting pos
    int xPos;
    int yPos = 0;
    char dir = 'R';
    int ci = 0;
    for(int i=0; i<map[0].size(); i++) {
        if (map[0][i] == '.') {
            xPos = i;
            break;
        }
    }
    while(ci<instructions.length()) {
        if (instructions[ci] == 'L') {
            switch(dir) {
                case 'U':
                    dir = 'L';
                    break;
                case 'L':
                    dir = 'D';
                    break;
                case 'D':
                    dir = 'R';
                    break;
                case 'R':
                    dir = 'U';
                    break;
            }
        } else if (instructions[ci] == 'R') {
            switch(dir) {
                case 'U':
                    dir = 'R';
                    break;
                case 'L':
                    dir = 'U';
                    break;
                case 'D':
                    dir = 'L';
                    break;
                case 'R':
                    dir = 'D';
                    break;
            }
        } else {
            //move
            // see if we have a double digit number
            int amt = instructions[ci] - '0';
            if(ci+1<instructions.size() && instructions[ci+1]!='L' && instructions[ci+1]!='R') {
                ci++;
                amt *= 10;
                amt += (instructions[ci] - '0');
            }

            for(int i=0; i<amt; i++) {
                if (dir == 'U') {
                    int newY = yPos - 1;
                    // see if we have to wrap
                    if (newY < 0 || map[newY][xPos] == ' ') {
                        for(int y = ySize-1; true; y--) {
                            if(map[y][xPos] != ' ') {
                                newY = y;
                                break;
                            }
                        }
                    }
                    if (map[newY][xPos] != '#') {
                        yPos = newY;
                    }
                }
                if (dir == 'D') {
                    int newY = yPos + 1;
                    // see if we have to wrap
                    if (newY >= ySize || map[newY][xPos] == ' ') {
                        for(int y = 0; true; y++) {
                            if(map[y][xPos] != ' ') {
                                newY = y;
                                break;
                            }
                        }
                    }
                    if (map[newY][xPos] != '#') {
                        yPos = newY;
                    }
                }
                if (dir == 'L') {
                    int newX = xPos - 1;
                    // see if we have to wrap
                    if (newX < 0 || map[yPos][newX] == ' ') {
                        for(int x = xSize-1; true; x--) {
                            if(map[yPos][x] != ' ') {
                                newX = x;
                                break;
                            }
                        }
                    }
                    if (map[yPos][newX] != '#') {
                        xPos = newX;
                    }
                }
                if (dir == 'R') {
                    int newX = xPos + 1;
                    // see if we have to wrap
                    if (newX >= xSize || map[yPos][newX] == ' ') {
                        for(int x = 0; true; x++) {
                            if(map[yPos][x] != ' ') {
                                newX = x;
                                break;
                            }
                        }
                    }
                    if (map[yPos][newX] != '#') {
                        xPos = newX;
                    }
                }
            }
        }
        ci++;
    }
    //rdlu
    int dirAmt;
    switch(dir) {
        case 'U':
            dirAmt = 3;
            break;
        case 'L':
            dirAmt = 2;
            break;
        case 'D':
            dirAmt = 1;
            break;
        case 'R':
            dirAmt = 0;
            break;
    }
    return 1000*(yPos+1) + 4*(xPos+1) + dirAmt;
}
struct State {
    int face;
    int x;
    int y;
    char dir;
};
// actually made a cube to figure these out
State processWrap(State& s) {
    State s1=s;
    if (s.y==-1) {
        // off the top
        if (s.face == 0) {
            s1.face = 5;
            s1.x = 0;
            s1.y = s.x;
            s1.dir = 'R';
        }
        if (s.face == 1) {
            s1.face = 5;
            s1.x = s.x;
            s1.y = 49;
            s1.dir = 'U';
        }
        if (s.face == 2) {
            s1.face = 0;
            s1.x = s.x;
            s1.y = 49;
            s1.dir = 'U';
        }
        if (s.face == 3) {
            s1.face = 2;
            s1.x = 0;
            s1.y = s.x;
            s1.dir = 'R';
        }
        if (s.face == 4) {
            s1.face = 2;
            s1.x = s.x;
            s1.y = 49;
            s1.dir = 'U';
        }
        if (s.face == 5) {
            s1.face = 3;
            s1.x = s.x;
            s1.y = 49;
            s1.dir = 'U';
        }
    }
    if (s.x==-1) {
        // off the left
        if (s.face == 0) {
            s1.face = 3;
            s1.x = 0;
            s1.y = 49-s.y;
            s1.dir = 'R';
        }
        if (s.face == 1) {
            s1.face = 0;
            s1.x = 49;
            s1.y = s.y;
            s1.dir = 'L';
        }
        if (s.face == 2) {
            s1.face = 3;
            s1.x = s.y;
            s1.y = 0;
            s1.dir = 'D';
        }
        if (s.face == 3) {
            s1.face = 0;
            s1.x = 0;
            s1.y = 49-s.y;
            s1.dir = 'R';
        }
        if (s.face == 4) {
            s1.face = 3;
            s1.x = 49;
            s1.y = s.y;
            s1.dir = 'L';
        }
        if (s.face == 5) {
            s1.face = 0;
            s1.x = s.y;
            s1.y = 0;
            s1.dir = 'D';
        }
    }
    if (s.y==50) {
        // off the bottom
        if (s.face == 0) {
            s1.face = 2;
            s1.x = s.x;
            s1.y = 0;
            s1.dir = 'D';
        }
        if (s.face == 1) {
            s1.face = 2;
            s1.x = 49;
            s1.y = s.x;
            s1.dir = 'L';
        }
        if (s.face == 2) {
            s1.face = 4;
            s1.x = s.x;
            s1.y = 0;
            s1.dir = 'D';
        }
        if (s.face == 3) {
            s1.face = 5;
            s1.x = s.x;
            s1.y = 0;
            s1.dir = 'D';
        }
        if (s.face == 4) {
            s1.face = 5;
            s1.x = 49;
            s1.y = s.x;
            s1.dir = 'L';
        }
        if (s.face == 5) {
            s1.face = 1;
            s1.x = s.x;
            s1.y = 0;
            s1.dir = 'D';
        }
    }
    if (s.x==50) {
        // off the right
        if (s.face == 0) {
            s1.face = 1;
            s1.x = 0;
            s1.y = s.y;
            s1.dir = 'R';
        }
        if (s.face == 1) {
            s1.face = 4;
            s1.x = 49;
            s1.y = 49-s.y;
            s1.dir = 'L';
        }
        if (s.face == 2) {
            s1.face = 1;
            s1.x = s.y;
            s1.y = 49;
            s1.dir = 'U';
        }
        if (s.face == 3) {
            s1.face = 4;
            s1.x = 0;
            s1.y = s.y;
            s1.dir = 'R';
        }
        if (s.face == 4) {
            s1.face = 1;
            s1.x = 49;
            s1.y = 49-s.y;
            s1.dir = 'L';
        }
        if (s.face == 5) {
            s1.face = 4;
            s1.x = s.y;
            s1.y = 49;
            s1.dir = 'U';
        }
    }
    return s1;
}
void Part2() {
    vector<vector<vector<char>>> cube = parseForPart2();
    string instructions = getInstInput();

    // initialize to start
    State s;
    s.dir = 'R';
    s.x=0;
    s.y=0;
    s.face=0;

    int ci = 0;
    
    while(ci<instructions.length()) {
        if (instructions[ci] == 'L') {
            switch(s.dir) {
                case 'U':
                    s.dir = 'L';
                    break;
                case 'L':
                    s.dir = 'D';
                    break;
                case 'D':
                    s.dir = 'R';
                    break;
                case 'R':
                    s.dir = 'U';
                    break;
            }
        } else if (instructions[ci] == 'R') {
            switch(s.dir) {
                case 'U':
                    s.dir = 'R';
                    break;
                case 'L':
                    s.dir = 'U';
                    break;
                case 'D':
                    s.dir = 'L';
                    break;
                case 'R':
                    s.dir = 'D';
                    break;
            }
        } else {
            //move
            // see if we have a double digit number
            int amt = instructions[ci] - '0';
            if(ci+1<instructions.size() && instructions[ci+1]!='L' && instructions[ci+1]!='R') {
                ci++;
                amt *= 10;
                amt += (instructions[ci] - '0');
            }

            for(int i=0; i<amt; i++) {
                State s1 = s;
                if (s.dir == 'U') {
                    s1.y = s.y - 1;
                }
                else if (s.dir == 'D') {
                    s1.y = s.y+1;
                }
                else if (s.dir == 'L') {
                    s1.x = s.x-1;
                }
                else if (s.dir == 'R') {
                    s1.x = s.x+1;
                }
                //
                s1 = processWrap(s1);
                if (cube[s1.face][s1.y][s1.x] != '#') {
                        s = s1;
                }
                // output(map,xPos,yPos);
            }
        }
        ci++;
    }
    //rdlu
    int dirAmt;
    switch(s.dir) {
        case 'U':
            dirAmt = 3;
            break;
        case 'L':
            dirAmt = 2;
            break;
        case 'D':
            dirAmt = 1;
            break;
        case 'R':
            dirAmt = 0;
            break;
    }
    cout << "Didn't code figuring out the final location w.r.t. the original map\nLocal location:\n";
    cout << "Face: " << s.face << "\n";
    cout << "Row: " << (s.y + 1) << "\n";
    cout << "Column: "<< (s.x + 1) << "\n";
    cout << "Direction: " << s.dir <<" ("<<dirAmt<<")\n";
}


// Driver Code
int main()
{
    std::cout << "Part 1: " << Part1() << "\n";
    cout << "Part 2\n";
    Part2();
    
    return 0;
}
