using Microsoft.VisualStudio.TestTools.UnitTesting;
using C1;
using TestCommon;

namespace C1.Tests
{
    [DeploymentItem("TestData", "C1_TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(2000)]
        public void Q1DoorestanTest()
        {
            RunTest(new Q1("TD1"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C1", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}