using Microsoft.VisualStudio.TestTools.UnitTesting;
using C7;
using TestCommon;

namespace C7.Tests
{
    [DeploymentItem("TestData", "C7_TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(500)]
        public void Q1TopViewTest()
        {
            RunTest(new Q1TopView("TD1"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C7", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
