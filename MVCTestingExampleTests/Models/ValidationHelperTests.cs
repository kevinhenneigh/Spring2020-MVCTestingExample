using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTestingExample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCTestingExample.Models.Tests
{
    [TestClass()]
    public class ValidationHelperTests
    {
        [TestMethod()]
        [DataRow("9.99")]
        [DataRow("$20.00")] // Works with US currency only
        [DataRow(".99")]
        [DataRow("0.01")]
        [DataRow("0")]
        [DataRow("100000000")]
        public void IsValidPrice_ValidPrice_ReturnsTrue(string input)
        {
            bool result = ValidationHelper.IsValidPrice(input);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("five")]
        [DataRow("3 and 5 cents")]
        [DataRow("5 dollars")]
        [DataRow("5.00.01")]
        [DataRow("5.00$")]
        public void IsValidPrice_InValidPrice_ReturnFalse(string input)
        {
            bool result = ValidationHelper.IsValidPrice(input);
            Assert.IsFalse(result);
        }
    }
}