using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Abstract
{
    public interface IEducationService
    {
        ValueTask<Education> GetEducationByIdASync(int id);
        Task CreateEducationWithUserAsync(Education education, AppUser user);
        void DeleteEducation(Education education);
        void DeleteRangeEducationAsync(IEnumerable<Education> education);
        Task AddRangEducationAsync(IEnumerable<Education> educations);
        Task<bool> UpdateEducationForUser(Education educationToBeUpdated, AppUser appUser);
        Task<bool> RemoveEducationForUser(Education education, AppUser appUser);
        Task<bool> AddingEducationForUser(AppUser user, Education education);
        Task<IEnumerable<Education>> GetUserEducationsForUser(AppUser user);
        IEnumerable<Education> FindAsync(Expression<Func<Education, bool>> predicate);
        Task<IEnumerable<Education>> GetAllEducationAsync();
        Task<Education> SingleorDefault(Expression<Func<Education, bool>> expression);
        Task<IEnumerable<Education>> GetWhereListAsync(Expression<Func<Education, bool>> expression);

    }
}
