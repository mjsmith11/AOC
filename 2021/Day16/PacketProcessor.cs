public class PacketProcessor {
    public string data;
    public long versionSum;
    public long value;

    public PacketProcessor(string data) {
        this.data = data;
        versionSum = 0;
    }

    public int process(int currentIndex) {
        int initCurrentIndex = currentIndex;
        long version = binToLong(data.Substring(currentIndex,3));
        currentIndex += 3;
        long type = binToLong(data.Substring(currentIndex,3));
        currentIndex += 3;
        
        versionSum += version;
        if (type == 4) {
            string literalStr = "";
            bool hasNext = true;
            while(hasNext) {
                hasNext = data.Substring(currentIndex,1)=="1";
                literalStr = literalStr + data.Substring(currentIndex+1,4);
                currentIndex += 5;
            }
            long literalInt = binToLong(literalStr);
            value = literalInt;
        } else {
            List<long> subvalues = new List<long>();
            long lengthTypeId = binToLong(data.Substring(currentIndex,1));
            currentIndex++;
            if(lengthTypeId==0) {
                long totalLength = binToLong(data.Substring(currentIndex,15));
                currentIndex += 15;
                int targetIndex = currentIndex + (int)totalLength;
                while(currentIndex < targetIndex) {
                    currentIndex += process(currentIndex);
                    subvalues.Add(value);
                }
            } else if (lengthTypeId==1) {
                long numSubpackets = binToLong(data.Substring(currentIndex,11));
                currentIndex += 11;
                for(int i=0;i<numSubpackets;i++) {
                    currentIndex += process(currentIndex);
                    subvalues.Add(value);
                }
            }
            if (type==0) {
                value = subvalues.Sum(x => x);
            } else if (type==1) {
                long product = 1;
                foreach(long l in subvalues) {
                    product *= l;
                }
                value =product;
            } else if (type==2) {
                value = subvalues.Min(x => x);
            } else if (type ==3) {
                value = subvalues.Max(x => x);
            } else if (type == 5) {
                value = (subvalues[0]>subvalues[1]?1:0);
            } else if (type == 6) {
                value = (subvalues[0]<subvalues[1]?1:0);
            } else if (type == 7) {
                value = (subvalues[0]==subvalues[1]?1:0);
            }
        }
        return currentIndex-initCurrentIndex;
    }
    private long binToLong(string bin) {
        long num = 0;
        for(int i=0; i<bin.Length; i++) {
            int index = bin.Length - 1 - i;
            if (bin.Substring(index,1)=="1") {
                num += (long)Math.Pow(2,i);
            }
        }
        return num;
    }
}