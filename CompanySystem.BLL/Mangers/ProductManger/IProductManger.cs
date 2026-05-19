using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySystem.BLL
{
    public interface IProductManger
    {
        List<ProductReadVM> GetAllProduct();
        ProductReadVM? GetProductById(int id);
        void CreateProduct(ProductCreateVM product, string? imageUrl);
        void UpdateProduct(ProductEditVM product, string? imageUrl);
        void DeleteProduct(int id);
    }
}
