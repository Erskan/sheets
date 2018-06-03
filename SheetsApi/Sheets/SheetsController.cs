using Microsoft.AspNetCore.Mvc;
using Serilog;
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
            Log.Information("GET sheets/{id} called from {RemoteIpAddress}.", id, HttpContext.Connection.RemoteIpAddress);
            var sheet = await _sheetService.GetAsync(id);
            if(sheet == null)
            {
                Log.Warning("sheets/{id} NOT found. Returning 404.", id);
                return NotFound();
            }
            Log.Information("sheets/{id} found. Returning sheet.", id);
            return Ok(sheet);
        }

        [HttpPost]
        [SwaggerResponse(201, typeof(int))]
        [SwaggerResponse(400, typeof(FluentValidation.Results.ValidationResult))]
        public async Task<IActionResult> CreateSheet([FromBody] Sheet sheet)
        {
            Log.Information("POST sheets/ called from {RemoteIpAddress}.", HttpContext.Connection.RemoteIpAddress);
            if(sheet == null)
            {
                return StatusCode(400);
            }

            // TODO: Fix validation. Currently not validating anything..
            var validator = new SheetValidator();
            var validationResult = validator.Validate(sheet);
            if (!validationResult.IsValid)
            {
                return StatusCode(400, validationResult);
            }

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
