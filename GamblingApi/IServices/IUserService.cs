using GamblingApi.Models;
using System.Threading.Tasks;

namespace GamblingApi.IServices
{
    public interface IUserService
    {
        Task AddUser(UserModel player);
    }
}
