using ApplicationLayer.AuthCommand_Handler.AuthCommand;
using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.AuthCommand_Handler.AuthHandler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, OperationResult<string>>
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginCommandHandler(IGenericRepository<User> userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<OperationResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .FirstOrDefaultAsync(u => u.Username == request.LoginDto.Username, cancellationToken);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.LoginDto.Password, user.PasswordHash))
            {
                return OperationResult<string>.Failure("Fel användarnamn eller lösenord");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return OperationResult<string>.Success(token);
        }
    }
}
