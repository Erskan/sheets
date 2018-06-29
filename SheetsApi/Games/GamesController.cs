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
            var games = (await _gameService.GetAllAsync()).ToList();
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
        [HttpDelete("{id}")]
        [SwaggerResponse(200, typeof(int))]
        [SwaggerResponse(400, typeof(string))]
        [SwaggerResponse(401)]
        [SwaggerResponse(500)]
        public async Task<IActionResult> DeleteGame(int id)
        {
            Log.Information("DELETE games/{id} called from {RemoteIpAddress}.", HttpContext.Connection.RemoteIpAddress, id);
            if (id <= 0)
            {
                return StatusCode(400, "Supplied id is lesser than or equal to zero(0).");
            }

            var removedId = await _gameService.DeleteAsync(id);
            if (removedId <= 0)
            {
                Log.Warning("There was a problem when trying to delete game id: {id} from the database. Returning 400.", id);
                return StatusCode(400, $"There was a problem deleting the game id: {id} from the database. Make sure a valid id was supplied.");
            }

            Log.Information("Game with id {removedId} was deleted from the database.", removedId);
            return Ok(id);
        }
    }
}
