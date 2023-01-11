
namespace Esempio1.Model;

public class Tag
{
    public string TagId { get; set; }
    public string TagName { get; set; }
    public ICollection<Post> Posts { get; set; }
}
