using MyBlogBLL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBLL.Services.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {


    }
}
