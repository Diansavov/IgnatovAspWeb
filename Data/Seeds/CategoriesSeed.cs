using Microsoft.AspNetCore.Identity;
using TestIgnatov.Data;
using TestIgnatov.Models;

namespace TestIgnatov.Data.Seeds
{
    class CategoriesSeed
    {
        public static async void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ProductsDbContext>();
                await CreateCategories(context);
            }
        }
        public static async Task CreateCategories(ProductsDbContext productsDbContext)
        {
            if (!productsDbContext.Categories.Any())
            {
                await productsDbContext.Categories.AddAsync(new Category() { Name = "Drink" });
                await productsDbContext.Categories.AddAsync(new Category() { Name = "Food" });
                await productsDbContext.Categories.AddAsync(new Category() { Name = "Furniture" });

                await productsDbContext.SaveChangesAsync();
            }
        }
    }
}