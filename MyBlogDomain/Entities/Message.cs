using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDomain.Entities
{
    public class Message : BaseEntity
    {
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }

    }
}
