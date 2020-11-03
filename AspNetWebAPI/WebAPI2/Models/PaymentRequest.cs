using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebAPI2.Models
{
    public class PaymentRequest
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public decimal Amount { get; set; }

        [Required( ErrorMessage ="Customer name is required")]
        public string CustomerName { get; set; }

    }

    public class PaymentResponse
    {
        public Guid PaymentId { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
    }
}