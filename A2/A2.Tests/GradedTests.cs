using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TestCommon;
using System.Linq;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        public static void StressTest(int N,int M)
        {
            long n,result1,result2;
            Random r = new Random();
            Q1NaiveMaxPairWise q1 = new Q1NaiveMaxPairWise("Stress test Q1");
            Q2FastMaxPairWise q2 = new Q2FastMaxPairWise("Stress test Q2");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (true && sw.ElapsedMilliseconds < 5000)
            {
                n = r.Next(2,N);
                long[] A = new long[n];
                for (int i = 0; i < n; i++)
                    A[i] = r.Next(0,M);
                for (int i = 0; i < n; i++)
                    Console.Write(A[i] + " ");
                Console.WriteLine();
                result1 = q1.Solve(A);
                result2 = q2.Solve(A);
                if (result1 == result2)
                    System.Console.WriteLine("OK");
                else
                {
                    System.Console.WriteLine("Wrong answer: " + result1 + result2);
                    return;
                }
            }
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
            StressTest(10,7);
            // Assert.Inconclusive();
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}