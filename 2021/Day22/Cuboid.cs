using System.Collections.Generic;
using System;

public class Cuboid {
    OrderedTriple low;
    OrderedTriple high;
    public string instruction;

    public Cuboid(OrderedTriple low, OrderedTriple high, string instruction) {
        this.low = low;
        this.high = high;
        this.instruction = instruction;
    }

    public long calculateDelta() {
        long x = high.x - low.x+1;
        long y = high.y - low.y+1;
        long z = high.z - low.z+1;
        long size = x*y*z;
        if(instruction=="on") { 
            return size; 
        }
        else { 
            return -1*size; 
        }
    }

    // evaluates a Cuboid assuming c has already been done and we are now processing this
    // the returned cuboid is what needs to be applied to make sure nothing is counted twice.
    public Cuboid intersect(Cuboid c) {
        if (low.x > c.high.x) { return null; }
        if (high.x < c.low.x) { return null; }
        if (low.y > c.high.y) { return null; }
        if (high.y < c.low.y) { return null; }
        if (low.z > c.high.z) { return null; }
        if (high.z < c.low.z) { return null; }

        int xMin = Math.Max(low.x, c.low.x);
        int xMax = Math.Min(high.x, c.high.x);

        int yMin = Math.Max(low.y, c.low.y);
        int yMax = Math.Min(high.y, c.high.y);

        int zMin = Math.Max(low.z, c.low.z);
        int zMax = Math.Min(high.z, c.high.z);

        // we have to undo what c is doing in the intersection
        string newInstruction = c.instruction=="on"?"off":"on";
        return new Cuboid(new OrderedTriple(xMin, yMin, zMin), new OrderedTriple(xMax,yMax,zMax), newInstruction);
    }

}