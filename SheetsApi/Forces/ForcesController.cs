using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SheetsApi.Shared.Interfaces;
using Serilog;

namespace SheetsApi.Forces
{
    [Authorize]
    [Route("forces")]
    public class ForcesController : Controller
    {
        private readonly IForceService _forceService;
        public ForcesController(IForceService forceService)
        {
            _forceService = forceService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Log.Information("GET forces called from {RemoteIpAddress}.", HttpContext.Connection.RemoteIpAddress);
            var forces = await _forceService.GetAllAsync();
            if (forces == null || !forces.Any())
            {
                Log.Warning("forces NOT found. Returning 404.");
                return NotFound();
            }

            var forcesFound = forces.Count();
            Log.Information("{forcesFound} sheets found. Returning sheets.", forcesFound);
            return Ok(forces);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateForce([FromBody] Force force)
        {
            throw new NotImplementedException();
        }
    }
}
