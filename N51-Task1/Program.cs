using N51_Task1.Extensions;


var oldPost = new Post("Title1", "Description", new List<Topic> { new Topic(1, "IT"), new Topic(2, "Math") });
var updatedPost = new Post("Title1", "Description",
    new List<Topic> { new Topic(1, "at"), new Topic(2, "matem"), new Topic(3, "Nimadir") });

var result = oldPost.Topics.ZipIntersectBy(updatedPost.Topics, topic => topic.Id);

foreach (var (old, newTopic) in result)
{
    Console.WriteLine($"Eski : {old.Name}");
    Console.WriteLine($"Yangi : {newTopic.Name}");
}

public class Post
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<Topic> Topics { get; set; }

    public Post(string title, string description, List<Topic> Topics)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        this.Topics = Topics;
    }
}

public class Topic
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Topic(int id, string name)
    {
        Id = id;
        Name = name;
    }
}