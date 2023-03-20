using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Edit(int id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var categroyFromDb = _db.Categories.Find(id);
            if (categroyFromDb == null) return NotFound();
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category categoryObj)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Update(categoryObj);
                _db.SaveChanges(true);
                return RedirectToAction("Index");

            }
            else
            {
                return View(categoryObj);

            }
            
        }
      //Get
      public IActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {

                return NotFound();
            }
            else
            {
                _db.Categories.Remove(categoryFromDb);
                _db.SaveChanges(true);
                return RedirectToAction("Index");
            }
            return View(id);
        }
    }
}
