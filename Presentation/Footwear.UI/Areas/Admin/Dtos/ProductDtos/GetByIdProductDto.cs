namespace Footwear.UI.Areas.Admin.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int ProductStock { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public bool IsWoman { get; set; }
        public int CategoryID { get; set; }
    }
}
