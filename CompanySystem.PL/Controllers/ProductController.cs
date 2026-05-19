using CompanySystem.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanySystem.PL
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductManger _productManger;
        private readonly ICategoryManger _categoryManger;
        public ProductController(IProductManger productManger, ICategoryManger categoryManger)
        {
            _productManger = productManger;
            _categoryManger = categoryManger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var products = _productManger.GetAllProduct();
            return View(products);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var product = _productManger.GetProductById(id);
            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryManger.GetAllCategories();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCreateVM productCreateVM)
        {
            if (ModelState.IsValid)
            {
                _productManger.CreateProduct(productCreateVM);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _categoryManger.GetAllCategories();
            return View(productCreateVM);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var product = _productManger.GetProductById(id);
            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var productEditVM = new ProductEditVM
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                ExpiryDate = product.ExpiryDate,
                CategoryId = product.CategoryId
            };

            ViewBag.Categories = _categoryManger.GetAllCategories();
            return View(productEditVM);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(ProductEditVM productEditVM)
        {
            if (ModelState.IsValid)
            {
                var productInDb = _productManger.GetProductById(productEditVM.Id);
                if (productInDb == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                _productManger.UpdateProduct(productEditVM);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _categoryManger.GetAllCategories();
            return View(productEditVM);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _productManger.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
