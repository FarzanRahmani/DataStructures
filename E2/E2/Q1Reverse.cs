using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q1Reverse : Processor
    {
        public Q1Reverse(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E2Processors.ProcessQ1Reverse(inStr, Solve);

        public LinkedList<long> Solve(long n, LinkedList<long> list)
        {
            Node<long> curr = list.Head;
            Node<long> next = curr.Next;
            curr.Next = null;
            while (next != null)
            {
                Node<long> tmpNext = next.Next;
                next.Next = curr;
                curr = next;
                next = tmpNext;
            }
            list.Head = curr;
            return list;
        }
    }
}
