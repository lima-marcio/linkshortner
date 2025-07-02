using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class LinkShortnerController : Controller
{
  private readonly ILinkShortnerService _linkShortnerService;
  public LinkShortnerController(ILinkShortnerService linkShortnerService)
  {
    _linkShortnerService = linkShortnerService;
  }

  [HttpGet("links")]
  public async Task<IActionResult> GetLinks()
  {
    var links = await _linkShortnerService.GetAllShortenedUrlsAsync();
    return Ok(links);
  }

  [HttpPost("shorten")]
  public async Task<IActionResult> ShortenUrl([FromBody] ShortenRequest request)
  {
    var shortUrl = await _linkShortnerService.ShortenUrlAsync(request.OriginalUrl);
    return Ok(new { ShortUrl = shortUrl });
  }


}