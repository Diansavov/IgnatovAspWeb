using System.Net;
using TestIgnatov.Models;
using TestIgnatov.Models.ViewModels;
using TestIgnatov.Models.ViewModels.Product;
using TestIgnatov.Repository.Categories;
using TestIgnatov.Repository.Products;

namespace TestIgnatov.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        public ProductsService(IProductRepository productRepository, ICategoriesRepository categoriesRepository)
        {
            _productRepository = productRepository;
            _categoriesRepository = categoriesRepository;
        }
        public async Task AddAsync(AddProduct addProducts)
        {
            Product product = new Product()
            {
                Name = addProducts.Name,
                Price = addProducts.Price,
                Stock = addProducts.Stock,
                Description = addProducts.Description,
            };
            foreach (var categoryName in addProducts.CategoryName)
            {
                Category category = _categoriesRepository.GetByName(categoryName);
                product.Categories.Add(category);

            }

            string imagePath = "";
            if (addProducts.Image == null)
            {
                imagePath = "wwwroot/images/defaultImage.png";
            }
            else
            {
                using (var memoryStream = new MemoryStream())
                {
                    addProducts.Image.CopyTo(memoryStream);
                    // Upload the file if less than 2 MB  
                    if (memoryStream.Length < 2097152)
                    {
                        imagePath = $"wwwroot/images/profilePics/{addProducts.Name.ToLower()}/{addProducts.Name.ToLower()}.png";
                        Directory.CreateDirectory(Path.GetDirectoryName(imagePath));
                        FileStream fileStream = new FileStream(imagePath, FileMode.Create);
                        addProducts.Image.CopyTo(fileStream);
                    }
                    else
                    {
                        imagePath = null;
                        return;
                    }
                }
            }
            product.ImagePath = imagePath;


            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            Product product = await _productRepository.Get(id);

            _productRepository.Delete(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task Edit(EditProduct editPlanet)
        {
            Product product = new Product(editPlanet);
            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<Product> Get(string id)
        {
            return await _productRepository.Get(id);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
        public List<Product> GetSearched(SearchProduct search)
        {
            List<Product> searchedProducts = _productRepository.GetAll();

            if (search.Name != null)
            {
                searchedProducts = searchedProducts.Where(x => x.Name.ToLower().Contains(search.Name.ToLower())).ToList();
            }
            if (search.Stock != null)
            {
                searchedProducts = searchedProducts.Where(x => x.Stock.ToString().ToLower().Contains(search.Stock.ToLower())).ToList();
            }
            return searchedProducts;
        }
    }
}