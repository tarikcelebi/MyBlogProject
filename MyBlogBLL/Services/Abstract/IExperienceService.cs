using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Abstract
{
    public interface IExperienceService
    {
        ValueTask<Experience> GetExperienceByIdASync(int id);
        Task CreateExperienceWithUserAsync(Experience experience,AppUser user);
        void DeleteExperience(Experience experience);
        void DeleteRangeExperienceAsync(IEnumerable<Experience> experiences);
        Task AddRangExperienceAsync(IEnumerable<Experience> experiences);
        Task<bool> UpdateExperienceForUser(Experience experienceToBeUpdated, AppUser appUser);
        Task<bool> RemoveExperienceForUser(Experience experience, AppUser appUser);
        Task<bool> AddingExperienceForUser(AppUser user, Experience experience);
        Task<IEnumerable<Experience>> GetUserExperiencesForUser(AppUser user);
        IEnumerable<Experience> FindAsync(Expression<Func<Experience, bool>> predicate);
        Task<IEnumerable<Experience>> GetAllExperienceAsync();
        Task<Experience> SingleorDefault(Expression<Func<Experience, bool>> expression);
        Task<IEnumerable<Experience>> GetWhereListAsync(Expression<Func<Experience, bool>> expression);
    }
}
