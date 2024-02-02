﻿using MyBlogDomain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.Models.AccountVMs
{
    public class AppUserVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int Age { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
