using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SheetsApi.Shared.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;

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
        [SwaggerResponse(200, typeof(IEnumerable<Game>))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(500)]
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
        [SwaggerResponse(200, typeof(Game))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public async Task<IActionResult> GetAsync(int id)
        {
            Log.Information("GET games/{id} called from {RemoteIpAddress}.", id, HttpContext.Connection.RemoteIpAddress);
            if (id <= 0)
            {
                return BadRequest("The supplied id was equal to or less than zero (0).");
            }

            var game = await _gameService.GetAsync(id);
            if (game == null)
            {
                Log.Warning("Game NOT found. Returning 404.");
                return NotFound();
            }

            Log.Information("Game found. Returning game object.");
            return Ok(game);
        }

        [HttpPost]
        [SwaggerResponse(201, typeof(int))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(500)]
        public async Task<IActionResult> CreateAsync([FromBody] Game game)
        {
            Log.Information("POST games/ called from {RemoteIpAddress}.", HttpContext.Connection.RemoteIpAddress);
            if (game == null)
            {
                Log.Information("Null game supplied. Returning 400.");
                return StatusCode(400);
            }

            var gameValidator = new GameValidator();
            var validationResult = gameValidator.Validate(game);
            if (!validationResult.IsValid)
            {
                Log.Information("Validation error in supplied game. Returning 400.");
                return StatusCode(400, validationResult.Errors);
            }

            var id = await _gameService.CreateAsync(game);
            Log.Information("Successfully created game {id}", id);
            return Created($"Successfully created new game with id {id}", id);
        }
    }
}
