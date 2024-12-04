using TestIgnatov.Models;

namespace TestIgnatov.Repository.Products
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Task<Product> Get(string id);
        Task AddAsync(Product product);
        Task SaveChangesAsync();
        void Delete(Product product);
        void Update(Product product);
    }
}