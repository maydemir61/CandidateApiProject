using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Transaction:IEntity
    {
        [Key]
        public int TransactionId { get; set; }
        public int CustomerId { get; set; }
        public string OrderId { get; set; }
        public string TypeId { get; set; }
        public long Amount { get; set; }
        public string CardPan { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string Status { get; set; }


    }
}
