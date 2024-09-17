using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q3RedBlackTree : Processor
    {
        public Q3RedBlackTree(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E2Processors.ProcessQ3RedBlackTree(inStr, Solve);

        public List<long> Solve(long n, long[] arr)
        {
            throw new NotImplementedException();
        }
    }
}
