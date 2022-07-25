using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBService;
using Service.Data;
using Service.Models;
using Moq;
using System.Collections.Generic;
using Customer.Service.Viewmodel;
using System.Linq;
using CustomerData;

namespace CustomerTest
{

    [TestClass]
    public class UnitTestCustomer
    {
        private List<customer> _custList = new List<customer>();
        

        /// <summary>
        /// Init the custmer record
        /// </summary>
        [TestInitialize]
        public void testInit()
        {
            _custList.Add(
                 new customer
                 {
                     id = 1,
                     firstName = "Winne",
                     lastName = "Janc",
                     memberCardNumber = "0473128446",
                     policyNumber = "1405677686",
                     dataOfBirth = "26/07/1995"
                 }
            );

        }



        [TestMethod]
        public void SearchCustomer()
        {

            List<customer> cuslist = _custList.ToList();
            
            var mockRepo = new Mock<ICustomerRepository>();
            string polno = "1405677686";
            string custno = "0473128446";
            mockRepo.Setup(x => x.GetCustomer(polno, custno)).Returns(cuslist);

            var customerModule = new CustomerModule(mockRepo.Object);
            List<customer> res = customerModule.GetCustomer(polno, custno).ToList();

            Assert.AreEqual(res.Count(), 1);
            Assert.AreEqual(res[0].firstName, cuslist[0].firstName);
            Assert.AreEqual(res[0].lastName, cuslist[0].lastName);

        }


    }
}
