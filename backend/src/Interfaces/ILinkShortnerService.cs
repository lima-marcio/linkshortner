public interface ILinkShortnerService
{
  Task<string> ShortenUrlAsync(string longUrl);
  Task<string> GetOriginalUrlAsync(string shortUrl);
  Task<IEnumerable<string>> GetAllShortenedUrlsAsync();
  // Task<bool> DeleteShortenedUrlAsync(string shortUrl);
}