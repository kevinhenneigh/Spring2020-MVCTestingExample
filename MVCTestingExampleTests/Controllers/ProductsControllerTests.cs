using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTestingExample.Controllers;
using MVCTestingExample.Models;
using MVCTestingExample.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCTestingExample.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        [TestMethod()]
        public void Index_ReturnsAViewResult_WithAListOfAllProducts()
        {
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetAllProductsAsync())
                    .ReturnsAsync(GetProducts());
        }

        private List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    ProductId = 1, Name = "Computer", Price = "199.99"
                },
                new Product()
                {
                    ProductId = 2, Name = "Webcam", Price = "49.99"
                },
                new Product()
                {
                    ProductId = 3, Name = "Desk", Price = "200"
                }
            };
        }
    }
}