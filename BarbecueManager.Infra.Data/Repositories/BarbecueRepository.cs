using BarbecueManager.Domain.Entities;
using BarbecueManager.Domain.Interfaces;

namespace BarbecueManager.Infra.Data.Repositories
{
    public class BarbecueRepository : Repository<Barbecue>, IBarbecueRepository
    {
        public BarbecueRepository(BarbecueManagerContext context) : base(context) { }

        public Task RemovePerson(int idPerson)
        {
            throw new NotImplementedException();
        }
    }
}
