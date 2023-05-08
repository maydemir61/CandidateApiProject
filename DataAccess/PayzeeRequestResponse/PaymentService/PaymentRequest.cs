using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PayzeeRequestResponse.PaymentService
{
   public class PaymentRequest
   {
       public int memberId { get; set; }
       public int merchantId { get; set; }
       public string customerId { get; set; }
       public string cardNumber { get; set; }
       public string expiryDateMonth { get; set; }
       public string expiryDateYear { get; set; }
       public string cvv { get; set; }
       public int secureDataId { get; set; }
       public string cardAlias { get; set; }
       public string userCode { get; set; }
       public string txnType { get; set; }
       public string installmentCount { get; set; }
       public string currency { get; set; }
       public string orderId { get; set; }
       public string totalAmount { get; set; }
       public string pointAmount { get; set; }
       public string rnd { get; set; }
       public string hash { get; set; }
       public string description { get; set; }
       public string cardHolderName { get; set; }
       public string requestIp { get; set; }
       //public BillingInfo billingInfo { get; set; }
       //public DeliveryInfo deliveryInfo { get; set; }
       //public List<OrderProductList> orderProductList { get; set; }
   }


}
