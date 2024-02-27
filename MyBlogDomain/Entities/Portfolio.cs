using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDomain.Entities
{
    public class Portfolio : BaseEntity
    {

        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string ProjectUrl { get; set; }
        public string ImageURL2 { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserID { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
