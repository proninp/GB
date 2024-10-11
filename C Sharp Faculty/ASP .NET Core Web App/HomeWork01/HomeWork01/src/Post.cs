namespace HomeWork01.src;
public class Post
{
    public int UserId { get; set; }

    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Body { get; set; } = string.Empty;

    public override string ToString() =>
        $"{UserId}\n{Id}\n{Title}\n{Body}";
}