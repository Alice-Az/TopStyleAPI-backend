namespace TopStyleAPI.Domain.Models.Order
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal OrderPrice { get; set; }
        public string FullName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
        public string City { get; set; } = default!;

    }
}
