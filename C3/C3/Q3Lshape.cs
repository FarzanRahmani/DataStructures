using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C3
{
    public class Q3Lshape : Processor
    {
        public Q3Lshape(string testDataName) : base(testDataName)
        {}

	public override Action<string, string> Verifier => LshapeVerifier.Verify;

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(lines[0]);
            var point = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray();
            var a = point[0];
            var b = point[1];
            var result = Solve(n, a, b);
            return string.Join("\n", result.Select(row => string.Join(" ", row)));
        }
        public static long[][] Solve(int n,int a, int b)
        {
            throw new NotImplementedException();
            //Code Here!!
        }
    }
}
