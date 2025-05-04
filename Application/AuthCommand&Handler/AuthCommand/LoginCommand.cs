using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.AuthCommand_Handler.AuthCommand
{
    public class LoginCommand(LoginDTO dto) : IRequest<OperationResult<string>>
    {
        public LoginDTO LoginDto { get; set; } = dto;
    }
}
