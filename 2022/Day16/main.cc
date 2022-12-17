// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <map>

#include "absl/strings/str_split.h"

using namespace std;

map<string, int> cache;
map<string, int> cache2;

class CaveValve {
    private:
        string name;
        bool isOpen;
        int flow;
        vector<string> neighbors;

    public:
        CaveValve(string myName, int myFlow, vector<string> myNeighbors) {
            name = myName;
            flow = myFlow;
            neighbors = myNeighbors;
            isOpen = false;
        }

        bool isValveOpen() {
            return isOpen;
        }

        void openValve() {
            isOpen = true;
        }

        void closeValve() {
            isOpen = false;
        }

        int getFlow() {
            return flow;
        }

        vector<string> getNeighbors() {
            return neighbors;
        }

        void print() {
            cout << name << " ";
            cout << flow << " ";
            cout << isOpen << " ";
            for (string s : neighbors) {
                cout << s << ", ";
            }
            cout << "\n";
        }
};

vector<string> getInput() {
    ifstream myfile ("Day16/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}



string getKey(string location, int minutes, int amt_to_release, map<string, CaveValve> valves, int other_players) {
    string k = location+","+to_string(minutes)+","+to_string(amt_to_release)+","+to_string(other_players);
    map<string, CaveValve>::iterator it;
    for (it = valves.begin(); it != valves.end(); it++)
    {
        if (it->second.getFlow()>0) {
            k = k + it->first + ":" + to_string(it->second.isValveOpen()) + ",";
        }
    }
    return k;
}

string getKey2(string location, string elephantLocation, int minutes, int amt_to_release, map<string, CaveValve> valves) {
    string k = location+","+elephantLocation+","+to_string(minutes)+","+to_string(amt_to_release)+",";
    map<string, CaveValve>::iterator it;
    for (it = valves.begin(); it != valves.end(); it++)
    {
        k = k + it->first + ":" + to_string(it->second.isValveOpen()) + ",";
    }
    return k;
}

bool allFlowOpen(map<string, CaveValve> valves) {
    map<string, CaveValve>::iterator it;
    for (it = valves.begin(); it != valves.end(); it++)
    {
        if (it->second.getFlow() > 0 && !it->second.isValveOpen()) 
        {
            return false;
        }
    }
    return true;
}
int maxAmtReleasable(string location, int minutes, int amt_to_release, map<string, CaveValve>& valves, int other_players) {
    if (auto cache_hit = cache.find(getKey(location, minutes, amt_to_release, valves, other_players)); cache_hit != cache.end()) {
        // cout << getKey(location, minutes, amt_to_release, valves) << "\n";
        if (other_players>0) {
            cout << "CACHE HIT " << other_players << " \n";
        }
        return cache_hit->second;
    } else {
        if (other_players>0) {
            cout << "CACHE miss " << other_players << " \n";
        }
    }
    if (minutes == 0) {
        // cout << getKey(location, minutes, amt_to_release, valves, other_players) << "\n";
        if (other_players<=0) {
            return 0;
        } else {
            cout << "RECURSING PLAYER\n";
            return maxAmtReleasable("AA",26,amt_to_release, valves, other_players-1);
        }
    }
    if (other_players==0 && allFlowOpen(valves)) {
        cache[getKey(location, minutes, amt_to_release, valves, other_players)] = 0; // minutes*amt_to_release;
        // cout << getKey(location, minutes, amt_to_release, valves) << "\n";
        return 0; //minutes*amt_to_release;
    }
    // best I can do with the rest of my minutes
    int max = 0;
    // stay put
    int val;
    // int val = maxAmtReleasable(location, minutes - 1, amt_to_release, valves);
    // max = val>max?val:max;

    
    for (string n : valves.at(location).getNeighbors()) {
        //cout << "Moving to " << n << "\n";
        val = maxAmtReleasable(n, minutes-1, amt_to_release, valves, other_players);
        max = val>max?val:max;
    }
    if (!valves.at(location).isValveOpen() && valves.at(location).getFlow() >0) {
        //cout << "Opening valve " << location << "\n";
        valves.at(location).openValve();
        val = (minutes-1) * valves.at(location).getFlow() + maxAmtReleasable(location, minutes - 1, amt_to_release + valves.at(location).getFlow(), valves, other_players);
        if (val>max) {
            max = val;
        }
        valves.at(location).closeValve();
        
    }
    // cout << "Returning " << max + amt_to_release << "\n";
    cache[getKey(location, minutes, amt_to_release, valves, other_players)] = max;
    // cout << getKey(location, minutes, amt_to_release, valves) << "\n";
    return max; //+ amt_to_release;
}

/*int maxAmtReleasable2a(string location, int minutes, int amt_to_release, map<string, CaveValve>& valves) {
    if (auto cache_hit = cache.find(getKey(location, minutes, amt_to_release, valves)); cache_hit != cache.end()) {
        // cout << getKey(location, minutes, amt_to_release, valves) << "\n";
        return cache_hit->second;
    }
    if (minutes == 0) {
        cout << getKey(location, minutes, amt_to_release, valves) << "\n";
        return 0;
    }
    if (allFlowOpen(valves)) {
        cache[getKey(location, minutes, amt_to_release, valves)] = minutes*amt_to_release;
        // cout << "A\n";
        return minutes*amt_to_release;
    }
    // best I can do with the rest of my minutes
    int max = 0;
    // stay put
    int val;
    // int val = maxAmtReleasable(location, minutes - 1, amt_to_release, valves);
    // max = val>max?val:max;

    
    for (string n : valves.at(location).getNeighbors()) {
        //cout << "Moving to " << n << "\n";
        val = maxAmtReleasable(n, minutes-1, amt_to_release, valves);
        max = val>max?val:max;
    }
    if (!valves.at(location).isValveOpen() && valves.at(location).getFlow() >0) {
        //cout << "Opening valve " << location << "\n";
        valves.at(location).openValve();
        val = maxAmtReleasable(location, minutes - 1, amt_to_release + valves.at(location).getFlow(), valves);
        if (val>max) {
            max = val;
        }
        valves.at(location).closeValve();
        
    }
    // cout << "Returning " << max + amt_to_release << "\n";
    cache[getKey(location, minutes, amt_to_release, valves)] = max + amt_to_release;
    // cout << getKey(location, minutes, amt_to_release, valves) << "\n";
    return max + amt_to_release;
}



int maxAmtReleasable2(string location, string elephantLocation, int minutes, int amt_to_release, map<string, CaveValve> valves) {
    if (auto cache_hit = cache2.find(getKey2(location, elephantLocation, minutes, amt_to_release, valves)); cache_hit != cache2.end()) {
        cout << "CACHE HIT!\n";
        return cache_hit->second;
    }
    if (minutes == 0) {
        return 0;
    }
    if (allFlowOpen(valves)) {
        cache2[getKey2(location, elephantLocation, minutes, amt_to_release, valves)] = minutes*amt_to_release;
        return minutes*amt_to_release;
    }
    // best I can do with the rest of my minutes
    int max = 0;
    // stay put
    int val;

    // I'll open mine and elephant moves
    if (!valves.at(location).isValveOpen() && valves.at(location).getFlow() >0) {
        //cout << "Opening valve " << location << "\n";
        valves.at(location).openValve();
        for (string e : valves.at(elephantLocation).getNeighbors()) {
            val = maxAmtReleasable2(location, e, minutes - 1, amt_to_release + valves.at(location).getFlow(), valves);
            max = val>max?val:max;
        }
        valves.at(location).closeValve();
    }
    // Elephant Opens and I move
    if (!valves.at(elephantLocation).isValveOpen() && valves.at(elephantLocation).getFlow() >0) {
        //cout << "Opening valve " << location << "\n";
        valves.at(elephantLocation).openValve();
        for (string m : valves.at(location).getNeighbors()) {
            val = maxAmtReleasable2(m, elephantLocation, minutes - 1, amt_to_release + valves.at(elephantLocation).getFlow(), valves);
            max = val>max?val:max;
        }
        valves.at(location).closeValve();
    }

    // both open
     if (!valves.at(elephantLocation).isValveOpen() && valves.at(elephantLocation).getFlow() >0 && !valves.at(location).isValveOpen() && valves.at(location).getFlow() >0) {
        valves.at(location).openValve();
        valves.at(elephantLocation).openValve();
        val = maxAmtReleasable2(location, elephantLocation, minutes - 1, amt_to_release + valves.at(elephantLocation).getFlow() + + valves.at(location).getFlow(), valves);
        max = val>max?val:max;
     }
    // both move
    for (string m : valves.at(location).getNeighbors()) {
        for (string e : valves.at(location).getNeighbors()) {
        //cout << "Moving to " << n << "\n";
            val = maxAmtReleasable2(m, e, minutes-1, amt_to_release, valves);
            max = val>max?val:max;
        }
    }
    cout << "Returning " << max + amt_to_release << "\n";
    cache2[getKey2(location, elephantLocation, minutes, amt_to_release, valves)] = max + amt_to_release;
    return max + amt_to_release;
}*/

int Part1() {
    map<string, CaveValve> valves;
    for(string s : getInput()) {
        if (strcmp("",s.c_str()) == 0) { continue; }
        string name = static_cast<vector<string>>(absl::StrSplit(s,' '))[1];
        string afterEqual = static_cast<vector<string>>(absl::StrSplit(s,'='))[1];
        int flow = atoi(static_cast<vector<string>>(absl::StrSplit(afterEqual,';'))[0].c_str());
        vector<string> vnstr = absl::StrSplit(s,"valves ");
        vector<string> neighbors = absl::StrSplit(vnstr[1], ", ");
        CaveValve v = CaveValve(name, flow, neighbors);
        // v.print();
        valves.insert(pair<string, CaveValve>(name, CaveValve(name, flow, neighbors)));
    }
    return maxAmtReleasable("AA",30,0,valves,0);
}

int Part2() {
    map<string, CaveValve> valves;
    for(string s : getInput()) {
        if (strcmp("",s.c_str()) == 0) { continue; }
        string name = static_cast<vector<string>>(absl::StrSplit(s,' '))[1];
        string afterEqual = static_cast<vector<string>>(absl::StrSplit(s,'='))[1];
        int flow = atoi(static_cast<vector<string>>(absl::StrSplit(afterEqual,';'))[0].c_str());
        vector<string> vnstr = absl::StrSplit(s,"valves ");
        vector<string> neighbors = absl::StrSplit(vnstr[1], ", ");
        CaveValve v = CaveValve(name, flow, neighbors);
        // v.print();
        valves.insert(pair<string, CaveValve>(name, CaveValve(name, flow, neighbors)));
    }
    return maxAmtReleasable("AA",26,0,valves,1);

}
// Driver Code
int main()
{
    // std::cout << "Part 1 " << Part1() << "\n";
    std::cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
