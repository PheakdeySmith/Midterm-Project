using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Midterm_Project.Data;
using Midterm_Project.Models;

namespace Midterm_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationContext _db;
        public CategoryController(ApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
			return View();
		}

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Categories.Add(category);
                    _db.SaveChanges();
                    TempData["success"] = "Category created successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "An error occurred while creating the category: " + ex.Message;
                }
            }

            return View(category);
        }

        [HttpGet("category/edit/{id}")]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var category = _db.Categories.FirstOrDefault(x => x.Id == id);

            return View(category);
        }

        [HttpPost("category/edit/{id}")]
        public IActionResult Edit(int id, Category category)
        {
            if(id != category.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
					_db.Categories.Update(category);
					_db.SaveChanges();
					TempData["success"] = "Category updated successfully";
					return RedirectToAction("Index");
				}
                catch (Exception ex)
                {
					TempData["error"] = "Failed to update category";
				}
            }

			return View(category);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var category = _db.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}

			_db.Categories.Remove(category);
			_db.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");
		}
	}
}
