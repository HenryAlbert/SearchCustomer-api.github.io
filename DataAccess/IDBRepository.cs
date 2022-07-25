using CustomerData;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DBService
{
    public interface IDBRepository
    {

        List<customer> GetCustomerByPolicyno(string policynumber);
        List<customer> GetCustomerByCustomerno(string custnumber);
        List<customer> GetCustomerByPolCust(string policynumber,string custnumber);

    }
}
