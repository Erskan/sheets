using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SheetsApi.Shared.Interfaces;

namespace SheetsApi.Games
{
    public class GameService : IGameService
    {
        private readonly ISheetsDbContext _context;

        public GameService(ISheetsDbContext context)
        {
            _context = context;
        }
    }
}
