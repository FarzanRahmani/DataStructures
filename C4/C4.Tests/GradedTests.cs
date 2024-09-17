using Microsoft.VisualStudio.TestTools.UnitTesting;
using C4;
using TestCommon;

namespace C4.Tests
{
    [DeploymentItem("TestData", "C4_TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(150)]
        public void Q1ToysTest()
        {
            RunTest(new Q1Toys("TD1"));
        }

		[TestMethod(), Timeout(1500)]
        public void Q2FroggieTest()
        {
            RunTest(new Q2Froggie("TD2"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C4", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
