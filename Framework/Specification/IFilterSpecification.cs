using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SAMA.Framework.Common.Helpers.Specification
{
    /// <summary>
    /// <see cref="eShopOnWeb"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFilterSpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        void AddInclude(Expression<Func<T, object>> includeExpression);
    }
}