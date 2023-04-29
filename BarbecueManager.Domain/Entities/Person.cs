namespace BarbecueManager.Domain.Entities
{
    public class Person : Entity
    {
        public Person(string fullname, decimal contributionAmount)
        {
            this.Fullname = fullname;
            this.ContributionAmount = contributionAmount;
        }

        public string Fullname { get; set; }
        public Decimal ContributionAmount { get; set; }

        public virtual ICollection<Barbecue> Barbecues { get; set; }
    }
}
