using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almazicks.DataContracts.DataContracts;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almazicks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroService _heroService;
        public HeroesController(IHeroService heroService)
        {
            _heroService = heroService;
        }
        // GET: api/Heros
        [HttpGet]
        public async Task<IEnumerable<HeroDto>> GetAsync()
        {
            return await _heroService.GetHeroesAsync();
        }

        // GET: api/Heros/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<HeroDto> GetAsync(int id)
        {
            return await _heroService.GetHeroAsync(id);
        }

        // POST: api/Heros
        [HttpPost]
        public async Task PostAsync([FromBody] HeroDto hero)
        {
            await _heroService.CreateHeroAsync(hero);
        }

        // PUT: api/Heros/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] HeroDto heroDto)
        {
            await _heroService.UpdateHeroAsync(id, heroDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteAsync(int id)
        {
            return await _heroService.DeleteHeroAsync(id);
        }
    }
}
