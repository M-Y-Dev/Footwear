namespace Footwear.UI.Areas.Admin.Dtos.AddressDtos
{
    public class GetByIdAddressDto
    {
        public int Id { get; set; } 
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
    }
}
