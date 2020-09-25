using System;
using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ApprovalTests_Problem.ApprovalTests
{
    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class SimpleTest
    {
        [TestMethod]
        public void TestList()
        {
            var names = new[] {"Llewellyn", "James", "Dan", "Jason", "Katrina"};
            Array.Sort(names);
            Approvals.VerifyAll(names, label: "");
        }
    }
}
