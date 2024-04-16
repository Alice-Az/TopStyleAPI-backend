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

        public async Task<Order> CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetMyOrders(int userID)
        {
            return await _context.Orders.Where(o => o.UserId == userID).ToListAsync();
        }

        public async Task<Order?> GetOrderDetails(int orderID)
        {
            return await _context.Orders.Include(o => o.OrderProducts).ThenInclude(op => op.Product).SingleOrDefaultAsync(o => o.Id == orderID);
        }
    }
}
