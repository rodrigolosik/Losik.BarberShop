using FluentValidation;
using Losik.BarberShop.Domain.Dtos.Clients;

namespace Losik.BarberShop.CrossCutting.Validators.Dtos
{
    public class AddNewClientDtoValidator : AbstractValidator<ClientDto>
    {
        public AddNewClientDtoValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(client => client.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(client => client.Email)
                .EmailAddress()
                .NotNull()
                .NotEmpty();

            RuleFor(client => client.BirthDate)
                .NotEmpty()
                .NotNull();

            RuleFor(client => client.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .MinimumLength(11);
        }
    }
}
