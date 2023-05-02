using BarbecueManager.Domain.Entities;

namespace BarbecueManager.Domain.Interfaces
{
    public interface IPersonService : IDisposable
    {
        Task Add(Person person, int barbecueId);
        Task<Person?> FindById(int id);
        Task<List<Person>> GetAll();
        Task Delete(int id);
    }
}
