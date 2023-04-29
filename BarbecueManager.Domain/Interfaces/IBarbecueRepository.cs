using BarbecueManager.Domain.Entities;

namespace BarbecueManager.Domain.Interfaces
{
    public interface IBarbecue : IRepository<Barbecue> 
    {
        Task RemovePerson(int idPerson);
    }
}
