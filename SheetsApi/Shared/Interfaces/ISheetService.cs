using SheetsApi.Sheets;
using System.Threading.Tasks;

namespace SheetsApi.Shared.Interfaces
{
    public interface ISheetService
    {
        Task<Sheet> GetAsync(int id);
        Task<int> CreateAsync(Sheet sheet);
    }
}
