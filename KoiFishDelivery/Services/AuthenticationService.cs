using KoiFishDelivery.Entities;
using KoiFishDelivery.Models;
using KoiFishDelivery.Repositories;

namespace KoiFishDelivery.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User? ValidateLogin(LoginRequest request)
        {
            var user = _userRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                return null;
            }
            if (user.Password == request.Password)
            {
                return user;
            }
            return null;
        }
    }
}
