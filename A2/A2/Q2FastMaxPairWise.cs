using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => long.Parse(s))
                    .ToArray()).ToString();

        public virtual long Solve(long[] numbers)
        {
            long index1 = 0;
            int n = numbers.Length;
            for (long i = 0; i < n; i++)
                if (numbers[i] > numbers[index1])
                    index1 = i;
            long index2 = 0;
            if (index1 == 0)
                index2 = 1;
            for (long i = 0; i < n; i++)
                if (numbers[i] > numbers[index2] && i != index1)
                    index2 = i;
            long ans = ((long)numbers[index1]) * ((long)numbers[index2]); 
            return ans;
            // int n = numbers.Length;
            // long[] ans = numbers.OrderBy(n => n).ToArray();
            // return ans[n-1]*ans[n-2];
        }
    }
}
