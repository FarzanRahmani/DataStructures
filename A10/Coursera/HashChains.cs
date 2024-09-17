using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


public class HashChains {

    // store all strings in one list
    // private static List<String> elems;
    private static LinkedList<string>[] hashTable;
    // for hash function
    private static long bucketCount;
    private static long prime = 1000000007; // p
    private static long multiplier = 263; // x

    public static void Main(String[] args) {
        processQueries();
        Console.ReadKey();
    }

    private static long hashFunc(String s) {
        long hash = 0;
        for (int i = s.Length - 1; i >= 0; --i)
            hash = (hash * multiplier + s[i]) % prime;
        return hash % bucketCount;
    }

    private static Query readQuery() {
        string[] toks = Console.ReadLine().Split();
        String type = toks[0];
        if (!type.Equals("check")) {
            String s = toks[1];
            return new Query(type, s);
        } else {
            long ind = int.Parse(toks[1]);
            return new Query(type, ind);
        }
    }

    private static void writeSearchResult(bool wasFound) {
        Console.WriteLine(wasFound ? "yes" : "no");
        // Uncomment the following if you want to play with the program interactively.
        // out.flush();
    }

    public static void processQuery(Query query) {
        long hashOfS;
        LinkedList<string> ll;
        switch (query.type) {
            case "add":
                hashOfS = (((hashFunc(query.s) % prime) + prime)%prime);
                ll = hashTable[hashOfS];
                if (!ll.Contains(query.s))
                    ll.AddFirst(query.s);
                break;
                // if (!elems.contains(query.s))
                //     elems.add(0, query.s);
            case "del":
                hashOfS = (((hashFunc(query.s) % prime) + prime)%prime);
                ll = hashTable[hashOfS];
                // if (ll.Contains(query.s))
                //     ll.Remove(query.s);
                ll.Remove(query.s);
                // if (elems.contains(query.s))
                //     elems.remove(query.s);
                break;
            case "find":
                hashOfS = (((hashFunc(query.s) % prime) + prime)%prime);
                ll = hashTable[hashOfS];
                writeSearchResult(ll.Contains(query.s));
                break;
            case "check":
                ll = hashTable[query.ind];
                foreach (string s in ll)
                {
                    Console.Write(s + " ");
                }
                Console.WriteLine();
                // Uncomment the following if you want to play with the program interactively.
                // out.flush();
                break;
            default:
                throw new ArgumentException("Unknown query: " + query.type);
        }
    }

    public static void processQueries() {
        // elems = new List<string>();
        bucketCount = long.Parse(Console.ReadLine());
        hashTable = new LinkedList<string>[bucketCount];
        for (int i = 0; i < bucketCount; i++)
        {
            hashTable[i] = new LinkedList<string>();
        }
        long queryCount = long.Parse(Console.ReadLine());
        for (int i = 0; i < queryCount; ++i) {
            processQuery(readQuery());
        }
    }

    public class Query {
        public String type;
        public String s;
        public long ind;

        public Query(String type, String s) {
            this.type = type;
            this.s = s;
        }

        public Query(String type, long ind) {
            this.type = type;
            this.ind = ind;
        }
    }


}