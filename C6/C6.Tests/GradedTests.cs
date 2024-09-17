using Microsoft.VisualStudio.TestTools.UnitTesting;
using C6;
using TestCommon;

namespace C6.Tests
{
    [DeploymentItem("TestData", "C6_TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(100)]
        public void Q1CircleTest()
        {
            RunTest(new Q1Circle("TD1"));
        }

		[TestMethod(), Timeout(2000)]
        public void Q2Truckest()
        {
            RunTest(new Q2Truck("TD2"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C6", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
