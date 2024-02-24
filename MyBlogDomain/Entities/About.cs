using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDomain.Entities
{
    public class About : BaseEntity
    {
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int Age { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Mail { get; set; }

        [Display(Name = "Phone")]
        [Phone]
        public string Phone { get; set; }
        public string ImageURL { get; set; }


    }
}
