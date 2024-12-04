using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

namespace TestIgnatov.Models.ViewModels.Category
{
    public class AddCategory
    {
        [Required]
        public string Name { get; set; }
    }
}