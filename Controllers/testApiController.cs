using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication12.Controllers
{
    public class testApiController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }
    }
}
