using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


using System.Net.Http;
using System.Web;
using CustomerData;

namespace DBService
{
    public class DBRepository : IDBRepository
    {
        

        private string _JsonFile;
        private List<customer> _source;


        public DBRepository()
        {
            GetJsonfilePath();
            loadJson();
        }

        private void GetJsonfilePath()
        {

            //string _JsonFile = ConfigurationManager.AppSettings["path"];
            //  string _JsonFile = HostingEnvironment.MapPath(ConfigurationManager.AppSettings["path"]);

             _JsonFile = HttpContext.Current.Server.MapPath(@ConfigurationManager.AppSettings["path"]);


            if (_JsonFile.Length <=0)
                throw new Exception("SQLConnection String not found");
        }

        private void loadJson()
        {
            try
            {
                  _source =JsonConvert.DeserializeObject<List<customer>>(File.ReadAllText(_JsonFile)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: while loading data .");
            }


        }

        /// <summary>
        /// GetCustomerByPolCust - To get the Customer information based on policynumber
        /// </summary>
        /// <param name="policynumber"></param>
        /// <returns></returns>
        public List<customer> GetCustomerByPolCust(string policynumber, string custnumber)
        {
            try
            {
               
                // filter data
                List<customer> filterData = _source.Where(x => x.policyNumber == policynumber && x.memberCardNumber == custnumber).ToList();
                EmptyRecord(ref filterData);


                return filterData;

            }
            catch (Exception ex)
            {
                throw new Exception("Error: GetCustomerByPolCust() .");
            }

        }


        /// <summary>
        /// GetCustomerByPolicyno - To get the Customer information based on policynumber
        /// </summary>
        /// <param name="policynumber"></param>
        /// <returns></returns>
        public List<customer> GetCustomerByPolicyno(string policynumber)
        {
            try
            {
                // filter data
                List<customer> filterData = _source.Where(x => x.policyNumber == policynumber).ToList();
                EmptyRecord(ref filterData);

                return filterData;

            }
            catch (Exception ex)
            {
                throw new Exception("Error: GetCustomerByPolicyno() .");
            }
           
        }

        private static  void EmptyRecord(ref List<customer> filterData)
        {
            if (filterData.Count <= 0)
            {
                filterData.Add(new customer { firstName = "", lastName = "", policyNumber = "", dataOfBirth = "", id = 0, memberCardNumber = "" });
                
            }
        }

        /// <summary>
        /// GetCustomerByCustomerno - Get customer information based on customer number 
        /// </summary>
        /// <param name="custnumber"></param>
        /// <returns></returns>

        public List<customer> GetCustomerByCustomerno(string custnumber)
        {
            try
            {
              
                // filter data
                List<customer> filterData = _source.Where(x => x.memberCardNumber == custnumber).ToList();
                EmptyRecord(ref filterData);
                return filterData;

            }
            catch (Exception ex)
            {
                throw new Exception("Error: GetCustomerByCustomerno() .");
            }


        }
        
    }
}
