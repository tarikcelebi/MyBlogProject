using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDomain.Entities
{
    public class Skill : BaseEntity
    {

        public Skill()
        {
            Skills = new List<Skill>();
        }
        public string SkillName { get; set; }
        public string Level { get; set; }
        public List<Skill> Skills;
    }
}
