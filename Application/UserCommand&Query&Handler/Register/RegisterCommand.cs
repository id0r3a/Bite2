using ApplicationLayer.DTOs.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.UserCommand_Query_Handler.Register
{
    public class RegisterCommand : IRequest<OperationResult<string>>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
