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

        public async Task<Order?> CreateOrder(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return order;
            }
            catch { return null; }
            
        }

        public async Task<List<Order>?> GetMyOrders(int userID)
        {
            try
            {
                return await _context.Orders.Where(o => o.UserId == userID).ToListAsync();
            }
            catch { return null; }
            
        }

        public async Task<Order?> GetOrderDetails(int orderID)
        {
            try
            {
                return await _context.Orders.Include(o => o.OrderProducts).ThenInclude(op => op.Product).SingleOrDefaultAsync(o => o.Id == orderID);
            }
            catch { return null; }
            
        }
    }
}
