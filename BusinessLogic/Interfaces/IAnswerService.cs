using Almazicks.DataContracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAnswerService
    {
        Task<AnswerDto> GetAnswerAsync(int id);
        Task<IEnumerable<AnswerDto>> GetAnswersAsync();
        Task CreateAnswerAsync(AnswerDto answer);
        Task UpdateAnswerAsync(int id, AnswerDto answer);
        Task<string> DeleteAnswerAsync(int id);
    }
}
