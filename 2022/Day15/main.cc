// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <unordered_set>
// #include <pair>

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
std::ostream&
operator<<( std::ostream& dest, __int128_t value )
{
    std::ostream::sentry s( dest );
    if ( s ) {
        __uint128_t tmp = value < 0 ? -value : value;
        char buffer[ 128 ];
        char* d = std::end( buffer );
        do
        {
            -- d;
            *d = "0123456789"[ tmp % 10 ];
            tmp /= 10;
        } while ( tmp != 0 );
        if ( value < 0 ) {
            -- d;
            *d = '-';
        }
        int len = std::end( buffer ) - d;
        if ( dest.rdbuf()->sputn( d, len ) != len ) {
            dest.setstate( std::ios_base::badbit );
        }
    }
    return dest;
}
__int128_t Part2(int maxCoord) {
    vector<string> strs = getInput();
    unordered_set<__int128_t> possibilities;
    for(int i=0; i<strs.size(); i++) {
        if (strcmp("",strs[i].c_str()) == 0) { continue; }
        vector<string> nums = absl::StrSplit(strs[i],' ');
        int sx = atoi(nums[0].c_str());
        int sy = atoi(nums[1].c_str());
        int bx = atoi(nums[2].c_str());
        int by = atoi(nums[3].c_str());

        int dist = abs(sx-bx) + abs(sy-by);
        int top = sy-dist;
        int bottom = sy+dist;
        int left = sx-dist;
        int right = sx+dist;

        // top to right
        int cx = sx;
        int cy = top-1;
        while(cx<=right) {
            if(cx>=0 && cx<=maxCoord && cy>=0 && cy<=maxCoord) {
                possibilities.insert(4000000*static_cast<__int128_t>(cx)+cy);
            }
            cx++;
            cy++;
        }
        // right to bottom
        cx = right+1;
        cy = sy;
        while(cy<=bottom) {
            if(cx>=0 && cx<=maxCoord && cy>=0 && cy<=maxCoord) {
                possibilities.insert(4000000*static_cast<__int128_t>(cx)+cy);
            }
            cx--;
            cy++;
        }

        // bottom to left
        cx = sx;
        cy = bottom+1;
        while(cx>=left) {
            if(cx>=0 && cx<=maxCoord && cy>=0 && cy<=maxCoord) {
                possibilities.insert(4000000*static_cast<__int128_t>(cx)+cy);
            }
            cx--;
            cy--;
        }

        // left to top
        cx = left-1;
        cy = sy;
        while(cy>=top) {
            if(cx>=0 && cx<=maxCoord && cy>=0 && cy<=maxCoord) {
                possibilities.insert(4000000*static_cast<__int128_t>(cx)+cy);
            }
            cx++;
            cy--;
        }

    }
    for(__int128_t n: possibilities) {
        int cx = n/4000000;
        int cy = n%4000000;
        bool good = true;
        for(int i=0; i<strs.size(); i++) {
            if (strcmp("",strs[i].c_str()) == 0) { continue; }
            vector<string> nums = absl::StrSplit(strs[i],' ');
            int sx = atoi(nums[0].c_str());
            int sy = atoi(nums[1].c_str());
            int bx = atoi(nums[2].c_str());
            int by = atoi(nums[3].c_str());
            if (cx==bx && cy==by) {
                good = false;
                break;
            }
            int dist = abs(sx-bx)+abs(sy-by);
            int cdist = abs(cx-sx) + abs(cy-sy);
            if(cdist<=dist) {
                good = false;
                break;
            }
        }
        if (good) { return n; }

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
