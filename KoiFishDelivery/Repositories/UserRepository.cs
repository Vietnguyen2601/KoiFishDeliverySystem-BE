using KoiFishDelivery.Entities;
using KoiFishDelivery.Models;

namespace KoiFishDelivery.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KoiFishDeleverySystemContext _context;
        public UserRepository(KoiFishDeleverySystemContext context)
        {
            _context = context;
        }
        public User? GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}

