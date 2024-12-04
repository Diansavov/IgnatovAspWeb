using TestIgnatov.Data;
using TestIgnatov.Models;

namespace TestIgnatov.Repository.Categories
{
    
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ProductsDbContext _productsDbContext;
        public CategoriesRepository(ProductsDbContext productsDbContext)
        {
            _productsDbContext = productsDbContext;
        }

        public async Task Add(Category category)
        {
            await _productsDbContext.Categories.AddAsync(category);
        }

        public List<Category> GetAll()
        {
            return _productsDbContext.Categories.ToList();
        }

        public Category GetByName(string name)
        {
            return  _productsDbContext.Categories.Where(x => x.Name == name).FirstOrDefault();
        }

        public async Task SaveChanges()
        {
            await _productsDbContext.SaveChangesAsync();
        }
    }
}