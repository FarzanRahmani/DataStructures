using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        private class VaI
        {
        public int index;
        public double VpU;

            public VaI(int index, double vpU)
            {
                this.index = index;
                VpU = vpU;
            }
        }
        private static double getOptimalValue(int n,double capacity, double[] values, double[] weights) {
            double value = 0;
            //write your code here
            // (double VpU,int index)[] ValueperUnit = new (double VpU,int index)[n];
            VaI[] ValueperUnit = new VaI[n];
            for (int i = 0; i < n; i++)
            {
                // ValueperUnit[i] = ((values[i] / weights[i]),i);
                ValueperUnit[i] = new VaI(i,(values[i] / weights[i]));
            }
            ValueperUnit = ValueperUnit.OrderByDescending(t => t.VpU).ToArray();

            double a;
            for (int i = 0; i < n; i++)
            {
                if (capacity == 0)
                    return value;
                a = System.Math.Min(capacity,weights[ValueperUnit[i].index]);
                value += a*ValueperUnit[i].VpU;
                weights[ValueperUnit[i].index] -= a;
                capacity -= a;
            }
            return value;
        }
        
        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            // values.Select(l => (double)l).ToArray();
            return (long)getOptimalValue(values.Length,capacity,values.Select(l => (double)l).ToArray(),weights.Select(l => (double)l).ToArray());
            // throw new NotImplementedException();
        }


        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;

    }
}
