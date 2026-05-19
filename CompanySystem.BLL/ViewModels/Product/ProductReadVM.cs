using System.ComponentModel.DataAnnotations;

namespace CompanySystem.BLL
{
    public class ProductReadVM
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? Category { get; set; }
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
