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
    ifstream myfile ("Day07/input.txt");
    vector<string> inp;
    while(myfile) {
        string s;
        getline(myfile, s);
        inp.push_back(s);
    }
    myfile.close();
    return inp;
}
class File {
    private:
        bool is_dir;
        vector<File*> children;
        int file_size;
        File* parent;
        string name;

    public:
        // root constructor
        File() {
            is_dir = true;
            children = vector<File*>();
            file_size = 0;
            parent = NULL;
            name = "/";
        }
        // dir constructor
        File(File* myParent, string myName) {
            is_dir = true;
            children = vector<File*>();
            file_size = 0;
            parent = myParent;
            name = myName;
        }

        // file constructor
        File(int mySize, string myName) {
            is_dir = false;
            file_size = mySize;
            parent = NULL;
            name = myName;
        }

        void add_child(File* child) {
            if (is_dir) {
                children.push_back(child);
            }
        }

        File* get_parent() {
            return parent;
        }

        int get_size() {
            if (is_dir) {
                int size = 0;
                for(File* child : children) {
                    size += child->get_size();
                }
                if (size <= 100000) {
                    sum_lte_100k += size;
                }
                return size;
            } else {
                return file_size;
            }
        }

        int Part1() {
            sum_lte_100k = 0;
            get_size();
            return sum_lte_100k;
        }

        int traverseForPart2(int minSize, int current) {
            if (is_dir) {
                int my_size = get_size();
                if (my_size>=minSize && my_size < current) {
                    current = my_size;
                }
                for (File* f : children) {
                    current = f->traverseForPart2(minSize, current);
                }
            }
            return current;
        }

};

File* getDirTree() {
    File* root = new File();
    File* pwd = root;
    for(string s : getInput()) {
         if (strcmp(s.c_str(), "") == 0) { continue; }
        vector<string> words = absl::StrSplit(s,' ');
        if (strcmp(words[0].c_str(), "$") == 0) {
            if (strcmp(words[1].c_str(), "cd") == 0) {
                if (strcmp(words[2].c_str(), "..") == 0) {
                    pwd = pwd->get_parent();
                } else {
                    File* newDir = new File(pwd, words[2]);
                    pwd->add_child(newDir);
                    pwd = newDir;
                }
            } // ignore ls commands
        } else if (strcmp(words[0].c_str(), "dir") != 0) {
            pwd->add_child(new File(atoi(words[0].c_str()), words[1]));
        }
    }
    return root;
}

int Part1() {
    File* root = getDirTree();
    return root->Part1();
}

int Part2() {
    File* root = getDirTree();
    int used = root->get_size();
    int free = 70000000 - used;
    int minSizeToDelete = 30000000 - free;

    return root->traverseForPart2(minSizeToDelete, used);
}
// Driver Code
int main()
{
    cout << "Part 1 " << Part1() << "\n";
    cout << "Part 2 " << Part2() << "\n";
    
    return 0;
}
