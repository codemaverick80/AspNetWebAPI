using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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


        // GET api/users
        [HttpGet]
        [Route("api/users")]
        public async Task<IHttpActionResult> GetAsync(CancellationToken ct)
        {
            //await Task.Delay(5000, ct);
            try
            {
                List<User> users = new List<User>();

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users", ct);
                    if (response.IsSuccessStatusCode == true)
                    {

                        string res = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<List<User>>(res);
                    }
                    return Ok(users);
                }

            }
            catch (TaskCanceledException ex)
            {
                throw;
            }

        }



        // GET api/payment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/payment
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



    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }


}
