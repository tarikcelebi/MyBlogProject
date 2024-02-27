using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("AppUser")]
        public string? AppUserID { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
