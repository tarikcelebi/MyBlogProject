using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDomain.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public IEnumerable<Label> Labels { get; set; }
    }
}
