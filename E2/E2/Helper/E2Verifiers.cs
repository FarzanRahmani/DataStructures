using System;
using System.Collections.Generic;
using System.IO;

namespace E2
{
    public class E2Verifiers
    {
        public static void VerifyQ2Passcode(
            string inFileName,
            string strResult)
        {
            var input = E2Processors.GetInputQ2Passcode(File.ReadAllText(inFileName));
            var outFileName = inFileName.Replace("In", "Out");
            var solveOutput = E2Processors.GetOutputQ2Passcode(strResult);
            var expectedOutput = E2Processors.GetOutputQ2Passcode(File.ReadAllText(outFileName));
            
            if (solveOutput.indices == null)
            {
                if (expectedOutput.indices == null)
                {
                    // ok
                    return;
                } else
                {
                    int idx_it = expectedOutput.indices.Item1;
                    int idx_jt = expectedOutput.indices.Item2;
                    throw new Exception($"Wrong result: received null but a[{idx_it}] * a[{idx_jt}] = {input.x} (one-based indices)");
                }
            }

            int idx_i = solveOutput.indices.Item1;
            int idx_j = solveOutput.indices.Item2;

            if (idx_i < 1 || idx_i > input.n)
            {
                throw new Exception($"Invalid index: {idx_i}, valid range [1, {input.n}]");
            }
            if (idx_j < 1 || idx_j > input.n)
            {
                throw new Exception($"Invalid index: {idx_j}, valid range [1, {input.n}]");
            }
            if (idx_i == idx_j)
            {
                throw new Exception($"Invalid indexes: first index {idx_i} cannot be equal to the second index {idx_j}");
            }

            long product = input.a[idx_i - 1] * input.a[idx_j - 1];

            // check overflow
            if (product / input.a[idx_i - 1] != input.a[idx_j - 1])
            {
                throw new Exception($"Invalid indexes: ({idx_i}, {idx_j}), product is greater than {input.x}");
            }

            if (product != input.x)
            {
                throw new Exception($"Wrong product: expected = {input.x} | actual = {product}");
            }
        }


        public static void VerifyQ5PortalsA(
            string inFileName,
            string strResult)
        {
            var outFileName = inFileName.Replace("In", "Out");
            int expectedOutput = int.Parse(File.ReadAllText(outFileName).Trim());
            string expectedStr = expectedOutput == 0 ? "YES" : "NO";

            if (strResult != expectedStr)
            {
                throw new Exception($"Wrong answer: Expected <{expectedStr}>, Actual <{strResult}>");
            }
        }
    }
}
