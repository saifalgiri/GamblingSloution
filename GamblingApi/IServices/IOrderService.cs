using GamblingApi.Models;
using System.Threading.Tasks;

namespace GamblingApi.IServices
{
    public interface IOrderService
    {
        Task<OrderModel> PlaceOrder(OrderModel order);
    }
}
