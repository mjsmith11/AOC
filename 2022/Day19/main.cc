// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <map>
#include <math.h> 

#include "absl/strings/str_split.h"

using namespace std;

vector<string> getInput() {
    ifstream myfile ("Day19/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}

struct State {
    int minutes;

    int oreRobots;
    int clayRobots;
    int obsidianRobots;
    int geodeRobots;

    int oreCost;
    int clayCost;
    int obsidianOreCost;
    int obsidianClayCost;
    int geodeOreCost;
    int geodeObsidianCost;

    int ore;
    int clay;
    int obsidian;
    int geodes;

    string getString() {
        string s = to_string(minutes);
        s += " " +to_string(oreRobots);
        s += " " +to_string(clayRobots);
        s += " " +to_string(obsidianRobots);
        s += " " +to_string(geodeRobots);
        s += " " +to_string(ore);
        s += " " +to_string(clay);
        s += " " +to_string(obsidian);
        s += " " +to_string(geodes);
        return s;
    }
};


int maxGeodes3(State& s) {
    if (s.minutes <= 0) {
        return s.geodes;
    }
    // do nothing
    int max = s.geodes + s.geodeRobots*s.minutes;

    // possible actions
    // try to build a geodeRobot
    if (s.obsidianRobots>0 && s.oreRobots>0) {
        int wait = 0;
        int obAmt = ceil(static_cast<double>(s.geodeObsidianCost-s.obsidian)/static_cast<double>(s.obsidianRobots));
        int orrAmt = ceil(static_cast<double>(s.geodeOreCost-s.ore)/static_cast<double>(s.oreRobots));
        wait = std::max(wait, obAmt);
        wait = std::max(wait, orrAmt);
        int remtime = s.minutes - wait - 1;
        if (remtime>0) {
            State s1 = s;
            s1.minutes = remtime;

            s1.geodes = s.geodes+s.geodeRobots*(wait+1);
            s1.obsidian = s.obsidian+s.obsidianRobots*(wait+1);
            s1.clay = s.clay+s.clayRobots*(wait+1);
            s1.ore = s.ore+s.oreRobots*(wait+1);
            s1.obsidian -= s.geodeObsidianCost;
            s1.ore -= s.geodeOreCost;
            s1.geodeRobots++;
            max = std::max(maxGeodes3(s1), max);
        }
    }
    
    // try to build an obsidian robot
    if (s.clayRobots>0 && s.oreRobots>0 && s.obsidianRobots < s.geodeObsidianCost) {
        int wait = 0;
        int clayAmt = ceil(static_cast<double>(s.obsidianClayCost-s.clay)/static_cast<double>(s.clayRobots));
        int orrAmt = ceil(static_cast<double>(s.obsidianOreCost-s.ore)/static_cast<double>(s.oreRobots));
        wait = std::max(wait, clayAmt);
        wait = std::max(wait, orrAmt);
        int remtime = s.minutes - wait - 1;
        if (remtime>0) {
            State s1 = s;
            s1.minutes = remtime;

            s1.geodes = s.geodes+s.geodeRobots*(wait+1);
            s1.obsidian = s.obsidian+s.obsidianRobots*(wait+1);
            s1.clay = s.clay+s.clayRobots*(wait+1);
            s1.ore = s.ore+s.oreRobots*(wait+1);
            s1.clay -= s.obsidianClayCost;
            s1.ore -= s.obsidianOreCost;
            s1.obsidianRobots++;
            max = std::max(maxGeodes3(s1), max);
        }
    }

    // try to build a clay robot
    if (s.oreRobots>0 && s.clayRobots < s.obsidianClayCost) {
        int wait = 0;
        int orrAmt = ceil(static_cast<double>(s.clayCost-s.ore)/static_cast<double>(s.oreRobots));
        wait = std::max(wait, orrAmt);
        int remtime = s.minutes - wait - 1;
        if (remtime>0) {
            State s1 = s;
            s1.minutes = remtime;

            s1.geodes = s.geodes+s.geodeRobots*(wait+1);
            s1.obsidian = s.obsidian+s.obsidianRobots*(wait+1);
            s1.clay = s.clay+s.clayRobots*(wait+1);
            s1.ore = s.ore+s.oreRobots*(wait+1);
            s1.ore -= s.clayCost;
            s1.clayRobots++;
            max = std::max(maxGeodes3(s1), max);
        }
    }

    // try to build an ore robot
    int maxOreNeeded = s.oreCost>s.clayCost?s.oreCost:s.clayCost;
    maxOreNeeded = maxOreNeeded>s.obsidianOreCost?maxOreNeeded:s.obsidianOreCost;
    maxOreNeeded = maxOreNeeded>s.geodeOreCost?maxOreNeeded:s.geodeOreCost;

    if (s.oreRobots>0 && s.oreRobots < maxOreNeeded) {
        int wait = 0;
        int orrAmt = ceil(static_cast<double>(s.oreCost-s.ore)/static_cast<double>(s.oreRobots));
        wait = std::max(wait, orrAmt);
        int remtime = s.minutes - wait - 1;
        if (remtime>0) {
            State s1 = s;
            s1.minutes = remtime;

            s1.geodes = s.geodes+s.geodeRobots*(wait+1);
            s1.obsidian = s.obsidian+s.obsidianRobots*(wait+1);
            s1.clay = s.clay+s.clayRobots*(wait+1);
            s1.ore = s.ore+s.oreRobots*(wait+1);
            s1.ore -= s.oreCost;
            s1.oreRobots++;
            max = std::max(maxGeodes3(s1), max);
        }
    }
    return max;
}

int Part1() {
    vector<string> inp = getInput();
    int quality = 0;
    for(string s : getInput()) {
        if (strcmp("",s.c_str()) == 0) { continue; }
        vector<string> words = absl::StrSplit(s,' ');
        vector<string> blueprintWords = absl::StrSplit(words[1],':');
        int blueprintNum = atoi(blueprintWords[0].c_str());

        State start;
        start.minutes = 24;

        start.oreRobots = 1;
        start.clayRobots = 0;
        start.obsidianRobots = 0;
        start.geodeRobots = 0;

        start.oreCost = atoi(words[6].c_str());
        start.clayCost = atoi(words[12].c_str());
        start.obsidianOreCost = atoi(words[18].c_str());
        start.obsidianClayCost = atoi(words[21].c_str());
        start.geodeOreCost = atoi(words[27].c_str());
        start.geodeObsidianCost = atoi(words[30].c_str());

        start.ore = 0;
        start.clay = 0;
        start.obsidian = 0;
        start.geodes = 0;

        int n = maxGeodes3(start);
        quality += blueprintNum * n;
    }
    return quality;
}

int Part2() {
    vector<string> inp = getInput();
    int prod = 1;
    for(int i=0; i<3; i++) {
        string s = inp[i];
        vector<string> words = absl::StrSplit(s,' ');
        vector<string> blueprintWords = absl::StrSplit(words[1],':');
        int blueprintNum = atoi(blueprintWords[0].c_str());

        State start;
        start.minutes = 32;

        start.oreRobots = 1;
        start.clayRobots = 0;
        start.obsidianRobots = 0;
        start.geodeRobots = 0;

        start.oreCost = atoi(words[6].c_str());
        start.clayCost = atoi(words[12].c_str());
        start.obsidianOreCost = atoi(words[18].c_str());
        start.obsidianClayCost = atoi(words[21].c_str());
        start.geodeOreCost = atoi(words[27].c_str());
        start.geodeObsidianCost = atoi(words[30].c_str());

        start.ore = 0;
        start.clay = 0;
        start.obsidian = 0;
        start.geodes = 0;

        int n = maxGeodes3(start);
        prod *= n;
    }
    return prod;
}

// Driver Code
int main()
{
    std::cout << "Part 1 " << Part1() << "\n";
    std::cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
