using System;
using System.Linq.Expressions;

namespace SAMA.Framework.Common.Helpers.Specification
{
    public abstract class SpecificationBase<T> : ISpecification<T>
    {
        private Func<T, bool> _compiledExpression;

        private Func<T, bool> CompiledExpression =>
            _compiledExpression ?? (_compiledExpression = SpecExpression.Compile());

        public abstract Expression<Func<T, bool>> SpecExpression { get; }

        public bool IsSatisfiedBy(T obj)
        {
            return CompiledExpression(obj);
        }
    }
}