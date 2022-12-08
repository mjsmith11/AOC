// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <stdlib.h> 

#include "absl/strings/str_split.h"

using namespace std;

int sum_lte_100k; // couldn't get a static member of the class to run right

vector<string> getInput() {
    ifstream myfile ("Day08/input.txt");
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
    vector<vector<int>> trees;
    vector<vector<bool>> visible;
    for(string s : getInput()) {
         if (strcmp(s.c_str(), "") == 0) { continue; }
         vector<int> line;
         vector<bool> tf;
         for (char c : s) {
            line.push_back(c-'0');
            tf.push_back(false);
         }
         trees.push_back(line);
         visible.push_back(tf);
    }
    int ySize = trees.size();
    int xSize = trees[0].size();
    // trees[y][x]
    // l/r
    for (int y=0; y<ySize; y++) {
        // from left
        // can see first tree
        visible[y][0] = true;
        int max = trees[y][0];
        for (int x=1; x<xSize; x++) {
            if (trees[y][x] > max) {
                max = trees[y][x];
                visible[y][x] = true;
            }
        }

        // from right
        // you can see the first
        visible[y][xSize - 1] = true;
        max = trees[y][xSize - 1];
        for (int x=xSize - 2; x>=0; x--) {
            if (trees[y][x] > max) {
                max = trees[y][x];
                visible[y][x] = true;
            }
        }
    }

    // u/d
    for (int x=0; x<xSize; x++) {
        // from top
        // can see first tree
        visible[0][x] = true;
        int max = trees[0][x];
        for (int y=1; y<ySize; y++) {
            if (trees[y][x] > max) {
                max = trees[y][x];
                visible[y][x] = true;
            }
        }

        // from bottom
        // you can see the first
        visible[ySize - 1][x] = true;
        max = trees[ySize - 1][x];
        for (int y=ySize - 2; y>=0; y--) {
            if (trees[y][x] > max) {
                max = trees[y][x];
                visible[y][x] = true;
            }
        }
    }
    int total = 0;
    for (int x=0; x<xSize; x++) {
        for (int y=0; y<ySize; y++) {
            if (visible[y][x]) { total++; }
        }
    }

    return total;
}

int calcScenicScore(vector<vector<int>> trees, int x, int y, int xSize, int ySize) {
    if (x==0 || y==0 || x==xSize - 1 || y==ySize - 1) { return 0; }
    int myHeight = trees[y][x];
    
    int upScore = 0;
    int lookY = y-1;
    while(lookY >= 0) {
        upScore++;
        if (trees[lookY][x] >= myHeight) {break;}
        lookY--;
    }

    int downScore = 0;
    lookY = y+1;
    while(lookY < ySize) {
        downScore++;
        if (trees[lookY][x] >= myHeight) {break;}
        lookY++;
    }

    int leftScore = 0;
    int lookX = x-1;
    while(lookX >= 0) {
        leftScore++;
        if (trees[y][lookX] >= myHeight) {break;}
        lookX--;
    }

    int rightScore = 0;
    lookX = x+1;
    while(lookX < xSize) {
        rightScore++;
        if (trees[y][lookX] >= myHeight) {break;}
        lookX++;
    }
    return upScore * downScore * leftScore * rightScore;
}

int Part2() {
    vector<vector<int>> trees;
    for(string s : getInput()) {
         if (strcmp(s.c_str(), "") == 0) { continue; }
         vector<int> line;
         for (char c : s) {
            line.push_back(c-'0');
         }
         trees.push_back(line);
    }
    int ySize = trees.size();
    int xSize = trees[0].size();
    int maxScore = 0;
    for(int x=0; x<xSize; x++) {
        for (int y=0; y<ySize; y++) {
            int score = calcScenicScore(trees, x, y, xSize, ySize);
            maxScore = score>maxScore ? score : maxScore;
        }
    }
    return maxScore;
}
// Driver Code
int main()
{
    cout << "Part 1 " << Part1() << "\n";
    cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
