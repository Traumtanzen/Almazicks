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
    public class AnswerService : IAnswerService
    {
        private readonly DiamondsDbContext _context;
        private readonly IMapper _mapper;
        public AnswerService(DiamondsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAnswerAsync(AnswerDto answer)
        {
            await _context.AddAsync(_mapper.Map<Answer>(answer));
            await _context.SaveChangesAsync();
        }

        public async Task<AnswerDto> GetAnswerAsync(int id)
        {
            var quest = await _context.Answers.FindAsync(id);
            return _mapper.Map<AnswerDto>(quest);
        }

        public async Task<IEnumerable<AnswerDto>> GetAnswersAsync()
        {
            var answers = await _context.Answers.ToListAsync();
            return _mapper.Map<IEnumerable<AnswerDto>>(answers);
        }

        public async Task UpdateAnswerAsync(int id, AnswerDto answer)
        {
            var newAnswer = _mapper.Map<Answer>(answer);
            newAnswer.Id = id;
            _context.Answers.Update(newAnswer);
            await _context.SaveChangesAsync();
        }

        public async Task<string> DeleteAnswerAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return "Answer deleted!";
        }
    }
}
