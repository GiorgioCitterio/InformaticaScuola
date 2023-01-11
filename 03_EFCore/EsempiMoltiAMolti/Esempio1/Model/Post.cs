
namespace Esempio1.Model;

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public ICollection<Tag> Tags { get; set; }
}

