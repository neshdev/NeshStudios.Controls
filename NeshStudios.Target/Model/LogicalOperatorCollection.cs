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

        public LogicalOperatorCollection(IEnumerable<LogicalOperator> operators)
        {
            foreach (var item in operators)
            {
                this.Add(item);
            }
        }

        public LogicalOperatorCollection()
            : base ()
        {

        }


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
}
