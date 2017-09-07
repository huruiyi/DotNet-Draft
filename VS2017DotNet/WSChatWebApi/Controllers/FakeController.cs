using System.Collections.Generic;
using System.Web.Http;

namespace WSChatWebApi.Controllers
{
    public class FakeController : ApiController
    {
        // GET api/fake
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/fake/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/fake
        public void Post([FromBody]string value)
        {
        }

        // PUT api/fake/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/fake/5
        public void Delete(int id)
        {
        }
    }
}