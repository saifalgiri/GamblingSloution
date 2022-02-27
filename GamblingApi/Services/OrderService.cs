using GamblingApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GamblingApi.IServices
{
    public class OrderService : IOrderService
    {
        private readonly DbContextModel dbContext;
        private readonly ILogger<OrderService> logger;
        public OrderService(DbContextModel dbContext,
            ILogger<OrderService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        public async Task<OrderModel> PlaceOrder(OrderModel order)
        {
            try
            {
                if (order != null)
                {
                    order.CreatedAt = DateTime.UtcNow;
                    await dbContext.Orders.AddAsync(order);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return order;
        }
    }
}
