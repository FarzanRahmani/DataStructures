using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Q2Passcode : Processor
    {
        public Q2Passcode(string testDataName) : base(testDataName)
        {
        }
        public override Action<string, string> Verifier => E2Verifiers.VerifyQ2Passcode;

        public override string Process(string inStr) => E2Processors.ProcessQ2Passcode(inStr, Solve);

        public Tuple<int,int> Solve(long n, long x, long[] a)
        {
            Dictionary<long,long> Possibles = new Dictionary<long,long>((int)n);
            for (int i = 0; i < n; i++)
            {
                if (x % a[i] == 0)
                    Possibles[i] = a[i];
            }
            foreach (var p in Possibles)
            {
                long wanted = x / p.Value;
                if (Possibles.ContainsValue(wanted))
                {
                    var Keys = Possibles.Keys;
                    foreach (var k in Keys)
                    {
                        if (Possibles[k] == wanted)
                            if (k != p.Key)
                                return new Tuple<int, int>((int)p.Key + 1,(int)k + 1);
                    }
                }
            }
            return null;
        }
    }
}
