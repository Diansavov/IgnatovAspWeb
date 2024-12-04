using Microsoft.AspNetCore.Identity;
using TestIgnatov.Data;
using TestIgnatov.Models;

namespace TestIgnatov.Data.Seeds
{
    class ProductsSeed
    {
        public static async void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ProductsDbContext>();
                await CreateProducts(context);
            }
        }
        public static async Task CreateProducts(ProductsDbContext productsDbContext)
        {
            if (!productsDbContext.Products.Any())
            {
                Product fanta = new Product()
                {
                    Name = "Fanta",
                    Price = 123,
                    Stock = 20,
                    Categories = productsDbContext.Categories.Where(x => x.Name == "Drink").ToList(),
                    Description = "Cool Nazi Drink",
                    ImagePath = "NoNO"
                };
                fanta.Categories.Add(productsDbContext.Categories.Where(x => x.Name == "Drink").FirstOrDefault());
                fanta.Categories.Add(productsDbContext.Categories.Where(x => x.Name == "Food").FirstOrDefault());
                Product spaghetti = new Product()
                {
                    Name = "Spaghetti",
                    Price = 69,
                    Stock = 120,
                    Description = "Italian Amazingness",
                    ImagePath = "NoNO"
                };
                spaghetti.Categories.Add(productsDbContext.Categories.Where(x => x.Name == "Food").FirstOrDefault());

                Product oven = new Product()
                {
                    Name = "Oven",
                    Price = 1233,
                    Stock = 10,
                    Description = "Ovening the oven oven",
                    ImagePath = "NoNO"
                };
                oven.Categories.Add(productsDbContext.Categories.Where(x => x.Name == "Furniture").FirstOrDefault());


                await productsDbContext.Products.AddAsync(fanta);
                await productsDbContext.Products.AddAsync(spaghetti);
                await productsDbContext.Products.AddAsync(oven);

                await productsDbContext.SaveChangesAsync();
            }
        }
    }
}