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

        public async Task<Force> GetAsync(int id)
        {
            var forceModel = await _context.Forces.FindAsync(id);
            return forceModel == null ? null : _mapper.Map<Force>(forceModel);
        }

        public async Task<int> CreateAsync(Force force)
        {
            var forceModel = _mapper.Map<ForceModel>(force);
            var createdModel = await _context.Forces.AddAsync(forceModel);
            _context.SaveChanges();
            return createdModel.Entity.ForceId;
        }
    }
}
