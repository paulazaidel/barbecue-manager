using BarbecueManager.Domain.Entities;
using BarbecueManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarbecueManager.Infra.Data.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(BarbecueManagerContext context) : base(context) { }

        public async Task Delete(Person person)
        {
            Context.Entry(person).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }
    }
}
