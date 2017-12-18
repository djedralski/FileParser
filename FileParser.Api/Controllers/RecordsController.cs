using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FileParser.Code;
using Newtonsoft.Json;
using FileParser.Api.Models;

namespace FileParser.Api.Controllers
{
    [Route("records")]
    public class RecordsController : Controller
    {
        // POST: records
        [HttpPost]
        public IActionResult Post([FromBody]JsonRecord input)
        {   
            try
            {
                var parsed = RecordParser.TryParseLine(input.RecordInput).Item1;
                AddRecord(parsed);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        // Get: records
        [HttpGet]
        public IActionResult Post()
        {

            var recordInput =
                "first1,last1,gender1,color1,11/11/2016";
            try
            {
                var parsed = RecordParser.TryParseLine(recordInput).Item1;
                AddRecord(parsed);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: records/sortby
        [HttpGet("{sortby}", Name = "Get")]
        public IActionResult Get(string sortby)
        {
            var records = GetRecordList();

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

        private List<Record> GetRecordList()
        {
            
            const string sessionKey = "Records";
            List<Record> records;
            var value = HttpContext.Session.GetString(sessionKey);
            if (string.IsNullOrEmpty(value))
            {
                records = new List<Record>();                
                HttpContext.Session.SetString(sessionKey, JsonConvert.SerializeObject(records));
            }
            else
            {
                records = JsonConvert.DeserializeObject<List<Record>>(value);
            }
            
            return records;
        }
        private void AddRecord(Record record)
        {
            const string sessionKey = "Records";
            List<Record> records;
            var value = HttpContext.Session.GetString(sessionKey);
            if (string.IsNullOrEmpty(value))
            {
                records = new List<Record> {record};
                HttpContext.Session.SetString(sessionKey, JsonConvert.SerializeObject(records));
            }
            else
            {
                records = JsonConvert.DeserializeObject<List<Record>>(value);
                records.Add(record);
                HttpContext.Session.SetString(sessionKey, JsonConvert.SerializeObject(records));
            }
        }

    }
}
