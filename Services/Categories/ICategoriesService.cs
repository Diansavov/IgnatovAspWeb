using TestIgnatov.Models;
using TestIgnatov.Models.ViewModels;
using TestIgnatov.Models.ViewModels.Category;

namespace TestIgnatov.Services.Categories
{
    public interface ICategoriesService
    {
        List<Category> GetAll();
        List<Category> GetProductCategories(string productId);
        Category GetByName(string name);
        Task AddAsync(AddCategory addCategory);
    }
}