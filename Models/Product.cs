using System.ComponentModel.DataAnnotations;
using TestIgnatov.Models.ViewModels.Product;

namespace TestIgnatov.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString();
            Categories = new List<Category>();
        }
        public Product(EditProduct editProduct)
        {
            Id = editProduct.Id;
            Name = editProduct.Name;
            Price = editProduct.Price;
            Stock = editProduct.Stock;
        }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public List<Category> Categories { get; set; }
    }
}