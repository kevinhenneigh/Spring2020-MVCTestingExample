using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCTestingExample.Models;
using MVCTestingExample.Models.Interfaces;

namespace MVCTestingExample.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _repo.GetAllProductsAsync();
            return View(products);
        }
    }
}
