using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebAPI2.Models;

namespace WebAPI2.Filters
{
    public class ValidateModelAttribute :ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string message = string.Empty;
            bool firstError = true;

            if (actionContext.ModelState.IsValid==false)
            {
                foreach (var item in actionContext.ModelState.Values)
                {
                    foreach (var e in item.Errors)
                    {
                        if (!firstError)
                        {
                            message += "; ";
                        }

                        message += e.ErrorMessage;
                        firstError = false;

                    }
                }


                PaymentError paymentError = new PaymentError();
                paymentError.ErrorMessage = message;
                paymentError.ErrorType = typeof(PaymentRequiredFieldException).Name;

                var response = new PaymentServiceResponse<Object>()
                {
                    Status = HttpStatusCode.BadRequest,
                    DataContent = null,
                    Error = paymentError
                };

                actionContext.Response = actionContext.Request.CreateResponse(response);

            }
        }




    }

    public class PaymentRequiredFieldException
    {
        public HttpStatusCode Ststus { get; set; }
        public string Message { get; set; }
    }
}