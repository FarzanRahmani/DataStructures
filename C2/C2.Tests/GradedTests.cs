using Microsoft.VisualStudio.TestTools.UnitTesting;
using C2;
using TestCommon;

namespace C2.Tests
{
    [DeploymentItem("TestData", "C2_TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(2000)]
        public void Q1FlowerShopTest()
        {
            RunTest(new Q1FlowerShop("TD1"));
        }

        [TestMethod(), Timeout(2000)]
        public void Q2ChocolateTest()
        {
            RunTest(new Q2Chocolate("TD2"));
        }

        [TestMethod(), Timeout(2000)]
        public void Q3ConnectivityTest()
        {
            Assert.Inconclusive();
            RunTest(new Q3Connectivity("TD3"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C2", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
