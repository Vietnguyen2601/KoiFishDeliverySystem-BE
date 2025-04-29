using KoiFishDeliverySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFishDeliverySystem.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string userId);
        Task<User> CreateAsync(User user);
        Task UpdateAsync(string userId, User user);
        Task DeleteAsync(string userId);
    }
}
