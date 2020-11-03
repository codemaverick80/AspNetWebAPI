using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI2.Controllers
{
    public class PaymentController : ApiController
    {
        // GET api/payment
        public IEnumerable<string> Get()
        {

           // throw new Exception("DOES NOT WORK!");
            return new string[] { "value1", "value2" };
        }

        // GET api/payment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/payment
        public void Post([FromBody] string value)
        {
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
