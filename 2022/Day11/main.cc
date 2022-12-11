// C++ program to demonstrate the
// boilerplate code
#include <iostream>
#include <string>
#include <fstream>
#include <vector>

using namespace std;

class Monkey {
    private:
        int num_inspected;
        int num_if_true;
        int num_if_false;
        vector<__int128_t> items;
        __int128_t add_amt;
        __int128_t mult_amt;
        __int128_t mod;

    public:
        Monkey(int myTrue, int myFalse, __int128_t myAdd, __int128_t myMult, __int128_t myMod) {
            num_inspected = 0;
            num_if_false = myFalse;
            num_if_true = myTrue;
            add_amt = myAdd;
            mult_amt = myMult;
            mod = myMod;
            items = vector<__int128_t>();
        }

        void addItem(__int128_t item) {
            items.push_back(item);
        }

        int getNumInspected() {
            return num_inspected;
        }

        void processItems(vector<Monkey*> monkeys) {
            for(__int128_t item : items) {
                num_inspected++;
                __int128_t multiplier = mult_amt==-1 ? item : mult_amt;
                item *= multiplier;
                item += add_amt;
                item /= 3;
                if (item % mod == 0) {
                    monkeys[num_if_true]->addItem(item);
                } else {
                    monkeys[num_if_false]->addItem(item);
                }
            }
            items = vector<__int128_t>();
        }
        // not sure why it's wrong for sample input
        void processItems2(vector<Monkey*> monkeys) {
            for(__int128_t item : items) {
                num_inspected++;
                __int128_t multiplier = mult_amt==-1 ? item : mult_amt;
                if (multiplier != 1) {
                    item *= multiplier;
                }
                if (add_amt != 0) {
                    item += add_amt;
                }
                //item %= 96577; // LCMs of divisors
                item %= 9699690;
                if (item % mod == 0) {
                    monkeys[num_if_true]->addItem(item);
                } else {
                    monkeys[num_if_false]->addItem(item);
                }
            }
            items = vector<__int128_t>();
        }
};

vector<Monkey*> getSampleInput() {
    vector<Monkey*> v;
    
    Monkey* m = new Monkey(2,3,0,19,23);
    m->addItem(78);
    m->addItem(98);
    v.push_back(m);

    m = new Monkey(2,0,6,1,19);
    m->addItem(54);
    m->addItem(65);
    m->addItem(75);
    m->addItem(74);
    v.push_back(m);

    m = new Monkey(1,3,0,-1,13);
    m->addItem(79);
    m->addItem(60);
    m->addItem(97);
    v.push_back(m);

    m = new Monkey(0,1,3,1,17);
    m->addItem(74);
    v.push_back(m);

    return v;
}

vector<Monkey*> getRealInput() {
    vector<Monkey*> v;
    
    Monkey* m = new Monkey(6,2,0,19,7);
    m->addItem(59);
    m->addItem(74);
    m->addItem(65);
    m->addItem(86);
    v.push_back(m);

    m = new Monkey(2,0,1,1,2);
    m->addItem(62);
    m->addItem(84);
    m->addItem(72);
    m->addItem(91);
    m->addItem(68);
    m->addItem(78);
    m->addItem(51);
    v.push_back(m);

    m = new Monkey(6,5,8,1,19);
    m->addItem(78);
    m->addItem(84);
    m->addItem(96);
    v.push_back(m);

    m = new Monkey(1,0,0,-1,3);
    m->addItem(97);
    m->addItem(86);
    v.push_back(m);

    m = new Monkey(3,1,6,1,13);
    m->addItem(50);
    v.push_back(m);

    m = new Monkey(4,7,0,17,11);
    m->addItem(73);
    m->addItem(65);
    m->addItem(69);
    m->addItem(65);
    m->addItem(51);
    v.push_back(m);

    m = new Monkey(5,7,5,1,5);
    m->addItem(69);
    m->addItem(82);
    m->addItem(97);
    m->addItem(93);
    m->addItem(82);
    m->addItem(84);
    m->addItem(58);
    m->addItem(63);
    v.push_back(m);

    m = new Monkey(3,4,3,1,17);
    m->addItem(81);
    m->addItem(78);
    m->addItem(82);
    m->addItem(76);
    m->addItem(79);
    m->addItem(80);
    v.push_back(m);

    return v;
}
void Part1() {
    vector<Monkey*> monkeys = getRealInput();
    for(int i=0; i<20; i++) {
        for(Monkey* m : monkeys) {
            m->processItems(monkeys);
        }
    }
    for(Monkey* m : monkeys) {
        cout << m->getNumInspected() << "\n";
    }
}
// doesn't work for sample input but does for real.  No idea why.
void Part2() {
    vector<Monkey*> monkeys = getRealInput();
    for(int i=0; i<10000; i++) {
        for(Monkey* m : monkeys) {
            m->processItems2(monkeys);
        }
    }
    for(Monkey* m : monkeys) {
        cout << m->getNumInspected() << "\n";
    }
}
// Driver Code
int main()
{
    Part1();
    cout << "\n";
    Part2();
    return 0;
}
