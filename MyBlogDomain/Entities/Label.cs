using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDomain.Entities
{
    public class Label : BaseEntity
    {
        public string LabelName { get; set; }
        public IEnumerable<Article> Articles { get; set; }

    }
}
