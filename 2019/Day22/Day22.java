import java.util.ArrayList;
import java.util.Collections;
import java.math.BigInteger; 
public class Day22 {

    public static void main(String[] args) {
        String input = "deal with increment 74\ndeal into new stack\ndeal with increment 67\ncut 6315\ndeal with increment 15\ncut -8049\ndeal with increment 69\ncut 2275\ndeal with increment 25\ncut 4811\ndeal with increment 47\ncut -9792\ndeal with increment 26\ncut -3014\ndeal with increment 47\ncut -1093\ndeal with increment 39\ncut -5322\ndeal with increment 14\ncut -7375\ndeal with increment 16\ncut 9627\ndeal into new stack\ncut 1632\ndeal into new stack\ncut -2904\ndeal with increment 69\ncut -3328\ndeal with increment 60\ncut 7795\ndeal into new stack\ndeal with increment 37\ncut -4238\ndeal with increment 19\ncut -3170\ndeal with increment 45\ncut 8631\ndeal with increment 64\ncut -2380\ndeal with increment 59\ncut -2802\ndeal with increment 19\ncut -3369\ndeal with increment 45\ndeal into new stack\ndeal with increment 71\ncut 5452\ndeal with increment 73\ncut -6609\ndeal with increment 33\ncut 1892\ndeal with increment 5\ncut 1395\ndeal into new stack\ncut -8514\ndeal with increment 46\ndeal into new stack\ndeal with increment 15\ncut 3963\ndeal with increment 2\ncut -2965\ndeal into new stack\ncut 640\ndeal with increment 13\ncut 8889\ndeal with increment 62\ncut 8331\ndeal with increment 49\ncut 6169\ndeal with increment 71\ndeal into new stack\ndeal with increment 33\ncut 6342\ndeal with increment 52\ncut 2875\ndeal with increment 39\ncut 4283\ndeal with increment 19\ncut 4102\ndeal with increment 57\ndeal into new stack\ncut -7801\ndeal with increment 38\ncut 4273\ndeal with increment 58\ncut -2971\ndeal with increment 46\ndeal into new stack\ncut 8043\ndeal with increment 52\ncut -7108\ndeal with increment 21\ncut 507\ndeal with increment 70\ncut -8658\ndeal with increment 64\ncut 7213\ndeal into new stack\ndeal with increment 61\ncut 9439";
        String[] lines = input.split("\n", 150);
        ArrayList<Integer> deck = new ArrayList<Integer>();
        int deckSize = 10007;
        for(int i=0; i<deckSize; i++) {
            deck.add(i);
        }
        for(int i = 0; i<lines.length; i++){
            String[] pieces = lines[i].split(" ", 5);
            if (pieces[0].equals("cut")) {
                deck = cut(deck, Integer.parseInt(pieces[1]));
            } else if (pieces[1].equals("into")) {
                deal(deck);
            } else {
                deck = dealWithInc(deck, Integer.parseInt(pieces[3]));
            }
        }
        for(int i=0; i<deckSize; i++) {
            if(deck.get(i) == 2019) {
                System.out.println("Part 1: " + i);
            }
        }
        // part 2 - attempting to collapse all shuffles into one operation
        // values a and b used by accompanying python script
        BigInteger MOD  = new BigInteger("119315717514047");
        BigInteger REP  = new BigInteger("101741582076661");
        
        BigInteger a  = new BigInteger("1");
        BigInteger b  = new BigInteger("0");
        
        for(int i = 0; i<lines.length; i++){
            String[] pieces = lines[i].split(" ", 5);
            if (pieces[0].equals("cut")) {
                b = b.subtract(BigInteger.valueOf(Integer.parseInt(pieces[1])));
            } else if (pieces[1].equals("into")) {
                a = a.multiply(BigInteger.valueOf(-1));
                b = b.multiply(BigInteger.valueOf(-1));
                b = b.subtract(BigInteger.valueOf(1));
            } else {
                a = a.multiply(BigInteger.valueOf(Integer.parseInt(pieces[3])));
                b = b.multiply(BigInteger.valueOf(Integer.parseInt(pieces[3])));
            }
        }
        a = a.mod(MOD);
        b = b.mod(MOD);
        
        BigInteger inv_a = a.modPow(MOD.subtract(BigInteger.valueOf(2)),MOD);
        BigInteger inv_b = b.multiply(BigInteger.valueOf(-1)).multiply(inv_a).mod(MOD);

        BigInteger[][] M = new BigInteger[2][2];
        M[0][0] = inv_a;
        M[1][0] = BigInteger.valueOf(0);
        M[0][1] = inv_b;
        M[1][1] = BigInteger.valueOf(1);
        
        BigInteger[][] Mexp = mat_pow(M, REP, MOD);
        
        BigInteger[][] v = new BigInteger[2][1];
        
        v[0][0] = BigInteger.valueOf(2020);
        v[1][0] = BigInteger.valueOf(1);
        
        System.out.println("Part 2: " + mat_mult(Mexp, v, MOD)[0][0]);
    }

    
    public static void deal(ArrayList<Integer> deck) {
        Collections.reverse(deck);
    }
    public static ArrayList<Integer> cut(ArrayList<Integer> deck, int amount)
    {
        ArrayList<Integer> newDeck = new ArrayList<Integer>();
        if (amount > 0) {
            for (int i = amount; i<deck.size(); i++) {
                newDeck.add(deck.get(i));
            }
            for(int i=0; i<amount; i++) {
                newDeck.add(deck.get(i));
            }
        } else {
            amount *= -1;
            for (int i = (deck.size() - amount); i < deck.size(); i++) {
                newDeck.add(deck.get(i));
            }
            for (int i=0; i<(deck.size() - amount); i++) {
                newDeck.add(deck.get(i));
            }
        }
        return newDeck;
    }
    public static ArrayList<Integer> dealWithInc(ArrayList<Integer> deck, int inc)
    {
        ArrayList<Integer> newDeck = new ArrayList<Integer>();
        for (int i=0; i<deck.size(); i++) {
            newDeck.add(0);
        }
        newDeck.set(0, deck.get(0));
        int pointer = 0;
        for(int i=1; i<deck.size(); i++) {
            pointer += inc;
            if (pointer>=deck.size()) {
                pointer -= deck.size();
            }
            newDeck.set(pointer, deck.get(i));
        }
        return newDeck;
    }
    public static BigInteger[][] mat_mult(BigInteger[][] A, BigInteger[][] B, BigInteger MOD)
    {
        int N = A.length;
        int M = B[0].length;
        
        int L = A[0].length;
        BigInteger[][] C = new BigInteger[N][M];
        
        for(int i=0; i<N; i++) {
            for(int j = 0; j<M; j++) {
                BigInteger acc = BigInteger.valueOf(0);
                for(int k=0; k<L; k++) {
                    acc = acc.add(A[i][k].multiply(B[k][j]));
                }
                acc = acc.mod(MOD);
                C[i][j] = acc;
            }
        }
        return C;
    }

    public static BigInteger[][] mat_pow(BigInteger[][] A, BigInteger exp, BigInteger mod) {
        BigInteger[][] res = new BigInteger[2][2];
        res[0][0] = BigInteger.valueOf(1);
        res[1][0] = BigInteger.valueOf(0);
        res[0][1] = BigInteger.valueOf(0);
        res[1][1] = BigInteger.valueOf(1);
        while (exp.compareTo(BigInteger.valueOf(0)) == 1) {
            if (exp.mod(BigInteger.valueOf(2)).compareTo(BigInteger.valueOf(1)) == 0) {
                res = mat_mult(res, A, mod);
            }
            A = mat_mult(A, A, mod);
            exp = exp.divide(BigInteger.valueOf(2));
        }
        return res;
    }
}