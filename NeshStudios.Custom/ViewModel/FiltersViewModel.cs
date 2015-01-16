﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NeshStudios.Custom.Model;
using NeshStudios.Custom.Framework;
using System.Collections;
using NeshStudios.Custom.Utility;


namespace NeshStudios.Custom.ViewModel
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

        

        public List<string> Properties { get; private set; }

        public FiltersViewModel(List<string> properties)
        {
            this.Properties = properties;

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
                if (item != null)
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


            this.AddCommands = new ObservableCollection<Tuple<string, ICommand>> 
            { 
                Tuple.Create("Single",this.AddFilterCommand), 
                Tuple.Create("Group",this.AddGroupCommand), 
            };
        }

        public FiltersViewModel()
            : this(PropertyListBuilder.CreatePropertyList<T>())
        {
            
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
