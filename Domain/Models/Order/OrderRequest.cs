namespace TopStyleAPI.Domain.Models.Order
{
    public class OrderRequest
    {
        public int UserID { get; set; }
        public List<int> ProductIDs { get; set; } = new List<int>();
        public string FullName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}
