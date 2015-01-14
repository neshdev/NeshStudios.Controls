using NeshStudios.Custom.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Custom.ViewModel
{
    public static class FiltersViewModelExtensions
    {
        public static IEnumerable<T> Filter<T>(this FiltersViewModel<T> fvm, IEnumerable<T> list)
        {
            var expression = fvm.CreateExpression();
            var filterd = list.AsQueryable().Where(expression);
            return filterd;
        }

        public static Expression<Func<T, bool>> CreateExpression<T>(this FiltersViewModel<T> fvm)
        {
            Expression<Func<T, bool>> predicate = PredicateBuilder.True<T>();;
            
            foreach (var item in fvm.Items)
            {
                var fcvm = item as FilterCriteriaViewModel;
                if (fcvm != null)
                {
                    Expression<Func<T,bool>> expression = fcvm.CreateExpression<T>();

                    switch (fcvm.LogicalOperator)
                    {
                        case LogicalOperator.Where:
                            predicate = predicate.And(expression);
                            break;
                        case LogicalOperator.WhereNot:
                            predicate = predicate.And(expression.Not());
                            break;
                        case LogicalOperator.And:
                            predicate = predicate.And(expression);
                            break;
                        case LogicalOperator.Or:
                            predicate = predicate.Or(expression);
                            break;
                        case LogicalOperator.AndNot:
                            predicate = predicate.And(expression.Not());
                            break;
                        case LogicalOperator.OrNot:
                            predicate = predicate.Or(expression.Not());
                            break;
                        default:
                            break;
                    }
                }

                var fvmInner = item as FiltersViewModel<T>;
                if (fvmInner != null)
                {
                    Expression<Func<T, bool>> expression = fvmInner.CreateExpression<T>();

                    switch (fvmInner.LogicalOperator)
                    {
                        case LogicalOperator.Where:
                            predicate = predicate.And(expression);
                            break;
                        case LogicalOperator.WhereNot:
                            predicate = predicate.And(expression.Not());
                            break;
                        case LogicalOperator.And:
                            predicate = predicate.And(expression);
                            break;
                        case LogicalOperator.Or:
                            predicate = predicate.Or(expression);
                            break;
                        case LogicalOperator.AndNot:
                            predicate = predicate.And(expression.Not());
                            break;
                        case LogicalOperator.OrNot:
                            predicate = predicate.Or(expression.Not());
                            break;
                        default:
                            break;
                    }
                }
            }

            return predicate;
        }
    }

    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Func<T, bool> Not<T>(this Func<T, bool> predicate)
        {
            return value => !predicate(value);
        }

        public static Expression<Func<T, bool>> Not<T>(
            this Expression<Func<T, bool>> predicate)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.Not(predicate.Body),
                predicate.Parameters);
        }

    }
}
