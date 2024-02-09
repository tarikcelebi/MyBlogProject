using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Concrete
{
    public interface ILabelService
    {
        Task<IEnumerable<Label>> GetAllLabels();
    }
}
