using Microsoft.AspNetCore.Identity;

namespace MyBlogDomain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Intentions { get; set; }
        public int Age { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}