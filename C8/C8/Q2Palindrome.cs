using System;
using System.Collections.Generic;
// using System.Collections.Generic.HashSet;
using System.Collections;
using System.Text;
using System.Linq;
using TestCommon;

namespace C8
{
    public class Q2Palindrome : Processor
    {
        public Q2Palindrome(string testDataName) : base(testDataName) {}

        public override string Process(string inStr) => C8Processors.ProcessQ2Palindrome(inStr, Solve);
        
        public long Solve(long n, long x, long k)
        {
            Set[] sets = new Set[n];
            for (long i = 0; i < n; i++)
                sets[i] = new Set();
            
            for (long i = 0; i < n-k+1; i++)
                for (long start = 0; start <= k/2; start++)
                {
                    long end = k - start - 1;
                    Union(sets[start+i] , sets[end+i]);
                }
            
            HashSet<Set> disjointSets = new HashSet<Set>();
            for (int i = 0; i < n; i++)
                disjointSets.Add(sets[i].getParent());
            
            return MyPower(x,disjointSets.Count,1000000007);
        }

        public class Set {
            public Set parent;
            public int rank; // union by rank
            public Set() { // makeSet
                rank = 0;
                parent = this;
            }
            public Set getParent() { // find
                // find super parent and compress path
                if (this.parent != this)
                    this.parent = this.parent.getParent();
                
                return parent;
            }
        }

        public static void Union(Set destination, Set source) { // union
            Set realDestination = destination.getParent();
            Set realSource = source.getParent();
            if (realDestination == realSource) 
                return;
            
            // merge two components here
            // use rank heuristic
            // update maximumNumberOfRows
            if (realDestination.rank > realSource.rank ) {
                realSource.parent = realDestination;
            }
            else
            {
                realDestination.parent = realSource.parent;
                
                if (realDestination.rank == realSource.rank)
                    realSource.rank++;
            }
        }

        public static long MyPower(long n,int p, long modulo) // n^p 
        {
            long result = 1; // 
            while (p > 0)
            {
                if (p % 2 == 0)
                {
                    n = (n*n)%modulo;
                    p /= 2;
                }
                else
                {
                    result = (result*n)%modulo;
                    p--;
                }
            }
            return result % modulo;
        }
    }
}