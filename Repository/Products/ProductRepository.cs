using Microsoft.EntityFrameworkCore;
using TestIgnatov.Data;
using TestIgnatov.Models;

namespace TestIgnatov.Repository.Products
{
    
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _productsDbContext;
        public ProductRepository(ProductsDbContext productsDbContext)
        {
            _productsDbContext = productsDbContext;
        }
        public async Task AddAsync(Product product)
        {
            _productsDbContext.Products.AddAsync(product);
        }

        public async Task<Product> Get(string id)
        {
            return await _productsDbContext.Products.FindAsync(id);
        }

        public void Delete(Product product)
        {
            _productsDbContext.Remove(product);
        }

        public async Task SaveChangesAsync()
        {
            await _productsDbContext.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            _productsDbContext.Products.Update(product);
        }
        public List<Product> GetAll()
        {
            return _productsDbContext.Products.Include(x => x.Categories).ToList();
        }
    }
}