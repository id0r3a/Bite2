using ApplicationLayer.DTOs;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using System;
using System.Threading.Tasks;


namespace ApplicationLayer.Services
{
    public class UserService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator) : IUserService
    {
        public async Task<string> RegisterAsync(RegisterDTO dto)
        {
            var usernameExists = await userRepository.UsernameExistsAsync(dto.Username);
            if (usernameExists)
            {
                throw new Exception("Username already taken.");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var newUser = new User
            {
                Username = dto.Username,
                PasswordHash = hashedPassword,
                Role = "User"
            };

            await userRepository.AddAsync(newUser);
            await userRepository.SaveChangesAsync();  // ✅ Viktigt om din repository har detta!

            // Return JWT directly after registration
            return jwtTokenGenerator.GenerateToken(newUser);
        }

        public async Task<string?> LoginAsync(LoginDTO dto)
        {
            var user = await userRepository.GetByUsernameAsync(dto.Username);
            if (user == null) return null;

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            if (!isPasswordValid) return null;

            return jwtTokenGenerator.GenerateToken(user);
        }
    }
}
