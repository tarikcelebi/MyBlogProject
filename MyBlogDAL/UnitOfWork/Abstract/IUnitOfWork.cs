using MyBlogDAL.Repositories.Abstract;
using MyBlogDAL.Repositories.Concrete;
using MyBlogDomain.Entities;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.UnitOfWork.Abstract
{
    // When this method called all the changes gonna save to the database with saveChanges method.
    // We are going to define all repositories here to manage from one place.
    // Bu sınıfta repo' ların instance I alınacak ve tüm uygulama boyunca buradan kullanılacak singleton'a benzer.

    public interface IUnitOfWork
    {

        PortfolioRepository portfolioRepository { get; }
        SkillRepository skillRepository { get; }
        SubjectRepository subjectRepository { get; }
        ArticleRepository articleRepository { get; }
        LabelRepository labelRepository { get; }
        AboutRepository aboutRepository { get; }
        ExperienceRepository experienceRepository { get; }
        EducationRepository EducationRepository { get; }
        Task<int> CommitAsync();
        void Dispose();


    }
}
