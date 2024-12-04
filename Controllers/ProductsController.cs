using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using TestIgnatov.Models;
using TestIgnatov.Models.ViewModels.Product;
using TestIgnatov.Services.Categories;
using TestIgnatov.Services.Products;

namespace TestIgnatov.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };
        public ProductsController(IProductsService productsService, ICategoriesService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
        }
        [HttpGet]
        public IActionResult Products()
        {
            List<Product> products = _productsService.GetAll();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddProduct userProduct)
        {
            if (ModelState.IsValid)
            {
                await _productsService.AddAsync(userProduct);
                return RedirectToAction("Products", "Products");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            Product product = await _productsService.Get(id);

            EditProduct editProduct = new EditProduct();
            editProduct.Id = product.Id;
            editProduct.Name = product.Name;
            editProduct.Price = Math.Round(product.Price, 2);
            editProduct.Stock = product.Stock;
            return View(editProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditProduct editProduct)
        {
            await _productsService.Edit(editProduct);
            return RedirectToAction("Products", "Products");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await _productsService.Delete(id);
            return RedirectToAction("Products", "Products");
        }
        /*Javascript ajax information*/
        public string GetAll(string searchProductJson)
        {
            SearchProduct searchProduct = JsonConvert.DeserializeObject<SearchProduct>(searchProductJson);

            List<Product> products = _productsService.GetSearched(searchProduct);

            string json = System.Text.Json.JsonSerializer.Serialize(products, _options);

            return json;
        }
        /*
    public string GetProductCategories(string productName)
    {
        Product product = _productsService.Get()

        List<Category> categories = _categoriesService.GetProductCategories();

        string json = System.Text.Json.JsonSerializer.Serialize(categories, _options);

        return json;
    }
        */
        public string GetAllCategories()
        {
            List<Category> categories = _categoriesService.GetAll();

            string json = System.Text.Json.JsonSerializer.Serialize(categories, _options);

            return json;
        }
    }
}