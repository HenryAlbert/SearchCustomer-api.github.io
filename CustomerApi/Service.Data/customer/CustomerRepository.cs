using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Models;
using DBService;
using System.Data;
using System.Data.SqlClient;
using CustomerData;

namespace Service.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDBRepository _IDBRepository;
       
        
        public CustomerRepository(IDBRepository DbRep)
        {
            _IDBRepository = DbRep;
        }

      


        #region Search
        public IEnumerable<customer> GetCustomer(string polno, string custno)
        {

            if (String.IsNullOrEmpty(custno))
                custno = "";

            if (String.IsNullOrEmpty(polno))
                polno = "";

            //search based on both polno & custno
            if (polno.Trim().Length > 0 && custno.Trim().Length > 0)
            {
                return SearchCustomer(polno, custno);
            }
            else if (polno.Trim().Length > 0 && custno.Trim().Length <= 0)
            {
               return SearchCustomerBypolno(polno);
            }
            else
            {
                return SearchCustomerByCustno(custno);
            }


        }
        
        private IEnumerable<customer> SearchCustomer(string polno, string custno)
        {
            return _IDBRepository.GetCustomerByPolCust(polno, custno) as IEnumerable<customer>;


        }
        private IEnumerable<customer> SearchCustomerBypolno(string polno )
        {
            return _IDBRepository.GetCustomerByPolicyno(polno) as IEnumerable<customer>;

        }
        private IEnumerable<customer> SearchCustomerByCustno(string custno)
        {
            return _IDBRepository.GetCustomerByCustomerno(custno) as IEnumerable<customer>;

        }
        
        #endregion Search


    }

}
