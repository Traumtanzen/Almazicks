﻿using Almazicks.DataContracts.DataContracts;
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
    public class QuestService : IQuestService
    {
        private readonly DiamondsDbContext _context;
        private readonly IMapper _mapper;
        public QuestService(DiamondsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateQuestAsync(QuestDto quest)
        {
            await _context.AddAsync(_mapper.Map<Quest>(quest));
            await _context.SaveChangesAsync();
        }

        public async Task<QuestDto> GetQuestAsync(int id)
        {
            var quest = await _context.Quests.FindAsync(id);
            return _mapper.Map<QuestDto>(quest);
        }

        public async Task<IEnumerable<QuestDto>> GetQuestsAsync()
        {
            var quests = await _context.Quests.ToListAsync();
            return _mapper.Map<IEnumerable<QuestDto>>(quests);
        }

        //Don't know \_(O____O)_/ 
        public async Task UpdateQuestAsync(int id, QuestDto quest)
        {
            var newQuest = _mapper.Map<Quest>(quest);
            newQuest.Id = id;
            _context.Quests.Update(newQuest);
            await _context.SaveChangesAsync();
        }

        public async Task<string> DeleteQuestAsync(int id)
        {
            var quest = await _context.Quests.FindAsync(id);
            _context.Quests.Remove(quest);
            await _context.SaveChangesAsync();
            return "Quest deleted!";
        }
    }
}
