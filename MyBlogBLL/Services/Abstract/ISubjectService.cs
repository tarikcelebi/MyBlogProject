using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Abstract
{
    public interface ISubjectService : IGenericService<Subject>
    {
        Task<IEnumerable<Subject>> GetAllSubjectsWithArticles();
        Task<Subject> GetWithArticleById(int id);
        Task<Subject> CreateSubject(Subject newSubject);
        Task UpdateSubject(int id, Subject UpdatedSubject);
        Task DeleteSubject(Subject subject);
    }
}
