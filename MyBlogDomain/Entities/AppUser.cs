﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyBlogDomain.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Skills = new List<Skill>();
            Abouts = new List<About>();
            Experiences = new List<Experience>();
            Portfolios = new List<Portfolio>();
            Educations = new List<Education>();
            Abouts = new List<About>();
        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        //public string Intentions { get; set; }
        public int Age { get; set; }

        public List<Subject>? Subjects { get; set; }
        public List<Education>? Educations { get; set; }
        public List<Portfolio>? Portfolios { get; set; }
        public List<Experience>? Experiences { get; set; }
        public List<Message> Messages { get; set; }
        public List<Skill>? Skills { get; set; }
        public List<About>? Abouts { get; set; }
        public List<Article>? Articles { get; set; }

        public override string ToString()
        {
            return UserName.ToString();
        }
    }
}