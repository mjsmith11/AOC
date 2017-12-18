using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017
{
    public class FirewallLayer
    {
        private int depth { get; }
        public int range { get; }
        private int currentLocation;
        //true for down, false for up
        private bool direction;

        public FirewallLayer(int depth, int range)
        {
            this.depth = depth;
            this.range = range;
            currentLocation = 1;
            direction = true;
        }

        public bool isAtTop()
        {
            return currentLocation == 1;
        }

        public int getSeverity()
        {
            return depth * range;
        }

        public void moveScanner()
        {
            if (range <= 1)
                return;
            if (currentLocation == 1)
                direction = true;
            if (currentLocation == range)
                direction = false;
            if (direction)
                currentLocation++;
            else
                currentLocation--;

        }
    }
}
