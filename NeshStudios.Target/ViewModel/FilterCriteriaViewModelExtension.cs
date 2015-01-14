using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Target.ViewModel
{
    public static class FilterCriteriaViewModelExtension
    {
        public static void Validate(this FilterCriteriaViewModel fcvm)
        {
            if (string.IsNullOrEmpty( fcvm.PropertyName))
            {
                throw new ArgumentException("PropertyName cannot be empty or null");
            }

            if (!fcvm.PropertyNames.Any(x=> x == fcvm.PropertyName))
            {
                throw new ArgumentException("PropertyName does not exists in class " + fcvm.Type.Name);
            }

            if ( fcvm.SearchObject == null)
            {
                throw new ArgumentException("SearchObject cannot be null");
            }
        }

        public static Expression<Func<T, bool>> CreateExpression<T>(this FilterCriteriaViewModel vm)
        {
            vm.Validate();

            Expression operatorExpression = null;
            MethodInfo method = null;
            ParameterExpression pe = Expression.Parameter(vm.Type, "x");

            Expression body = pe;
            foreach (var member in vm.PropertyName.Split('.'))
            {
                body = Expression.PropertyOrField(body, member);
            }

            Expression property = body;
            vm.SearchObject = Convert.ChangeType(vm.SearchObject, vm.PropertyType);
            Expression constant = Expression.Constant(vm.SearchObject, vm.PropertyType);

            if (vm.IsCaseInsensitive == false && vm.PropertyType == typeof(string))
            {
                method = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);
                property = Expression.Call(property, method);
                constant = Expression.Constant(((String)vm.SearchObject).ToLower());
            }
            
            switch (vm.Operator)
            {
                case NeshStudios.Target.Model.Operator.Equals:
                    operatorExpression = Expression.Equal(property, constant);
                    break;
                case NeshStudios.Target.Model.Operator.DoesNotEqual:
                    operatorExpression = Expression.NotEqual(property, constant);
                    break;
                case NeshStudios.Target.Model.Operator.IsGreaterThan:
                    operatorExpression = Expression.GreaterThan(property, constant);
                    break;
                case NeshStudios.Target.Model.Operator.IsLessThan:
                    operatorExpression = Expression.LessThan(property, constant);
                    break;
                case NeshStudios.Target.Model.Operator.IsGreaterThanOrEqualTo:
                    operatorExpression = Expression.GreaterThanOrEqual(property, constant);
                    break;
                case NeshStudios.Target.Model.Operator.IsLessThanOrEqualTo:
                    operatorExpression = Expression.LessThanOrEqual(property, constant);
                    break;
                case NeshStudios.Target.Model.Operator.StartsWith:
                    method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
                    operatorExpression = Expression.Call(property, method, constant);
                    break;
                case NeshStudios.Target.Model.Operator.Contains:
                    method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    operatorExpression = Expression.Call(property, method, constant);
                    break;
                case NeshStudios.Target.Model.Operator.DoesNotContain:
                    method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    operatorExpression = Expression.Call(property, method, constant);
                    operatorExpression = Expression.Not(operatorExpression);
                    break;
                case NeshStudios.Target.Model.Operator.EndsWith:
                    method = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
                    operatorExpression = Expression.Call(property, method, constant);
                    break;
                default:
                    Expression.Equal(property, constant);
                    break;
            }
            
            return Expression.Lambda<Func<T, bool>>(operatorExpression, pe);
        }
    }
}
