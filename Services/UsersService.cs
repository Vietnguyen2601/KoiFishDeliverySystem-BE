using KoiFishDeliverySystem.Models;
using KoiFishDeliverySystem.Repositories;
using KoiFishDeliverySystem.Repositories.Interfaces;
using KoiFishDeliverySystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFishDeliverySystem.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _usersRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(string userId)
        {
            var user = await _usersRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task<User> CreateAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@"))
            {
                throw new Exception("Invalid email address");
            }

            if (string.IsNullOrWhiteSpace(user.UserId))
            {
                throw new Exception("UserID is required");
            }

            await _usersRepository.AddAsync(user);
            return user;
        }

        public async Task UpdateAsync(string userId, User user)
        {
            if (userId != user.UserId)
            {
                throw new Exception("ID mismatch");
            }

            var existingUser = await _usersRepository.GetByIdAsync(userId);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@"))
            {
                throw new Exception("Invalid email address");
            }

            await _usersRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(string userId)
        {
            var user = await _usersRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            await _usersRepository.DeleteAsync(userId);
        }
    }
}
