using AAB_KATM_SERVER.Entities;

namespace AAB_KATM_SERVER.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<bool> IsUnique(int clientId);
    }
}
