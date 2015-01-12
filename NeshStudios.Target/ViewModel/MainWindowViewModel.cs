﻿using System;
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
                var list = FiltersViewModelExtensions.CreateLambda(this.FiltersTree[0], MasterList);
                this.Persons = new ObservableCollection<Person>(list);
            });

            FiltersTree = new ObservableCollection<FiltersViewModel<Person>>() { new FiltersViewModel<Person>() };

            this.MasterList = new ObservableCollection<Person>()
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
                    LastName="Devanathan",
                    BirthDate=DateTime.Now.Date,
                    IsActive = true,
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
                    FirstName="Greg", 
                    LastName="Yen",
                    BirthDate=DateTime.Now.AddDays(20).Date,
                    IsActive = true,
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
                    FirstName="Harija", 
                    LastName="Yalamanchi",
                    BirthDate=DateTime.Now.AddDays(-20).Date,
                    IsActive = false,
                },
            };

            this.Persons = new ObservableCollection<Person>(MasterList);
        }
    }
}
