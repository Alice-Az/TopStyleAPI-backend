using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly TopStyleContext _context;

        public OrderRepo(TopStyleContext context)
        {
            _context = context;
        }

        public Order CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public List<Order> GetMyOrders(int userID)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderDetails(int orderID)
        {
            throw new NotImplementedException();
        }
    }
}
