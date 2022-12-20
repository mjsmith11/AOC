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
State mine(State s, int rounds) {
    State s1 = s;
    s1.ore = s.ore + s.oreRobots*rounds;
    s1.clay = s.clay + s.clayRobots*rounds;
    s1.obsidian = s.obsidian + s.obsidianRobots*rounds;
    s1.geodes = s.geodes + s.geodeRobots*rounds;

    return s1;
}
map<string, int> cache;

int maxGeodes2(State& s, int score) {
    if (s.minutes>24) {return 0; }
    if (s.minutes <= 0) {
        if (s.minutes < 0) {
            cout << "Minutes ERROR\n";
        }
        return score;
    }
    int geodes = 0;
    int max = s.geodes + s.geodeRobots*s.minutes;
    // possible actions
    // build a geodeRobot right now
    if (s.obsidian >= s.geodeObsidianCost && s.ore >= s.geodeOreCost) {
        State s1 = mine(s, 1);
        s1.minutes--;
        s1.geodeRobots++;
        s1.obsidian -= s.geodeObsidianCost;
        s1.ore -= s.geodeOreCost;

        int val = maxGeodes2(s1, score+s1.minutes);
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

                int val = maxGeodes2(s1, score+s1.minutes);
                if(val>max) {
                    max = val;
                    geodes = s1.geodes;
                }
            }
        }
    }

    if (s.obsidianRobots < s.geodeObsidianCost) {
        // build a obsidian right now
        if (s.clay >= s.obsidianClayCost && s.ore >= s.obsidianOreCost) {
            State s1 = mine(s, 1);
            s1.minutes--;
            s1.obsidianRobots++;
            s1.clay -= s.obsidianClayCost;
            s1.ore -= s.obsidianOreCost;

            int val = maxGeodes2(s1, score);
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

                    int val = maxGeodes2(s1, score);
                    if(val>max) {
                        max = val;
                        geodes = s1.geodes;
                    }
                }
            }

        }
    }

    if (s.clayRobots < s.obsidianClayCost) {
        // build a clay robot right now
        if (s.ore >= s.clayCost) {
            State s1 = mine(s, 1);
            s1.minutes--;
            s1.clayRobots++;
            s1.ore -= s.clayCost;

            int val = maxGeodes2(s1, score);
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

                int val = maxGeodes2(s1, score);
                if(val>max) {
                    max = val;
                    geodes = s1.geodes;
                }
            }
        }
    }

    int maxOreNeeded = s.oreCost>s.clayCost?s.oreCost:s.clayCost;
    maxOreNeeded = maxOreNeeded>s.obsidianOreCost?maxOreNeeded:s.obsidianOreCost;
    maxOreNeeded = maxOreNeeded>s.geodeOreCost?maxOreNeeded:s.geodeOreCost;

    if (s.oreRobots < maxOreNeeded) {
        // build a ore robot right now
        if (s.ore >= s.oreCost) {
            State s1 = mine(s, 1);
            s1.minutes--;
            s1.oreRobots++;
            s1.ore -= s.oreCost;

            int val = maxGeodes2(s1, score);
            if(val>max) {
                max = val;
                geodes = s1.geodes;
            }
        } else { // wait until we can build a ore
            int extraOreNeeded = s.oreCost - s.ore;
            int rounds = ceil(static_cast<double>(extraOreNeeded)/static_cast<double>(s.oreRobots))+1;
            if (rounds<=s.minutes) {
                State s1 = mine(s, rounds);
                s1.minutes -= rounds;
                s1.oreRobots++;
                s1.ore -= s.oreCost;

                int val = maxGeodes2(s1, score);
                if(val>max) {
                    max = val;
                    geodes = s1.geodes;
                }
            }
        }
    }
    
    // nothing
    /*int val = 0;
    if (val > max) {
        cout << "Setting max to 0\n";
        geodes = 0;
        max = val;
    }*/
    return max;
}

int maxGeodes3(State& s) {
    if (s.minutes>24) {return 0; }
    if (s.minutes <= 0) {
        if (s.minutes < 0) {
            cout << "Minutes ERROR\n";
        }
        return s.geodes;
    }
    int geodes = 0;
    int max = s.geodes + s.geodeRobots*s.minutes;
    // possible actions
    // build a geodeRobot right now
    if (s.obsidianRobots>0 && s.oreRobots>0) {
        int wait = 0;
        int obAmt = ceil(s.geodeObsidianCost-s.obsidian/static_cast<double>(s.obsidianRobots));
        int orrAmt = ceil(s.geodeOreCost-s.ore/static_cast<double>(s.oreRobots));
        wait = std::max(wait, obAmt);
        wait = std::max(wait, orrAmt);
        int remtime = s.minutes - wait - 1;
        if (remtime>0) {
            State s1 = s;
            s1.minutes = remtime;

            s1.geodes = s.geodes+s.geodeRobots*(wait+1);
            s1.obsidian = s.obsidian+s.obsidianRobots*(wait+1);
            s1.geodes = s.clay+s.clayRobots*(wait+1);
            s1.geodes = s.ore+s.oreRobots*(wait+1);
            s1.obsidian -= s.geodeObsidianCost;
            s1.ore -= s.geodeOreCost;
            s1.geodeRobots++;
            max = std::max(maxGeodes3(s1), max);
        }
    }
    
    if (s.clayRobots>0 && s.oreRobots>0 && s.obsidianRobots < s.geodeObsidianCost) {
        int wait = 0;
        int clayAmt = ceil(s.obsidianClayCost-s.clay/static_cast<double>(s.clayRobots));
        int orrAmt = ceil(s.obsidianOreCost-s.ore/static_cast<double>(s.oreRobots));
        wait = std::max(wait, clayAmt);
        wait = std::max(wait, orrAmt);
        int remtime = s.minutes - wait - 1;
        if (remtime>0) {
            State s1 = s;
            s1.minutes = remtime;

            s1.geodes = s.geodes+s.geodeRobots*(wait+1);
            s1.obsidian = s.obsidian+s.obsidianRobots*(wait+1);
            s1.geodes = s.clay+s.clayRobots*(wait+1);
            s1.geodes = s.ore+s.oreRobots*(wait+1);
            s1.clay -= s.obsidianClayCost;
            s1.ore -= s.obsidianOreCost;
            s1.obsidianRobots++;
            max = std::max(maxGeodes3(s1), max);
        }
    }

    if (s.oreRobots>0 && s.clayRobots < s.obsidianClayCost) {
        int wait = 0;
        int orrAmt = ceil(s.clayCost-s.ore/static_cast<double>(s.oreRobots));
        wait = std::max(wait, orrAmt);
        int remtime = s.minutes - wait - 1;
        if (remtime>0) {
            State s1 = s;
            s1.minutes = remtime;

            s1.geodes = s.geodes+s.geodeRobots*(wait+1);
            s1.obsidian = s.obsidian+s.obsidianRobots*(wait+1);
            s1.geodes = s.clay+s.clayRobots*(wait+1);
            s1.geodes = s.ore+s.oreRobots*(wait+1);
            s1.ore -= s.clayCost;
            s1.clayRobots++;
            max = std::max(maxGeodes3(s1), max);
        }
    }

    int maxOreNeeded = s.oreCost>s.clayCost?s.oreCost:s.clayCost;
    maxOreNeeded = maxOreNeeded>s.obsidianOreCost?maxOreNeeded:s.obsidianOreCost;
    maxOreNeeded = maxOreNeeded>s.geodeOreCost?maxOreNeeded:s.geodeOreCost;

    if (s.oreRobots>0 && s.oreRobots < maxOreNeeded) {
        int wait = 0;
        int orrAmt = ceil(s.oreCost-s.ore/static_cast<double>(s.oreRobots));
        wait = std::max(wait, orrAmt);
        int remtime = s.minutes - wait - 1;
        if (remtime>0) {
            State s1 = s;
            s1.minutes = remtime;

            s1.geodes = s.geodes+s.geodeRobots*(wait+1);
            s1.obsidian = s.obsidian+s.obsidianRobots*(wait+1);
            s1.geodes = s.clay+s.clayRobots*(wait+1);
            s1.geodes = s.ore+s.oreRobots*(wait+1);
            s1.ore -= s.oreCost;
            s1.oreRobots++;
            max = std::max(maxGeodes3(s1), max);
        }
    }
    
    // nothing
    /*int val = 0;
    if (val > max) {
        cout << "Setting max to 0\n";
        geodes = 0;
        max = val;
    }*/
    return max;
}

int maxGeodes(State s) {
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
    vector<string> inp = getInput();
    int quality = 0;
    for(string s : getInput()) {
        if (strcmp("",s.c_str()) == 0) { continue; }
        vector<string> words = absl::StrSplit(s,' ');
        vector<string> blueprintWords = absl::StrSplit(words[1],':');
        int blueprintNum = atoi(blueprintWords[0].c_str());
        // cout << blueprintNum << "\n";
        State start;
        start.minutes = 24;

        start.oreRobots = 1;
        start.clayRobots = 0;
        start.obsidianRobots = 0;
        start.geodeRobots = 0;

        start.oreCost = atoi(words[6].c_str());
        // cout << start.oreCost << "\n";
        start.clayCost = atoi(words[12].c_str());
        // cout << start.clayCost << "\n";
        start.obsidianOreCost = atoi(words[18].c_str());
        // cout << start.obsidianOreCost << "\n";
        start.obsidianClayCost = atoi(words[21].c_str());
        // cout << start.obsidianClayCost << "\n";
        start.geodeOreCost = atoi(words[27].c_str());
        // cout << start.geodeOreCost << "\n";
        start.geodeObsidianCost = atoi(words[30].c_str());
        // cout << start.geodeObsidianCost<< "\n";

        start.ore = 0;
        start.clay = 0;
        start.obsidian = 0;
        start.geodes = 0;

        cache.clear();
        // cout << "Simulating blueprint # " << blueprintNum << "\n";
        int n = maxGeodes3(start);
        quality += blueprintNum * n;
        cout << blueprintNum << " : " << n<< "\n";
    }
    return quality;

    /*State start;
    start.minutes = 24;

    start.oreRobots = 1;
    start.clayRobots = 0;
    start.obsidianRobots = 0;
    start.geodeRobots = 0;

    start.oreCost = 2;
    start.clayCost = 3;
    start.obsidianOreCost = 3;
    start.obsidianClayCost = 8;
    start.geodeObsidianCost = 12;
    start.geodeOreCost = 3;

    start.ore = 0;
    start.clay = 0;
    start.obsidian = 0;
    start.geodes = 0;
    
    return maxGeodes2(start,0);*/
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
