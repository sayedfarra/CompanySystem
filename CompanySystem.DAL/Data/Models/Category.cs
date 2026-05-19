using System.ComponentModel.DataAnnotations;

namespace CompanySystem.DAL
{
    public class Category : IAuditEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Product> Products { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
