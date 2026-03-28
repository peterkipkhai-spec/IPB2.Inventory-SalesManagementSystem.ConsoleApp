using IPB2.Inventory_SalesManagementSystem.MVC.Features.Categories;
using IPB2.Inventory_SalesManagementSystem.MVC.Features.Categories.Models;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.Inventory_SalesManagementSystem.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryFeature _categoryFeature;

        public CategoriesController()
        {
            _categoryFeature = new CategoryFeature();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _categoryFeature.GetListAsync();
            if (response.IsSuccess)
            {
                return View(response.Data);
            }
            return View(new List<IPB2.Inventory_SalesManagementSystem.DB.Models.Category>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryFeature.CreateAsync(request);
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.Message);
            }
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _categoryFeature.GetByIdAsync(id);
            if (!response.IsSuccess || response.Data == null)
            {
                return NotFound();
            }

            var request = new CategoryRequest
            {
                CategoryId = response.Data.CategoryId,
                CategoryName = response.Data.CategoryName,
                Description = response.Data.Description
            };
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryRequest request)
        {
            if (id != request.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _categoryFeature.UpdateAsync(request);
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.Message);
            }
            return View(request);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryFeature.GetByIdAsync(id);
            if (!response.IsSuccess || response.Data == null)
            {
                return NotFound();
            }

            return View(response.Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _categoryFeature.DeleteAsync(id);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
