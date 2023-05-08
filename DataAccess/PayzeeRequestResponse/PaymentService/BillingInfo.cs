using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PayzeeRequestResponse.PaymentService
{
    public class BillingInfo
    {
        public string taxNo { get; set; }
        public string taxOffice { get; set; }
        public string firmName { get; set; }
        public string identityNumber { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string town { get; set; }
        public string zipCode { get; set; }
    }

}
