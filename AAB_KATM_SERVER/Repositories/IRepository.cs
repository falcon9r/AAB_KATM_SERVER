namespace AAB_KATM_SERVER.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task Create(T instance);

        Task<bool> Update(int id, T instance);

        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        Task Delete(int id);
    }
}
