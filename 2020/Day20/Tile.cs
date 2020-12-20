using System;

namespace Day20 {
    class Tile {
        public int topActive;
        public int bottomActive;
        public int leftActive;
        public int rightActive;
        public int number;
        public bool used;
        public char[,] map;
    
        public Tile (string[] data) {
            used = false;
            number = int.Parse(data[0].Substring(5,4));

            topActive = 0;
            foreach(char c in data[1]) {
                if (c =='#') { topActive++; }
            }

            int dataSize = data.Length; 
            bottomActive = 0;
            foreach(char c in data[dataSize - 1]) {
                if (c == '#') { bottomActive++; }
            }

            leftActive = 0;
            rightActive = 0;
            for(int i =1; i<dataSize; i++) {
                if(data[i][0] == '#') { leftActive++; }
                if(data[i][data[i].Length - 1] == '#') { rightActive++; }
            }

            map = new char[10,10];
            for(int y=0; y<10; y++) {
                for (int x=0; x<10; x++) {
                    map[x,y] = data[y+1][x]; //+1 on y to account for tile number line
                }
            }
        }

        public void flipLR() {
            int newTop = bottomActive;
            int newBottom = topActive;
            int newLeft = rightActive;
            int newRight = leftActive;

            topActive = newTop;
            bottomActive = newBottom;
            leftActive = newLeft;
            rightActive = newRight;

            char[,] newmap = new char[10,10];
            for(int y=0; y<10; y++) {
                for(int x=0; x<10; x++) {
                    newmap[x,y] = map[9-x,y];
                }
            }
            map = newmap;
        }

        public void clockwiseRotate() {
            int newTop = leftActive;
            int newBottom = rightActive;
            int newLeft = bottomActive;
            int newRight = topActive;

            topActive = newTop;
            bottomActive = newBottom;
            leftActive = newLeft;
            rightActive = newRight;

            char[,] newmap = new char[10,10];
            for(int y=0; y<10; y++) {
                for(int x=0; x<10; x++) {
                    newmap[x,y] = map[y,9-x];
                }
            }
            map = newmap;
        }    
    }
}