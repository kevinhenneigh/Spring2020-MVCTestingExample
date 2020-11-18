using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTestingExample.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCTestingExample.Controllers.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod()] 
        public void Index_ReturnsNonNullViewResult()
        {
            HomeController myComtroller = new HomeController();

            IActionResult result = myComtroller.Index();

            Assert.IsNotNull(result);
        }
    }
}