using System.Collections.Concurrent;

public class LinkShortnerService : ILinkShortnerService
{
  private readonly List<LinkShortedModel> _linkStore = new();
  private readonly object _lock = new();
  private readonly string _baseUrl = "http://localhost:5214";

  public async Task<string> ShortenUrlAsync(string originalUrl)
  {
    var linkModel = _linkStore.FirstOrDefault(l => l.OriginalUrl == originalUrl);

    if (linkModel != null)
    {
      if (linkModel.Expiration < DateTime.UtcNow)
      {
        _linkStore.RemoveAll(l => l.OriginalUrl == originalUrl);
      }
      else
      {
        return linkModel.ShortenUrl;
      }
    }
    else
    {
      var code = GenerateCode();
      linkModel = new LinkShortedModel
      {
        OriginalUrl = originalUrl,
        ShortenUrl = $"{_baseUrl}/{code}",
        Expiration = DateTime.UtcNow.AddMinutes(5)
      };

      lock (_lock)
      {
        _linkStore.Add(linkModel);
      }
    }

    return linkModel.ShortenUrl;
  }

  public async Task<string> GetOriginalUrlAsync(string shortUrl)
  {
    var linkModel = _linkStore.FirstOrDefault(l => l.ShortenUrl == $"{_baseUrl}/{shortUrl}");
    return await Task.FromResult(linkModel?.OriginalUrl);
  }

  private string GenerateCode()
  {
    return Guid.NewGuid().ToString("N")[..13];
  }

  public Task<IEnumerable<string>> GetAllShortenedUrlsAsync()
  {
    return Task.FromResult<IEnumerable<string>>(_linkStore.Select(l => l.ShortenUrl).ToList());
  }
}