using KoiFishDeliverySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFishDeliverySystem.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string userId);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(string userId);
    }
}
