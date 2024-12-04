using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestIgnatov.Models;
using TestIgnatov.Models.ViewModels.Category;
using TestIgnatov.Services.Categories;

namespace TestIgnatov.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoriesService _categoriesService;
    public CategoryController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    public IActionResult AddCategory()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddCategory(AddCategory addCategory)
    {
        if (ModelState.IsValid)
        {
            await _categoriesService.AddAsync(addCategory);
            return RedirectToAction("Index", "Home");
        }
        return View(addCategory);

    }
}
