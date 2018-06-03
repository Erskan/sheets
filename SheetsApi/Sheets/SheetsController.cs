using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SheetsApi.Sheets
{
    [Route("sheets")]
    public class SheetsController : Controller
    {
        [HttpGet]
        public Task<IActionResult> GetAllSheets()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetSheet(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<IActionResult> CreateSheet([FromBody] Sheet sheet)
        {
            throw new NotImplementedException();
        }


    }
}
