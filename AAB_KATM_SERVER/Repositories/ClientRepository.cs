using AAB_KATM_SERVER.DTOs.Clients;
using AAB_KATM_SERVER.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AAB_KATM_SERVER.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMapper mapper;
        private readonly ApplicationContext _context;

        public ClientRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task Create(Client instance)
        {
            await _context.Clients.AddAsync(instance);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetById(int id)
        {
            return await _context.Clients.Where(client => client.ClientId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> IsUnique(int clientId)
        {
            return !(await _context.Clients.Where(client => client.ClientId == clientId).AnyAsync());
        }

        public async Task<bool> Update(int id, Client instance)
        {
            Client client = await GetById(id);
            
            if (client is null)
            {
                return false;
            }

            client.NumberOfDeviations = instance.NumberOfDeviations;
            client.NumberOfContracts = instance.NumberOfContracts;
            client.AmountOfOverdueDebt = instance.AmountOfOverdueDebt;
            client.LoanAgreementAmount = instance.LoanAgreementAmount;
            client.AmountOfOverdueDebt = instance.AmountOfOverdueDebt;
            client.AmountOfOverdueInterests = instance.AmountOfOverdueInterests;

            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
