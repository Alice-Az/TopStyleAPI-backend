namespace TopStyleAPI.Domain.Models.Order
{
    public class OrderRequest
    {
        public List<int> ProductIDs { get; set; } = [];
        public string FullName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
        public string City { get; set; } = default!;
    }
}
