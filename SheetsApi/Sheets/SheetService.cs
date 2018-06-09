using System.Collections.Generic;
using System.Data.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SheetsApi.Shared;
using SheetsApi.Shared.Interfaces;
using System.Threading.Tasks;

namespace SheetsApi.Sheets
{
    public class SheetService : ISheetService
    {
        private readonly ISheetsDbContext _context;
        private readonly IMapper _mapper;

        public SheetService(ISheetsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Sheet> GetAsync(int id)
        {
            var sheetModel = await _context.Sheets.FindAsync(id);
            return sheetModel == null ? null : _mapper.Map<Sheet>(sheetModel);
        }

        public async Task<IEnumerable<Sheet>> GetAllAsync()
        {
            var sheetModels = await _context.Sheets.ToListAsync();
            return _mapper.Map<IEnumerable<Sheet>>(sheetModels);
        }

        public async Task<int> CreateAsync(Sheet sheet)
        {
            var sheetModel = _mapper.Map<SheetModel>(sheet);
            var addResult = await _context.Sheets.AddAsync(sheetModel);
            _context.SaveChanges();
            return addResult.Entity.SheetId;
        }

        public int Update(Sheet sheet)
        {
            var sheetModel = _mapper.Map<SheetModel>(sheet);
            var updateResult = _context.Sheets.Update(sheetModel);
            return updateResult.Entity.SheetId;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sheetToDelete = await _context.Sheets.FindAsync(id);
            if (sheetToDelete == null)
            {
                return -1;
            }

            var removedSheet = _context.Sheets.Remove(sheetToDelete);
            _context.SaveChanges();

            return removedSheet.Entity.SheetId;
        }
    }
}
