using SAMA.Framework.Common.Helpers.Domain;

namespace SAMA.YSolution.Domain.Countries
{
    public class CountryCreated : DomainEvent
    {
        public Country Country { get; set; }

        public override void Flatten()
        {
            Args.Add("Id", Country.Id);
            Args.Add("Name", Country.Name);
        }
    }
}