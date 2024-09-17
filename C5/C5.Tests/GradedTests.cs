using Microsoft.VisualStudio.TestTools.UnitTesting;
using C5;
using TestCommon;

namespace C5.Tests
{
    [DeploymentItem("TestData", "C5_TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(5000)]
        public void Q1StairsTest()
        {
            RunTest(new Q1Stairs("TD1"));
        }

		[TestMethod(), Timeout(5000)]
        public void Q2LCSTest()
        {
            RunTest(new Q2LCS("TD2"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C5", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
