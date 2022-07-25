using CustomerData;
using DBService;
using Service.Data;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer.Service.Viewmodel
{

    // This moudle can be used to do further level valiation check on payload/request from each request, specific to request/response process
    
    public class CustomerModule : ICustomerModule
    {
        private readonly ICustomerRepository _CustRepository;
        

        public CustomerModule( ICustomerRepository CustRepository)
        {
            _CustRepository = CustRepository;
        }


        public IEnumerable<customer> GetCustomer(string polno, string custno)
        {
            var c = _CustRepository.GetCustomer(polno, custno);

            return c;

        }

        

    }

}
