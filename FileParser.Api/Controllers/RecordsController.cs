using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileParser.Code;

namespace FileParser.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/records")]
    public class RecordsController : Controller
    {
        // POST: api/records
        [HttpPost]
        public void Post([FromBody]Record value)
        {
        }
        // GET: api/records
        [HttpGet]
        public List<string> Get()
        {
            return new List<string>{ "value1", "value2" };
        }

        // GET: api/records/5
        [HttpGet("{id}", Name = "Get")]
        public List<string> Get(string sortby)
        {
            return new List<string> { "value1", "value2" };
        }
              
        public static List<Record> getRecordList()
        {


            return new List<Record>();
        }
    }
}
