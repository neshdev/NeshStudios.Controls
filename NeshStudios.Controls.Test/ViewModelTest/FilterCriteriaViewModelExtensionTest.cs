using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeshStudios.Target.ViewModel;
using NeshStudios.Target;
using System.Linq;
using NeshStudios.Custom.ViewModel;
using NeshStudios.Custom.Model;


namespace NeshStudios.Controls.Test.ViewModelTest
{
    [TestClass]
    public class FilterCriteriaViewModelExtensionTest
    {

        [TestMethod]
        public void TestEqualsExpression()
        {
            //arrange
            var list = Common.SampleData.CreatePersons();
            //act
            var fcvm = new FilterCriteriaViewModel();
            fcvm.IsCaseInsensitive = false;
            fcvm.LogicalOperator = LogicalOperator.Where;
            fcvm.Operator = Operator.Equals;
            fcvm.PropertyName = "FirstName";
            fcvm.SearchObject = "dhinesh";
            fcvm.Type = typeof(Person);
            var expression = fcvm.CreateExpression<Person>();

            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list.Where(x => x.FirstName.ToLower() == "dhinesh").ToList();

            //assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestDoesNotEqualExpression()
        {
            //arrange
            var list = Common.SampleData.CreatePersons();
            //act
            var fcvm = new FilterCriteriaViewModel();
            fcvm.IsCaseInsensitive = false;
            fcvm.LogicalOperator = LogicalOperator.Where;
            fcvm.Operator = Operator.DoesNotEqual;
            fcvm.PropertyName = "FirstName";
            fcvm.SearchObject = "dhinesh";
            fcvm.Type = typeof(Person);
            var expression = fcvm.CreateExpression<Person>();

            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list.Where(x => x.FirstName.ToLower() != "dhinesh").ToList();

            //assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestGreaterThanExpression()
        {
            //arrange
            var list = Common.SampleData.CreatePersons();
            //act
            var fcvm = new FilterCriteriaViewModel();
            fcvm.IsCaseInsensitive = false;
            fcvm.LogicalOperator = LogicalOperator.Where;
            fcvm.Operator = Operator.IsGreaterThan;
            fcvm.PropertyName = "Age";
            fcvm.SearchObject = "21";
            fcvm.Type = typeof(Person);
            var expression = fcvm.CreateExpression<Person>();

            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list.Where(x => x.Age > 21).ToList();

            //assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestLessThanExpression()
        {
            //arrange
            var list = Common.SampleData.CreatePersons();
            //act
            var fcvm = new FilterCriteriaViewModel();
            fcvm.IsCaseInsensitive = false;
            fcvm.LogicalOperator = LogicalOperator.Where;
            fcvm.Operator = Operator.IsLessThan;
            fcvm.PropertyName = "Age";
            fcvm.SearchObject = "21";
            fcvm.Type = typeof(Person);
            var expression = fcvm.CreateExpression<Person>();

            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list.Where(x => x.Age < 21).ToList();

            //assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestGreaterThanOrEqualExpression()
        {
            //arrange
            var list = Common.SampleData.CreatePersons();
            //act
            var fcvm = new FilterCriteriaViewModel();
            fcvm.IsCaseInsensitive = false;
            fcvm.LogicalOperator = LogicalOperator.Where;
            fcvm.Operator = Operator.IsGreaterThanOrEqualTo;
            fcvm.PropertyName = "Age";
            fcvm.SearchObject = "21";
            fcvm.Type = typeof(Person);
            var expression = fcvm.CreateExpression<Person>();

            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list.Where(x => x.Age >= 21).ToList();

            //assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestLessThanOrEqualExpression()
        {
            //arrange
            var list = Common.SampleData.CreatePersons();
            //act
            var fcvm = new FilterCriteriaViewModel();
            fcvm.IsCaseInsensitive = false;
            fcvm.LogicalOperator = LogicalOperator.Where;
            fcvm.Operator = Operator.IsLessThanOrEqualTo;
            fcvm.PropertyName = "Age";
            fcvm.SearchObject = "21";
            fcvm.Type = typeof(Person);
            var expression = fcvm.CreateExpression<Person>();

            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list.Where(x => x.Age <= 21).ToList();

            //assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestStartsWithExpression()
        {
            //arrange
            var list = Common.SampleData.CreatePersons();
            //act
            var fcvm = new FilterCriteriaViewModel();
            fcvm.IsCaseInsensitive = false;
            fcvm.LogicalOperator = LogicalOperator.Where;
            fcvm.Operator = Operator.StartsWith;
            fcvm.PropertyName = "FirstName";
            fcvm.SearchObject = "dhi";
            fcvm.Type = typeof(Person);
            var expression = fcvm.CreateExpression<Person>();

            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list.Where(x => x.FirstName.ToLower().StartsWith("dhi")).ToList();

            //assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestContainsExpression()
        {
            //arrange
            var list = Common.SampleData.CreatePersons();
            //act
            var fcvm = new FilterCriteriaViewModel();
            fcvm.IsCaseInsensitive = false;
            fcvm.LogicalOperator = LogicalOperator.Where;
            fcvm.Operator = Operator.Contains;
            fcvm.PropertyName = "FirstName";
            fcvm.SearchObject = "nes";
            fcvm.Type = typeof(Person);
            var expression = fcvm.CreateExpression<Person>();

            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list.Where(x => x.FirstName.ToLower().Contains("nes")).ToList();

            //assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestDoesNotContainExpression()
        {
            //arrange
            var list = Common.SampleData.CreatePersons();
            //act
            var fcvm = new FilterCriteriaViewModel();
            fcvm.IsCaseInsensitive = false;
            fcvm.LogicalOperator = LogicalOperator.Where;
            fcvm.Operator = Operator.DoesNotContain;
            fcvm.PropertyName = "FirstName";
            fcvm.SearchObject = "nes";
            fcvm.Type = typeof(Person);
            var expression = fcvm.CreateExpression<Person>();

            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list.Where(x => !(x.FirstName.ToLower().Contains("nes"))).ToList();

            //assert
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestEndsWithExpression()
        {
            //arrange
            var list = Common.SampleData.CreatePersons();
            //act
            var fcvm = new FilterCriteriaViewModel();
            fcvm.IsCaseInsensitive = false;
            fcvm.LogicalOperator = LogicalOperator.Where;
            fcvm.Operator = Operator.EndsWith;
            fcvm.PropertyName = "FirstName";
            fcvm.SearchObject = "esh";
            fcvm.Type = typeof(Person);
            var expression = fcvm.CreateExpression<Person>();

            var actual = list.AsQueryable().Where(expression).ToList();
            var expected = list.Where(x => x.FirstName.ToLower().EndsWith("esh")).ToList();

            //assert
            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
