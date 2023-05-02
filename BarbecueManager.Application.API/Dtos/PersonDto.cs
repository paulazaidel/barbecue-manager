using BarbecueManager.Domain.Entities;

namespace BarbecueManager.Application.API.Dtos
{
    public class PersonDto
    {
        public string Fullname { get; set; }
        public Decimal ContributionAmount { get; set; }

        public int BarbecueId { get; set; }
    }
}
