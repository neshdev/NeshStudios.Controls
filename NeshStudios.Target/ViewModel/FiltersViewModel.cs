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

        List<string> properties = typeof(T).GetProperties().Select(x => x.Name).ToList();

        public FiltersViewModel()
        {
            this.FilterCriterias = new ObservableCollection<FilterCriteriaViewModel>();
            this.Filters = new ObservableCollection<FiltersViewModel<T>>();

            this.AddFilterCommand = new RelayCommand((o) =>
            {
                var collection = this.FilterCriterias.Count == 0 ? LogicalOperatorCollection.CreateFirstCollection() : LogicalOperatorCollection.CreateNCollection();
                var logicalOperator = this.FilterCriterias.Count == 0 ? LogicalOperator.Where : Model.LogicalOperator.And;
                

                this.FilterCriterias.Add(new FilterCriteriaViewModel 
                {
                    LogicalOperators = collection,
                    LogicalOperator = logicalOperator, 
                    Operators = OperatorCollection.CreateFirstCollection(),
                    Operator = Operator.Equals,
                    PropertyNames = properties,
                });
            });

            this.RemoveFilterCommand = new RelayCommand((o) =>
            {
                var item = o as FilterCriteriaViewModel;
                if ( item != null)
                {
                    this.FilterCriterias.Remove(item);
                }
            });

            this.AddGroupCommand = new RelayCommand((o) =>
            {
                var collection = this.Filters.Count == 0 ? LogicalOperatorCollection.CreateFirstCollection() : LogicalOperatorCollection.CreateNCollection();
                var logicalOperator = this.Filters.Count == 0 ? LogicalOperator.Where : Model.LogicalOperator.And;

                var fvm = new FiltersViewModel<T>();
                fvm.LogicalOperators = collection;
                fvm.LogicalOperator = logicalOperator;

                fvm.AddFilterCommand.Execute(null);
                this.Filters.Add(fvm);
            });


            this.RemoveGroupCommand = new RelayCommand((o) =>
            {
                var item = o as FiltersViewModel<T>;
                if (item != null)
                {
                    this.Filters.Remove(item);
                }
            });
        }

        private ObservableCollection<FilterCriteriaViewModel> _FilterCriterias;

        public ObservableCollection<FilterCriteriaViewModel> FilterCriterias
        {
            get
            {
                return _FilterCriterias;
            }
            set
            {
                if (_FilterCriterias != value)
                {
                    _FilterCriterias = value;
                    OnPropertyChanged(() => this.FilterCriterias);
                }
            }
        }

        private ObservableCollection<FiltersViewModel<T>> _Filters;

        public ObservableCollection<FiltersViewModel<T>> Filters
        {
            get
            {
                return _Filters;
            }
            set
            {
                if (_Filters != value)
                {
                    _Filters = value;
                    OnPropertyChanged(() => this.Filters);
                }
            }
        }

        public ICommand AddFilterCommand { get; set; }
        public ICommand RemoveFilterCommand { get; set; }

        public ICommand AddGroupCommand { get; set; }
        public ICommand RemoveGroupCommand { get; set; }        
    }
}
