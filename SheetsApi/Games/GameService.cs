using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SheetsApi.Shared.Interfaces;

namespace SheetsApi.Games
{
    public class GameService : IGameService
    {
        private readonly ISheetsDbContext _context;
        private readonly IMapper _mapper;

        public GameService(ISheetsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            var gameModels = await _context.Games.ToListAsync();
            return _mapper.Map<IEnumerable<Game>>(gameModels);
        }

        public async Task<Game> GetAsync(int id)
        {
            var gameModel = await _context.Games.FindAsync(id);
            return gameModel == null ? null : _mapper.Map<Game>(gameModel);
        }

        public async Task<int> CreateAsync(Game game)
        {
            var gameModel = _mapper.Map<GameModel>(game);
            var createdModel = await _context.Games.AddAsync(gameModel);
            _context.SaveChanges();
            return createdModel.Entity.GameId;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var gameToDelete = await _context.Games.FindAsync(id);
            if (gameToDelete == null)
            {
                return -1;
            }

            var removedGame = _context.Games.Remove(gameToDelete);
            _context.SaveChanges();

            return removedGame.Entity.GameId;
        }
    }
}
