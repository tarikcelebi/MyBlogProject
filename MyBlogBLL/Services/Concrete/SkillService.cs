using MyBlogBLL.Services.Abstract;
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
                existingSkill.AppUsers.Add(user);
            else
            {
                skill.AppUsers = new List<AppUser> { user };
                await unitOfWork.skillRepository.AddAsync(skill);
            }
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

        public async Task<bool> RemoveSkillForUser(Skill skill, AppUser appUser)
        {
            var existingSkill = await unitOfWork.skillRepository.GetByIdWithIncludesAsync(skill.Id, appUser);

            if (existingSkill != null)
            {
                appUser.Skills.Remove(existingSkill); 
                if (await unitOfWork.CommitAsync() > 0) 
                    return true;
            }

            return false;
        }

        public async Task<Skill> GetSkillById(int id)
        {
            return await unitOfWork.skillRepository.GetByIdASync(id);
        }

        public async Task<Skill> GetSkillByName(string Name)
        {
            return await unitOfWork.skillRepository.SingleorDefault(x => x.SkillName == Name) ?? new Skill { SkillName="boş"};
        }

        public async Task<IEnumerable<Skill>> GetSkills()
        {
            return await unitOfWork.skillRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Skill>> GetUserSkillsByUser(AppUser user)
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

        public async Task<bool> UpdateSkillForUser(Skill skillTobeUpdated, AppUser appUser)
        {
            Skill skillWithUser = await unitOfWork.skillRepository
            .GetByIdWithIncludesAsync(skillTobeUpdated.Id, appUser);

            skillWithUser.SkillName = skillTobeUpdated.SkillName;
            skillWithUser.Level = skillTobeUpdated.Level;

            if (await unitOfWork.CommitAsync() > 1)
                return true;
            return false;
        }
    }
}
