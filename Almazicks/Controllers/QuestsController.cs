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
    public class QuestsController : ControllerBase
    {
        private readonly IQuestService _questService;
        public QuestsController(IQuestService questService)
        {
            _questService = questService;
        }
        // GET: api/Quests
        [HttpGet]
        public async Task<IEnumerable<QuestDto>> GetAsync()
        {
            return await _questService.GetQuestsAsync();
        }

        // GET: api/Quests/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<QuestDto> GetAsync(int id)
        {
            return await _questService.GetQuestAsync(id);
        }

        // POST: api/Quests
        [HttpPost]
        public async Task PostAsync([FromBody] QuestDto quest)
        {
            await _questService.CreateQuestAsync(quest);
        }

        // PUT: api/Quests/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] QuestDto questDto)
        {
            await _questService.UpdateQuestAsync(id, questDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteAsync(int id)
        {
            return await _questService.DeleteQuestAsync(id);
        }
    }
}
