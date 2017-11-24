using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SAMA.Framework.Common.Helpers.Specification
{
    public abstract class SpecificationBase<TEntity> : ISpecification<TEntity>
    {
        private Func<TEntity, bool> _compiledExpression;

        private Func<TEntity, bool> CompiledExpression =>
            _compiledExpression ?? (_compiledExpression = Criteria.Compile());

        public abstract Expression<Func<TEntity, bool>> Criteria { get; }
        public List<Expression<Func<TEntity, object>>> Includes { get; }
        public List<string> IncludeStrings { get; }

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return CompiledExpression(candidate);
        }

        protected virtual void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
    }
}