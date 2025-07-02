using Microsoft.AspNetCore.Mvc;

[Route("/{shortUrl}")]
public class OriginalUrlController : Controller
{
  private readonly ILinkShortnerService _linkShortnerService;
  public OriginalUrlController(ILinkShortnerService linkShortnerService)
  {
    _linkShortnerService = linkShortnerService;
  }

  [HttpGet]
  public async Task<IActionResult> GetOriginalUrl(string shortUrl)
  {
    if (string.IsNullOrEmpty(shortUrl))
    {
      return BadRequest("Short URL cannot be null or empty.");
    }

    var originalUrl = await _linkShortnerService.GetOriginalUrlAsync(shortUrl);
    if (originalUrl == null)
    {
      return NotFound("Original URL not found for the provided short URL.");
    }

    return Redirect(originalUrl);
  }
}