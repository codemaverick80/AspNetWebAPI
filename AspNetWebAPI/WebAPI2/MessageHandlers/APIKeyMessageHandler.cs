using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI2.MessageHandlers
{
    /*
     * A Messge handler is a class that receives an HTTP request and returns and HTTP response.
     * 
     * Typically, a series of message handleres are chained together. The First handler receives an 
     * HTTP request, does some processing and gives the request to the next handler. At some point, the 
     * response is created and goes back up the chain. This pattern is called a delegating handlre
     * 
     * https://www.asp.net/web-api/overview/advanced/httpclient-message-handlers
     */
    public class APIKeyMessageHandler: DelegatingHandler
    {
        private const string APIKeyToValidate = "API2020@DEMOKEY"; // it could be anything and should be stored in secure location
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool validKey = false;
            IEnumerable<string> requestHeaders;
            var apiKeyFromHeader = request.Headers.TryGetValues("APIKEY", out requestHeaders);

            if (apiKeyFromHeader)
            {
                if (requestHeaders.FirstOrDefault().Equals(APIKeyToValidate))
                {
                    validKey = true;
                }               
            }
            if (!validKey)
            {
                return request.CreateResponse(HttpStatusCode.Forbidden, "Invalid API Key");
            }

            //// chaning next message handler in the pipeline ==>
           
            var response= await base.SendAsync(request, cancellationToken);


            if (!response.IsSuccessStatusCode)
            {
                var requestURL = request.RequestUri;
                var statusCode = response.StatusCode;
                var responseDate = response.Headers.Date;
            }



            return response;
        }

    }
}