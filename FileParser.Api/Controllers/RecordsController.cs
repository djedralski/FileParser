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
        public void Post([FromBody]string value)
        {
            //FileParser.Code.Record.
        }
        
        // GET: api/records/sortby
        [HttpGet("{id}", Name = "Get")]
        public List<Record> Get(string sortby)
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
                    records = records.OrderBy(x => x.LastName).ThenBy(x=>x.FirstName).ToList();
                    break;
                default:
                    //errorConsole.WriteLine("Default case");
                    break;
            }

            return records;
        }
              
        public static List<Record> getRecordList()
        {


            return new List<Record>();
        }
    }
}
