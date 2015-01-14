﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeshStudios.Target.ViewModel;
using NeshStudios.Target;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace NeshStudios.Controls.Test.ViewModelTest
{
    [TestClass]
    public class FiltersViewModelExtensionsTest
    {
        [TestMethod]
        public void Test_Where_1Items_Expression()
        {
            var list = Common.SampleData.CreatePersons();

            var fvm = new FiltersViewModel<Person> 
            {
                Items= new ObservableCollection<Object>()
                {
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.Where, Operator = Target.Model.Operator.Contains, PropertyName = "FirstName",SearchObject = "dhi", Type = typeof(Person),},
                },
                LogicalOperator = Target.Model.LogicalOperator.Where,
            };

            var expression = fvm.CreateExpression();
            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list.Where(x => x.FirstName.ToLower().Contains("dhinesh")).ToList();

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Test_Where_2Items_Expression_With_Where_And()
        {
            var list = Common.SampleData.CreatePersons();

            var fvm = new FiltersViewModel<Person>
            {
                Items = new ObservableCollection<Object>()
                {
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.Where, Operator = Target.Model.Operator.Contains, PropertyName = "FirstName",SearchObject = "dhi", Type = typeof(Person),},
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.And, Operator = Target.Model.Operator.Contains, PropertyName = "LastName",SearchObject = "dev", Type = typeof(Person),},
                },
                LogicalOperator = Target.Model.LogicalOperator.Where,
            };

            var expression = fvm.CreateExpression();
            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list
                .Where(
                        x =>     x.FirstName.ToLower().Contains("dhi") 
                             &&  x.LastName.ToLower().Contains("dev")
                ).ToList();

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Test_Where_2Items_Expression_With_Where_Or()
        {
            var list = Common.SampleData.CreatePersons();

            var fvm = new FiltersViewModel<Person>
            {
                Items = new ObservableCollection<Object>()
                {
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.Where, Operator = Target.Model.Operator.Contains, PropertyName = "FirstName",SearchObject = "dhi", Type = typeof(Person),},
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.Or, Operator = Target.Model.Operator.Contains, PropertyName = "LastName",SearchObject = "yen", Type = typeof(Person),},
                },
                LogicalOperator = Target.Model.LogicalOperator.Where,
            };

            var expression = fvm.CreateExpression();
            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list
                .Where(
                        x => x.FirstName.ToLower().Contains("dhi")
                             || x.LastName.ToLower().Contains("yen")
                ).ToList();

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Test_Where_2Items_Expression_With_Where_AndNot()
        {
            var list = Common.SampleData.CreatePersons();

            var fvm = new FiltersViewModel<Person>
            {
                Items = new ObservableCollection<Object>()
                {
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.Where, Operator = Target.Model.Operator.Contains, PropertyName = "FirstName",SearchObject = "dhi", Type = typeof(Person),},
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.AndNot, Operator = Target.Model.Operator.Contains, PropertyName = "LastName",SearchObject = "yen", Type = typeof(Person),},
                },
                LogicalOperator = Target.Model.LogicalOperator.Where,
            };

            var expression = fvm.CreateExpression();
            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list
                .Where(
                        x => x.FirstName.ToLower().Contains("dhi")
                             && !(x.LastName.ToLower().Contains("yen"))
                ).ToList();

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Test_Where_2Items_Expression_With_Where_OrNot()
        {
            var list = Common.SampleData.CreatePersons();

            var fvm = new FiltersViewModel<Person>
            {
                Items = new ObservableCollection<Object>()
                {
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.Where, Operator = Target.Model.Operator.Contains, PropertyName = "FirstName",SearchObject = "dhi", Type = typeof(Person),},
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.OrNot, Operator = Target.Model.Operator.Contains, PropertyName = "LastName",SearchObject = "yen", Type = typeof(Person),},
                },
                LogicalOperator = Target.Model.LogicalOperator.Where,
            };

            var expression = fvm.CreateExpression();
            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list
                .Where(
                        x => x.FirstName.ToLower().Contains("dhi")
                             || !(x.LastName.ToLower().Contains("yen"))
                ).ToList();

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Test_Where_3Items_Expression_With_Where_And_Or()
        {
            var list = Common.SampleData.CreatePersons();

            var fvm = new FiltersViewModel<Person>
            {
                Items = new ObservableCollection<Object>()
                {
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.Where, Operator = Target.Model.Operator.Contains, PropertyName = "FirstName",SearchObject = "dhi", Type = typeof(Person),},
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.And, Operator = Target.Model.Operator.Contains, PropertyName = "LastName",SearchObject = "dev", Type = typeof(Person),},
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.Or, Operator = Target.Model.Operator.IsGreaterThanOrEqualTo, PropertyName = "Age",SearchObject = "21", Type = typeof(Person),},
                },
                LogicalOperator = Target.Model.LogicalOperator.Where,
            };

            var expression = fvm.CreateExpression();
            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list
                .Where(
                        x => x.FirstName.ToLower().Contains("dhi")
                             && x.LastName.ToLower().Contains("yen")
                             || x.Age >= 21
                ).ToList();

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Test_Expression_Where_And_GroupAnd()
        {
            var list = Common.SampleData.CreatePersons();

            var fvm = new FiltersViewModel<Person>
            {
                LogicalOperator = Target.Model.LogicalOperator.Where,
                Items = new ObservableCollection<Object>()
                {
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.Where, Operator = Target.Model.Operator.Contains, PropertyName = "FirstName",SearchObject = "dhi", Type = typeof(Person),},
                    new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.And, Operator = Target.Model.Operator.Contains, PropertyName = "LastName",SearchObject = "dev", Type = typeof(Person),},
                    new FiltersViewModel<Person> 
                    {
                        LogicalOperator = Target.Model.LogicalOperator.Or,
                        Items = new ObservableCollection<object>()
                        {
                            new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.Where, Operator = Target.Model.Operator.Contains, PropertyName = "FirstName",SearchObject = "asc", Type = typeof(Person),},
                            new FilterCriteriaViewModel { IsCaseInsensitive = false, LogicalOperator = Target.Model.LogicalOperator.And, Operator = Target.Model.Operator.Contains, PropertyName = "LastName",SearchObject = "port", Type = typeof(Person),},
                        },
                    },
                },
                
            };

            var expression = fvm.CreateExpression();
            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list
                .Where(
                        x => x.FirstName.ToLower().Contains("dhi") && x.LastName.ToLower().Contains("dev")
                             || (x.FirstName.ToLower().Contains("asc") && x.LastName.ToLower().Contains("port"))
                ).ToList();

            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
