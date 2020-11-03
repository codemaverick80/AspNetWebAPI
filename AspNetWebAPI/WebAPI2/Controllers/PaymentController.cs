using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI2.Models;

namespace WebAPI2.Controllers
{
    public class PaymentController : ApiController
    {
        // GET api/payment
        public PaymentServiceResponse<List<PaymentResponse>> Get()
        {
            PaymentServiceResponse<List<PaymentResponse>> response = new PaymentServiceResponse<List<PaymentResponse>>();
            response.Status = HttpStatusCode.OK;
            // throw new Exception("DOES NOT WORK!");


            List<PaymentResponse> list = new List<PaymentResponse>();
            list.Add(new PaymentResponse() { PaymentId = Guid.NewGuid(), CustomerId = 4512, Balance = 4512.45m });
            list.Add(new PaymentResponse() { PaymentId = Guid.NewGuid(), CustomerId = 4514, Balance = 1425 });
            list.Add(new PaymentResponse() { PaymentId = Guid.NewGuid(), CustomerId = 4516, Balance = 458.45m });
            list.Add(new PaymentResponse() { PaymentId = Guid.NewGuid(), CustomerId = 4517, Balance = 350.45m });

            try
            {
                response.DataContent = list;

            }
            catch (Exception ex)
            {

                response.Status = HttpStatusCode.InternalServerError;
                response.DataContent = null;
                response.Error = new PaymentError() { ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };

            }

            return response;



        }

        // GET api/payment/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public PaymentServiceResponse<PaymentResponse> Post([FromBody]PaymentRequest request)
        {

            PaymentServiceResponse<PaymentResponse> response = new PaymentServiceResponse<PaymentResponse>();
            response.Status = HttpStatusCode.OK;

            try
            {
               // throw new ArgumentNullException(nameof(request.Amount), "Amount is null");
                response.DataContent = new PaymentResponse()
                {
                    PaymentId = Guid.NewGuid(),
                    CustomerId = request.CustomerId,
                    Balance = 4513.25m
                };

            }
            catch (Exception ex)
            {

                response.Status = HttpStatusCode.InternalServerError;
                response.DataContent = null;
                response.Error = new PaymentError() { ErrorMessage = ex.Message, ErrorType = ex.GetType().ToString() };

            }

            return response;

        }

        // PUT api/payment/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/payment/5
        public void Delete(int id)
        {
        }
    }
}
