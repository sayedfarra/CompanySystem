
namespace CompanySystem.DAL
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetAllWithCategory();
        Product? GetByIdWithCategory(int ProductID);
    }
}
