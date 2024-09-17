using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q4ChainingProfiler : Processor
    {
        public Q4ChainingProfiler(string testDataName) : base(testDataName)
        {
        }

        /// <summary>
        /// FNV-1a - (Fowler/Noll/Vo) is a fast, consistent, non-cryptographic hash algorithm with good dispersion. (see http://isthe.com/chongo/tech/comp/fnv/#FNV-1a)
        /// </summary>
        private static int GetFNV1aHashCode(string str, int bucketCount)
        {
            if (str == null)
                return 0;
            var length = str.Length;
            int hash = length;
            for (int i = 0; i != length; ++i)
                hash = (hash ^ str[i]) * 16777619;
            return (hash % bucketCount + bucketCount) % bucketCount;
        }

        public override string Process(string inStr) => E2Processors.ProcessQ4ChainingProfiler(inStr, Solve);

        // Returns:
        //      A Tuple:
        //          Item1 = Adjusted sample variance of the chain lengths
        //          Item2 = Hash table, a list of length bucketCount
        public Tuple<double, List<LinkedList<string>>> Solve(int n, int bucketCount, string[] s)
        {
            List<LinkedList<string>> hashTable = new List<LinkedList<string>>(bucketCount);
            for (int i = 0; i < bucketCount; i++)
            {
                hashTable.Add(new LinkedList<string>());
            }
            for (int i = 0; i < n; i++)
            {
                string tmp = s[i];
                int HashTmp = GetFNV1aHashCode(tmp,bucketCount);
                hashTable[HashTmp].AddLast(tmp);
            }
            double ave = (double)n / (double)bucketCount;
            double sum = 0;
            for (int i = 0; i < bucketCount; i++)
            {
                double size = hashTable[i].Size();
                sum += Math.Pow(size - ave,2);
            }
            double variance = sum / (double)(bucketCount - 1);
            return new Tuple<double, List<LinkedList<string>>>(variance,hashTable);
        }
    }
}
