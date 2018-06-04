using System.Collections.Generic;
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
            var sheetModel = await _context.Sheets.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Sheet>(sheetModel);
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
            return addResult.Entity.Id;
        }
    }
}
