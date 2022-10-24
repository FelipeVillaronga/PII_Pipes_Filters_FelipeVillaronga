using TwitterUCU;

namespace CompAndDel.Filters;
public class TwitterFilter : IFilter
{
    public TwitterFilter(string path)
    {
        this.Path= path;
    }
    public string Path {get; set;}
    public IPicture Filter(IPicture picture)
    {
        var twitter = new TwitterImage();
        twitter.PublishToTwitter("Nueva imagen: ", this.Path);
        return picture;
    }

}    
