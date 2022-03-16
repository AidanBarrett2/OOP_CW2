using CW2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2
{
    [TestClass]
    public class TestCount
    {
        string expected1 = "77";
        string expected2 = "30";
        string expected3 = "15";
        string expected4 = "9";
        [TestMethod]
        public void TestMethod1()
        {
            Form2 f2 = new Form2();
            string str = f2.Candidate1Votes;
            string str2 = f2.Candidate2Votes;
            string str3 = f2.Candidate3Votes;
            string str4 = f2.Candidate4Votes;
            Assert.AreEqual(expected1, str);
            Assert.AreEqual(expected2, str2);
            Assert.AreEqual(expected3, str3);
            Assert.AreEqual(expected4, str4);
        }
    }
}
