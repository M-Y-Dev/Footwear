
using Footwear.Domain.Entities;

namespace Footwear.UI.Areas.Admin.Dtos
{
    public class ResultProductDto
    {
        public  int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int ProductStock { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public  Category Category { get; set; }
    }
}
