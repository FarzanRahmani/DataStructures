using Microsoft.VisualStudio.TestTools.UnitTesting;
using C9;
using TestCommon;

namespace C9.Tests
{
    [DeploymentItem("TestData", "C9_TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(10000)]
        public void Q1MedianTest()
        {
            RunTest(new Q1Median("TD1"));
        }

        [TestMethod(), Timeout(10000)]
        public void Q2SnakesTest()
        {
            RunTest(new Q2Snakes("TD2"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C9", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
