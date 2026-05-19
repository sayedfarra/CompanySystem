using CompanySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySystem.BLL
{
    public class CategoryManger : ICategoryManger
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryManger(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCategory(CategoryCreateVM categoryCreateVM)
        {
            var category = new Category
            {
                Name = categoryCreateVM.Name
            };
            _unitOfWork.CategoryRepository.Insert(category);
            _unitOfWork.Save();
        }

        public void DeleteCategory(int id)
        {
            var category= _unitOfWork.CategoryRepository.GetById(id);
            if(category == null) return;
            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.Save();
        }

        public List<CategoryReadVM> GetAllCategories()
        {
             var categories = _unitOfWork.CategoryRepository.GetAll();
            return categories.Select(c => new CategoryReadVM
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        public CategoryReadVM GetCategoryById(int id)
        {
           var category = _unitOfWork.CategoryRepository.GetById(id);
           if (category == null) return null;
           return new CategoryReadVM
           {
               Id = category.Id,
               Name = category.Name
           };
        }

        public void UpdateCategory(CategoryEditVM categoryEditVM)
        {
            var category = _unitOfWork.CategoryRepository.GetById(categoryEditVM.Id);
            if (category == null) return;
            category.Name = categoryEditVM.Name;
            _unitOfWork.Save();
        }
    }
}
