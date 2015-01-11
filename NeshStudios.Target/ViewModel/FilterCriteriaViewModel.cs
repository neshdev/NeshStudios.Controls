using NeshStudios.Target.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NeshStudios.Target.ViewModel
{
    public class FilterCriteriaViewModel : NotificationObject
    {
        private LogicalOperatorCollection _LogicalOperators;

        public LogicalOperatorCollection LogicalOperators
        {
            get
            {
                return _LogicalOperators;
            }
            set
            {
                if (_LogicalOperators != value)
                {
                    _LogicalOperators = value;
                    OnPropertyChanged(() => this.LogicalOperators);
                }
            }
        }

        private OperatorCollection _Operators;

        public OperatorCollection Operators
        {
            get
            {
                return _Operators;
            }
            set
            {
                if (_Operators != value)
                {
                    _Operators = value;
                    OnPropertyChanged(() => this.Operators);
                }
            }
        }

        private List<string> _PropertyNames;

        public List<string> PropertyNames
        {
            get
            {
                return _PropertyNames;
            }
            set
            {
                if (_PropertyNames != value)
                {
                    _PropertyNames = value;
                    OnPropertyChanged(() => this.PropertyNames);
                }
            }
        }

        private LogicalOperator _LogicalOperator;

        public LogicalOperator LogicalOperator
        {
            get
            {
                return _LogicalOperator;
            }
            set
            {
                if (_LogicalOperator != value)
                {
                    _LogicalOperator = value;
                    OnPropertyChanged(() => this.LogicalOperator);
                }
            }
        }

        private string _PropertyName;

        public string PropertyName
        {
            get
            {
                return _PropertyName;
            }
            set
            {
                if (_PropertyName != value)
                {
                    _PropertyName = value;
                    OnPropertyChanged(() => this.PropertyName);
                }
            }
        }

        private Operator _Operator;

        public Operator Operator
        {
            get
            {
                return _Operator;
            }
            set
            {
                if (_Operator != value)
                {
                    _Operator = value;
                    OnPropertyChanged(() => this.Operator);
                }
            }
        }

        private string _SearchText;

        public string SearchText
        {
            get
            {
                return _SearchText;
            }
            set
            {
                if (_SearchText != value)
                {
                    _SearchText = value;
                    OnPropertyChanged(() => this.SearchText);
                }
            }
        }
    }
}
