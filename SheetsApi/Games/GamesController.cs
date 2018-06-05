using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SheetsApi.Shared.Interfaces;

namespace SheetsApi.Games
{
    [Route("games")]
    [Authorize]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Log.Information("GET games called from {RemoteIpAddress}.", HttpContext.Connection.RemoteIpAddress);
            var games = await _gameService.GetAllAsync();
            if (games == null || !games.Any())
            {
                Log.Warning("games NOT found. Returning 404.");
                return NotFound();
            }

            var gamesFound = games.Count();
            Log.Information("{gamesFound} sheets found. Returning sheets.", gamesFound);
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Game game)
        {
            throw new NotImplementedException();
        }
    }
}
