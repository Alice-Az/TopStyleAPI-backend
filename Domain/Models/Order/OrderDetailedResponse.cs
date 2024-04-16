namespace TopStyleAPI.Domain.Models.Order
{
    public class OrderDetailedResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal OrderPrice { get; set; }
        public List<OrderProductResponse> Products { get; set; }
    }
}
