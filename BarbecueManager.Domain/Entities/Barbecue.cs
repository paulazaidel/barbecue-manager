using System.Numerics;

namespace BarbecueManager.Domain.Entities
{
    public class Barbecue : Entity
    {
        public Barbecue() { }
        public Barbecue(string description, string observation, DateTime date, decimal contributionAmountWithDrinks, decimal contributionAmountWithoutDrinks)
        {
            this.Description = description;
            this.Observation = observation; 
            this.Date = date;
            this.ContributionAmountWithDrinks = contributionAmountWithDrinks;
            this.ContributionAmountWithoutDrinks = contributionAmountWithoutDrinks;
        }

        public string Description { get; set; }
        public string Observation { get; set; }
        public DateTime Date { get; set; }
        public Decimal ContributionAmountWithDrinks { get; set; }
        public Decimal ContributionAmountWithoutDrinks { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
