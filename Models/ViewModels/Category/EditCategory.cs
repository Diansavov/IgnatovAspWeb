using System.ComponentModel.DataAnnotations;

namespace TestIgnatov.Models.ViewModels.Category
{
    public class EditCategory
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}