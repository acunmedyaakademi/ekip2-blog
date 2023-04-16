using filmblog.Models;

namespace filmblogu.Models
{
    public class BlogArticleVM
    {
        public List<Comment> Comments { get; set; }
        public Movie Movie { get; set; }
        public List<Category> Categories { get; set; }
    }
}
