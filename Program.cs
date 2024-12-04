using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestIgnatov.Data;
using TestIgnatov.Models;
using TestIgnatov.Repository.Categories;
using TestIgnatov.Repository.Products;
using TestIgnatov.Services.Categories;
using TestIgnatov.Services.Products;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProductsDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConString")));


builder.Services.AddDefaultIdentity<Users>(options => options.SignIn.RequireConfirmedAccount = false)
.AddRoles<IdentityRole>().AddEntityFrameworkStores<ProductsDbContext>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

SeedData.Seed(app);
app.Run();
