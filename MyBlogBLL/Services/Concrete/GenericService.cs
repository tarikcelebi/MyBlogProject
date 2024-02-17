//using MyBlogBLL.Services.Abstract;
//using MyBlogDAL.Repositories.Abstract;
//using MyBlogDAL.Repositories.Concrete;
//using MyBlogDAL.UnitOfWork.Abstract;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyBlogBLL.Services.Concrete
//{
//    public class GenericService<T> : IGenericService<T> where T : class
//    {
//        private readonly IUnitOfWork unitOfWork;


//        public GenericService(IUnitOfWork unitOfWork)
//        {
//            this.unitOfWork = unitOfWork;

//        }

//        public async Task AddAsync(T entity)
//        {
//            try
//            {
//                await unitOfWork
//                await unitOfWork.CommitAsync();
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public async Task AddRangeAsync(IEnumerable<T> entities)
//        {
//            try
//            {
//                await unitOfWork.Repository.AddRangeAsync(entities);
//                await unitOfWork.CommitAsync();
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public void Delete(T entity)
//        {
//            try
//            {
//                unitOfWork.Repository.Delete(entity);
//                unitOfWork.CommitAsync();
               
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public void DeleteRange(IEnumerable<T> entities)
//        {
//            try
//            {
//                unitOfWork.Repository.DeleteRange(entities);
//                unitOfWork.CommitAsync();
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public IEnumerable<T> FindAsync(Expression<Func<T, bool>> predicate)
//        {
//            try
//            {
//                return unitOfWork.Repository.FindAsync(predicate);
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public async Task<IEnumerable<T>> GetAllAsync()
//        {
//            try
//            {
//                return await unitOfWork.Repository.GetAllAsync();
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public async ValueTask<T> GetByIdASync(int id)
//        {
//            try
//            {
//                return await unitOfWork.Repository.GetByIdASync(id);
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public async Task<IEnumerable<T>> GetWhereListAsync(Expression<Func<T, bool>> expression)
//        {
//            try
//            {
//                return await unitOfWork.Repository.GetWhereListAsync(expression);
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public async Task<T> SingleorDefault(Expression<Func<T, bool>> expression)
//        {
//            try
//            {
//               return await unitOfWork.Repository.SingleorDefault(expression);
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }
//    }
//}
