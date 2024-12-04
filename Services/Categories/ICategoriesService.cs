using TestIgnatov.Models;
using TestIgnatov.Models.ViewModels;
using TestIgnatov.Models.ViewModels.Category;

namespace TestIgnatov.Services.Categories
{
    public interface ICategoriesService
    {
        List<Category> GetAll();
        Category GetByName(string name);
        Task AddAsync(AddCategory addCategory);
    }
}