using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerData
{
    /// <summary>
    /// Customer Model
    /// </summary>
    public class customer
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string memberCardNumber { get; set; }
        public string policyNumber { get; set; }
        public string dataOfBirth { get; set; }

    }
}
