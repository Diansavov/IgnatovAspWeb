using TestIgnatov.Models;

namespace TestIgnatov.Repository.Categories
{
    public interface ICategoriesRepository
    {
        List<Category> GetAll();
        Task Add(Category category);
        Category GetByName(string name);
        Task SaveChanges();
    }
}