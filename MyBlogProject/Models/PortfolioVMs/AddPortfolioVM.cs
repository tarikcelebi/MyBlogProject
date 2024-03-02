using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.Models.PortfolioVMs
{
    public class AddPortfolioVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public string ProjectUrl { get; set; }
        public IFormFile ProjectPic { get; set; }
        public IFormFile ProjectPic2 { get; set; }
        public string ImageURL2 { get; set; }
        public string AppUserId { get; set; }
    }
}
