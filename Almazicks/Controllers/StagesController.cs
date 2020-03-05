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
    public class StagesController : ControllerBase
    {
        private readonly IStageService _stageService;
        public StagesController(IStageService stageService)
        {
            _stageService = stageService;
        }
        // GET: api/Stages
        [HttpGet]
        public async Task<IEnumerable<StageDto>> GetAsync()
        {
            return await _stageService.GetStagesAsync();
        }

        // GET: api/Stages/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<StageDto> GetAsync(int id)
        {
            return await _stageService.GetStageAsync(id);
        }

        // POST: api/Stages
        [HttpPost]
        public async Task PostAsync([FromBody] StageDto stage)
        {
            await _stageService.CreateStageAsync(stage);
        }

        // PUT: api/Stages/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] StageDto stageDto)
        {
            await _stageService.UpdateStageAsync(id, stageDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteAsync(int id)
        {
            return await _stageService.DeleteStageAsync(id);
        }
    }
}
