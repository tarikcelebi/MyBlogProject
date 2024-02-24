using MyBlogDAL.Repositories.Abstract;
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
        IRepository<Portfolio> portfolioRepository { get; }
        IRepository<Subject> subjectRepository { get; }
        IRepository<Article> articleRepository { get; }
        IRepository<Label> labelRepository { get; }
        IRepository<About> aboutRepository { get; }
        IRepository<Skill> skillRepository { get; }
        IRepository<Experience> experienceRepository { get;  }
        Task<int> CommitAsync();
        void Dispose();


    }
}
