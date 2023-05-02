using BarbecueManager.Domain.Entities;

namespace BarbecueManager.Domain.Interfaces
{
    public interface IBarbecueService : IDisposable
    {
        Task Add(Barbecue barbecue);
        Task<Barbecue?> FindById(int id);
        Task<List<Barbecue>> GetAll();
    }
}
