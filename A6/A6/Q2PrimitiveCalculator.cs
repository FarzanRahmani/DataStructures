using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) => 
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        // private static List<long> optimal_sequence(long n) {
        //     List<long> sequence = new List<long>();
        //     long[] minNumOps = new long[n+1];
        //     minNumOps[0] = 0;
        //     minNumOps[1] = 0;
        //     for (long i = 2; i <= n; i++)
        //     {
        //         minNumOps[i] = minNumOps[i-1] + 1; // +1

        //         if (i % 2 == 0) // /2
        //             if (minNumOps[i / 2] + 1  < minNumOps[i])
        //                 minNumOps[i] = minNumOps[i / 2] + 1;

        //         if (i % 3 == 0) // /3
        //             if (minNumOps[i / 3] + 1  < minNumOps[i])
        //                 minNumOps[i] = minNumOps[i / 3] + 1;
        //     }

        //     sequence.Add(n);
        //     while (n > 1)
        //     {
        //         long Op1 = long.MaxValue,Op3 = long.MaxValue,Op2 = long.MaxValue;
        //         Op1 = minNumOps[n-1];
        //         if ( n%2 == 0)
        //             Op2 = minNumOps[n / 2];
        //         if ( n%3 == 0)
        //             Op3 = minNumOps[n / 3];
                
        //         if (Op1 < Op2)
        //             if (Op1 < Op3)
        //                 {
        //                     sequence.Add(n-1);
        //                     n--;
        //                 }
        //             else
        //                 {
        //                     sequence.Add(n / 3);
        //                     n /= 3;
        //                 }
        //         else
        //             if (Op2 < Op3)
        //             {
        //                 sequence.Add(n / 2);
        //                 n /= 2;
        //             }
        //             else
        //             {
        //                 sequence.Add(n / 3);
        //                 n /= 3;
        //             }
        //     }

        //     sequence.Reverse();
        //     return sequence;
        // }


        public long[] Solve(long n)
        {
            // return optimal_sequence(n).ToArray();
            List<long> sequence = new List<long>();
            long[] minNumOps = new long[n+1];
            minNumOps[0] = 0;
            minNumOps[1] = 0;
            for (long i = 2; i <= n; i++)
            {
                minNumOps[i] = minNumOps[i-1] + 1; // +1

                if (i % 2 == 0) // /2
                    if (minNumOps[i / 2] + 1  < minNumOps[i])
                        minNumOps[i] = minNumOps[i / 2] + 1;

                if (i % 3 == 0) // /3
                    if (minNumOps[i / 3] + 1  < minNumOps[i])
                        minNumOps[i] = minNumOps[i / 3] + 1;
            }

            sequence.Add(n);
            while (n > 1)
            {
                long Op1 = long.MaxValue,Op3 = long.MaxValue,Op2 = long.MaxValue;
                Op1 = minNumOps[n-1];
                if ( n%2 == 0)
                    Op2 = minNumOps[n / 2];
                if ( n%3 == 0)
                    Op3 = minNumOps[n / 3];
                
                if (Op1 < Op2)
                    if (Op1 < Op3)
                        {
                            sequence.Add(n-1);
                            n--;
                        }
                    else
                        {
                            sequence.Add(n / 3);
                            n /= 3;
                        }
                else
                    if (Op2 < Op3)
                    {
                        sequence.Add(n / 2);
                        n /= 2;
                    }
                    else
                    {
                        sequence.Add(n / 3);
                        n /= 3;
                    }
            }

            sequence.Reverse();
            return sequence.ToArray();
        }
    }
}
