
using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UserCommand_Query_Handler.Register
{
    public class RegisterCommandHandler(IGenericRepository<User> repository, IJwtTokenGenerator jwtGenerator) : IRequestHandler<RegisterCommand, OperationResult<string>>
    {
        public async Task<OperationResult<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // Kontrollera om användarnamn redan finns
            var existingUser = await repository.FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);
            if (existingUser != null)
            {
                return OperationResult<string>.Failure("Username already taken.");
            }

            // Skapa och hasha lösenordet
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new User
            {
                Username = request.Username,
                PasswordHash = hashedPassword,
                Role = "User"
            };

            // Spara till databasen
            await repository.AddAsync(newUser);
            await repository.SaveChangesAsync();

            // Skapa token
            var token = jwtGenerator.GenerateToken(newUser);

            return OperationResult<string>.Success(token, "User registered and logged in successfully.");
        }
    }
}
