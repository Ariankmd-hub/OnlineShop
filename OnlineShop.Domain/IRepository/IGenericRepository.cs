using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.IRepository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        
        // IEnumerable much lighter than ICollection . 
        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        void Update(T entity);
        void Remove(T entity);

    }
}
