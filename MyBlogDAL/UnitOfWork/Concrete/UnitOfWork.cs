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

        private SubjectRepository SubjectRepository;
        private AboutRepository AboutRepository;
        private ArticleRepository ArticleRepository;
        private LabelRepository LabelRepository;
        private ExperienceRepository ExperienceRepository;
        private PortfolioRepository PortfolioRepository;
        private SkillRepository SkillRepository;


        public UnitOfWork(MyBlogDbContext myBlogDbContext)
        {
            _context = myBlogDbContext;
        }



        PortfolioRepository IUnitOfWork.portfolioRepository => PortfolioRepository ?? new PortfolioRepository(_context);

        SkillRepository IUnitOfWork.skillRepository => SkillRepository ?? new SkillRepository(_context);

        SubjectRepository IUnitOfWork.subjectRepository => SubjectRepository??new SubjectRepository(_context);

        ArticleRepository IUnitOfWork.articleRepository => ArticleRepository ?? new ArticleRepository(_context);

        LabelRepository IUnitOfWork.labelRepository => LabelRepository ?? new LabelRepository(_context);

        AboutRepository IUnitOfWork.aboutRepository => AboutRepository ?? new AboutRepository(_context);

        ExperienceRepository IUnitOfWork.experienceRepository => ExperienceRepository ?? new ExperienceRepository(_context);

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
