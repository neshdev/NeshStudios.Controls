using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Target.ViewModel
{
    public static class FiltersViewModelExtensions 
    {
        public static IQueryable<T> CreateLambda<T>(FiltersViewModel<T> fvm, IEnumerable<T> list )
        {
            if ( fvm.Items.Count == 0)
            {
                throw new NotImplementedException("invalid");
            }

            var firstItem = fvm.Items.First();

            var fcvm = firstItem as FilterCriteriaViewModel;
            var expressionRoot = fcvm.CreateExpression<T>();
            if (fcvm != null)
            {
                for (int i = 1; i < fvm.Items.Count; i++)
                {
                    var expression = ((FilterCriteriaViewModel)fvm.Items[i]).CreateExpression<T>();
                    switch (((FilterCriteriaViewModel)fvm.Items[i]).LogicalOperator)
                    {
                        case NeshStudios.Target.Model.LogicalOperator.And:
                            expressionRoot = expressionRoot.And(expression);
                            break;
                        case NeshStudios.Target.Model.LogicalOperator.Or:
                            expressionRoot = expressionRoot.Or(expression);
                            break;
                        default:
                            break;
                    }
                }

            }

            return list.AsQueryable().Where(expressionRoot);
        }
    }

    public class ParameterRebinder : ExpressionVisitor
    {

        private readonly Dictionary<ParameterExpression, ParameterExpression> map;



        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {

            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();

        }



        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {

            return new ParameterRebinder(map).Visit(exp);

        }



        protected override Expression VisitParameter(ParameterExpression p)
        {

            ParameterExpression replacement;

            if (map.TryGetValue(p, out replacement))
            {

                p = replacement;

            }

            return base.VisitParameter(p);

        }

    }


    public static class Utility
    {

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {

            // build parameter map (from parameters of second to parameters of first)

            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);



            // replace parameters in the second lambda expression with parameters from the first

            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);



            // apply composition of lambda expression bodies to parameters from the first expression 

            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);

        }



        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {

            return first.Compose(second, Expression.And);

        }



        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {

            return first.Compose(second, Expression.Or);

        }

        public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {

            return first.Compose(second, Expression.Or);

        }

        public static Expression<Func<T, bool>> BuildAnd<T>(params Expression<Func<T, bool>>[] conditions)
        {
            return conditions.Aggregate<Expression<Func<T, bool>>, Expression<Func<T, bool>>>(null, (current, expression) => current == null ? expression : current.And(expression));
        }

        public static Expression<Func<T, bool>> BuildOr<T>(params Expression<Func<T, bool>>[] conditions)
        {
            return conditions.Aggregate<Expression<Func<T, bool>>, Expression<Func<T, bool>>>(null, (current, expression) => current == null ? expression : current.Or(expression));
        }

        public static Expression<Func<T, bool>> BuildOrElse<T>(params Expression<Func<T, bool>>[] conditions)
        {
            return conditions.Aggregate<Expression<Func<T, bool>>, Expression<Func<T, bool>>>(null, (current, expression) => current == null ? expression : current.OrElse(expression));
        }

    }

    //public static class PredicateBuilder
    //{
    //    public static Expression<Func<T, bool>> True<T>() { return f => true; }
    //    public static Expression<Func<T, bool>> False<T>() { return f => false; }

    //    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
    //                                                        Expression<Func<T, bool>> expr2)
    //    {
    //        var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
    //        return Expression.Lambda<Func<T, bool>>
    //              (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
    //    }

    //    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
    //                                                         Expression<Func<T, bool>> expr2)
    //    {
    //        var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
    //        return Expression.Lambda<Func<T, bool>>
    //              (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
    //    }
    //}
}
