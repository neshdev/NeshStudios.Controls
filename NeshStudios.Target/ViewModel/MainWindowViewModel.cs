using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NeshStudios.Target.Common;
using NeshStudios.Custom.ViewModel;
using NeshStudios.Custom.Framework;
using NeshStudios.Target.Model;

namespace NeshStudios.Target.ViewModel
{
    public class MainWindowViewModel : NotificationObject
    {
        private ObservableCollection<FiltersViewModel<Person>> _FiltersTree;

        public ObservableCollection<FiltersViewModel<Person>> FiltersTree
        {
            get
            {
                return _FiltersTree;
            }
            set
            {
                if (_FiltersTree != value)
                {
                    _FiltersTree = value;
                    OnPropertyChanged(() => this.FiltersTree);
                }
            }
        }

        private ObservableCollection<Person> _MasterList;

        public ObservableCollection<Person> MasterList
        {
            get
            {
                return _MasterList;
            }
            set
            {
                if (_MasterList != value)
                {
                    _MasterList = value;
                    OnPropertyChanged(() => this.MasterList);
                }
            }
        }

        private ObservableCollection<Person> _Persons;

        public ObservableCollection<Person> Persons
        {
            get
            {
                return _Persons;
            }
            set
            {
                if (_Persons != value)
                {
                    _Persons = value;
                    OnPropertyChanged(() => this.Persons);
                }
            }
        }

        public ICommand QueryCommand { get; set; }

        public MainWindowViewModel()
        {
            QueryCommand = new RelayCommand((o) =>
            {
                var list = this.FiltersTree[0].Filter(this.MasterList);
                this.Persons = new ObservableCollection<Person>(list);
            });

            FiltersTree = new ObservableCollection<FiltersViewModel<Person>>() { new FiltersViewModel<Person>() };

            this.MasterList = SampleData.CreatePersons();

            this.Persons = new ObservableCollection<Person>(MasterList);
        }
    }
}
