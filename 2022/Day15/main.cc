// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <unordered_set>

#include "absl/strings/str_split.h"

using namespace std;

vector<string> getInput() {
    ifstream myfile ("Day15/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}


int Part1(int targetRow) {
    unordered_set<int> nobeacons;
    unordered_set<int> targetrowbecons;
    vector<string> strs = getInput();
    for(int i=0; i<strs.size(); i++) {
        if (strcmp("",strs[i].c_str()) == 0) { continue; }
        vector<string> nums = absl::StrSplit(strs[i],' ');
        int sx = atoi(nums[0].c_str());
        int sy = atoi(nums[1].c_str());
        int bx = atoi(nums[2].c_str());
        int by = atoi(nums[3].c_str());

        if (by==targetRow) {
            targetrowbecons.insert(bx);
        }

        int dist = abs(sx-bx) + abs(sy-by);
        int yPart = abs(targetRow-sy);
        int maxX = dist-yPart;
        if(maxX > 0) {
            for(int i=sx-maxX; i<= sx+maxX; i++) {
                nobeacons.insert(i);
            }
        }
    }
    return nobeacons.size()-targetrowbecons.size();
}

long Part2(int maxCoord) {
    vector<string> strs = getInput();
    for(int r=0; r<=maxCoord; r++) {
        unordered_set<int> nobeacons;
        unordered_set<int> targetrowbecons;
        for(int i=0; i<strs.size(); i++) {
            if (strcmp("",strs[i].c_str()) == 0) { continue; }
            vector<string> nums = absl::StrSplit(strs[i],' ');
            int sx = atoi(nums[0].c_str());
            int sy = atoi(nums[1].c_str());
            int bx = atoi(nums[2].c_str());
            int by = atoi(nums[3].c_str());

            if (by==r) {
                targetrowbecons.insert(bx);
            }

            int dist = abs(sx-bx) + abs(sy-by);
            int yPart = abs(r-sy);
            int maxX = dist-yPart;
            if(maxX > 0) {
                int start = sx-maxX>0? sx-maxX : 0;
                int end = sx+maxX<maxCoord? sx+maxX : maxCoord;
                for(int i=start; i<= end; i++) {
                    nobeacons.insert(i);
                }
            }
        }
        if (r%100 == 0) {
            cout << "Row " << r << " Impossible locations: " << nobeacons.size()-targetrowbecons.size() << " Beacons " << targetrowbecons.size() << "\n";
        }
        if (nobeacons.size() + targetrowbecons.size() < maxCoord+1) {
            // find x
            __int128_t total = 0;
            for(int n : nobeacons) {
                total += static_cast<__int128_t>(n);
            }
            for(int n : targetrowbecons) {
                total += static_cast<__int128_t>(n);
            }
            int x = maxCoord*(maxCoord+1)/2 - total;
            cout << "  ("<< x <<", "<< r <<")\n";
            return x*4000000+r;
        }
    }
    return 2;
}
// Driver Code
int main()
{
    std::cout << "Part 1 " << Part1(2000000) << "\n";
    std::cout << "Part 2 " << Part2(4000000) << "\n";
    
    return 0;
}
