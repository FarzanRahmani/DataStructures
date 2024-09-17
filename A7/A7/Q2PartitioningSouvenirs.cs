using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        class WeightAndIndexes
        {
            public long weight;
            public long[] indexes;

            public WeightAndIndexes(long weight, long[] indexes)
            {
                this.weight = weight;
                this.indexes = indexes;
            }
        }

        static WeightAndIndexes optimalWeight(long Weight, long[] options) {
            long[,] value = new long[Weight + 1 ,  options.Length + 1];
            for (long i = 0; i <= Weight; i++)
                value[i,0] = 0;
            for (long i = 0; i < options.Length; i++) // <=
                value[0,i] = 0;
            
            for (long i = 1; i <= options.Length; i++)
            {
                for (long w = 1; w <= Weight; w++)
                {
                    value[w,i] = value[w,i-1];
                    if (options[i-1] <= w)
                    {
                        long val = value[w - options[i-1],i-1] + options[i-1]; // all are gold --> value per unit all : 1 --> value(options[i]) == weight(options[i])
                        if (value[w,i] < val)
                        {
                            value[w,i] = val;
                        }
                    }
                }
            }

            long[] optimalSolution = new long[options.Length+1];
            long wBackTrack = Weight;
            for (long i = options.Length; i > 0; i--)
            {
                if(wBackTrack - options[i-1] >= 0)
                    if (value[wBackTrack - options[i-1],i-1] + options[i-1] > value[wBackTrack,i-1])
                    {
                        optimalSolution[i] = 1;
                        wBackTrack -= options[i-1]; // - weight(options[i-1])
                    }
                    else
                    {
                        optimalSolution[i] = 0;
                    }
            }
            return new WeightAndIndexes(value[Weight,options.Length],optimalSolution);
            // return value[Weight,options.Length];
        }

        private static long partition3(long[] A) {
            long sum = A.Sum();
            if(sum % 3 != 0)
                return 0;
            long eachPerson = sum / 3;
            var Person1 = optimalWeight(eachPerson,A);
            if (Person1.weight != eachPerson)
                return 0;

            long[] inds = Person1.indexes;
            foreach (var ind in inds)
            {
                if (ind == 1)
                    A[ind-1] = 0;
            }
            A = A.Where(n => n != 0).ToArray();

            var Person2 = optimalWeight(eachPerson,A);
            if (Person2.weight != eachPerson)
                return 0;

            // -----------
            // inds = Person2.indexes;
            // foreach (var ind in inds)
            // {
            //     if (ind == 1)
            //         A[ind-1] = 0;
            // }
            // A = A.Where(n => n != 0).ToArray();

            // var Person3 = optimalWeight(eachPerson,A);
            // if (Person3.weight != eachPerson)
            //     return 0;
            // ----------------

            return 1;

            // inds = Person1.indexes;
            // for (long i = 1; i < inds.Length; i++)
            // {
            //     if (inds[i] == 1)
            //         // ListA.RemoveAt(i-1);
            //         ListA[i-1] = 0;
            // }
        }

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            if (souvenirsCount == 0)
                return 0;
            return partition3(souvenirs);
        }
    }
}
