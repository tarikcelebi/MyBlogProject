using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlogDomain.Entities;
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
        [Required]
        public string CheckPassword { get; set; }
        public int Age { get; set; }
        public Task<IEnumerable<SelectListItem>> Subjects { get; set; }
    }
}
