using KoiFishDelivery.Entities;
using KoiFishDelivery.Models;

namespace KoiFishDelivery.Services
{
    public interface IAuthenticationService
    {
        User? ValidateLogin(LoginRequest request);
    }
}
