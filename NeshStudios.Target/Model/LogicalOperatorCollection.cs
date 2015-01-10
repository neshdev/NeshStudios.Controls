using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NeshStudios.Target.Model
{
    public class LogicalOperatorCollection : ObservableCollection<LogicalOperator>
    {
        private static LogicalOperatorCollection _LogicalOperatorCollection1= new LogicalOperatorCollection()
        {
            LogicalOperator.Where,
            LogicalOperator.WhereNot,
        };

        public static LogicalOperatorCollection CreateFirstCollection()
        {
            return _LogicalOperatorCollection1;
        }

        private static LogicalOperatorCollection _LogicalOperatorCollectionN = new LogicalOperatorCollection()
        {
                LogicalOperator.And,
                LogicalOperator.AndNot,
                LogicalOperator.Or,
                LogicalOperator.OrNot,
        };

        public static LogicalOperatorCollection CreateNCollection()
        {
            return _LogicalOperatorCollectionN;
        }
    }

    public class OperatorCollection : ObservableCollection<Operator>
    {

        private static OperatorCollection _OperatorCollection = new OperatorCollection()
        {
            Operator.Contains,
            Operator.DoesNotContain,
            Operator.StartsWith,
            Operator.EndsWith,
            Operator.Equals,
            Operator.DoesNotEqual,
            Operator.IsGreaterThan,
            Operator.IsLessThan,
            Operator.IsGreaterThanOrEqualTo,
            Operator.IsLessThanOrEqualTo,
        };
            

        public static OperatorCollection CreateFirstCollection()
        {
            return _OperatorCollection;
        }
    }


}
