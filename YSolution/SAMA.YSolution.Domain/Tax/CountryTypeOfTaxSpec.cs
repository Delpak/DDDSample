using System;
using System.Linq.Expressions;
using SAMA.Framework.Common.Helpers.Specification;

namespace SAMA.YSolution.Domain.Tax
{
    public class CountryTypeOfTaxSpec : SpecificationBase<CountryTax>
    {
        private readonly Guid countryId;
        private readonly TaxType taxType;

        public CountryTypeOfTaxSpec(Guid countryId, TaxType taxType)
        {
            this.countryId = countryId;
            this.taxType = taxType;
        }

        public override Expression<Func<CountryTax, bool>> SpecExpression
        {
            get
            {
                return countryTax => countryTax.Country.Id == countryId
                                     && countryTax.Type == taxType;
            }
        }

        public override bool Equals(object obj)
        {
            var countryTypeOfTaxSpecCompare = obj as CountryTypeOfTaxSpec;
            if (countryTypeOfTaxSpecCompare == null)
                throw new InvalidCastException("obj");

            return countryTypeOfTaxSpecCompare.countryId == countryId &&
                   countryTypeOfTaxSpecCompare.taxType == taxType;
        }
    }
}