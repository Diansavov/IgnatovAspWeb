using Microsoft.AspNetCore.Identity;
using TestIgnatov.Data;
using TestIgnatov.Data.Seeds;
using TestIgnatov.Models;

namespace TestIgnatov.Data
{
    class SeedData
    {
        public static async void Seed(IApplicationBuilder applicationBuilder)
        {
            RolesSeed.Seed(applicationBuilder);
            CategoriesSeed.Seed(applicationBuilder);
            ProductsSeed.Seed(applicationBuilder);
        }
        
    }
}