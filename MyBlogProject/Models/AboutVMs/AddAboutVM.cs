using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.Models.AboutVMs
{
    public class AddAboutVM
    {
        [MaxLength(25)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(500)]
        [Required]
        public string Description { get; set; }

        public int Age { get; set; }


        [Display(Name = "Phone")]
        [Phone]
        [Required]
        public string Phone { get; set; }
        public IFormFile? ProfilePic { get; set; }
        public string? ImageURL { get; set; }
        public string AppUserId { get; set; }
    }
}
