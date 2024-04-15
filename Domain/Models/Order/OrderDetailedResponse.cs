namespace TopStyleAPI.Domain.Models.Order
{
    public class OrderDetailedResponse
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public decimal Price { get; set; }
        public List<OrderProductResponse> Products { get; set; }
    }
}
