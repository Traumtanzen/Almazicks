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
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        // GET: api/Answers
        [HttpGet]
        public async Task<IEnumerable<AnswerDto>> GetAsync()
        {
            return await _answerService.GetAnswersAsync();
        }

        // GET: api/Answers/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<AnswerDto> GetAsync(int id)
        {
            return await _answerService.GetAnswerAsync(id);
        }

        // POST: api/Answers
        [HttpPost]
        public async Task PostAsync([FromBody] AnswerDto answer)
        {
            await _answerService.CreateAnswerAsync(answer);
        }

        // PUT: api/Answers/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] AnswerDto answerDto)
        {
            await _answerService.UpdateAnswerAsync(id, answerDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteAsync(int id)
        {
            return await _answerService.DeleteAnswerAsync(id);
        }
    }
}
