

namespace Donation_Platform_For_Education.Domain.Abstarction
{
    public interface IGenericRepository<T, Tkey>
    {
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(Tkey id);
        Task<T> Update(T entity);
    }
}
