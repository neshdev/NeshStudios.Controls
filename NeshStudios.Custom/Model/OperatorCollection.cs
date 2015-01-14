using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NeshStudios.Custom.Model
{
    public class OperatorCollection : ObservableCollection<Operator>
    {
        public OperatorCollection(IEnumerable<Operator> operators)
        {
            foreach (var item in operators)
            {
                this.Add(item);
            }
        }

        public OperatorCollection()
            : base()
        {

        }


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

        private static OperatorCollection _StringOperatorCollection = new OperatorCollection()
        {
            Operator.Contains,
            Operator.DoesNotContain,
            Operator.StartsWith,
            Operator.EndsWith,
            Operator.Equals,
            Operator.DoesNotEqual,
        };

        private static OperatorCollection _NumberCollection = new OperatorCollection()
        {
            Operator.Equals,
            Operator.DoesNotEqual,
            Operator.IsGreaterThan,
            Operator.IsLessThan,
            Operator.IsGreaterThanOrEqualTo,
            Operator.IsLessThanOrEqualTo,
        };

        private static OperatorCollection _DateCollection = new OperatorCollection()
        {
            Operator.Equals,
            Operator.DoesNotEqual,
            Operator.IsGreaterThan,
            Operator.IsLessThan,
            Operator.IsGreaterThanOrEqualTo,
            Operator.IsLessThanOrEqualTo,
        };

        private static OperatorCollection _BoolCollection = new OperatorCollection()
        {
            Operator.Equals,
            Operator.DoesNotEqual,
        };


        public static OperatorCollection CreateFirstCollection()
        {
            return _OperatorCollection;
        }

        public static OperatorCollection CreateStringCollection()
        {
            return _StringOperatorCollection;
        }

        public static OperatorCollection CreateNumberCollection()
        {
            return _NumberCollection;
        }


        public static OperatorCollection CreateDateCollection()
        {
            return _DateCollection;
        }

        public static OperatorCollection CreateBoolCollection()
        {
            return _BoolCollection;
        }


    }
}
