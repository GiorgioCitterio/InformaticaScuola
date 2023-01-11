
namespace Esempio2.Model;

public class PostTag
{
    public int Id { get; set; }
    public DateTime PublicationDate { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; }
    public string TagId { get; set; }
    public Tag Tag { get; set; }
}

