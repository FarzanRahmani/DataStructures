using Microsoft.VisualStudio.TestTools.UnitTesting;
using E1;
using TestCommon;

namespace E1.Tests
{
    [DeploymentItem("TestData", "E1_TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(1000)]
        public void Q1PartitionTest()
        {
            RunTest(new Q1Partition("TD1"));
        }

        [TestMethod(), Timeout(5000)]
        public void Q2CarsTest()
        {
            RunTest(new Q2Cars("TD2"));
        }

        [TestMethod(), Timeout(5000)]
        public void Q3CarsTest()
        {
            Assert.Inconclusive();
            RunTest(new Q3TeamSeas("TD3"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("E1", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
