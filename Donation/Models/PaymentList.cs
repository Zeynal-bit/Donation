using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Donation.Models
{
    public class PaymentList 
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string OrderNumber { get; set; }
        public int Amount { get; set; }
        public string ReturnUrl { get; set; }
        public string FailUrl { get; set; }
        public string Description { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public int OrderStatus { get; set; }

        public string orderId { get; set; }
        public string formUrl { get; set; }

        public string Discriminator { get; set; }

        [NotMapped]
        public decimal Price
        {
            get
            {
                return (decimal)Amount / 100;
            }
        }

        [NotMapped]
        public string Currency => $"{Price} TMT";

    }
}
