using MyBlogDAL.Context;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDAL.Repositories.Concrete;
using MyBlogDAL.UnitOfWork.Abstract;
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
        private AboutRepository AboutRepository;
        private PortfolioRepository PortfolioRepository;
        private ArticleRepository ArticleRepository;
        private LabelRepository LabelRepository;
        private SubjectRepository SubjectRepository;

        public UnitOfWork(MyBlogDbContext myBlogDbContext)
        {
            _context = myBlogDbContext;
        }

        public ISubjectRepository Subjects => SubjectRepository = SubjectRepository ?? new SubjectRepository(_context);

        public ILabelRepository Labels => LabelRepository = LabelRepository ?? new LabelRepository(_context);

        public IArticleRepository Articles => ArticleRepository = ArticleRepository ?? new ArticleRepository(_context);

        public IPortfolioRepository Portfolios => PortfolioRepository = PortfolioRepository ?? new PortfolioRepository(_context);

        public IAboutRepository Abouts => AboutRepository = AboutRepository ?? new AboutRepository(_context);

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
