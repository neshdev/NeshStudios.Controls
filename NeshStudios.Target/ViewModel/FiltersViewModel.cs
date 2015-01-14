using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NeshStudios.Target.Model;


namespace NeshStudios.Target.ViewModel
{
    public class FiltersViewModel<T> : NotificationObject
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


        private void CreatePropertyList(Type t, List<string> values, string baseName)
        {
            foreach (var item in t.GetProperties())
            {
                var propertyName = item.Name;

                if (item.PropertyType.IsClass && !(item.PropertyType.Module.ScopeName == "CommonLanguageRuntimeLibrary"))
                {
                    this.CreatePropertyList(item.PropertyType, values, propertyName + ".");
                }
                //need to think about how to implement collections
                //todo, does not support collection types
                //else if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                //{
                    
                //}
                //else if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                //{
                   
                //}
                //else if (item.PropertyType.GetInterface(typeof(IEnumerable<>).FullName) != null)
                //{
                   
                //}
                else
                {
                    values.Add(baseName + propertyName);
                }
            }
        }


        List<string> properties;

        public FiltersViewModel()
        {
            var list = new List<string>();
            CreatePropertyList(typeof(T), list , string.Empty);
            properties = list;
                
            this.Items = new ObservableCollection<object>();

            this.AddFilterCommand = new RelayCommand((o) =>
            {
                var collection = this.Items.Count == 0 ? LogicalOperatorCollection.CreateFirstCollection() : LogicalOperatorCollection.CreateNCollection();
                var logicalOperator = this.Items.Count == 0 ? LogicalOperator.Where : Model.LogicalOperator.And;
                

                this.Items.Add(new FilterCriteriaViewModel
                {
                    LogicalOperators = new LogicalOperatorCollection(collection),
                    LogicalOperator = logicalOperator, 
                    Operator = Operator.Contains,
                    PropertyNames = properties,
                    PropertyName = properties.First(),
                    Type = typeof(T),
                    SearchObject = "",
                });
            });

            this.RemoveFilterCommand = new RelayCommand((o) =>
            {
                var item = o as FilterCriteriaViewModel;
                if ( item != null)
                {
                    this.Items.Remove(item);
                }
            });

            this.AddGroupCommand = new RelayCommand((o) =>
            {
                var collection = this.Items.Count == 0 ? LogicalOperatorCollection.CreateFirstCollection() : LogicalOperatorCollection.CreateNCollection();
                var logicalOperator = this.Items.Count == 0 ? LogicalOperator.Where : Model.LogicalOperator.And;

                var fvm = new FiltersViewModel<T>();
                fvm.LogicalOperators = new LogicalOperatorCollection(collection);
                fvm.LogicalOperator = logicalOperator;

                fvm.AddFilterCommand.Execute(null);
                this.Items.Add(fvm);
            });


            this.RemoveGroupCommand = new RelayCommand((o) =>
            {
                var item = o as FiltersViewModel<T>;
                if (item != null)
                {
                    this.Items.Remove(item);
                }
            });


            this.AddCommands = new ObservableCollection<Tuple<string,ICommand>> 
            { 
                Tuple.Create("Single",this.AddFilterCommand), 
                Tuple.Create("Group",this.AddGroupCommand), 
            };
        }

        private ObservableCollection<object> _Items;

        public ObservableCollection<object> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                if (_Items != value)
                {
                    _Items = value;
                    OnPropertyChanged(() => this.Items);
                }
            }
        }

        private ObservableCollection<Tuple<string,ICommand>> _AddCommands;

        public ObservableCollection<Tuple<string, ICommand>> AddCommands
        {
            get
            {
                return _AddCommands;
            }
            set
            {
                if (_AddCommands != value)
                {
                    _AddCommands = value;
                    OnPropertyChanged(() => this.AddCommands);
                }
            }
        }

        


        public ICommand AddFilterCommand { get; set; }
        public ICommand RemoveFilterCommand { get; set; }

        public ICommand AddGroupCommand { get; set; }
        public ICommand RemoveGroupCommand { get; set; }        
    }
}
