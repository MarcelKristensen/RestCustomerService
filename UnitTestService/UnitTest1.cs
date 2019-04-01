using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestCustomerService.Controllers;
using RestCustomerService.Model;

namespace UnitTestService
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAllList()
        {
            CustomerController cc = new CustomerController();
            List<Customer> cList = cc.Get();
            Assert.AreEqual(4, cList.Count);
        }

        [TestMethod]
        public void TestGetOneElementList()
        {
            CustomerController cc = new CustomerController();
            Customer c = cc.CustomerGet(2);
            Assert.AreEqual(2, c.ID);
            Assert.AreEqual(c.FirstName, "Lasse");

            Customer c1 = cc.CustomerGet(17);
            Assert.IsNull(c1);
        }

        [TestMethod]
        public void TestPostElement()
        {
            CustomerController cc = new CustomerController();
            List<Customer> cList = cc.Get();
            int preCount = cList.Count;

            Customer c = new Customer(5, "Dat", "boi", 1996);
            cc.CustomerInsert(c);

            Assert.AreEqual(preCount+1, cList.Count);
        }

        [TestMethod]
        public void TestDeleteElement()
        {
            CustomerController cc = new CustomerController();
            cc.DeleteCustomer(4);
            Customer c1 = cc.CustomerGet(4);
            Assert.IsNull(c1);
            
        }
    }
}
