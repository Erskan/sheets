using System.Collections.Generic;
using System.Threading.Tasks;
using SheetsApi.Forces;

namespace SheetsApi.Shared.Interfaces
{
    public interface IForceService
    {
        Task<IEnumerable<Force>> GetAllAsync();
        Task<Force> GetAsync(int id);
        Task<int> CreateAsync(Force force);
        Task<int> DeleteAsync(int id);
    }
}