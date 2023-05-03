using BarbecueManager.Domain.Entities;
using BarbecueManager.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarbecueManager.Infra.Data.Tests.Repositories
{
    public class BarbecueRepositoryTests
    {
        private readonly BarbecueRepository _barbecueRepository;
        private readonly BarbecueManagerContext _context;

        public BarbecueRepositoryTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BarbecueManagerContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new BarbecueManagerContext(optionsBuilder.Options);
            _barbecueRepository = new BarbecueRepository(_context);

            var barbecue = new Barbecue() { Description = "Test" , Observation = "Observation" };


            _context.Barbecues.Add(barbecue);
            _context.SaveChanges();
        }

        [Fact]
        public async void Add_Success()
        {
            // Arrange
            var description = "TestAdd";

            // Act
            var barbecue = new Barbecue(description, "observation", DateTime.UtcNow, 200, 150);
            await _barbecueRepository.Add(barbecue);

            // Assert
            var expected = _context.Barbecues.FirstOrDefault(x => x.Description == description);
            Assert.NotNull(expected);
        }

        [Fact]
        public async void GetAll_Success()
        {
            // Act
            var result = await _barbecueRepository.GetAll();

            // Assert
            var expected = _context.Barbecues.ToList();
            Assert.NotNull(result);
            Assert.Equal(expected.Count, result.Count); ;
        }

        [Fact]
        public async void GetById_Success()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _barbecueRepository.GetById(id);

            // Assert
            Assert.NotNull(result);
        }
    }
}
