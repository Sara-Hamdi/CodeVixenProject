using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using mvcProject.Data;
using mvcProject.Models;

namespace mvcProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category categoryObj)
        {
            if(categoryObj.Name==categoryObj.NumOfBooks.ToString())
            {
                ModelState.AddModelError("Name", "the category name cannot match exactly the display order");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(categoryObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(categoryObj);
            }
        }
        //GET
        public IActionResult Edit(Category categoryObj)
        {
            return View();
        }
      
    }
}
