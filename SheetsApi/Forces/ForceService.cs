using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SheetsApi.Shared.Interfaces;

namespace SheetsApi.Forces
{
    public class ForceService : IForceService
    {
        private readonly ISheetsDbContext _context;
        private readonly IMapper _mapper;

        public ForceService(ISheetsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Force>> GetAllAsync()
        {
            var forceModels = await _context.Forces.ToListAsync();
            return _mapper.Map<IEnumerable<Force>>(forceModels);
        }
    }
}
