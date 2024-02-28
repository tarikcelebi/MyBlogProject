using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Abstract
{
    public interface ISkillService
    {
        Task<Skill> CreateSkill(Skill skill);
        Task UpdateSkill(Skill skillTobeUpdated, Skill skill);
        Task DeleteSkill(Skill skill);
        Task<IEnumerable<Skill>> GetSkills();
        Task<Skill> GetSkillById(int id);
        Task<bool> AddingSkillForUser(AppUser user, Skill skill);
        Task<IEnumerable<Skill>> GetUserSkillByUser(AppUser user);

    }
}
