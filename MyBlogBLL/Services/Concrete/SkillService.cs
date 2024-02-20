﻿using MyBlogBLL.Services.Abstract;
using MyBlogDAL.UnitOfWork.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Concrete
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork unitOfWork;


        public SkillService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<Skill> CreateSkill(Skill skill)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSkill(Skill skill)
        {
            throw new NotImplementedException();
        }

        public Task<Skill> GetSkillById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Skill>> GetSkills()
        {
            return await unitOfWork.skillRepository.GetAllAsync();
        }

        public Task UpdateSkill(Skill skillTobeUpdated, Skill skill)
        {
            throw new NotImplementedException();
        }
    }
}
