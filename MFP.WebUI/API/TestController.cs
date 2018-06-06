using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.API
{
    public class TestController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

            
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST api/<controller>
        public List<TUser> Post([FromBody]TUser user)
        {
            return new List<TUser> {new TUser() {username="123",words="321"}, new TUser() { username = "456", words = "654" } };
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class TUser
    {
        public string username { get; set; }
        public string words { get; set; }
    }
}