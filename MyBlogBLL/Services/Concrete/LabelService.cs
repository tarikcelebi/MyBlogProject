using MyBlogBLL.Services.Abstract;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Label = MyBlogDomain.Entities.Label;

namespace MyBlogBLL.Services.Concrete
{
    public class LabelService : GenericService<Label>, ILabelService
    {
        public Task<IEnumerable<Label>> GetAllLabels()
        {
            throw new NotImplementedException();
        }
    }
}
