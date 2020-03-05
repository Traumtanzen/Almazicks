using Almazicks.DataContracts.DataContracts;
using AutoMapper;
using BusinessLogic.Interfaces;
using Data;
using Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class StageService : IStageService
    {
        private readonly DiamondsDbContext _context;
        private readonly IMapper _mapper;
        public StageService(DiamondsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateStageAsync(StageDto stage)
        {
            await _context.AddAsync(_mapper.Map<Stage>(stage));
            await _context.SaveChangesAsync();
        }

        public async Task<StageDto> GetStageAsync(int id)
        {
            var stage = await _context.Stages.FindAsync(id);
            return _mapper.Map<StageDto>(stage);
        }

        public async Task<IEnumerable<StageDto>> GetStagesAsync()
        {
            var stages = await _context.Stages.ToListAsync();
            return _mapper.Map<IEnumerable<StageDto>>(stages);
        }

        public async Task UpdateStageAsync(int id, StageDto stage)
        {
            var newStage = _mapper.Map<Stage>(stage);
            newStage.Id = id;
            _context.Stages.Update(newStage);
            await _context.SaveChangesAsync();
        }

        public async Task<string> DeleteStageAsync(int id)
        {
            var stage = await _context.Stages.FindAsync(id);
            _context.Stages.Remove(stage);
            await _context.SaveChangesAsync();
            return "Stage deleted!";
        }
    }
}
