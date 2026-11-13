using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.IRepository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        
        // IEnumerable much lighter than ICollection . 
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

        Task AddAsync(T entity, CancellationToken cancellationToken);

        void Update(T entity);
        void Remove(T entity);

    }
}
