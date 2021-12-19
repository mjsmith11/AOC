using System.Collections.Generic;
public class Scanner {
    public List<OrderedTriple> beacons;
    public OrderedTriple offset;
    public bool hasOffset;

    public Scanner() {
        beacons = new List<OrderedTriple>();
        hasOffset = false;
        offset = null;
    }

    public void  addOffset(List<OrderedTriple> newList, OrderedTriple offset) {
        beacons = newList;
        this.offset = offset;
        hasOffset = true;

    }
}