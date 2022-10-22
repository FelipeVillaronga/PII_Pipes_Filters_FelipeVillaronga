using TwitterUCU;

namespace Library;
public abstract class TwitterPrinter
{
    public static void TweetImage(string path)
    {
        var twitter = new TwitterImage();
        twitter.PublishToTwitter("Estaso actual de la imagen: ", path);
    }

}    
