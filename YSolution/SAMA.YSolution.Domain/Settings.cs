using SAMA.YSolution.Domain.Countries;

namespace SAMA.YSolution.Domain
{
    public class Settings
    {
        public Settings()
        {
        }

        public Settings(Country businessCountry)
        {
            BusinessCountry = businessCountry;
        }

        public virtual Country BusinessCountry { get; protected set; }
    }
}