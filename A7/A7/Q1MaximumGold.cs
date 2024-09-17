using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        static long optimalWeight(long Weight, long[] options) {
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
            return value[Weight,options.Length];

            // backtrack
            // long[] optimalSolution = new long[options.Length+1];
            // long wBackTrack = Weight;
            // for (long i = options.Length; i > 0; i--)
            // {
            //     if(wBackTrack - options[i-1] >= 0)
            //         if (value[wBackTrack - options[i-1],i-1] + options[i-1] > value[wBackTrack,i-1])
            //         {
            //             optimalSolution[i] = 1;
            //             wBackTrack -= options[i-1]; // - weight(options[i-1])
            //         }
            //     else
            //     {
            //         optimalSolution[i] = 0;
            //     }
            // }
        }


        public long Solve(long W, long[] goldBars)
        {
            return optimalWeight(W,goldBars);
        }
    }
}
