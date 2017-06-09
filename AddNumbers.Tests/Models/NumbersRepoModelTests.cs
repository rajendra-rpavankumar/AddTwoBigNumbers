using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddNumbers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace AddNumbers.Models.Tests
{
    [TestClass()]
    public class NumbersRepoModelTests
    {
        private NumbersRepoModel calNum;
        [TestInitialize]
        public void Initialize()
        {          
            Mock<LoggerRepoModels> myMock = new Mock<LoggerRepoModels>();
            calNum = new NumbersRepoModel(myMock.Object);
        }

        [TestMethod()]
        public void CheckDecimalest()
        {
            var value = calNum.CheckInput("123456.10");
            Assert.IsFalse(value);
        }

        [TestMethod()]
        public void CheckInputforNonNumericTest()
        {
            var value = calNum.CheckInput("123456c");
            Assert.IsFalse(value);
        }

        [TestMethod()]
        public void CheckInputforIntegerTest()
        {
            var value = calNum.CheckInput("123456");
            Assert.IsTrue(value);
        }
        [TestMethod()]
        public void CheckInputforNegativeTest()
        {
            var value = calNum.CheckInput("-123456");
            Assert.IsTrue(value);
        }
        [TestMethod()]
        public void AddTest()
        {
            string result = calNum.Add("10", "10");
            Assert.AreEqual("20", result);
        }

        [TestMethod()]
        public void AddLargeNumbersTest()
        {
            string result = calNum.Add("100000000000000000000", "100000000000000000000");
            Assert.AreEqual("200000000000000000000", result);
        }

        [TestMethod()]
        public void AddNegativeNumbersTest()
        {
            string result = calNum.Add("-100000000000000000000", "-100000000000000000000");
            Assert.AreEqual("-200000000000000000000", result);
        }

    }
}