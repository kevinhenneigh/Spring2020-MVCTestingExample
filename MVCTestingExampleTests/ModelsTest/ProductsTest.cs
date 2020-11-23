using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTestingExample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCTestingExampleTests.ModelsTest
{
   [TestClass]
    public class ProductsTest
    {
        [TestMethod]
        public void Name_SetToNull_ThrowsArgumentNullException()
        {
            Product p = new Product();
            Assert.ThrowsException<ArgumentNullException>
                (
                    () => p.Name = null
                );
        }
    }
}
