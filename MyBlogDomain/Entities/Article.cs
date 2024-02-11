namespace MyBlogDomain.Entities
{
    public class Article : BaseEntity
    {


        public string Header { get; set; }
        public string Body { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public IEnumerable<Label> Labels { get; set; }
    }
}