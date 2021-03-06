﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SheetsApi.Shared.Interfaces;
using Serilog;
using System.Linq;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(typeof(IEnumerable<Force>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            Log.Information("GET forces called from {RemoteIpAddress}.", HttpContext.Connection.RemoteIpAddress);
            var forces = (await _forceService.GetAllAsync()).ToList();
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
        [ProducesResponseType(typeof(Force), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteForce(int id)
        {
            Log.Information("DELETE forces/{id} called from {RemoteIpAddress}.", HttpContext.Connection.RemoteIpAddress, id);
            if (id <= 0)
            {
                return StatusCode(400, "Supplied id is lesser than or equal to zero(0).");
            }

            var removedId = await _forceService.DeleteAsync(id);
            if (removedId <= 0)
            {
                Log.Warning("There was a problem when trying to delete force id: {id} from the database. Returning 400.", id);
                return StatusCode(400, $"There was a problem deleting the force id: {id} from the database. Make sure a valid id was supplied.");
            }

            Log.Information("Force with id {removedId} was deleted from the database.", removedId);
            return NoContent();
        }

        [HttpPut("{forceId}/sheets/{sheetId}")]
        public async Task<IActionResult> AddSheetAsync(int forceId, int sheetId)
        {
            Log.Information("PUT forces/{forceId}/sheets/{sheetId} called from {RemoteIpAddress}.", forceId, sheetId, HttpContext.Connection.RemoteIpAddress);
            if (sheetId <= 0)
            {
                return StatusCode(400, "Supplied id is lesser than or equal to zero(0).");
            }

            var result = await _forceService.AddSheetAsync(forceId, sheetId);
            if (result <= 0)
            {
                Log.Error("Could not add sheet {sheetId} to force {forceId}", sheetId, forceId);
                return StatusCode(500);
            }

            Log.Information("Sheet {sheetId} added to force {forceId}", sheetId, forceId);
            return Created(String.Empty, result);
        }
    }
}
