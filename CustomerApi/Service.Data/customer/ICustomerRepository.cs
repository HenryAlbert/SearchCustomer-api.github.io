using CustomerData;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public interface ICustomerRepository
    {
        #region Search

        
        IEnumerable<customer> GetCustomer(string polno, string custno);
        
        #endregion  Search

    }
}
