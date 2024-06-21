using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testeController : ControllerBase
    {
        // GET: api/<testeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<testeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "testando.......";
        }

        // POST api/<testeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<testeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<testeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
