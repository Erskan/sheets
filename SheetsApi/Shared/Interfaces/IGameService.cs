using System.Collections.Generic;
using System.Threading.Tasks;
using SheetsApi.Games;

namespace SheetsApi.Shared.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game> GetAsync(int id);
        Task<int> CreateAsync(Game game);
        Task<int> DeleteAsync(int id);
    }
}