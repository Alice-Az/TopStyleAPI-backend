namespace TopStyleAPI.Domain.Models.Order
{
    public class OrderResponse
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public decimal Price { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

    }
}
