using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;
using System;
using System.Collections.Generic;

namespace E2.Tests
{
    [DeploymentItem("TestData", "E2_TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(7000)]
        public void Q1ReverseTest()
        {
            RunTest(new Q1Reverse("TD1"));
        }

        [TestMethod(), Timeout(2000)]
        public void Q2PasscodeTest()
        {
            RunTest(new Q2Passcode("TD2"));
        }

        [TestMethod(), Timeout(2000)]
        public void Q3RedBlackTreeTest()
        {
            Assert.Inconclusive();
            RunTest(new Q3RedBlackTree("TD3"));
        }
        
        [TestMethod(), Timeout(2000)]
        public void Q4ChainingProfilerTest()
        {
            RunTest(new Q4ChainingProfiler("TD4"));
        }
        
        [TestMethod(), Timeout(2000)]
        public void Q5PortalsATest()
        {
            RunTest(new Q5PortalsA("TD5"));
        }

        [TestMethod(), Timeout(5000)]
        public void Q6PortalsBTest()
        {
            RunTest(new Q6PortalsB("TD5"));
        }
        
        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("E2", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
