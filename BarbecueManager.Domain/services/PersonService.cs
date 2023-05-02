using BarbecueManager.Domain.Entities;
using BarbecueManager.Domain.Interfaces;

namespace BarbecueManager.Domain.services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IBarbecueRepository _repositoryBarbecue;

        public PersonService(IPersonRepository repository, IBarbecueRepository repositoryBarbecue)
        {
            _repository = repository;
            _repositoryBarbecue = repositoryBarbecue;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task Add(Person person, int barbecueId)
        {
            var barbecue = await _repositoryBarbecue.GetById(barbecueId);
            
            person.Barbecues = new List<Barbecue>() { barbecue };
            await _repository.Add(person);
        }

        public async Task<Person?> FindById(int id)
        {
            var person = await _repository.GetById(id);
            return person;
        }

        public async Task<List<Person>> GetAll()
        {
            var persons = await _repository.GetAll();
            return persons;
        }

        public async Task Delete(int id)
        {
            var person = await _repository.GetById(id);
            await _repository.Delete(person);
        }
    }
}
