using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileParser.Code;
using Newtonsoft.Json;

namespace FileParser.Api.Controllers
{

    [Route("records")]
    public class RecordsController : Controller
    {
        // POST: records
        [HttpPost]
        public IActionResult Post([FromBody]IEnumerable<string> recordInput)
        {
            //FileParser.Code.Record.
            return Ok();
        }

        // GET: records/sortby
        [HttpGet("{sortby}", Name = "Get")]
        public IActionResult Get(string sortby)
        {
            var records = getRecordList();

            switch (sortby)
            {
                case "gender":
                    records = records.OrderBy(x => x.Gender).ToList();
                    break;
                case "birthdate":
                    records = records.OrderBy(x => x.DateOfBirth).ToList();
                    break;
                case "name":
                    records = records.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
                    break;
                default:
                    return NotFound();

            }
            return Ok(JsonConvert.SerializeObject(records));
        }

        public static List<Record> getRecordList()
        {


            return new List<Record>();
        }
    }
}
