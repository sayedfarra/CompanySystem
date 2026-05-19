using CompanySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySystem.BLL
{
    public interface ICategoryManger
    {
        List<CategoryReadVM> GetAllCategories();
        CategoryReadVM GetCategoryById(int id);
        void CreateCategory(CategoryCreateVM categoryCreateVM);
        void DeleteCategory(int id);
        void UpdateCategory(CategoryEditVM categoryEditVM);
    }
}
