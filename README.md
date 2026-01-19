# About
<br /><br />

# Stacks of this project
- .NET 9
- HotChocolate (GraphQL .net lib)
- Visual Studio Community
<br /><br />


# Install Nuget packages
<img width="1192" height="280" alt="image" src="https://github.com/user-attachments/assets/ae4b2a7e-bf97-408e-b0a1-39f847cfb39f" />
<br /><br />



# Class with GraphQL metods
```c#
public sealed class NewsQueryGraphQL
{
    private readonly INewsRepository _newsRepository;

    public NewsQueryGraphQL(INewsRepository newsRepository) =>
        _newsRepository = newsRepository;

    [UsePaging]
    [UseFiltering]
    [UseSorting]
    [GraphQLName("retrieveAllNews")]
    public IQueryable<News> GetNews() => 
        _newsRepository.Query();

    [GraphQLName("retrieveNewsById")]
    public News? GetNewsById(int id) => 
        _newsRepository.GetById(id);
}
```

# Domain / Repository Class _(simulation)_

```c#
public sealed class News
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishedAt { get; set; }
}
```

```c#
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
            PublishedAt = DateTime.UtcNow.AddDays(-2),
            CategoryId = 2
        },
        new News
        {
            Id = 2,
            Title = "Community plants 1,000 trees",
            Description = "Volunteers came together to plant trees in an urban area.",
            PublishedAt = DateTime.UtcNow.AddDays(-1),
            CategoryId = 2
        },
        new News
        {
            Id = 3,
            Title = "Students create low-cost water filter",
            Description = "A group of students developed an affordable water filter.",
            PublishedAt = DateTime.UtcNow,
            CategoryId = 3
        }
    };

    public IQueryable<News> Query()
        => _news.AsQueryable();

    public News? GetById(int id)
        => _news.FirstOrDefault(n => n.Id == id);
}
```
<br /><br />



# Inicialization Program.cs
<img width="864" height="867" alt="image" src="https://github.com/user-attachments/assets/5f2aa293-dbf2-4642-b88a-33974ffd46ea" />
<br /><br />


# Acess the URL we defined on the Program.cs file

In my case: https://localhost:7103/graphql/  
<br />

Filtering by "dog" word
<img width="1906" height="1004" alt="image" src="https://github.com/user-attachments/assets/cd73f877-96f3-40b2-9567-740a8af07731" />
