using Microsoft.EntityFrameworkCore;
using MVCTestingExample.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTestingExample.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public EFProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a product to the data store
        /// </summary>        
        public Task AddProductAsync(Product p)
        {
            _context.Add(p);
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a product from the database
        /// </summary>
        public Task DeleteProductAsync(Product p)
        {
            _context.Remove(p);
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Returns a list of all products in the database
        /// </summary>
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                           .OrderBy(p => p.Name)
                           .ToListAsync();
        }
        
        /// <summary>
        /// Returns a single product by id
        /// or NULL if no product exists
        /// </summary>
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                           .Where(p => p.ProductId == id)
                           .SingleOrDefaultAsync();
        }

        /// <summary>
        /// Used to updayte an existing product
        /// in the database
        /// </summary>
        public Task UpdateProductAsync(Product p)
        {
            _context.Entry(p).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
