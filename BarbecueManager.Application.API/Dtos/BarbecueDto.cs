using BarbecueManager.Domain.Entities;

namespace BarbecueManager.Application.API.Dtos
{
    public class BarbecueDto
    {
        public string Description { get; set; }
        public string Observation { get; set; }
        public DateTime Date { get; set; }
        public Decimal ContributionAmountWithDrinks { get; set; }
        public Decimal ContributionAmountWithoutDrinks { get; set; }
    }
}
