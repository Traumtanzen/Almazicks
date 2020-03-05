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
    public class HeroService : IHeroService
    {
        private readonly DiamondsDbContext _context;
        private readonly IMapper _mapper;
        public HeroService(DiamondsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateHeroAsync(HeroDto hero)
        {
            await _context.AddAsync(_mapper.Map<Hero>(hero));
            await _context.SaveChangesAsync();
        }

        public async Task<HeroDto> GetHeroAsync(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            return _mapper.Map<HeroDto>(hero);
        }

        public async Task<IEnumerable<HeroDto>> GetHeroesAsync()
        {
            var heros = await _context.Heroes.ToListAsync();
            return _mapper.Map<IEnumerable<HeroDto>>(heros);
        }

        public async Task UpdateHeroAsync(int id, HeroDto hero)
        {
            var newHero = _mapper.Map<Hero>(hero);
            newHero.Id = id;
            _context.Heroes.Update(newHero);
            await _context.SaveChangesAsync();
        }

        public async Task<string> DeleteHeroAsync(int id)
        {
            var hero = await _context.Heroes.FindAsync(id);
            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();
            return "Hero deleted!";
        }
    }
}
