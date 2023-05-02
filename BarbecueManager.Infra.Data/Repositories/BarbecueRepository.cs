using BarbecueManager.Domain.Entities;
using BarbecueManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarbecueManager.Infra.Data.Repositories
{
    public class BarbecueRepository : Repository<Barbecue>, IBarbecueRepository
    {
        public BarbecueRepository(BarbecueManagerContext context) : base(context) { }

        public override async Task<List<Barbecue>> GetAll()
        {
            return await Context.Barbecues
                .AsNoTracking()
                .Include(p => p.Persons)
                .ToListAsync();
        }

        public override async Task<Barbecue?> GetById(int id)
        {
            return await Context.Barbecues
                .Include(prop => prop.Persons)
                .FirstOrDefaultAsync(prop => prop.Id == id);
        }

        public Task RemovePerson(int idPerson)
        {
            throw new NotImplementedException();
        }
    }
}
