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
    public class RegisterCommand : IRequest<OperationResult<string>>
    {
        public RegisterDTO RegisterDto { get; }

        //public RegisterCommand(RegisterDTO dto)
        //{
        //    RegisterDto = dto;
        //}
    }

}
