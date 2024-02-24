using MyBlogDAL.Context;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDAL.Repositories.Concrete;
using MyBlogDAL.UnitOfWork.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyBlogDbContext _context;
        private IRepository<Portfolio> PortfolioRepository;
        private IRepository<Subject> SubjectRepository;
        private IRepository<About> AboutRepository;
        private IRepository<Article> ArticleRepository;
        private IRepository<Label> LabelRepository;
        private IRepository<Skill> SkillRepository;
        private IRepository<Experience> ExperienceRepository;


        public UnitOfWork(MyBlogDbContext myBlogDbContext)
        {
            _context = myBlogDbContext;
        }

        //public ISubjectRepository Subjects => SubjectRepository = SubjectRepository ?? new SubjectRepository(_context);

        //public ILabelRepository Labels => LabelRepository = LabelRepository ?? new LabelRepository(_context);

        //public IArticleRepository Articles => ArticleRepository = ArticleRepository ?? new ArticleRepository(_context);

        //public IPortfolioRepository Portfolios => PortfolioRepository = PortfolioRepository ?? new PortfolioRepository(_context);

        //public IAboutRepository Abouts => AboutRepository = AboutRepository ?? new AboutRepository(_context);


        public IRepository<Portfolio> portfolioRepository => PortfolioRepository ?? new PortfolioRepository(_context);

        public IRepository<Subject> subjectRepository => SubjectRepository ?? new SubjectRepository(_context);

        public IRepository<Article> articleRepository => ArticleRepository??new ArticleRepository(_context);

        public IRepository<Label> labelRepository => LabelRepository ?? new LabelRepository(_context);

        public IRepository<About> aboutRepository => AboutRepository ?? new AboutRepository(_context);

        public IRepository<Skill> skillRepository => SkillRepository ?? new SkillRepository(_context);

        public IRepository<Experience> experienceRepository => ExperienceRepository ?? new ExperienceRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
