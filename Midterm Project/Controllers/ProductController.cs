using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Midterm_Project.Data;
using Midterm_Project.Models;
using System;
using System.Linq;

namespace Midterm_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext _db;
        public ProductController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var products = _db.Products
                .Include(p => p.Supplier)
                .Include(p => p.Category)
                .ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewData["Suppliers"] = _db.Suppliers.ToList();
            ViewData["Categories"] = _db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                    _db.Products.Add(product);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                TempData["error"] = "Failed to create product";
                throw; 
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewData["Suppliers"] = _db.Suppliers.ToList();
            ViewData["Categories"] = _db.Categories.ToList();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product editedProduct)
        {
            if (id != editedProduct.Id)
            {
                return BadRequest();
            }
            try
            {
                _db.Update(editedProduct);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                TempData["error"] = "Failed to update product";
                throw;
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _db.Products.Remove(product);
            _db.SaveChanges();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
