using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAuto.WebApp.Controllers
{
    public class MyAPIController : ApiController
    {
        // GET: api/MyAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MyAPI/5
        public string Get(int id)
        {
            return "value";
        }
        // GET: api/MyAPI/5
        public string Get(string str)
        {
            return "value" + str;
        }

        // POST: api/MyAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MyAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MyAPI/5
        public void Delete(int id)
        {
        }
    }
}
