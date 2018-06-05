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
    }
}
