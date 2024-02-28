﻿using MyBlogBLL.Services.Abstract;
using MyBlogDAL.UnitOfWork.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<bool> AddingSkillForUser(AppUser user,Skill skill)
        {
            var existingSkill = await unitOfWork.skillRepository.SingleorDefault(s => s.Id == skill.Id);

            if (existingSkill != null)
            {

                existingSkill.AppUsers.Add(user);
            }
            else
            {
                skill.AppUsers = new List<AppUser> { user };
                await unitOfWork.skillRepository.AddAsync(skill);
            }

            // Save changes to the database
            if (await unitOfWork.CommitAsync() > 0)
                return true;
            else
                return false;

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

        public async Task<IEnumerable<Skill>> GetUserSkillByUser(AppUser user)
        {
            return await unitOfWork.skillRepository.GetWhereListAsync(x => x.AppUsers.Any(AppUser=>AppUser.Id == user.Id));
        }

        public async Task<Skill> GetUserSkills(string expression)
        {
            //return await unitOfWork.skillRepository.GetWhereListAsync(x => x.AppUsers.Find(expression.FirstOrDefault(x => expression.)));
            throw new NotImplementedException();

        }

        public Task UpdateSkill(Skill skillTobeUpdated, Skill skill)
        {
            throw new NotImplementedException();
        }
    }
}
