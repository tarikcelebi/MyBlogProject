using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDomain.Entities
{
	public class Education : BaseEntity
	{
        [MaxLength(50)]
        public string SchoolName { get; set; }
		[MaxLength(50)]
		public string Department { get; set; }
		[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
		public DateTime StartedDate { get; set; }
		[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
		public DateTime EndedDate { get; set; }
		[MaxLength(250)]
		public string? Clubs { get; set; }
		[MaxLength(50)]
		public string? Degree { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserID { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
