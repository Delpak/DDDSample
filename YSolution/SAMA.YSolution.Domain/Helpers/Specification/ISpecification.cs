using System;
using System.Linq.Expressions;

namespace SAMA.YSolution.Domain.Helpers.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecExpression { get; }
        bool IsSatisfiedBy(T obj);
    }
}