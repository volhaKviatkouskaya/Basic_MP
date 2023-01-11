using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLibrary.Tests
{
    [TestClass()]
    public class ProductRepositoryTests
    {
        [TestInitialize]
        public void Init()
        {
            /*
            _connString = Properties.Settings.Default.OrderConnectionString;
            SqlConnection _connection;
            SqlDataAdapter _dataAdapter;
            DataSet _dataSet;
            TableName = "Products";
            */
        }

        [TestMethod()]
        public void InsertItemTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectItemByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectAllTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateItemTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteItemTest()
        {
            Assert.Fail();
        }
    }
}