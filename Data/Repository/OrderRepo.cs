using Microsoft.EntityFrameworkCore;
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
            return _context.Orders.Where(o => o.UserId == userID).ToList();
        }

        public Order? GetOrderDetails(int orderID)
        {
            return _context.Orders.Include(o => o.OrderProducts).ThenInclude(op => op.Product).SingleOrDefault(o => o.Id == orderID);
        }
    }
}
