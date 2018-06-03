﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SheetsApi.Shared;
using SheetsApi.Shared.Interfaces;
using System.Threading.Tasks;

namespace SheetsApi.Sheets
{
    public class SheetService : ISheetService
    {
        private readonly SheetsDbContext _context;
        private readonly IMapper _mapper;

        public SheetService(SheetsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Sheet> GetAsync(int id)
        {
            var sheetModel = await _context.Sheets.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Sheet>(sheetModel);
        }
    }
}