using CompanySystem.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanySystem.PL
{
    public class CategoryController : Controller
    {
        /*------------------------------------------------------------------*/
        private readonly ICategoryManger _categoryManger;

        /*------------------------------------------------------------------*/
        public CategoryController(ICategoryManger categoryManger)
        {
            _categoryManger = categoryManger;
        }
        /*------------------------------------------------------------------*/
   
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoryManger.GetAllCategories();
            return View(categories);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = _categoryManger.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        ///*------------------------------------------------------------------*/
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View(new CategoryCreateVM());
        }
        ///*------------------------------------------------------------------*/
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CategoryCreateVM categoryCreateVM)
        {
            _categoryManger.CreateCategory(categoryCreateVM);
            return RedirectToAction("Index");
        }
        ///*------------------------------------------------------------------*/
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var category = _categoryManger.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View();
        }
        ///*------------------------------------------------------------------*/
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(CategoryEditVM categoryEditVM)
        {
            _categoryManger.UpdateCategory(categoryEditVM);
            return RedirectToAction("Index");
        }
        ///*------------------------------------------------------------------*/
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var category = _categoryManger.GetCategoryById(id);
            if (category != null)
            {
                _categoryManger.DeleteCategory(id);
            }
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
    }
}
