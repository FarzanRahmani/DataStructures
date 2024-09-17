using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;



public class HashSubstring {

    public static void Main(String[] args) {
        printOccurrences(getOccurrences(readInput()));
    }

    private static Data readInput() {
        String pattern = Console.ReadLine();
        String text = Console.ReadLine();
        return new Data(pattern, text);
    }

    private static void printOccurrences(List<long> ans) {
        foreach (long an in ans)
            Console.Write(an + " ");
    }

    private static long PolyHash(String s, long prime , long multiplier) {
        long hash = 0;
        for (int i = s.Length - 1; i >= 0; --i)
            hash = (hash * multiplier + s[i]) % prime;
        return hash;
    }

    private static long[] PreComputeHashes(string t,int pLenght,long prime,long x)
    {
        int tLenght = t.Length;
        long[] H = new long[tLenght-pLenght+1];
        string s = t.Substring(tLenght-pLenght);
        H[tLenght-pLenght] = PolyHash(s,prime,x);
        long y = 1;
        for (int i = 1; i <= pLenght; i++)
            y = y*x % prime;
        
        y = ((y%prime) + prime)%prime;
        for (int i = tLenght-pLenght-1; i >= 0; i--)
            H[i] = ((x*H[i+1] + t[i] - y*t[i + pLenght] % prime) + prime)%prime;
            // H[i] = (x*H[i+1] + t[i] - y*t[i + pLenght] ) % prime;
        
        return H;
    }

    private static List<long> getOccurrences(Data input) {
        // String p = input.pattern, t = input.text;
        // int m = p.Length, n = t.Length;
        // List<long> occurrences = new List<long>();
        // for (int i = 0; i + m <= n; ++i) {
            // bool equal = true;
            // for (int j = 0; j < m; ++j) {
            //     if (p[j] != t[i + j]) {
            //         equal = false;
            //         break;
            //     }
	        // }
            // if (equal)
            //     occurrences.Add(i);
	    // }
        // return occurrences;
        long prime = 1000000007,x = 263;
        string p = input.pattern,t = input.text;
        int pLenght = p.Length;
        List<long> result = new List<long>();
        long pHash = ((PolyHash(input.pattern,prime,x) % prime) + prime)%prime;
        // long pHash = PolyHash(input.pattern,prime,x) % prime;
        long[] H = PreComputeHashes(t,pLenght,prime,x);
        for (int i = 0; i <= t.Length-pLenght; i++)
        {
            if (pHash != H[i])
                continue;
            bool equal = true;
            for (int j = 0; j < pLenght; ++j) 
                if (p[j] != t[i + j]) {
                    equal = false;
                    break;
                }
	        
            if (equal)
                result.Add(i);
        }
        return result;
    }

    public class Data {
        public String pattern;
        public String text;
        public Data(String pattern, String text) {
            this.pattern = pattern;
            this.text = text;
        }
    }

}