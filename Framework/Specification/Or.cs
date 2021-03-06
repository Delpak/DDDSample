﻿using System;
using System.Linq.Expressions;

namespace SAMA.Framework.Common.Helpers.Specification
{
    public class Or<T> : SpecificationBase<T>
    {
        private readonly ISpecification<T> left;
        private readonly ISpecification<T> right;

        public Or(
            ISpecification<T> left,
            ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        // OrSpecification
        public override Expression<Func<T, bool>> Criteria
        {
            get
            {
                var objParam = Expression.Parameter(typeof(T), "obj");

                var newExpr = Expression.Lambda<Func<T, bool>>(
                    Expression.OrElse(
                        Expression.Invoke(left.Criteria, objParam),
                        Expression.Invoke(right.Criteria, objParam)
                    ),
                    objParam
                );

                return newExpr;
            }
        }
    }
}