using BarbecueManager.Domain.Entities;
using BarbecueManager.Domain.Interfaces;
using BarbecueManager.Domain.services;
using Moq;

namespace BarbecueManager.Domain.Tests.Services
{
    public class BarbecueServiceTests
    {
        [Fact]
        public async void GetById_Success()
        {
            // Arrange
            var id = 1;
            var barbecue = new Barbecue("description", "observation", DateTime.UtcNow, 200, 150);
            barbecue.Id = id;

            var barbecueRepository = new Mock<IBarbecueRepository>();
            barbecueRepository.Setup(props => props.GetById(id))
               .ReturnsAsync(barbecue);

            var planetService = new BarbecueService(barbecueRepository.Object);

            // Act
            var result = await planetService.FindById(id);

            // Assert
            Assert.NotNull(result);
            barbecueRepository.Verify(r => r.GetById(id), Times.Once);
        }

        [Fact]
        public async void GetAll_Success()
        {
            // Arrange
            var barbecues = new List<Barbecue>();
            barbecues.Add(new Barbecue() { Id = 1 });
            barbecues.Add(new Barbecue() { Id = 2 });

            var barbecueRepository = new Mock<IBarbecueRepository>();
            barbecueRepository.Setup(props => props.GetAll())
               .ReturnsAsync(barbecues);

            var planetService = new BarbecueService(barbecueRepository.Object);

            // Act
            var result = await planetService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.ToList().Count, barbecues.Count);
            barbecueRepository.Verify(r => r.GetAll(), Times.Once);
        }
    }
}
