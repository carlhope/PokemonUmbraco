using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;
namespace PokemonUmbraco;

public class PokemonDetailsContentFinder : IContentFinder
{
    private readonly IUmbracoContextAccessor _contextAccessor;

    public PokemonDetailsContentFinder(IUmbracoContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;

    }

    public Task<bool> TryFindContent(IPublishedRequestBuilder request)
    {
        var path = request.Uri.GetAbsolutePathDecoded().ToLowerInvariant();

        if (path.StartsWith("/pokemon/details/"))
        {
            var umbracoContext = _contextAccessor.GetRequiredUmbracoContext();

            var detailsNode = umbracoContext.Content.GetById(
                Guid.Parse("2323380d-44c8-4ab2-b792-a7ce091cb6e0")
            );

            if (detailsNode != null)
            {
                request.SetPublishedContent(detailsNode);
                return Task.FromResult(true);
            }
        }

        return Task.FromResult(false);
    }
}
