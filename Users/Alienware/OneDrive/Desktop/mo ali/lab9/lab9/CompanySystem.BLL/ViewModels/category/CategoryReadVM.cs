using CompanySystem.DAL;

namespace CompanySystem.BLL
{
    public class CategoryReadVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
