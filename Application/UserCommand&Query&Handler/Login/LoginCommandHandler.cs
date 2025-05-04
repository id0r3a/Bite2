using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.UserCommand_Query_Handler.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, OperationResult<string>>
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginCommandHandler(IGenericRepository<User> repository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _repository = repository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<OperationResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.FirstOrDefaultAsync(
                u => u.Username == request.Username,
                cancellationToken);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return OperationResult<string>.Failure("Invalid username or password.");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            // Antingen så här:
            return OperationResult<string>.Success(token);
            // Eller om din klass verkligen heter SuccessResult:
            // return OperationResult<string>.SuccessResult(token, "Login successful.");
        }
    }
}
