using BarbecueManager.Domain.Entities;
using BarbecueManager.Domain.Interfaces;
using System;

namespace BarbecueManager.Domain.services
{
    public class BarbecueService : IBarbecueService
    {
        private readonly IBarbecueRepository _repository;
        public BarbecueService(IBarbecueRepository repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task Add(Barbecue barbecue)
        {
            await _repository.Add(barbecue);
        }

        public async Task<Barbecue?> FindById(int id)
        {
            var barbecue = await _repository.GetById(id);
            return barbecue;
        }

        public async Task<List<Barbecue>> GetAll()
        {
            var barbecue = await _repository.GetAll();
            return barbecue;
        }
    }
}
