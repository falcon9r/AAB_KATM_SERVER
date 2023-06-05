using AAB_KATM_SERVER.DTOs.Clients;
using AAB_KATM_SERVER.Entities;
using AAB_KATM_SERVER.Repositories;
using FluentValidation;
using System.Data;

namespace AAB_KATM_SERVER.Validators
{
    public class ClientValidator :  AbstractValidator<ClientDTO>
    {
        public ClientValidator(IClientRepository clientRepository)
        {
            RuleFor(client => client.ClientId).Must((client, clientId) => clientRepository.IsUnique(clientId).Result).WithMessage("Client ID must be unique");
            RuleFor(client => client.NumberOfDeviations).NotNull();
            RuleFor(client => client.NumberOfContracts).NotNull();
            RuleFor(client => client.LoanAgreementAmount).NotNull();
            RuleFor(client => client.AmountOfOverdueInterests).NotNull();
            RuleFor(client => client.AmountOfOverdueDebt).NotNull();
            RuleFor(client => client.TheAmountOfUrgentDebt).NotNull();
        }
    }
}
