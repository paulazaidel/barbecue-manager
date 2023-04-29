using BarbecueManager.Domain.Entities;

namespace BarbecueManager.Domain.Interfaces
{
    public interface IBarbecueRepository : IRepository<Barbecue> 
    {
        Task RemovePerson(int idPerson);
    }
}
