using poc.graphql.api.Model;

namespace poc.graphql.api.Repository;

public interface INewsRepository
{
    IQueryable<News> Query();
    News? GetById(int id);
}

public sealed class NewsRepository : INewsRepository
{
    private readonly List<News> _news = new()
    {
        new News
        {
            Id = 1,
            Title = "Firefighter rescues dog from mud",
            Description = "A firefighter saved a dog trapped in mud, inspiring local residents.",
            PublishedAt = DateTime.UtcNow.AddDays(-2)            
        },
        new News
        {
            Id = 2,
            Title = "Community plants 1,000 trees",
            Description = "Volunteers came together to plant trees in an urban area.",
            PublishedAt = DateTime.UtcNow.AddDays(-1)
        },
        new News
        {
            Id = 3,
            Title = "Students create low-cost water filter",
            Description = "A group of students developed an affordable water filter.",
            PublishedAt = DateTime.UtcNow            
        }
    };

    public IQueryable<News> Query()
        => _news.AsQueryable();

    public News? GetById(int id)
        => _news.FirstOrDefault(n => n.Id == id);
}