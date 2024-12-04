using TestIgnatov.Models;
using TestIgnatov.Models.ViewModels.Category;
using TestIgnatov.Repository.Categories;
using TestIgnatov.Repository.Products;

namespace TestIgnatov.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task AddAsync(AddCategory addCategory)
        {
            Category category = new Category();
            category.Name = addCategory.Name;
            await _categoriesRepository.Add(category);
            await _categoriesRepository.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _categoriesRepository.GetAll();
        }

        public Category GetByName(string name)
        {
            if (name == "null")
            {
                return null;
            }
            return _categoriesRepository.GetByName(name);
        }

        public List<Category> GetProductCategories(string productId)
        {
            return _categoriesRepository.GetAll().Where(x => x.Products == new List<Product>() {new Product() {Id = productId}}).ToList();
        }
    }
}