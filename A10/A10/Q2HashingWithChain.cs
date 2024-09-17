using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class Q2HashingWithChain : Processor
    {
        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);


        public string[] Solve(long bucketCountInput, string[] commands)
        {
            int queryCnt = commands.Length;
            bucketCount = bucketCountInput;
            List<string> ans = new List<string>(queryCnt);
            processQueries(ans,queryCnt,commands);
            return ans.ToArray();


            // List<string> result = new List<string>();
            // foreach (var cmd in commands)
            // {
            //     var toks = cmd.Split();
            //     var cmdType = toks[0];
            //     var arg = toks[1];

            //     switch (cmdType)
            //     {
            //         case "add":
            //             Add(arg);
            //             break;
            //         case "del":
            //             Delete(arg);
            //             break;
            //         case "find":
            //             result.Add(Find(arg));
            //             break;
            //         case "check":
            //             result.Add(Check(int.Parse(arg)));
            //             break;
            //     }
            // }
            // return result.ToArray();
        }

        private static LinkedList<string>[] hashTable;
        // for hash function
        private static long bucketCount;
        private static long prime = 1000000007; // p
        private static long multiplier = 263; // x

        private static long hashFunc(String s) {
            long hash = 0;
            for (int i = s.Length - 1; i >= 0; --i)
                hash = (hash * multiplier + s[i]) % prime;
            return hash % bucketCount;
        }

        private static Query readQuery(string v) {
            string[] toks = v.Split();
            String type = toks[0];
            if (!type.Equals("check")) {
                String s = toks[1];
                return new Query(type, s);
            } else {
                long ind = int.Parse(toks[1]);
                return new Query(type, ind);
            }
        }

        public static void processQuery(Query query, List<string> ans) {
            long hashOfS;
            LinkedList<string> ll;
            switch (query.type) {
                case "add":
                    hashOfS = (((hashFunc(query.s) % prime) + prime)%prime);
                    ll = hashTable[hashOfS];
                    if (!ll.Contains(query.s))
                        ll.AddFirst(query.s);
                    break;
                case "del":
                    hashOfS = (((hashFunc(query.s) % prime) + prime)%prime);
                    ll = hashTable[hashOfS];
                    ll.Remove(query.s);
                    break;
                case "find":
                    hashOfS = (((hashFunc(query.s) % prime) + prime)%prime);
                    ll = hashTable[hashOfS];
                    if (ll.Contains(query.s))
                        ans.Add("yes");
                    else
                        ans.Add("no");
                    break;
                case "check":
                    ll = hashTable[query.ind];
                    string result = "";
                    foreach (string s in ll)
                        result += s + " ";
                    if (result == "")
                        {
                            ans.Add("-");
                            break;
                        }
                    result = result.TrimEnd();
                    ans.Add(result);
                    // Uncomment the following if you want to play with the program interactively.
                    // out.flush();
                    break;
                default:
                    throw new ArgumentException("Unknown query: " + query.type);
            }
        }

        public static void processQueries(List<string> ans, int queryCnt, string[] commands) {
            // elems = new List<string>();
            hashTable = new LinkedList<string>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
                hashTable[i] = new LinkedList<string>();
            
            for (int i = 0; i < queryCnt; ++i) 
                processQuery(readQuery(commands[i]),ans);
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



        // public const long BigPrimeNumber = 1000000007;
        // public const long ChosenX = 263;

        // public static long PolyHash(
        //     string str, int start, int count,
        //     long p = BigPrimeNumber, long x = ChosenX)
        // {
        //     long hash = 0;
        //     return hash;

        //     // long hash = 0;
        //     // for (int i = str.Length - 1; i >= 0; --i)
        //     //     hash = (hash * multiplier + str[i]) % prime;
        //     // return hash % bucketCount;
        // }

    }
}
