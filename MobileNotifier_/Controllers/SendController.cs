using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MobileNotifier_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        // GET api/send
        [HttpGet]
        public void Send(string apiToken, string userKey, string message)
        {
            var parameters = new NameValueCollection {
                        { "token", apiToken },
                        { "user", userKey },
                        { "message", message }
            };

            using (var client = new WebClient())
            {
                client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
            }
        }
    }
}
