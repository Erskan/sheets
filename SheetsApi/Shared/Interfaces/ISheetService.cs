using System.Collections.Generic;
using SheetsApi.Sheets;
using System.Threading.Tasks;

namespace SheetsApi.Shared.Interfaces
{
    public interface ISheetService
    {
        Task<Sheet> GetAsync(int id);
        Task<IEnumerable<Sheet>> GetAllAsync();
        Task<int> CreateAsync(Sheet sheet);
        int Update(Sheet sheet);
        Task<int> DeleteAsync(int id);
    }
}
