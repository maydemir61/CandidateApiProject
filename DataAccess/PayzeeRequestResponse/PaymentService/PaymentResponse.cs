using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PayzeeRequestResponse.PaymentService
{
    public class PaymentResponse
    {
        public bool fail { get; set; }
        public int statusCode { get; set; }
        public PaymentResult result { get; set; }
    }
}
