
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsempiModel2.Model;

public class Post
{
    [Key]
    public int CodicePost { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int BlogForeignKey { get; set; }
    [ForeignKey("BlogForeignKey")]
    public Blog Blog { get; set; }
}
