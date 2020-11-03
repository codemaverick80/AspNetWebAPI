using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebAPI2.Models
{
    public class PaymentServiceResponse<T>
    {
        public HttpStatusCode   Status { get; set; }
        public T DataContent { get; set; }

        public PaymentError Error { get; set; }


    }

    public class PaymentError
    {
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }

    }
}