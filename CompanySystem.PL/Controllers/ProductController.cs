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
        private readonly IWebHostEnvironment _env;
        public ProductController(IProductManger productManger, ICategoryManger categoryManger, IWebHostEnvironment env)
        {
            _productManger = productManger;
            _categoryManger = categoryManger;
            _env = env;
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
                string? imageUrl = null;
                if (productCreateVM.Image != null && productCreateVM.Image.Length > 0)
                {
                    imageUrl = SaveImage(productCreateVM.Image);
                }
                _productManger.CreateProduct(productCreateVM, imageUrl);
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
                CategoryId = product.CategoryId,
                ExistingImageUrl = product.ImageUrl
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

                string? imageUrl = productEditVM.ExistingImageUrl;
                if (productEditVM.Image != null && productEditVM.Image.Length > 0)
                {
                    imageUrl = SaveImage(productEditVM.Image);
                }

                _productManger.UpdateProduct(productEditVM, imageUrl);
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

        private string SaveImage(IFormFile image)
        {
            var uploadsFolder = Path.Combine(_env.WebRootPath, "images", "products");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            return "/images/products/" + uniqueFileName;
        }
    }
}
