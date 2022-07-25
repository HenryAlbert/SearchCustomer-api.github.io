using CustomerData;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Service.Viewmodel
{
    public interface ICustomerModule
    {

        IEnumerable<customer> GetCustomer(string polno, string custno);
        

    }
}
