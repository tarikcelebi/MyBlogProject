using MyBlogDAL.Repositories.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services
{
    public class SubjectService
    {
        private readonly ISubjectRepository subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        IEnumerable<Subject> GetAllSubjects()
        {
            return subjectRepository.GetAll();
        }

        bool AddSubject(Subject subject)
        {
            return subjectRepository.Add(subject);

        }

        bool UpdateSubject(Subject subject)
        {
            return subjectRepository.Update(subject);
        }

        bool DeleteSubject(Subject subject)
        {
            return subjectRepository.Delete(subject);
        }

        Subject GetSubject(int id)
        {
            return subjectRepository.GetById(id);
        }









        
    }
}
