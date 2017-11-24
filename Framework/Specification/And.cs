using System;
using System.Linq.Expressions;

namespace SAMA.Framework.Common.Helpers.Specification
{
    public class And<TEntity> : SpecificationBase<TEntity>
    {
        private readonly ISpecification<TEntity> _left;
        private readonly ISpecification<TEntity> _right;

        public And(
            ISpecification<TEntity> left,
            ISpecification<TEntity> right)
        {
            this._left = left;
            this._right = right;
        }

        // AndSpecification
        public override Expression<Func<TEntity, bool>> Criteria
        {
            get
            {
                var objParam = Expression.Parameter(typeof(TEntity), "obj");

                var newExpr = Expression.Lambda<Func<TEntity, bool>>(
                    Expression.AndAlso(
                        Expression.Invoke(_left.Criteria, objParam),
                        Expression.Invoke(_right.Criteria, objParam)
                    ),
                    objParam
                );

                return newExpr;
            }
        }
    }
}