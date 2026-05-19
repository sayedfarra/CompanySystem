using CompanySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySystem.BLL
{
    public class ProductManger : IProductManger
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductManger(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ProductReadVM> GetAllProduct()
        {
            var Products=_unitOfWork.ProductRepository.GetAllWithCategory();
            return Products.Select(p => new ProductReadVM
            {
                Id = p.Id,
                Title= p.Title,
                Description= p.Description,
                Price= p.Price,
                Count= p.Count,
                ExpiryDate= p.ExpiryDate,
                Category= p.Category.Name,
                CategoryId = p.CategoryId,
                ImageUrl = p.ImageUrl
            }).ToList();
        }

        public ProductReadVM? GetProductById(int id)
        {
            var Product=_unitOfWork.ProductRepository.GetByIdWithCategory(id);
            if (Product == null) return null;
            return new ProductReadVM
            {
                Id = Product.Id,
                Title= Product.Title,
                Description= Product.Description,
                Price= Product.Price,
                Count= Product.Count,
                ExpiryDate= Product.ExpiryDate,
                Category= Product.Category.Name,
                CategoryId = Product.CategoryId,
                ImageUrl = Product.ImageUrl
            };
        }
        public void CreateProduct(ProductCreateVM product, string? imageUrl)
        {
            var Product = new Product
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                ExpiryDate = product.ExpiryDate,
                CategoryId = product.CategoryId,
                ImageUrl = imageUrl
            };
            _unitOfWork.ProductRepository.Insert(Product);
            _unitOfWork.Save();
        }

        public void UpdateProduct(ProductEditVM product, string? imageUrl)
        {
            var Product = _unitOfWork.ProductRepository.GetById(product.Id);
            if (Product == null) return;
            Product.Title = product.Title;
            Product.Description = product.Description;
            Product.Price = product.Price;
            Product.Count = product.Count;
            Product.ExpiryDate = product.ExpiryDate;
            Product.CategoryId = product.CategoryId;
            Product.ImageUrl = imageUrl ?? Product.ImageUrl;
            _unitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            var Product = _unitOfWork.ProductRepository.GetById(id);
            if (Product == null) return;
            _unitOfWork.ProductRepository.Delete(Product);
            _unitOfWork.Save();

        }
    }
}
