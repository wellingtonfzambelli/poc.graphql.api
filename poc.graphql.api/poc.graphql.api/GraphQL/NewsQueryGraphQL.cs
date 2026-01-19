using poc.graphql.api.Model;
using poc.graphql.api.Repository;

namespace poc.graphql.api.GraphQL;

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