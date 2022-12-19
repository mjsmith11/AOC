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
State mine(State s, int rounds) {
    State s1 = s;
    s1.ore = s.ore + s.oreRobots*rounds;
    s1.clay = s.clay + s.clayRobots*rounds;
    s1.obsidian = s.obsidian + s.obsidianRobots*rounds;
    s1.geodes = s.geodes + s.geodeRobots*rounds;

    return s1;
}
map<string, int> cache;

int maxGeodes2(State& s) {
    // cout << "Caclulationg with " << s.minutes << "minutes\n";
    if (s.minutes>24) {return 0; }
    if (s.minutes <= 0) {
        if (s.minutes < 0) {
            cout << "Minutes ERROR\n";
        }
        return 0;
    }
    // cout << "Before cache check\n";
    if (auto r = cache.find(s.getString()); r != cache.end()) {
        cout << "CACHE HIT!!\n";
        return r->second;
    }

    int max = 0;
    int geodes = 0;

    // possible actions
    // build a geodeRobot right now
    if (s.obsidian >= s.geodeObsidianCost && s.ore >= s.geodeOreCost) {
        State s1 = mine(s, 1);
        s1.minutes--;
        s1.geodeRobots++;
        s1.obsidian -= s.geodeObsidianCost;
        s1.ore -= s.geodeOreCost;

        int val = maxGeodes2(s1);
        if(val>max) {
            max = val;
            geodes = s1.geodes;
        }
    } else { // wait until we can build a geode
        if (s.obsidianRobots>0) { // if we aren't mining obsidian, we can't build it
            int extraObsidianNeeded = s.geodeObsidianCost - s.obsidian;
            int extraOreNeeded = s.geodeOreCost - s.ore;
            int obRounds = ceil(static_cast<double>(extraObsidianNeeded)/static_cast<double>(s.obsidianRobots));
            int oreRounds = ceil(static_cast<double>(extraOreNeeded)/static_cast<double>(s.oreRobots));
            int rounds = obRounds>oreRounds?obRounds:oreRounds+1; // add 1 for this round
            if (rounds <= s.minutes) {
                State s1 = mine(s, rounds);
                s1.minutes -= rounds;
                s1.geodeRobots++;
                s1.obsidian -= s.geodeObsidianCost;
                s1.ore -= s.geodeOreCost;

                int val = maxGeodes2(s1);
                if(val>max) {
                    max = val;
                    geodes = s1.geodes;
                }
            }
        }
    }

    // build a obsidian right now
    if (s.clay >= s.obsidianClayCost && s.ore >= s.obsidianOreCost) {
        State s1 = mine(s, 1);
        s1.minutes--;
        s1.obsidianRobots++;
        s1.clay -= s.obsidianClayCost;
        s1.ore -= s.obsidianOreCost;

        int val = maxGeodes2(s1);
        if(val>max) {
            max = val;
            geodes = s1.geodes;
        }
    } else { // wait until we can build a obsidian
        if (s.clayRobots>0) { // if we aren't mining clay, we can't build it
            int extraClayNeeded = s.obsidianClayCost - s.clay;
            int extraOreNeeded = s.obsidianOreCost - s.ore;
            int clayRounds = ceil(static_cast<double>(extraClayNeeded)/static_cast<double>(s.clayRobots));
            int oreRounds = ceil(static_cast<double>(extraOreNeeded)/static_cast<double>(s.oreRobots));
            int rounds = clayRounds>oreRounds?clayRounds:oreRounds+1; // add 1 for this round
            if (rounds <= s.minutes) {
                State s1 = mine(s, rounds);
                s1.minutes -= rounds;
                s1.obsidianRobots++;
                s1.clay -= s.obsidianClayCost;
                s1.ore -= s.obsidianOreCost;

                int val = maxGeodes2(s1);
                if(val>max) {
                    max = val;
                    geodes = s1.geodes;
                }
            }
        }
    }

    // build a clay robot right now
    if (s.ore >= s.clayCost) {
        State s1 = mine(s, 1);
        s1.minutes--;
        s1.clayRobots++;
        s1.ore -= s.clayCost;

        int val = maxGeodes2(s1);
        if(val>max) {
            max = val;
            geodes = s1.geodes;
        }
    } else { // wait until we can build a clay
        int extraOreNeeded = s.clayCost - s.ore;
        int rounds = ceil(static_cast<double>(extraOreNeeded)/static_cast<double>(s.oreRobots))+1;
        if (rounds <= s.minutes) {
            State s1 = mine(s, rounds);
            s1.minutes -= rounds;
            s1.clayRobots++;
            s1.ore -= s.clayCost;

            int val = maxGeodes2(s1);
            if(val>max) {
                max = val;
                geodes = s1.geodes;
            }
        }
    }

    // build a ore robot right now
    if (s.ore >= s.oreCost) {
        State s1 = mine(s, 1);
        s1.minutes--;
        s1.oreRobots++;
        s1.ore -= s.oreCost;

        int val = maxGeodes2(s1);
        if(val>max) {
            max = val;
            geodes = s1.geodes;
        }
    } else { // wait until we can build a clay
        int extraOreNeeded = s.oreCost - s.ore;
        int rounds = ceil(static_cast<double>(extraOreNeeded)/static_cast<double>(s.oreRobots))+1;
        if (rounds<=s.minutes) {
            State s1 = mine(s, rounds);
            s1.minutes -= rounds;
            s1.oreRobots++;
            s1.ore -= s.oreCost;

            int val = maxGeodes2(s1);
            if(val>max) {
                max = val;
                geodes = s1.geodes;
            }
        }
    }
    // wait until the end
    int val = s.geodeRobots*s.minutes;
    if (val > max) {
        geodes = 0;
        max = val;
    }
    return max;
    return geodes+max-s.geodeRobots;
}

int maxGeodes(State& s) {
    // cout << "No vars" << s.ore << "\n";
    // cout << "Processing with " << s.minutes << " minutes and " << s.ore <<" ore\n";
    if (s.minutes>24) {return 0; }
    if (s.minutes <= 0) {
        return 0;
    }
    // cout << "Before cache check\n";
    if (auto r = cache.find(s.getString()); r != cache.end()) {
        cout << "CACHE HIT!!\n";
        return r->second;
    }
    // cout << "After cache check\n";
    // bool canMakeOre = (s.ore >= s.oreCost);
    // bool canMakeClay = (s.ore >= s.clayCost);
    // bool canMakeObsidian (s.ore >= s.obsidianOreCost && s.clay >= s.obsidianClayCost);
    // bool canMakeGeode (s.ore >= s.geodeOreCost && s.obsidian >= s.geodeObsidianCost);

    int max = 0;
    int geodes = 0;
    
    // geode
    if (s.obsidianRobots > 0) {
        int obsidianNeeded = s.geodeObsidianCost - s.obsidian;
        int oreNeeded = s.geodeOreCost - s.ore;
        obsidianNeeded = obsidianNeeded>0?obsidianNeeded:0;
        oreNeeded = oreNeeded>0?oreNeeded:0;
        int obRounds = ceil(static_cast<double>(obsidianNeeded)/static_cast<double>(s.obsidianRobots));
        int oreRounds = ceil(static_cast<double>(oreNeeded)/static_cast<double>(s.oreRobots));
        int rounds = obRounds>oreRounds?obRounds:oreRounds;
        if (rounds <s.minutes) {
            cout << "Running geode " << rounds << "rounds\n";
            return 0;
            State s1 = mine(s, rounds);
            s1.minutes -= rounds;
            s1.geodeRobots++;
            int val = maxGeodes(s1);
            if (val>max) {
                max = val;
                geodes = s1.geodes;
            }
        }
    }

    // Obsidian
    if (s.clayRobots > 0) {
        int clayNeeded = s.obsidianClayCost - s.clay;
        int oreNeeded = s.obsidianOreCost - s.ore;
        clayNeeded = clayNeeded>0?clayNeeded:0;
        oreNeeded = oreNeeded>0?oreNeeded:0;
        int clayRounds = ceil(static_cast<double>(clayNeeded)/static_cast<double>(s.clayRobots));
        int oreRounds = ceil(static_cast<double>(oreNeeded)/static_cast<double>(s.oreRobots));
        int rounds = clayRounds>oreRounds?clayRounds:oreRounds;
        if (rounds < s.minutes) {
            cout << "Running obsidian " << rounds << "rounds and " << s.minutes << " minutes \n";
            State s1 = mine(s, rounds);
            s1.minutes -= rounds;
            s1.obsidianRobots++;
            cout << "Obsidian Recurse " << s1.minutes << " " << s1.ore << "\n";
            int val = maxGeodes(s1);
            cout << "After recurse\n";
            if (val>max) {
                max = val;
                geodes = s1.geodes;
            }
        }
    }

    // Clay
    int oreNeeded = s.clayCost - s.ore;
    oreNeeded = oreNeeded>0?oreNeeded:0;
    int oreRounds = ceil(static_cast<double>(oreNeeded)/static_cast<double>(s.oreRobots));
    if (oreRounds < s.minutes) {
        State s1 = mine(s, oreRounds);
        cout << "Running clay " << oreRounds << "rounds\n";
            s1.minutes = s.minutes - oreRounds;
            s1.clayRobots++;
            int val = maxGeodes(s1);
            if (val>max) {
                    max = val;
                    geodes = s1.geodes;
            }
    }

    // Ore
    int oreNeeded2 = s.oreCost - s.ore;
    oreNeeded2 = oreNeeded2>0?oreNeeded2:0;
    int oreRounds2 = ceil(static_cast<double>(oreNeeded2)/static_cast<double>(s.oreRobots));
    if (oreRounds2 < s.minutes) {
        cout << "Running ore " << oreRounds2 << "rounds\n";
        State s2 = mine(s, oreRounds2);
        s2.minutes -= oreRounds2;
        s2.oreRobots++;
        int val2 = maxGeodes(s2);
        if (val2>max) {
                max = val2;
                geodes = s2.geodes;
        }
    }

    /*s1.minutes--;
    s1.ore += s1.oreRobots;
    s1.clay += s1.clayRobots;
    s1.obsidian += s1.obsidianRobots;
    s1.geodes += s1.geodeRobots;

    // build nothing
    int max = maxGeodes(s1);

    if (canMakeOre) {
        cout << "Making ore\n";
        s1.ore -= s.oreCost;
        s1.oreRobots++;
        int val = maxGeodes(s1);
        max = val>max?val:max;
        s1.ore += s.oreCost;
        s1.oreRobots--;
    }

    if (canMakeClay) {
        cout << "Making clay\n";
        s1.ore -= s.clayCost;
        s1.clayRobots++;
        int val = maxGeodes(s1);
        max = val>max?val:max;
        s1.ore += s.clayCost;
        s1.clayRobots--;
    }

    if (canMakeObsidian) {
        cout << "Making obsidian\n";
        s1.ore -= s.obsidianOreCost;
        s1.clay -= s.obsidianClayCost;
        s1.obsidianRobots++;
        int val = maxGeodes(s1);
        max = val>max?val:max;
        s1.ore += s.obsidianOreCost;
        s1.clay += s.obsidianClayCost;
        s1.obsidianRobots--;
    }

    if (canMakeGeode) {
        cout << "Making geode\n";
        s1.ore -= s.geodeOreCost;
        s1.obsidian -= s.geodeObsidianCost;
        s1.geodeRobots++;
        int val = maxGeodes(s1);
        max = val>max?val:max;
        s1.ore += s.geodeOreCost;
        s1.obsidian += s.geodeObsidianCost;
        s1.geodeRobots--;
    }*/
    cache[s.getString()] = geodes + max;

    return geodes + max;
}

int Part1() {
    State start;
    start.minutes = 24;

    start.oreRobots = 1;
    start.clayRobots = 0;
    start.obsidianRobots = 0;
    start.geodeRobots = 0;

    start.oreCost = 4;
    start.clayCost = 2;
    start.obsidianOreCost = 3;
    start.obsidianClayCost = 14;
    start.geodeObsidianCost = 7;
    start.geodeOreCost = 2;

    start.ore = 0;
    start.clay = 0;
    start.obsidian = 0;
    start.geodes = 0;
    
    return maxGeodes2(start);
}

int Part2() {
    
    return 2;
}

// Driver Code
int main()
{
    std::cout << "Part 1 " << Part1() << "\n";
    std::cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
