using System;
using SAMA.YSolution.Domain.Customers;
using SAMA.YSolution.Domain.Helpers.Domain;
using SAMA.YSolution.Domain.Helpers.Repository;
using SAMA.YSolution.Domain.Products;
using SAMA.YSolution.Domain.Tax;

namespace SAMA.YSolution.Domain.Services
{
    public class TaxService : IDomainService
    {
        private readonly IRepository<CountryTax> countryTax;
        private readonly Settings settings;

        public TaxService(Settings settings, IRepository<CountryTax> countryTax)
        {
            this.countryTax = countryTax;
            this.settings = settings;
        }

        public decimal Calculate(Customer customer, Product product)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (product == null)
                throw new ArgumentNullException("product");

            var customerCountryTax = countryTax.FindOne(new CountryTypeOfTaxSpec(customer.CountryId, TaxType.Customer));
            var businessCountryTax =
                countryTax.FindOne(new CountryTypeOfTaxSpec(settings.BusinessCountry.Id, TaxType.Business));

            return product.Cost * customerCountryTax.Percentage
                   + product.Cost * businessCountryTax.Percentage;
        }
    }
}