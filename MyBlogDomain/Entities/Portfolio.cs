using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDomain.Entities
{
    public class Portfolio : BaseEntity
    {

        public string Name { get; set; }
        public string ImageURL { get; set; }
    }
}
