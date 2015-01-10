using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

        

        public MainWindowViewModel()
        {
            FiltersTree = new ObservableCollection<FiltersViewModel<Person>>() { new FiltersViewModel<Person>() };

            this.Persons = new ObservableCollection<Person>()
            {
                new Person 
                { 
                    Address = new Address
                    {
                        City = "1234",
                        Line1 = "asdfsaf asdfas dfasdf",
                        Line2 = "something else sillt",
                        State = "NJ",
                        Zip = "23451",
                    }, 
                    Age=21, 
                    FirstName="Dhinesh", 
                    LastName="Devanatahn"
                },
                new Person 
                { 
                    Address = new Address
                    {
                        City = "1234",
                        Line1 = "asdfsaf asdfas dfasdf",
                        Line2 = "something else sillt",
                        State = "NJ",
                        Zip = "23451",
                    }, 
                    Age=21, 
                    FirstName="Dhinesh", 
                    LastName="Devanatahn"
                },
                new Person 
                { 
                    Address = new Address
                    {
                        City = "1234",
                        Line1 = "asdfsaf asdfas dfasdf",
                        Line2 = "something else sillt",
                        State = "NJ",
                        Zip = "23451",
                    }, 
                    Age=21, 
                    FirstName="Dhinesh", 
                    LastName="Devanatahn"
                },
            };
        }
    }
}
