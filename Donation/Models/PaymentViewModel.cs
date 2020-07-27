using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Donation.Models
{
    public class PaymentViewModel 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string orderId { get; set; }
        public string formUrl { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
        public int orderStatus { get; set; }
        public string orderNumber { get; set; }
        public int amount { get; set; }
    }
}
