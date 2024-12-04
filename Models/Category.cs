using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestIgnatov.Models
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}