using TestIgnatov.Models;
using TestIgnatov.Models.ViewModels.Product;

namespace TestIgnatov.Services.Products
{
    public interface IProductsService
    {
        List<Product> GetAll();
        Task<Product> Get(string id);

        Task AddAsync(AddProduct addPlanet);
        Task Edit(EditProduct editProduct);
        List<Product> GetSearched(SearchProduct search);
        Task Delete(string id);
    }
}