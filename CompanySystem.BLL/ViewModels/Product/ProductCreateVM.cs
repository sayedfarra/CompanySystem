using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CompanySystem.BLL
{
    public class ProductCreateVM
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        public int Count { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CategoryId { get; set; }

        public List<SelectListItem>? Categorys { get; set; }
    }
}
