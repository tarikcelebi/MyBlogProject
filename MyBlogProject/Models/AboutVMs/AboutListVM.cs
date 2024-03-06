using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.Models.AboutVMs
{
    public class AboutListVM
    {

        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string? ImageURL { get; set; }

    }
}
