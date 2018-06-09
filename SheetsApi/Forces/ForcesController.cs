﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SheetsApi.Shared.Interfaces;
using Serilog;
using System.Linq;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SheetsApi.Forces
{
    [Route("forces")]
    [Authorize]
    public class ForcesController : Controller
    {
        private readonly IForceService _forceService;
        public ForcesController(IForceService forceService)
        {
            _forceService = forceService;
        }
        [HttpGet]
        [SwaggerResponse(200, typeof(IEnumerable<Force>))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(500)]
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
        [SwaggerResponse(200, typeof(Force))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public async Task<IActionResult> GetAsync(int id)
        {
            Log.Information("GET forces/{id} called from {RemoteIpAddress}.", id, HttpContext.Connection.RemoteIpAddress);
            if (id <= 0)
            {
                return BadRequest("The supplied id was equal to or less than zero (0).");
            }

            var force = await _forceService.GetAsync(id);
            if (force == null)
            {
                Log.Warning("force NOT found. Returning 404.");
                return NotFound();
            }
            
            Log.Information("Force found. Returning force object.");
            return Ok(force);
        }

        [HttpPost]
        [SwaggerResponse(201, typeof(int))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(500)]
        public async Task<IActionResult> CreateForce([FromBody] Force force)
        {
            Log.Information("POST forces/ called from {RemoteIpAddress}.", HttpContext.Connection.RemoteIpAddress);
            if (force == null)
            {
                Log.Information("Null force supplied. Returning 400.");
                return StatusCode(400);
            }

            var forceValidator = new ForceValidator();
            var validationResult = forceValidator.Validate(force);
            if (!validationResult.IsValid)
            {
                Log.Information("Validation error in supplied force. Returning 400.");
                return StatusCode(400, validationResult.Errors);
            }

            var id = await _forceService.CreateAsync(force);
            Log.Information("Successfully created force {id}", id);
            return Created($"Successfully created new force with id {id}", id);
        }
    }
}
