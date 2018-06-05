using Microsoft.AspNetCore.Mvc;
using Serilog;
using SheetsApi.Shared.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SheetsApi.Sheets
{
    [Authorize]
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
        [SwaggerResponse(401)]
        [SwaggerResponse(500)]
        public async Task<IActionResult> GetAllSheets()
        {
            Log.Information("GET sheets called from {RemoteIpAddress}.", HttpContext.Connection.RemoteIpAddress);
            var sheets = await _sheetService.GetAllAsync();
            if (sheets == null || !sheets.Any())
            {
                Log.Warning("sheets NOT found. Returning 404.");
                return NotFound();
            }

            var sheetsFound = sheets.Count();
            Log.Information("{sheetsFound} sheets found. Returning sheets.", sheetsFound);
            return Ok(sheets);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200, typeof(Sheet))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(500)]
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
        [SwaggerResponse(400, typeof(IEnumerable<FluentValidation.Results.ValidationFailure>))]
        [SwaggerResponse(401)]
        [SwaggerResponse(500)]
        public async Task<IActionResult> CreateSheet([FromBody] Sheet sheet)
        {
            Log.Information("POST sheets/ called from {RemoteIpAddress}.", HttpContext.Connection.RemoteIpAddress);
            if(sheet == null)
            {
                Log.Information("Null sheet supplied. Returning 400.");
                return StatusCode(400);
            }

            var sheetValidator = new SheetValidator();
            var validationResult = sheetValidator.Validate(sheet);
            if (!validationResult.IsValid)
            {
                Log.Information("Validation error in supplied sheet. Returning 400.");
                return StatusCode(400, validationResult.Errors);
            }

            var id = await _sheetService.CreateAsync(sheet);
            Log.Information("Successfully created sheet {id}", id);
            return Created($"Successfully created new sheet with id {id}", id);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(200, typeof(int))]
        [SwaggerResponse(400, typeof(IEnumerable<FluentValidation.Results.ValidationFailure>))]
        [SwaggerResponse(401)]
        [SwaggerResponse(500)]
        public async Task<IActionResult> UpdateSheet([FromBody] Sheet sheet)
        {
            Log.Information("PUT sheets/ called from {RemoteIpAddress}.", HttpContext.Connection.RemoteIpAddress);
            if (sheet == null)
            {
                Log.Information("Null sheet supplied. Returning 400.");
                return StatusCode(400);
            }

            var sheetValidator = new SheetValidator();
            var validationResult = sheetValidator.Validate(sheet);
            if (!validationResult.IsValid)
            {
                Log.Information("Validation error in supplied sheet. Returning 400.");
                return StatusCode(400, validationResult.Errors);
            }

            var id = _sheetService.Update(sheet);
            Log.Information("Successfully updated sheet {id}", id);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(200, typeof(int))]
        [SwaggerResponse(401)]
        [SwaggerResponse(500)]
        public Task<IActionResult> DeleteSheet(int id)
        {
            throw new NotImplementedException();
        }
    }
}
