using System;
using System.Net;
using System.Web.Http;
using Service.Models;
using DBService;
using Service.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http.Cors;
using Customer.Service.Viewmodel;
using CustomerData;

namespace Customer.Controllers
{
    /// <summary>
    /// Search the customer information 
    /// </summary>
 
    //[EnableCors(origins: "http://localhost:53016", headers: "*", methods: "*")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerModule _custModule;

        public CustomerController(ICustomerModule custModule)
        {

            _custModule = custModule;
        }

        #region GET 

       

        /// <summary>
        /// Search Customer based on Policynumber , Customer number or both
        /// </summary>
        /// <param name="polno"> policy number</param>
        /// <param name="custno"> Customer number</param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IHttpActionResult>Get([FromUri] string polno, string custno)  //Search based on polcy number
        {
            try
            {

                if (string.IsNullOrWhiteSpace(polno) && string.IsNullOrWhiteSpace(custno))
                {
                    return BadRequest("polno or custno is empty");
                }

                var cust = await Task.FromResult(_custModule.GetCustomer(polno, custno));
                if (cust != null)
                   return FormatResult(cust);
                else
                    return NotFound();
            }
            catch
            {
                return InternalServerError();
            }
        }

       

        #endregion Get 

        private IHttpActionResult FormatResult(IEnumerable<customer> cust)
        {
            if (cust.Count() > 1) return Ok(new { Items = cust });
            else
                return Ok(cust);
        }
        
    }
}
