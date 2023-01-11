using EFCoreIrlanda;
using var db = new BloggingContext();

//db.Add(new Blog { Url = "nuovourl" });
//db.Add(new Post { Content = "esempiopost", BlogId = 1 });
//db.SaveChanges();
var post = db.Posts.OrderBy(p => p.PostId).First();
Console.WriteLine(post.Content);