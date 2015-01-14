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
        public Type PropertyType
        {
            get
            {
                if (this.PropertyName == null)
                {
                    return typeof(string);
                }
                else
                {                    
                    var results = FollowPropertyPath(this.Type, this.PropertyName);
                    return results;
                }
            }
        }

        public static Type FollowPropertyPath(Type currentType, string path)
        {
            if (path == null) throw new ArgumentNullException("path");

            foreach (string propertyName in path.Split('.'))
            {
                int brackStart = propertyName.IndexOf("[");

                var property = currentType.GetProperty(brackStart > 0 ? propertyName.Substring(0, brackStart) : propertyName);

                if (property == null)
                    return null;

                currentType = property.PropertyType;

                if (brackStart > 0)
                {
                    foreach (Type iType in currentType.GetInterfaces())
                    {
                        if (iType.IsGenericType && iType.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                        {
                            currentType = iType.GetGenericArguments()[1];
                            break;
                        }
                        if (iType.IsGenericType && iType.GetGenericTypeDefinition() == typeof(ICollection<>))
                        {
                            currentType = iType.GetGenericArguments()[0];
                            break;
                        }
                    }
                }
            }

            return currentType;
        }
        
        public OperatorCollection OperatorCollection
        {
            get
            {
                if (this.PropertyName == null)
                    return new OperatorCollection(OperatorCollection.CreateFirstCollection());

                var type = this.PropertyType;
                if (typeof(string) == type || typeof(char) == type)
                {
                    this.SearchObject = this.SearchObject.ToString();
                    return new OperatorCollection(OperatorCollection.CreateStringCollection());
                }
                else if (typeof(int) == type)
                {
                    var input = 0;
                    var isSuccess = Int32.TryParse(this.SearchObject.ToString(), out input);
                    this.SearchObject = isSuccess ? input : 0;
                    return new OperatorCollection(OperatorCollection.CreateNumberCollection());
                }
                else if (typeof(double) == type)
                {
                    var input = 0d;
                    var isSuccess = Double.TryParse(this.SearchObject.ToString(), out input);
                    this.SearchObject = isSuccess ? input : 0d;
                    return new OperatorCollection(OperatorCollection.CreateNumberCollection());
                }
                else if (typeof(float) == type )
                {
                    var input = 0f;
                    var isSuccess = float.TryParse(this.SearchObject.ToString(), out input);
                    this.SearchObject = isSuccess ? input : 0f;
                    return new OperatorCollection(OperatorCollection.CreateNumberCollection());
                }
                else if (typeof(decimal) == type)
                {
                    var input = 0m;
                    var isSuccess = Decimal.TryParse(this.SearchObject.ToString(), out input);
                    this.SearchObject = isSuccess ? input : 0m;
                    return new OperatorCollection(OperatorCollection.CreateNumberCollection());
                }
                else if (typeof(DateTime) == type)
                {
                    var input = DateTime.Now.Date;
                    var isSuccess = DateTime.TryParse(this.SearchObject.ToString(), out input);
                    this.SearchObject = isSuccess ? input : DateTime.Now.Date;
                    return new OperatorCollection(OperatorCollection.CreateDateCollection());
                }
                else if (typeof(bool) == type)
                {
                    var input = false;
                    var isSuccess = Boolean.TryParse(this.SearchObject.ToString(), out input);
                    this.SearchObject = isSuccess ? input : false;
                    return new OperatorCollection(OperatorCollection.CreateBoolCollection());
                }       
                else
                {
                    this.SearchObject = "";
                    return new OperatorCollection(OperatorCollection.CreateStringCollection());
                }
            }
        }

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
                    OnPropertyChanged(() => this.PropertyType);
                    OnPropertyChanged(() => this.OperatorCollection);
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

        private object _SearchObject;

        public object SearchObject
        {
            get
            {
                return _SearchObject;
            }
            set
            {
                if (_SearchObject != value)
                {
                    _SearchObject = value;
                    OnPropertyChanged(() => this.SearchObject);
                }
            }
        }

        private Type _Type;

        public Type Type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (_Type != value)
                {
                    _Type = value;
                    OnPropertyChanged(() => this.Type);
                }
            }
        }

        private bool _IsCaseInsensitive;

        public bool IsCaseInsensitive
        {
            get
            {
                return _IsCaseInsensitive;
            }
            set
            {
                if (_IsCaseInsensitive != value)
                {
                    _IsCaseInsensitive = value;
                    OnPropertyChanged(() => this.IsCaseInsensitive);
                }
            }
        }
    }
}
