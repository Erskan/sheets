using Microsoft.AspNetCore.Mvc;
using SheetsApi.Shared.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SheetsApi.Sheets
{
    [Route("sheets")]
    public class SheetsController : Controller
    {
        private readonly ISheetService _sheetService;
        public SheetsController(ISheetService sheetService)
        {
            _sheetService = sheetService;
        }

        [HttpGet]
        [SwaggerResponse(200, typeof(IEnumerable<Sheet>))]
        public Task<IActionResult> GetAllSheets()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200, typeof(Sheet))]
        [SwaggerResponse(400)]
        public async Task<IActionResult> GetSheet(int id)
        {
            var sheet = await _sheetService.GetAsync(id);
            if(sheet == null)
            {
                return NotFound();
            }
            return Ok(sheet);
        }

        [HttpPost]
        [SwaggerResponse(200, typeof(int))]
        public Task<IActionResult> CreateSheet([FromBody] Sheet sheet)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        [SwaggerResponse(200, typeof(int))]
        public Task<IActionResult> UpdateSheet([FromBody] Sheet sheet)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(200, typeof(int))]
        public Task<IActionResult> DeleteSheet(int id)
        {
            throw new NotImplementedException();
        }
    }
}
