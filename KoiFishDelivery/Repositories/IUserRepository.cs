using KoiFishDelivery.Entities;

namespace KoiFishDelivery.Repositories
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
    }
}
