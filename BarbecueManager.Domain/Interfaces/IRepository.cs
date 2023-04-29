using BarbecueManager.Domain.Entities;

namespace BarbecueManager.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task<TEntity?> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task<int> SaveChanges();
    }
}
