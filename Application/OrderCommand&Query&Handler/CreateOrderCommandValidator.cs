using ApplicationLayer.OrderCommand_Query_Handler.OrderCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.OrderCommand_Query_Handler
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("At least one item is required.")
                .Must(items => items.All(i => i.MenuItemId > 0 && i.Quantity > 0))
                .WithMessage("Each item must have a valid MenuItemId and Quantity > 0.");
        }
    }
}
