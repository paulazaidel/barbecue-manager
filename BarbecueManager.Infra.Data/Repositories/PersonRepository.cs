using BarbecueManager.Domain.Entities;
using BarbecueManager.Domain.Interfaces;

namespace BarbecueManager.Infra.Data.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(BarbecueManagerContext context) : base(context) { }
    }
}
