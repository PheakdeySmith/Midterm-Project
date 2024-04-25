using Microsoft.AspNetCore.Mvc;
using Midterm_Project.Data;
using Midterm_Project.Models;

namespace Midterm_Project.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationContext _db;
        public SupplierController(ApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objSupplierList = _db.Suppliers.ToList();
            return View(objSupplierList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
			if (ModelState.IsValid)
			{
				try
				{
					_db.Suppliers.Add(supplier);
					_db.SaveChanges();
					TempData["success"] = "Supplier created successfully";
					return RedirectToAction("Index");
				}
				catch (Exception ex)
				{
					TempData["error"] = "An error occurred while creating the supplier: " + ex.Message;
				}
			}

			return View(supplier);
		}

		[HttpGet("supplier/edit/{id}")]
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var supplier = _db.Suppliers.FirstOrDefault(x => x.Id == id);

			return View(supplier);
		}

		[HttpPost("supplier/edit/{id}")]
		public IActionResult Edit(int id, Supplier supplier)
		{
			if (id != supplier.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_db.Suppliers.Update(supplier);
					_db.SaveChanges();
					TempData["success"] = "Supplier updated successfully";
					return RedirectToAction("Index");
				}
				catch (Exception ex)
				{
					TempData["error"] = "Failed to update supplier";
				}
			}

			return View(supplier);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var supplier = _db.Suppliers.Find(id);
			if (supplier == null)
			{
				return NotFound();
			}

			_db.Suppliers.Remove(supplier);
			_db.SaveChanges();
			TempData["success"] = "Supplier deleted successfully";
			return RedirectToAction("Index");
		}
	}
}
