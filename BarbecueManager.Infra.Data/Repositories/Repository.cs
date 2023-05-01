using BarbecueManager.Domain.Entities;
using BarbecueManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarbecueManager.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly BarbecueManagerContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(BarbecueManagerContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
